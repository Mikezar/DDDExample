using Domain.Abstract;

namespace Domain.OrderAggregate
{
    public class OrderItem : Entity
    {
        public int ProductId { get; }
        public decimal Price { get; }
        public decimal Discount { get; }
        public ushort Quantity {get;}

        public OrderItem(int productId, decimal price, decimal discount, ushort quantity)
        {
            ProductId = productId;
            Price = price - discount;
            Discount = discount;
            Quantity = quantity;
        }
    }
}