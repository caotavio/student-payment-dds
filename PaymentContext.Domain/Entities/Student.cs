
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email) //highlight, Ctrl + ., generate constructor for more expressive code
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
            
            AddNotifications(name, document, email); //this groups all errors of name, document and email
        }
        //the PRIVATE closes the class for modification althought it is still open for instatiation (open-closed principle)
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } } //IReadOnlyCollection instead of List

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var sub in _subscriptions)
            {
                if (sub.Active)
                {
                    hasSubscriptionActive = true;
                }
            }

            AddNotifications(new Contract()
                .Requires()
                .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "You already have an active signature.")
                .AreEquals(0, subscription.Payments.Count, "Student.Subscription.Payments", "This subscription does not contain payments")
            );

            //Alternative code
            // if (hasSubscriptionActive)
            // {
            //     AddNotification("Student.Subscriptions", "You already have an active signature.");
            // }
        }
    }
}