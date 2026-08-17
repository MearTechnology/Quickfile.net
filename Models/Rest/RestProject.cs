using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class ProjectsCreateRequest
{
    [JsonPropertyName("reference_id")]
    public long? ReferenceId { get; set; }

    [JsonPropertyName("reference_type")]
    public string? ReferenceType { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

}

public class ProjectsDeleteRequest
{
    [JsonPropertyName("reference_id")]
    public long? ReferenceId { get; set; }

    [JsonPropertyName("reference_type")]
    public string? ReferenceType { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

}
