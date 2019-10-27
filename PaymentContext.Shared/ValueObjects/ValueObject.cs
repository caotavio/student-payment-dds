using Flunt.Notifications;

namespace PaymentContext.Shared.ValueObjects
{
    public abstract class ValueObject : Notifiable
    {
        
    }
}

//This empty class on serve a purprose of allowing a more readable code, because as the entities receive a ": Entity" beside the class name
//the VOs will receive ": ValueObject" beside their name so it will be explicit what is what.
//Also, if we need to implement something that is common to all value objects we can just add it to this class.