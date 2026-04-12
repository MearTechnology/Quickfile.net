using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class JournalCreateRequest
{
    public JournalData JournalData { get; set; } = new();
}

public class JournalData
{
    public string Date { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public JournalLines JournalLines { get; set; } = new();
}

public class JournalLines
{
    [XmlElement("JournalLine")]
    public List<JournalLine> JournalLine { get; set; } = new();
}

public class JournalLine
{
    public int NominalCode { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
}

public class JournalCreateResponse
{
    public int JournalID { get; set; }
}

public class JournalDeleteRequest
{
    public int JournalID { get; set; }
}

public class JournalDeleteResponse
{
}

public class JournalGetRequest
{
    public int JournalID { get; set; }
}

public class JournalGetResponse
{
    public JournalRecord JournalData { get; set; } = new();
}

public class JournalSearchRequest
{
    public JournalSearchParameters SearchParameters { get; set; } = new();
}

public class JournalSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public string? Description { get; set; }
}

public class JournalSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<JournalRecord> Record { get; set; } = new();
}

public class JournalRecord
{
    public int JournalID { get; set; }
    public string Date { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
