using CoreServiceCollection.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CoreServiceCollection.Core
{
    public static class ServiceCollectionInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IPersonService, PersonService>();
            services.AddScoped<IIdentifierServiceScoped, IdentifierService>();
            services.AddTransient<IIdentifierServiceTransient, IdentifierService>();

            return services;
        }
    }
}