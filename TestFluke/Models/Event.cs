using System;
using System.Collections.Generic;

namespace Models
{

    public class Event
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public IList<EventItem> Events { get; set; }
    }

    public class EventItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public IList<Categories> Categories { get; set; }
    }

    public class Categories
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
