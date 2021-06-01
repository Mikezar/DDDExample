using System;
using Domain.Abstract;

namespace Domain.OrderAggregate
{
    public class DeliveryAddress : ValueObject
    {
        public string State {get; }
        public string City {get; }
        public string Street {get; }
        public string HouseNumber {get; }
        
        public DeliveryAddress(string state, string city, string street, string houseNumber)
        {
            if (string.IsNullOrEmpty(state)) throw new ArgumentNullException(nameof(state));
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException(nameof(city));
            if (string.IsNullOrEmpty(street)) throw new ArgumentNullException(nameof(street));
            if (string.IsNullOrEmpty(houseNumber)) throw new ArgumentNullException(nameof(houseNumber));

            State = state;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }
    }
}