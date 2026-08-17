namespace Quickfile.Net;

public class QuickfileOptions
{
    // Legacy API v1.2 configuration
    public string AccountNumber { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string ApplicationId { get; set; } = string.Empty;
    public string WebhookSecret { get; set; } = string.Empty;
    public QuickfileFormat Format { get; set; } = QuickfileFormat.Json;

    // REST API v2 configuration
    public string? BearerToken { get; set; }
    public string RestBaseUrl { get; set; } = "https://api-beta.quickfile.co.uk";
}

public enum QuickfileFormat
{
    Json,
    Xml
}
