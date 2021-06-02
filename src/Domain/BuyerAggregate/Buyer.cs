using Domain.Abstract;
using System;

namespace Domain.BuyerAggregate
{
    public class Buyer : Entity, IAggregateRoot
    {
        private const int EmailLength = 150;
        private const int NameLength = 300;

        public string Name { get; private set; }
        public string Email { get; private set; }

        public Buyer(string name, string email)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (name.Length > NameLength) throw new ArgumentNullException(nameof(name));

            Name = name;

            ChangeEmail(email);

            AddEvent(new BuyerCreatedEvent(this));
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));
            if (email.Length > EmailLength) throw new ArgumentNullException(nameof(email));

            Email = email;
        }
    }
}