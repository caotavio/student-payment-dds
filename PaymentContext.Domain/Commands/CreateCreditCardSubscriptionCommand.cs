using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

// In here we gather all the information that we need to create a paypal subscription
// The command's function is to gather all the wight information to perform a certain task and provided somewhere else where it's needed.
// Dotnet's web api has the capacity to map a json to a c# object using a serializer
namespace PaymentCommand.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string LastTransactionNumber { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }

        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Name must have at least 3 characters.")
                .HasMinLen(LastName, 3, "Name.LastName", "Last name must have at least 3 characters.")
                .HasMaxLen(LastName, 40, "Name.FirstName", "Last name must have a maximum of 40 characters.")
            );
        }
    }
}