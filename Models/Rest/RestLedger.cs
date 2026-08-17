using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class LedgersNominalsResponse
{
    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("is_purchase_code")]
    public bool? IsPurchaseCode { get; set; }

    [JsonPropertyName("is_sales_code")]
    public bool? IsSalesCode { get; set; }

}

public class LedgersSearchResponse
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("NetValue")]
    public double? NetValue { get; set; }

    [JsonPropertyName("transactions")]
    public List<LedgersSearchTransaction>? Transactions { get; set; }

}

public class LedgersSearchTransaction
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}

public class OpeningBalance
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}
