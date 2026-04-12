using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class InvoiceSearchRequest
{
    public InvoiceSearchParameters SearchParameters { get; set; } = new();
}

public class InvoiceSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public string? Status { get; set; }
}

public class InvoiceSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<InvoiceSummary> Record { get; set; } = new();
}

public class InvoiceSummary
{
    public int InvoiceID { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public string IssueDate { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
}
