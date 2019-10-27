using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentCommand.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]

    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateCreditCardSubscriptionCommand();
            command.FirstName = "Otto";
            command.LastName = "Octavius";
            command.Document = "99999999999";
            command.Email = "doc@otto.com";
            command.CardHolderName = "O Octavius";
            command.CardNumber = "2272789065437812";
            command.LastTransactionNumber = "94872408937";
            command.PaymentNumber = "12345";
            command.PaidDate = DateTime.Now;
            command.ExpirationDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "SPYDER CORP";
            command.PayerDocument = "12345678911";
            command.PayerDocumentType = EDocumentType.PPS;
            command.PayerEmail = "otto@evilbro.com";
            command.Street = "aiuzanj";
            command.Number = "uashus";
            command.City = "as";
            command.County = "as";
            command.Country = "as";
            command.Postcode = "1234567";

            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}

//This test is just an example. In this case as we already have fail fast validation implemented we woul not need this test