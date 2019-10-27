using System;
using Flunt.Notifications;

namespace PaymentContext.Shared.Entities
 {
     public abstract class Entity : Notifiable
     {
        protected Entity()
        {
            Id = Guid.NewGuid(); //a GUID does not perform as good in a database but we can generate it with .NET and not use the db to generate it, that means less db requests
        }

        public Guid Id { get; private set; }
     }
 }

 //All Entities must have Ids, as Value Objects don't