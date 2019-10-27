using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string city, string county, string country, string postcode)
        {
            Street = street;
            Number = number;
            City = city;
            County = county;
            Country = country;
            Postcode = postcode;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(Street, 3, "Address.Street", "Street name must have at least 3 characters.")
                .HasMinLen(Number, 1, "Address.Number", "Must have at least 1 number.")
                .HasMinLen(City, 3, "Address.City", "City must have at least 3 characters.")
                .HasMinLen(County, 3, "Address.County", "County must have at least 3 characters.")
                .HasMinLen(Country, 3, "Address.Country", "Country must have at least 3 characters.")
                .HasMinLen(Postcode, 7, "Address.Postcode", "Postcode must have at least 7 characters.")
            );
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string City { get; private set; }
        public string County { get; private set; }
        public string Country { get; private set; }
        public string Postcode { get; private set; }
    }
}

//Used as a complex object to avoid the use of primitive values such as "public string FirstName { get; private set; }"
//using value objects you can avoid code repetition and create code than can be tested more effectively.