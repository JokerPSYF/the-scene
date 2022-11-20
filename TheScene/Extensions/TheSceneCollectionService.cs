using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data.Common;

namespace TheScene.Extensions.DependencyInjection
{
    public static class TheSceneCollectionService
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<IEventService, EventService>();

            return services;
        }

    }
}
