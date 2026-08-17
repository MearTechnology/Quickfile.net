using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class JournalCreateLine
{
    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("debit_amount")]
    public double? DebitAmount { get; set; }

    [JsonPropertyName("credit_amount")]
    public double? CreditAmount { get; set; }

}

public class JournalCreateRequest
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("is_currency_revaluation")]
    public bool? IsCurrencyRevaluation { get; set; }

    [JsonPropertyName("lines")]
    public List<JournalCreateLine>? Lines { get; set; }

}

public class JournalCreateResponse
{
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

}

public class JournalGetResponse
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("folder")]
    public string? Folder { get; set; }

    [JsonPropertyName("lines")]
    public List<JournalGetResponseLine>? Lines { get; set; }

}

public class JournalGetResponseLine
{
    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("credit")]
    public double? Credit { get; set; }

    [JsonPropertyName("debit")]
    public double? Debit { get; set; }

}

public class JournalSearchResponseItem
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("has_rec_profile")]
    public bool? HasRecProfile { get; set; }

}
