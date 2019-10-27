using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]

    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentNumberIsInvalid()
        {
            var doc = new Document("123", EDocumentType.PPS);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("7654321")]
        [DataRow("3982728")]
        [DataRow("9273222")]
        public void ShouldReturnSuccessWhenDocumentNumberIsValid(string ppsn)
        {
            var doc = new Document(ppsn, EDocumentType.PPS);
            Assert.IsTrue(doc.Valid);
        }
    }
}

//A test is nothing more than a class decorated with [TestClass] and void methods decorated with [TestMethod]
//Methodology -> Red, Green, Refactor