using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment //we already have the email in Payment so we only need paypal's transaction's code
    {
        //since this class inherits from an abstract class it has to have all of it's parameters and receive ":base"
        public PayPalPayment(
            string transactionCode,
            DateTime paidDate,
            DateTime expirationDate,
            decimal total,
            decimal totalPaid,
            string payer,
            Document document,
            Address address,
            Email email) : base(
                paidDate,
                expirationDate,
                total,
                totalPaid,
                payer,
                document,
                address,
                email)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }        
    }
}