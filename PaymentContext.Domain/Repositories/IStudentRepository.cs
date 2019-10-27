using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
    }
}

//This pattern (Repository Pattern) abstracts the access to data. In this case it doesn't matter where the data comes from, making your code more testable,
//letting the code dependant on abstractions and not implementation.  