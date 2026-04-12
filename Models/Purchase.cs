using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class PurchaseCreateRequest
{
    public PurchaseData PurchaseData { get; set; } = new();
}

public class PurchaseData
{
    public int SupplierID { get; set; }
    public string ReceiptDate { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public decimal Tax { get; set; }
    public string? Reference { get; set; }
}

public class PurchaseCreateResponse
{
    public int PurchaseID { get; set; }
}

public class PurchaseUpdateRequest
{
    public int PurchaseID { get; set; }
    public PurchaseData PurchaseData { get; set; } = new();
}

public class PurchaseUpdateResponse
{
    public int PurchaseID { get; set; }
}

public class PurchaseSearchRequest
{
    public PurchaseSearchParameters SearchParameters { get; set; } = new();
}

public class PurchaseSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public string? Status { get; set; }
}

public class PurchaseSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<PurchaseSummary> Record { get; set; } = new();
}

public class PurchaseSummary
{
    public int PurchaseID { get; set; }
    public string SupplierCompanyName { get; set; } = string.Empty;
    public string ReceiptDate { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
}

public class PurchaseGetRequest
{
    public int PurchaseID { get; set; }
}

public class PurchaseGetResponse
{
    public PurchaseDetail PurchaseRecord { get; set; } = new();
}

public class PurchaseDetail
{
    public int PurchaseID { get; set; }
    public int SupplierID { get; set; }
    public string ReceiptDate { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
}

public class PurchaseDeleteRequest
{
    public int PurchaseID { get; set; }
}

public class PurchaseDeleteResponse
{
}
