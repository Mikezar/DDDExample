using Domain.Abstract;

namespace Domain.OrderAggregate
{
    public class OrderStatus : Enumeration
    {
        public static OrderStatus Created => new OrderStatus(1, nameof(Created));
        public static OrderStatus Payed => new OrderStatus(2, nameof(Payed));
        public static OrderStatus Done => new OrderStatus(3, nameof(Done));
        public static OrderStatus Cancelled => new OrderStatus(4, nameof(Cancelled));

        public OrderStatus(ushort id, string name) : base(id, name)
        {

        }
    }
}