using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class PurchaseOrderCreateLine
{
    [JsonPropertyName("quantity")]
    public double? Quantity { get; set; }

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

public class PurchaseOrderPostRequest
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

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("item_lines")]
    public List<PurchaseOrderCreateLine>? ItemLines { get; set; }

    [JsonPropertyName("payment")]
    public PurchasePaymentData? Payment { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

}

public class PurchaseOrderPutRequest
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

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("item_lines")]
    public List<PurchaseOrderCreateLine>? ItemLines { get; set; }

    [JsonPropertyName("payment")]
    public PurchasePaymentData? Payment { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

}

public class PurchaseOrdersGetItemsResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("unit_cost")]
    public double? UnitCost { get; set; }

    [JsonPropertyName("qty")]
    public double? Qty { get; set; }

    [JsonPropertyName("sub_total")]
    public double? SubTotal { get; set; }

    [JsonPropertyName("vat_rate")]
    public double? VatRate { get; set; }

    [JsonPropertyName("vat_amount")]
    public double? VatAmount { get; set; }

    [JsonPropertyName("line_total")]
    public double? LineTotal { get; set; }

}

public class PurchaseOrdersGetResponse
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

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("exchange_rate")]
    public double? ExchangeRate { get; set; }

    [JsonPropertyName("parent_id")]
    public long? ParentId { get; set; }

    [JsonPropertyName("item_lines")]
    public List<PurchaseOrdersGetItemsResponse>? ItemLines { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("vat_codes")]
    public List<string>? VatCodes { get; set; }

}
