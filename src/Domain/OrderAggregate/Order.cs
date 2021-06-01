using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;

namespace Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        private List<OrderItem> _orderItems;
        public int BuyerId { get; private set; }
        public DeliveryAddress DeliveryAddress { get; private set; }
        public CardInformation CardInformation { get; private set; }
        public int StatusId { get; private set; }
        public string PaymentId {get; private set;}
        
        public IReadOnlyCollection<OrderItem> Items => _orderItems;

        protected Order()
        {
            _orderItems = new List<OrderItem>();
        }

        public Order(int buyerId, CardInformation card, DeliveryAddress address) : this()
        {
            BuyerId = buyerId;
            DeliveryAddress = address;
            CardInformation = card;
            StatusId = OrderStatus.Created.Id;
        }

        public void AddItem(int productId, decimal count, decimal discount, ushort quantity)
        {
            _orderItems.Add(new OrderItem(productId, count, discount, quantity));
        }

        public void SetPaidStatus()
        {
            StatusId = OrderStatus.Payed.Id;
        }

        public void SetCancelledStatus()
        {
            if (StatusId == OrderStatus.Payed.Id || StatusId == OrderStatus.Done.Id)
                throw new InvalidOperationException();

            StatusId = OrderStatus.Cancelled.Id;
        }
        
        public void SetDoneStatus()
        {
            if (StatusId != OrderStatus.Payed.Id)
                throw new InvalidOperationException();

            StatusId = OrderStatus.Done.Id;
        }

        public void SetPaymentId(string paymentId)
        {
            PaymentId = paymentId;
        }

        public decimal GetTotaslSum() => _orderItems.Sum(o => o.Quantity * o.Price);
    }
}