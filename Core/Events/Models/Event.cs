using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Events.Models
{
    public abstract class Event
    {
        public string EventId { get; }

        public Event(string eventId)
        {
            EventId = eventId;
        }
    }
}
