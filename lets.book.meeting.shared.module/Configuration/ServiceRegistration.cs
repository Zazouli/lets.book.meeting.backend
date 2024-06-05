using lets.book.meeting.shared.module.Core.Services;
using meetspace.room.management.module.Core.Services;
using meetspace.room.management.module.Infrastructor.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lets.book.meeting.shared.module.Configuration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddSharedDomainDependencies(
        this IServiceCollection services)
        {
            services.AddScoped<ISharedService, SharedService>();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
