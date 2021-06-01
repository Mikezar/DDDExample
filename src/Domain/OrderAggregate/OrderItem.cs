using Domain.Abstract;

namespace Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; private set; }
        public decimal Price { get; private set; }
        public decimal Discount { get; private set; }
        public ushort Quantity {get; private set; }

        public OrderItem(int productId, decimal price, decimal discount, ushort quantity)
        {
            ProductId = productId;
            Price = price - discount;
            Discount = discount;
            Quantity = quantity;
        }
    }
}