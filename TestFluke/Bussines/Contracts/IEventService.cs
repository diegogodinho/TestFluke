using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Contracts
{
    public interface IEventService
    {
        Event GetEvents(string sortBy);
        Event GetEventsByDate(DateTime datesearch, string sortBy);
        Event GetEventsByStatus(string statusEvent, string sortBy);
        Event GetEventsByCategory(int category, string sortBy);
    }
}
