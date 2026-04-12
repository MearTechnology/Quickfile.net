using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class LedgerSearchRequest
{
    public LedgerSearchParameters SearchParameters { get; set; } = new();
}

public class LedgerSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public int? NominalCode { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
}

public class LedgerSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<LedgerRecord> Record { get; set; } = new();
}

public class LedgerRecord
{
    public int JournalID { get; set; }
    public string Date { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public int NominalCode { get; set; }
}

public class LedgerGetNominalLedgersRequest
{
    public string Range { get; set; } = "1-200";
}

public class LedgerGetNominalLedgersResponse : BaseResponseBody
{
    [XmlElement("NominalLedger")]
    public List<NominalLedger> NominalLedger { get; set; } = new();
}

public class NominalLedger
{
    public int NominalCode { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}

public class LedgerGetRequest
{
    public int NominalCode { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
}

public class LedgerGetResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<LedgerRecord> Record { get; set; } = new();
}
