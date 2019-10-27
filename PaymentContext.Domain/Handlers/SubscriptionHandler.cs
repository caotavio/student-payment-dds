using System;
using Flunt.Notifications;
using PaymentCommand.Domain.Commands;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler :
        Notifiable,
        IHandler<CreateCreditCardSubscriptionCommand>,
        IHandler<CreatePayPalSubscriptionCommand>
        
    {
        //For this handler to work we need a student repository, and that is why we need to pass it via dependency injection (resolved by the API)
        //Every external service that we need (e.g -> welcome email) we'll do the same injection
        private readonly IStudentRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCreditCardSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Subscription failed");
            }

            //Verify if document is registered
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "This PPS number is already in use");
            }

            //Verify if email is registered
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "This email address is already in use");
            }

            //Generate VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.PPS);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.City, command.County, command.Country, command.Postcode);

            //Generate Entities
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new CreditCardPayment(
                command.CardHolderName,
                command.CardNumber,
                command.LastTransactionNumber,
                command.PaidDate,
                command.ExpirationDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.Number, command.PayerDocumentType),
                address,
                email
            );

            //Relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Group validations
            AddNotifications(name, document, email, address, student, subscription, payment);

            //Check notifications
            if (Invalid)
            {
                return new CommandResult(false, "Subscription failed");
            }
            
            //Save information
            _repository.CreateSubscription(student);
            
            //Send welcome email
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome to our website", "Your subscription was created");
        
            //Return information
            return new CommandResult(true, "Subscription successful");
        }

        public ICommandResult Handle(CreatePayPalSubscriptionCommand command)
        {
            //Fail Fast Validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Subscription failed");
            }

            //Verify if document is registered
            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "This PPS number is already in use");
            }

            //Verify if email is registered
            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Email", "This email address is already in use");
            }

            //Generate VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EDocumentType.PPS);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.City, command.County, command.Country, command.Postcode);

            //Generate Entities
            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            //To add payment types this is the ony part that changes
            var payment = new PayPalPayment(
                command.TransactionCode,
                command.PaidDate,
                command.ExpirationDate,
                command.Total,
                command.TotalPaid,
                command.Payer,
                new Document(command.Number, command.PayerDocumentType),
                address,
                email
            );

            //Relationships
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            //Group validations
            AddNotifications(name, document, email, address, student, subscription, payment);
            
            //Check notifications
            if (Invalid)
            {
                return new CommandResult(false, "Subscription failed");
            }
            
            //Save information
            _repository.CreateSubscription(student);
            
            //Send welcome email
            _emailService.Send(student.Name.ToString(), student.Email.Address, "Welcome to our website", "Your subscription was created");
        
            //Return information
            return new CommandResult(true, "Subscription successful");
        }
    }
}