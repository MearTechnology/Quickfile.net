using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class PurchaseOrderCreateRequest
{
    public PurchaseOrderData PurchaseOrderData { get; set; } = new();
}

public class PurchaseOrderData
{
    public int SupplierID { get; set; }
    public string IssueDate { get; set; } = string.Empty;
    public PurchaseOrderLines PurchaseOrderLines { get; set; } = new();
}

public class PurchaseOrderLines
{
    [XmlElement("Item")]
    public List<PurchaseOrderItem> Item { get; set; } = new();
}

public class PurchaseOrderItem
{
    public int ItemID { get; set; }
    public string ItemDescription { get; set; } = string.Empty;
    public string ItemNominalCode { get; set; } = "5000";
    public decimal UnitCost { get; set; }
    public decimal Qty { get; set; }
}

public class PurchaseOrderCreateResponse
{
    public int PurchaseOrderID { get; set; }
    public string PurchaseOrderNumber { get; set; } = string.Empty;
}

public class PurchaseOrderDeleteRequest
{
    public int PurchaseOrderID { get; set; }
}

public class PurchaseOrderDeleteResponse
{
}

public class PurchaseOrderGetRequest
{
    public int PurchaseOrderID { get; set; }
}

public class PurchaseOrderGetResponse
{
    public PurchaseOrderRecord PurchaseOrderData { get; set; } = new();
}

public class PurchaseOrderRecord
{
    public int PurchaseOrderID { get; set; }
    public int SupplierID { get; set; }
    public string IssueDate { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class PurchaseOrderSearchRequest
{
    public PurchaseOrderSearchParameters SearchParameters { get; set; } = new();
}

public class PurchaseOrderSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public int? SupplierID { get; set; }
}

public class PurchaseOrderSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<PurchaseOrderRecord> Record { get; set; } = new();
}
