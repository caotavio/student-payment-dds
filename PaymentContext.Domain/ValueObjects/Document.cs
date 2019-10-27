using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document Number", "Invalid Document")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validate()
        {
            if (Type == EDocumentType.PPS && Number.Length == 7)
                return true;
            
            return false;
        }
    }
}

//Used as a complex object to avoid the use of primitive values such as "public string FirstName { get; private set; }"
//using value objects you can avoid code repetition and create code than can be tested more effectively.