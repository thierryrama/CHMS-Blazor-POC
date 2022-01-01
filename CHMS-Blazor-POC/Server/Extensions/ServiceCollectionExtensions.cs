using StatCan.Chms.Services;

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
        /// Register all the business services into the DI engine
        /// </summary>
        /// <param name="services">DI engine to register services into</param>
        /// <param name="configuration">Application configuration to get settings from</param>
        /// <returns>The same DI engine as from input to allow builder pattern</returns>
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<BookingBusinessService>();

            return services;
        }
    }
}
