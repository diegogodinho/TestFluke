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

        public EventDetail GetEvent(GetEventByIdModel model)
        {
            if (model != null && !string.IsNullOrEmpty(model.EventID))
            {
                var eventsResult = this.Get<EventDetail>($"events/{model.EventID}");

                if (!string.IsNullOrEmpty(model.SortByField))
                {
                    eventsResult.Categories = SortCategories(eventsResult, model.SortByField, model.SortMethod);
                }
                return eventsResult;

            }
            return null;
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
            var orderByParameter = Expression.Parameter(typeof(EventItem));
            var orderByExpression = Expression.Lambda<Func<EventItem, IComparable>>(Expression.PropertyOrField(orderByParameter, sort), orderByParameter).Compile();
            if (string.IsNullOrEmpty(sortMethod) || sortMethod == "asc")
                return currentEvent.Events.OrderBy(orderByExpression);
            else
                return currentEvent.Events.OrderByDescending(orderByExpression);

        }

        private IEnumerable<Categories> SortCategories(EventDetail eventDetails, string sort, string sortMethod)
        {
            var orderByParameter = Expression.Parameter(typeof(Categories));
            var orderByExpression = Expression.Lambda<Func<Categories, IComparable>>(Expression.PropertyOrField(orderByParameter, sort), orderByParameter).Compile();
            if (string.IsNullOrEmpty(sortMethod) || sortMethod == "asc")
                return eventDetails.Categories.OrderBy(orderByExpression);
            else
                return eventDetails.Categories.OrderByDescending(orderByExpression);

        }
    }
}
