using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GetEventModel
    {
        public string StatusEvent { get; set; }
        public string Category { get; set; }
        public string SortByField { get; set; }
        public string SortMethod { get; set; }
    }
}
