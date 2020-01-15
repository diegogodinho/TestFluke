using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Contracts
{
    public interface IEventService
    {
        Event GetEvents();
        Event GetEventsByDate(DateTime datesearch, string sortBy);
        Event GetEventsByStatus(string status, string sortBy);
        Event GetEventsByCategory(string category, string sortBy);
    }
}
