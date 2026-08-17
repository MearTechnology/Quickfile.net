using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class InventoryCreateRequest
{
    [JsonPropertyName("item_id")]
    public long? ItemId { get; set; }

    [JsonPropertyName("item_name")]
    public string? ItemName { get; set; }

    [JsonPropertyName("item_description")]
    public string? ItemDescription { get; set; }

    [JsonPropertyName("unit_cost")]
    public double? UnitCost { get; set; }

    [JsonPropertyName("item_type")]
    public string? ItemType { get; set; }

    [JsonPropertyName("vat_rate")]
    public double? VatRate { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("qty")]
    public double? Qty { get; set; }

}

public class InventoryItemModel
{
    [JsonPropertyName("item_id")]
    public long? ItemId { get; set; }

    [JsonPropertyName("created_date")]
    public string? CreatedDate { get; set; }

    [JsonPropertyName("item_name")]
    public string? ItemName { get; set; }

    [JsonPropertyName("item_description")]
    public string? ItemDescription { get; set; }

    [JsonPropertyName("item_value")]
    public double? ItemValue { get; set; }

    [JsonPropertyName("item_type")]
    public string? ItemType { get; set; }

    [JsonPropertyName("vat_percentage")]
    public double? VatPercentage { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("quantity")]
    public double? Quantity { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

}
