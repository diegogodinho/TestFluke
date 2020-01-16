using Bussines.Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bussines.Service
{
    internal class EventService : HttpRequests, IEventService
    {
        private readonly ISettings settings;

        public EventService(ISettings settings) : base(settings.UrlBaseApi)
        {
            this.settings = settings;
        }

        public Event GetEvents(string sortBy)
        {
            if (string.IsNullOrEmpty(sortBy))
                return this.Get<Event>("events");

            else
            {
                var events = this.Get<Event>("events");
                events.Events = SortEvents(events, sortBy);
                return events;
            }
        }

        public Event GetEventsByCategory(int category, string sortBy)
        {
            if (category == 0)
                return null;

            var events = this.Get<Event>($"categories/{category}");

            if (!string.IsNullOrEmpty(sortBy))
            {
                events.Events = SortEvents(events, sortBy);
                return events;
            }
            return events;
        }

        public Event GetEventsByDate(DateTime datesearch, string sortBy)
        {
            var events = this.Get<Event>($"events?status=closed");
            events.Events = events.Events.Where(r => r.Closed.HasValue &&
            (r.Closed.Value.Year == datesearch.Year && r.Closed.Value.Month == datesearch.Month && r.Closed.Value.Day == datesearch.Day)).ToList();
            if (!string.IsNullOrEmpty(sortBy))
            {
                events.Events = SortEvents(events, sortBy);
                return events;
            }
            return events;
        }

        public Event GetEventsByStatus(string statusEvent, string sortBy)
        {
            statusEvent = string.IsNullOrEmpty(statusEvent) ? "open" : statusEvent;
            var events = this.Get<Event>($"events?status={statusEvent}");

            if (!string.IsNullOrEmpty(sortBy))
            {
                events.Events = SortEvents(events, sortBy);
                return events;
            }
            return events;
        }

        private IEnumerable<EventItem> SortEvents(Event currentEvent, string sort)
        {
            switch (sort)
            {
                case
                    "date":
                    return currentEvent.Events.OrderBy(r => r.Closed);
                case
                    "status":
                    return currentEvent.Events.OrderBy(r => r.IsClosed);
                case
                    "category":
                    return currentEvent.Events.OrderBy(r => r.Title).Select(d => new EventItem
                    {
                        Id = d.Id,
                        Closed = d.Closed,
                        Link = d.Link,
                        Title = d.Title,
                        Categories = d.Categories.OrderBy(r => r.Title)
                    });
                default:
                    var orderByParameter = Expression.Parameter(typeof(EventItem));
                    var orderByExpression = Expression.Lambda<Func<EventItem, IComparable>>(Expression.PropertyOrField(orderByParameter, sort), orderByParameter).Compile();
                    return currentEvent.Events.OrderBy(orderByExpression);

            }
        }
    }
}
