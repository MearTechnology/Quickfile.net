using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class Purchase
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

}

public class PurchaseCreateLine
{
    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("sub_total")]
    public double? SubTotal { get; set; }

    [JsonPropertyName("vat_rate")]
    public double? VatRate { get; set; }

    [JsonPropertyName("vat_amount")]
    public double? VatAmount { get; set; }

}

public class PurchasePaymentData
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

}

public class PurchaseRefund
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}

public class PurchasesGetItemsResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("sub_total")]
    public double? SubTotal { get; set; }

    [JsonPropertyName("vat_rate")]
    public double? VatRate { get; set; }

    [JsonPropertyName("vat_amount")]
    public double? VatAmount { get; set; }

    [JsonPropertyName("line_total")]
    public double? LineTotal { get; set; }

}

public class PurchasesGetResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("created_date")]
    public string? CreatedDate { get; set; }

    [JsonPropertyName("receipt_date")]
    public string? ReceiptDate { get; set; }

    [JsonPropertyName("due_date")]
    public string? DueDate { get; set; }

    [JsonPropertyName("supplier_name")]
    public string? SupplierName { get; set; }

    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("supplier_reference")]
    public string? SupplierReference { get; set; }

    [JsonPropertyName("receipt_number")]
    public string? ReceiptNumber { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("net_total")]
    public double? NetTotal { get; set; }

    [JsonPropertyName("vat_total")]
    public double? VatTotal { get; set; }

    [JsonPropertyName("gross_total")]
    public double? GrossTotal { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("exchange_rate")]
    public double? ExchangeRate { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }

    [JsonPropertyName("item_lines")]
    public List<PurchasesGetItemsResponse>? ItemLines { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("vat_codes")]
    public List<string>? VatCodes { get; set; }

}

public class PurchasesPostRequest
{
    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("receipt_date")]
    public string? ReceiptDate { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("vat_codes")]
    public List<string>? VatCodes { get; set; }

    [JsonPropertyName("suppplier_reference")]
    public string? SuppplierReference { get; set; }

    [JsonPropertyName("term_days")]
    public int? TermDays { get; set; }

    [JsonPropertyName("item_lines")]
    public List<PurchaseCreateLine>? ItemLines { get; set; }

    [JsonPropertyName("payment")]
    public PurchasePaymentData? Payment { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

}

public class PurchasesPutRequest
{
    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("receipt_date")]
    public string? ReceiptDate { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("vat_codes")]
    public List<string>? VatCodes { get; set; }

    [JsonPropertyName("suppplier_reference")]
    public string? SuppplierReference { get; set; }

    [JsonPropertyName("term_days")]
    public int? TermDays { get; set; }

    [JsonPropertyName("item_lines")]
    public List<PurchaseCreateLine>? ItemLines { get; set; }

    [JsonPropertyName("payment")]
    public PurchasePaymentData? Payment { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

}

public class PurchasesSearchResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("receipt_date")]
    public string? ReceiptDate { get; set; }

    [JsonPropertyName("supplier_name")]
    public string? SupplierName { get; set; }

    [JsonPropertyName("supplier_id")]
    public long? SupplierId { get; set; }

    [JsonPropertyName("supplier_reference")]
    public string? SupplierReference { get; set; }

    [JsonPropertyName("receipt_number")]
    public string? ReceiptNumber { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("gross_total")]
    public double? GrossTotal { get; set; }

    [JsonPropertyName("net_total")]
    public double? NetTotal { get; set; }

    [JsonPropertyName("vat_total")]
    public double? VatTotal { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("term_days")]
    public int? TermDays { get; set; }

}
