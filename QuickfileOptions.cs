namespace Quickfile.Net;

public class QuickfileOptions
{
    public string AccountNumber { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public string ApplicationId { get; set; } = string.Empty;
    public QuickfileFormat Format { get; set; } = QuickfileFormat.Json;
}

public enum QuickfileFormat
{
    Json,
    Xml
}
