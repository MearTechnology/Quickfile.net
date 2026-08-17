using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class BanksAccountsDetailResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("bank_type")]
    public string? BankType { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("is_hidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("sort_code")]
    public string? SortCode { get; set; }

    [JsonPropertyName("account_no")]
    public string? AccountNo { get; set; }

    [JsonPropertyName("consents")]
    public List<Consent>? Consents { get; set; }

}

public class BanksAccountsCreateRequest
{
    [JsonPropertyName("bank_name_id")]
    public int? BankNameId { get; set; }

    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("sort_code")]
    public string? SortCode { get; set; }

    [JsonPropertyName("opening_balance")]
    public OpeningBalance? OpeningBalance { get; set; }

    [JsonPropertyName("dashboard_pinned")]
    public bool? DashboardPinned { get; set; }

}

public class BanksAccountsResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("bank_type")]
    public string? BankType { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("is_hidden")]
    public bool? IsHidden { get; set; }

    [JsonPropertyName("sort_code")]
    public string? SortCode { get; set; }

    [JsonPropertyName("account_no")]
    public string? AccountNo { get; set; }

}

public class BanksAccountsBalancesResponse
{
    [JsonPropertyName("balance")]
    public double? Balance { get; set; }

}

public class BanksIdsResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("logo_path")]
    public string? LogoPath { get; set; }

}

public class BanksCreateTransactionRequest
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("duplicate_check")]
    public bool? DuplicateCheck { get; set; }

}

public class BanksTransactionResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("tag_status")]
    public string? TagStatus { get; set; }

}

public class BanksTransactionDetailedResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("tag_status")]
    public string? TagStatus { get; set; }

    [JsonPropertyName("balance")]
    public double? Balance { get; set; }

}
