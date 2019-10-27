using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentCommand.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]

    public class CreateCreditCardSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateCreditCardSubscriptionCommand();
            command.FirstName = "";
            command.Validate();

            Assert.AreEqual(false, command.Valid);
        }
    }
}

//This test is just an example. In this case as we already have fail fast validation implemented we woul not need this test