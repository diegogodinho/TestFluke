using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class CategoryViewModel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
    }
}
