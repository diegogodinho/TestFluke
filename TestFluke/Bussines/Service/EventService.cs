using Bussines.Contracts;
using Models;
using RequestService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Service
{
    internal class EventService : HttpRequests, IEventService
    {
        private readonly ISettings settings;

        public EventService(ISettings settings) : base(settings.UrlBaseApi)
        {
            this.settings = settings;
        }

        public Event GetEvents()
        {
            return this.Get<Event>("events");
        }

        public Event GetEventsByCategory(string category, string sortBy)
        {
            throw new NotImplementedException();
        }

        public Event GetEventsByDate(DateTime datesearch, string sortBy)
        {
            throw new NotImplementedException();
        }

        public Event GetEventsByStatus(string status, string sortBy)
        {
            throw new NotImplementedException();
        }
    }
}
