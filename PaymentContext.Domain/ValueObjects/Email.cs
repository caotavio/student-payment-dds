using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "Invalid Email")
            ); //This makes sure that the constructor follows a contract that it is in fact a valid email, else it will return a notification
            //As our notifications are grouped in Student.cs they will be added to others if they exist. 
        }

        public string Address { get; private set; }
    }
}

//Used as a complex object to avoid the use of primitive values such as "public string FirstName { get; private set; }"
//using value objects you can avoid code repetition and create code than can be tested more effectively.