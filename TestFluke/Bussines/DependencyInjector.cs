using Bussines.Contracts;
using Bussines.Service;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Bussines
{
    public static class DependencyInjector
    {
        public static void BussinesDependenctyInjector(this IServiceCollection service)
        {
            service.AddScoped<IEventService, EventService>();
            service.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
