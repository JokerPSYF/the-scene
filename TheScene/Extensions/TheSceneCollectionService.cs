using TheScene.Infrastructure.Data.Common;

namespace TheScene.Extensions.DependencyInjection
{
    public static class TheSceneCollectionService
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
