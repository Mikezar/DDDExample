using System;
using Domain.Abstract;

namespace Domain.OrderAggregate
{
    public class CardInformation : ValueObject
    {
        public string Brand { get; private set; }
        public string Number { get; private set; }
        public string Holder { get; private set; }   
        public string SecurityCode { get; private set; }
        public DateTime ExpirationDate {get; private set; }

        public CardInformation() { }

        public CardInformation(string brand, string number, string holder, string securityCode, DateTime expirationDate)
        {
            if (string.IsNullOrEmpty(brand)) throw new ArgumentNullException(nameof(brand));
            if (string.IsNullOrEmpty(number)) throw new ArgumentNullException(nameof(number));
            if (string.IsNullOrEmpty(holder)) throw new ArgumentNullException(nameof(holder));
            if (string.IsNullOrEmpty(securityCode)) throw new ArgumentNullException(nameof(securityCode));

            Brand = brand;
            Number = number;
            Holder = holder;
            SecurityCode = securityCode;
            ExpirationDate = expirationDate;
        }
    }
}