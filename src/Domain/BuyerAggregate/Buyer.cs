using Domain.Abstract;
using Domain.Exceptions;

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
            if (string.IsNullOrEmpty(name)) throw new DomainException(nameof(name));
            if (name.Length > NameLength) throw new DomainException(nameof(name));

            Name = name;

            ChangeEmail(email);

            AddEvent(new BuyerCreatedEvent(this));
        }

        public void ChangeEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new DomainException(nameof(email));
            if (email.Length > EmailLength) throw new DomainException(nameof(email));

            Email = email;
        }
    }
}