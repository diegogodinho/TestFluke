using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class GetEventByIdModel
    {
        public string EventID { get; set; }
        public string SortByField { get; set; }
        public string SortMethod { get; set; }
    }
}
