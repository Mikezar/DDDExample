using Domain.Abstract;
using System;

namespace Domain.ProductAggregate
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name {get; private set; }
        public string Description {get; private set; }
        public decimal Price {get; private set; }
        public ushort Quantity {get; private set; }
        public decimal Discount {get; private set; }
        public string ImageUrl {get; private set;}
        public bool IsAvailable { get; private set; }
        public DateTimeOffset Created {get;}

        public Product(string name, string description, decimal price, ushort quantity, decimal discount, string imageUrl)
        {
            Update(name, description, price, quantity, discount);

            ImageUrl = imageUrl;
            IsAvailable = quantity > 0;
            Created = DateTimeOffset.UtcNow;
        }

        public void SetAvailability(bool isAvailable)
        {
            if (Quantity == 0) throw new InvalidOperationException();

            IsAvailable = isAvailable;
        }

        public void SetImage(string imageUrl)
        {
            ImageUrl = imageUrl;
        }

        public void Update(string name, string description, decimal price, ushort quantity, decimal discount)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException(nameof(description));
            if (price <= 0) throw new ArgumentException(nameof(price));
            if (discount < 0 || discount >= price) throw new ArgumentException(nameof(discount));
            if (quantity < 0) throw new ArgumentException(nameof(quantity));

            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            Discount = discount;
        }
    }
}