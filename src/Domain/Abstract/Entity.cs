using System.Collections.Generic;
using MediatR;


namespace Domain.Abstract
{
    public abstract class Entity
    {
        private int _id;
        private List<INotification> _events;

        public int Id {
            get{
                return _id;
            }
            protected set{
                _id = value;
            }
        }

        public IReadOnlyCollection<INotification> Events => _events?.AsReadOnly();

        public void AddEvent(INotification notification)
        {
            if (_events == null)
                _events = new List<INotification>();

            _events.Add(notification);
        }
    }
}