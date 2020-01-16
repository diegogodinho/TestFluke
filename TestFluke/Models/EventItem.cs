using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EventItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime? Closed { get; set; }
        public bool IsClosed
        {
            get { return Closed.HasValue; }
        }
        public IEnumerable<Categories> Categories { get; set; }
    }
}
