using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class PaymentsClientGetResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("client_name")]
    public string? ClientName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("exchange_rate")]
    public double? ExchangeRate { get; set; }

    [JsonPropertyName("invoices")]
    public List<Invoice>? Invoices { get; set; }

    [JsonPropertyName("refund")]
    public List<Refund>? Refund { get; set; }

    [JsonPropertyName("total_allocated")]
    public double? TotalAllocated { get; set; }

}

public class PaymentsClientPostRequest
{
    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("invoice_id")]
    public long? InvoiceId { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("apply_credit")]
    public bool? ApplyCredit { get; set; }

    [JsonPropertyName("send_confirmation")]
    public bool? SendConfirmation { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

}

public class PaymentsClientPostResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("client_name")]
    public string? ClientName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("exchange_rate")]
    public double? ExchangeRate { get; set; }

    [JsonPropertyName("invoices")]
    public List<Invoice>? Invoices { get; set; }

    [JsonPropertyName("refund")]
    public List<Refund>? Refund { get; set; }

}

public class PaymentsClientSearchResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("client_name")]
    public string? ClientName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

}

public class PaymentsSupplierGetResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("supplier_name")]
    public string? SupplierName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }

    [JsonPropertyName("nominal_code")]
    public long? NominalCode { get; set; }

    [JsonPropertyName("exchange_rate")]
    public double? ExchangeRate { get; set; }

    [JsonPropertyName("total_allocated")]
    public double? TotalAllocated { get; set; }

    [JsonPropertyName("purchases")]
    public List<Purchase>? Purchases { get; set; }

    [JsonPropertyName("refund")]
    public List<PurchaseRefund>? Refund { get; set; }

    [JsonPropertyName("total_unallocated")]
    public double? TotalUnallocated { get; set; }

}

public class PaymentsSupplierPostRequest
{
    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("purchase_id")]
    public long? PurchaseId { get; set; }

    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("apply_credit")]
    public bool? ApplyCredit { get; set; }

    [JsonPropertyName("send_confirmation")]
    public bool? SendConfirmation { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

}

public class PaymentsSupplierPostResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("supplier_name")]
    public string? SupplierName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }

    [JsonPropertyName("nominal_code")]
    public long? NominalCode { get; set; }

    [JsonPropertyName("exchange_rate")]
    public double? ExchangeRate { get; set; }

    [JsonPropertyName("total_allocated")]
    public double? TotalAllocated { get; set; }

    [JsonPropertyName("purchases")]
    public List<Purchase>? Purchases { get; set; }

    [JsonPropertyName("refund")]
    public List<PurchaseRefund>? Refund { get; set; }

}

public class PaymentsSupplierSearchResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("supplier_name")]
    public string? SupplierName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

}

public class Refund
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}
