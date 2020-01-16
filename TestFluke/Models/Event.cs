using System;
using System.Collections.Generic;

namespace Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<EventItem> Events { get; set; }
    }
    
}
