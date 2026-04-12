using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Quickfile.Net;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQuickfile(this IServiceCollection services, Action<QuickfileOptions> configureOptions)
    {
        services.Configure(configureOptions);
        services.AddHttpClient<QuickfileClient>((sp, client) =>
        {
            var options = sp.GetRequiredService<IOptions<QuickfileOptions>>().Value;
            // Additional HttpClient configuration can be added here if needed
        });

        return services;
    }
}
