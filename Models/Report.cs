using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class ReportAgeingRequest
{
    public string AgeingType { get; set; } = string.Empty; // DEBTOR or CREDITOR
    public string? ToDate { get; set; }
}

public class ReportAgeingResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<AgeingRecord> Record { get; set; } = new();
}

public class AgeingRecord
{
    public int? ClientID { get; set; }
    public int? SupplierID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public decimal Current { get; set; }
    public decimal Period1 { get; set; }
    public decimal Period2 { get; set; }
    public decimal Period3 { get; set; }
    public decimal Period4 { get; set; }
}

public class ReportBalanceSheetRequest
{
    public string? ToDate { get; set; }
    public bool ShowAsNBV { get; set; }
}

public class ReportBalanceSheetResponse
{
    [XmlElement("Record")]
    public List<BalanceSheetRecord> Record { get; set; } = new();
}

public class BalanceSheetRecord
{
    public int NominalCode { get; set; }
    public string NominalName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
}

public class ReportChartOfAccountsRequest
{
    public int? StartNominalCode { get; set; }
    public int? EndNominalCode { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public bool ExcludeZeroBalanceLedgers { get; set; }
}

public class ReportChartOfAccountsResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<ChartOfAccountsRecord> Record { get; set; } = new();
}

public class ChartOfAccountsRecord
{
    public int NominalCode { get; set; }
    public string NominalName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
}

public class ReportProfitAndLossRequest
{
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
}

public class ReportProfitAndLossResponse
{
    [XmlElement("Record")]
    public List<ProfitAndLossRecord> Record { get; set; } = new();
}

public class ProfitAndLossRecord
{
    public int NominalCode { get; set; }
    public string NominalName { get; set; } = string.Empty;
    public decimal Total { get; set; }
}

public class ReportVatObligationsRequest
{
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public string? Status { get; set; } // Open or Fulfilled
}

public class ReportVatObligationsResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<VatObligationRecord> Record { get; set; } = new();
}

public class VatObligationRecord
{
    public string PeriodKey { get; set; } = string.Empty;
    public string Start { get; set; } = string.Empty;
    public string End { get; set; } = string.Empty;
    public string Due { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public class ReportSubscriptionsRequest
{
}

public class ReportSubscriptionsResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<SubscriptionRecord> Record { get; set; } = new();
}

public class SubscriptionRecord
{
    public int SubscriptionID { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string NextRunDate { get; set; } = string.Empty;
    public string Frequency { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}
