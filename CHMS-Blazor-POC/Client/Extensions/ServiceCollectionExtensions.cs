using StatCan.Chms.Client.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Collection of extension methods for augmenting service registration and configuration. 
    /// 
    /// Microsoft recommends to keep this in the Microsoft.Extensions.DependencyInjection namespace.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the <see cref="CultureManager"/> to the services.
        /// </summary>
        /// <param name="services">The DI service</param>
        /// <param name="options">An action to set the options for the <see cref="CultureManager"/></param>
        /// <returns></returns>
        public static IServiceCollection AddCultureManager(this IServiceCollection services, Action<CultureManagerOptions> options)
        {
            services.AddSingleton<CultureManager>();
            services.Configure<CultureManagerOptions>(options);

            return services;
        }
    }
}
