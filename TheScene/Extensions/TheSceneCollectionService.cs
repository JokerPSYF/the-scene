using TheScene.Core.Exception;
using TheScene.Core.Interface;
using TheScene.Core.Service;
using TheScene.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TheSceneCollectionService
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICommonService, CommonService>();

            return services;
        }
    }
}
