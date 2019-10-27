using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "Name must have at least 3 characters.")
                .HasMinLen(LastName, 3, "Name.LastName", "Last name must have at least 3 characters.")
                .HasMaxLen(LastName, 40, "Name.FirstName", "Last name must have a maximum of 40 characters.")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}

//Used as a complex object to avoid the use of primitive values such as "public string FirstName { get; private set; }"
//using value objects you can avoid code repetition and create code than can be tested more effectively.