using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class ChartOfAccountsResponse
{
    [JsonPropertyName("code")]
    public int? Code { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("system_code")]
    public bool? SystemCode { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}

public class BalanceSheetResponse
{
    [JsonPropertyName("totals")]
    public BalanceSheetResponseTotals? Totals { get; set; }

    [JsonPropertyName("fixed_assets")]
    public List<BalanceSheetResponseAssets>? FixedAssets { get; set; }

    [JsonPropertyName("current_assets")]
    public List<BalanceSheetResponseAssets>? CurrentAssets { get; set; }

    [JsonPropertyName("current_liabilities")]
    public List<BalanceSheetResponseAssets>? CurrentLiabilities { get; set; }

    [JsonPropertyName("capital_and_reserves")]
    public List<BalanceSheetResponseAssets>? CapitalAndReserves { get; set; }

}

public class BalanceSheetResponseAssets
{
    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("nominal_code_name")]
    public string? NominalCodeName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}

public class BalanceSheetResponseTotals
{
    [JsonPropertyName("fixed_assets")]
    public double? FixedAssets { get; set; }

    [JsonPropertyName("current_assets")]
    public double? CurrentAssets { get; set; }

    [JsonPropertyName("current_liabilities")]
    public double? CurrentLiabilities { get; set; }

    [JsonPropertyName("long_term_liabilities")]
    public double? LongTermLiabilities { get; set; }

    [JsonPropertyName("capital_and_reserves")]
    public double? CapitalAndReserves { get; set; }

}

public class AgeingResponse
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("prepayments")]
    public double? Prepayments { get; set; }

    [JsonPropertyName("total_overdue")]
    public double? TotalOverdue { get; set; }

    [JsonPropertyName("not_yet_due")]
    public double? NotYetDue { get; set; }

    [JsonPropertyName("aged_0_15")]
    public double? Aged015 { get; set; }

    [JsonPropertyName("aged_16_30")]
    public double? Aged1630 { get; set; }

    [JsonPropertyName("aged_31_60")]
    public double? Aged3160 { get; set; }

    [JsonPropertyName("aged_61_90")]
    public double? Aged6190 { get; set; }

    [JsonPropertyName("aged_Over90")]
    public double? AgedOver90 { get; set; }

}

public class ProfitAndLossResponse
{
    [JsonPropertyName("totals")]
    public ProfitAndLossTotalsResponse? Totals { get; set; }

    [JsonPropertyName("turnovers")]
    public List<ProfitAndLossEntryResponse>? Turnovers { get; set; }

    [JsonPropertyName("less_cost_of_sales")]
    public List<ProfitAndLossEntryResponse>? LessCostOfSales { get; set; }

    [JsonPropertyName("less_expenses")]
    public List<ProfitAndLossEntryResponse>? LessExpenses { get; set; }

}

public class ProfitAndLossTotalsResponse
{
    [JsonPropertyName("turnover")]
    public double? Turnover { get; set; }

    [JsonPropertyName("less_cost_of_sales")]
    public double? LessCostOfSales { get; set; }

    [JsonPropertyName("less_expenses")]
    public double? LessExpenses { get; set; }

    [JsonPropertyName("net_profit")]
    public double? NetProfit { get; set; }

}

public class ProfitAndLossEntryResponse
{
    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("nominal_code_name")]
    public string? NominalCodeName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}

public class VatObligationsResponse
{
    [JsonPropertyName("period")]
    public string? Period { get; set; }

    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("to")]
    public string? To { get; set; }

    [JsonPropertyName("due")]
    public string? Due { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

}

public class SubscriptionsResponse
{
    [JsonPropertyName("created_date")]
    public string? CreatedDate { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("expiry_date")]
    public string? ExpiryDate { get; set; }

}

public class EventLogResponse
{
    [JsonPropertyName("count")]
    public int? Count { get; set; }

    [JsonPropertyName("location")]
    public string? Location { get; set; }

    [JsonPropertyName("next_token")]
    public string? NextToken { get; set; }

    [JsonPropertyName("data")]
    public List<EventLogResponseItem>? Data { get; set; }

}

public class EventLogResponseItem
{
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }

    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }

    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

}
