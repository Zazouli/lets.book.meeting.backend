using meetspace.room.management.module.Core.Services;
using meetspace.room.management.module.Infrastructor.CosmosDB;
using meetspace.room.management.module.Infrastructor.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace meetspace.room.management.module.Configuration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRoomManagementDependencies(
        this IServiceCollection services)
        {
            services.AddScoped<ICosmosDBClientFactory, CosmosDBClientFactory>();
            services.AddScoped<IRoomManagementRepository, RoomManagementRepository>();
            services.AddScoped<IRoomManagementService, RoomManagementService>();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
