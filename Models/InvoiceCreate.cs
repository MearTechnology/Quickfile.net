using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class InvoiceCreateRequest
{
    public InvoiceData InvoiceData { get; set; } = new();
}

public class InvoiceData
{
    public int ClientID { get; set; }
    public string IssueDate { get; set; } = string.Empty;
    public string DueDate { get; set; } = string.Empty;
    public CurrencyInfo CurrencyInfo { get; set; } = new();
    public int TermDays { get; set; }
    public string Language { get; set; } = "en";
    public InvoiceLines InvoiceLines { get; set; } = new();
}

public class CurrencyInfo
{
    public string CurrencyCode { get; set; } = "GBP";
}

public class InvoiceLines
{
    [XmlElement("Item")]
    public List<InvoiceItem> Item { get; set; } = new();
}

public class InvoiceItem
{
    public int ItemID { get; set; }
    public string ItemDescription { get; set; } = string.Empty;
    public string ItemNominalCode { get; set; } = "4000";
    public decimal UnitCost { get; set; }
    public decimal Qty { get; set; }
    public TaxInfo? Tax1 { get; set; }
}

public class TaxInfo
{
    public string TaxName { get; set; } = "VAT";
    public decimal TaxPercentage { get; set; } = 20;
}

public class InvoiceCreateResponse
{
    public int InvoiceID { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
}
