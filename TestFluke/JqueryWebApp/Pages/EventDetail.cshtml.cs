using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JqueryWebApp
{
    public class EventDetailModel : PageModel
    {
        public string EventID { get; set; }
       
        public void OnGet(string e)
        {
            this.EventID = e;
        }
    }
}