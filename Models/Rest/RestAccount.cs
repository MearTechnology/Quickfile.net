using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class AccountDto
{
    [JsonPropertyName("AccNumber")]
    public string? AccNumber { get; set; }

    [JsonPropertyName("BusinessName")]
    public string? BusinessName { get; set; }

    [JsonPropertyName("CompanyNumber")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("CreatedDate")]
    public DateTimeOffset? CreatedDate { get; set; }

    [JsonPropertyName("BusinessType")]
    public string? BusinessType { get; set; }

    [JsonPropertyName("Address")]
    public string? Address { get; set; }

    [JsonPropertyName("Postcode")]
    public string? Postcode { get; set; }

    [JsonPropertyName("IsVatRegistered")]
    public bool? IsVatRegistered { get; set; }

    [JsonPropertyName("VatRegistrationNumber")]
    public string? VatRegistrationNumber { get; set; }

    [JsonPropertyName("YearEndDate")]
    public string? YearEndDate { get; set; }

    [JsonPropertyName("AccountStats")]
    public AccountStatsDto? AccountStats { get; set; }

}

public class AccountStatsDto
{
    [JsonPropertyName("LastUpdated")]
    public DateTimeOffset? LastUpdated { get; set; }

    [JsonPropertyName("AccountSize")]
    public string? AccountSize { get; set; }

    [JsonPropertyName("NominalCount_12m")]
    public int? NominalCount12m { get; set; }

    [JsonPropertyName("NominalCount")]
    public int? NominalCount { get; set; }

    [JsonPropertyName("SalesInvoiceCount")]
    public int? SalesInvoiceCount { get; set; }

    [JsonPropertyName("PurchaseInvoiceCount")]
    public int? PurchaseInvoiceCount { get; set; }

    [JsonPropertyName("ClientCount")]
    public int? ClientCount { get; set; }

    [JsonPropertyName("SupplierCount")]
    public int? SupplierCount { get; set; }

    [JsonPropertyName("RollingTurnover")]
    public double? RollingTurnover { get; set; }

}
