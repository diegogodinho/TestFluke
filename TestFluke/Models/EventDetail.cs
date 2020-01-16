using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class EventDetail
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
    }
}
