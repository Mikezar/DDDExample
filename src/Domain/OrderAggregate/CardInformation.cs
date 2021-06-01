using System;
using Domain.Abstract;

namespace Domain.OrderAggregate
{
    public class CardInformation : ValueObject
    {
        public string Brand { get;}
        public string Number { get;}
        public string Holder { get;}   
        public string SecurityCode { get;}
        public DateTime ExpirationDate {get;}

        public CardInformation(string cardBrand, string cardNumber, string cardHolder, string cardSecurityCode, DateTime cardExpirationDate)
        {
            if (string.IsNullOrEmpty(cardBrand)) throw new ArgumentNullException(nameof(cardBrand));
            if (string.IsNullOrEmpty(cardNumber)) throw new ArgumentNullException(nameof(cardNumber));
            if (string.IsNullOrEmpty(cardHolder)) throw new ArgumentNullException(nameof(cardHolder));
            if (string.IsNullOrEmpty(cardSecurityCode)) throw new ArgumentNullException(nameof(cardSecurityCode));

            Brand = cardBrand;
            Number = cardNumber;
            Holder = cardHolder;
            SecurityCode = cardSecurityCode;
            ExpirationDate = cardExpirationDate;
        }
    }
}