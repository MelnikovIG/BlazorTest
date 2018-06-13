using ColorGameComponent;
using Microsoft.Extensions.DependencyInjection;

namespace ColorGame.Component
{
    public static class ServiceCollectionsExtensions
    {
        public static void RegisterColorGameServices(this IServiceCollection services)
        {
            services.AddSingleton<IGameConfiguration, GameConfiguration>();
            services.AddSingleton<IColorGenerator, ColorGenerator>();
        }
    }
}
