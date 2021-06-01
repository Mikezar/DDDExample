using Domain.Abstract;
using System;

namespace Domain.BuyerAggregate
{
    public class Buyer : Entity, IAggregateRoot
    {
        public string Name {get; }
        public string Email {get; private set; }

        public Buyer(string name, string email)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            Name = name;

            ChangeEmail(email);
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}