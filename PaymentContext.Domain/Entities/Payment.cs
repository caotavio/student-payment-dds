using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity //it's abstract because you cannot instantiate it by itself. You need to have a payment type
    {
        protected Payment(DateTime paidDate, DateTime expirationDate, decimal total, decimal totalPaid, string payer, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper(); //automatically generate new GUID
            PaidDate = paidDate;
            ExpirationDate = expirationDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerOrEqualsThan(0, Total, "Payment.Total", "The total cannot be 0")
                .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "The paid value is less than the charged value")
            );
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }

        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }

        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}