using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Domain.InterfaceRepository;
using ToDoList.Infrastructure.Repository;

namespace ToDoList.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IToDoRepository, ToDoRepository>();
            return services;
        }
    }
}
