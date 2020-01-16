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

        public Event GetEvents(GetEventModel model)
        {
            if (model != null)
            {
                var url = string.IsNullOrEmpty(model.Category) ? "events" : $"categories/{model.Category}";
                url += string.IsNullOrEmpty(model.StatusEvent) ? "" : $"?status={model.StatusEvent}";

                var eventsReturn = this.Get<Event>(url);

                if (!string.IsNullOrEmpty(model.SortByField))
                {
                    eventsReturn.Events = SortEvents(eventsReturn, model.SortByField, model.SortMethod);
                }
                return eventsReturn;
            }
            else
            {
                return this.Get<Event>("events");
            }
        }

        private IEnumerable<EventItem> SortEvents(Event currentEvent, string sort, string sortMethod)
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
                    if (string.IsNullOrEmpty(sortMethod) || sortMethod == "asc")
                        return currentEvent.Events.OrderBy(orderByExpression);
                    else
                        return currentEvent.Events.OrderByDescending(orderByExpression);

            }
        }
    }
}
