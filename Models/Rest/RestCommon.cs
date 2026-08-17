using System.Net;
using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

/// <summary>
/// Pagination details returned in paged REST API responses.
/// </summary>
public class PaginationModel
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    [JsonPropertyName("offset")]
    public int? Offset { get; set; }
}

/// <summary>
/// Generic wrapper for REST API responses containing an array of items with count and location.
/// </summary>
/// <typeparam name="T">The item type.</typeparam>
public class RestArrayResponse<T>
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("data")]
    public List<T>? Data { get; set; }
}

/// <summary>
/// Generic wrapper for REST API responses containing paginated items.
/// </summary>
/// <typeparam name="T">The item type.</typeparam>
public class RestPagedResponse<T>
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("paging")]
    public PaginationModel? Paging { get; set; }

    [JsonPropertyName("data")]
    public List<T>? Data { get; set; }
}

/// <summary>
/// Represents an error response from the Quickfile REST API.
/// </summary>
public class QuickfileRestException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string? ResponseContent { get; }

    public QuickfileRestException(HttpStatusCode statusCode, string message, string? responseContent = null) 
        : base(message)
    {
        StatusCode = statusCode;
        ResponseContent = responseContent;
    }
}
