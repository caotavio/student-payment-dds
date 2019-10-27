using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment //only store infos to identify the purchase (in CardNumber just the last 4 digits)
    {
        //since this class inherits from an abstract class it has to have all of it's parameters and receive ":base"
        public CreditCardPayment(
            string cardHolderName,
            string cardNumber,
            string lastTransactionNumber,
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
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}