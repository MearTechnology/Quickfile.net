using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class DocumentUploadResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

}
