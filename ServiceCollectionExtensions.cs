using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Quickfile.Net.Webhook;

namespace Quickfile.Net;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddQuickfile(this IServiceCollection services, Action<QuickfileOptions> configureOptions)
    {
        services.Configure(configureOptions);
        
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<QuickfileOptions>>().Value);

        services.AddHttpClient<QuickfileClient>();
        services.AddTransient<QuickfileWebhookParser>();

        return services;
    }
}
