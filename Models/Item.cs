using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class ItemCreateRequest
{
    public ItemDetails ItemDetails { get; set; } = new();
}

public class ItemDetails
{
    public string ItemName { get; set; } = string.Empty;
    public string? ItemDescription { get; set; }
    public decimal UnitCost { get; set; }
    public string ItemType { get; set; } = "INVENTORY";
}

public class ItemCreateResponse
{
    public int ItemID { get; set; }
}

public class ItemDeleteRequest
{
    public int ItemID { get; set; }
}

public class ItemDeleteResponse
{
}

public class ItemGetRequest
{
    public int ItemID { get; set; }
}

public class ItemGetResponse
{
    public ItemRecord ItemDetails { get; set; } = new();
}

public class ItemSearchRequest
{
    public ItemSearchParameters SearchParameters { get; set; } = new();
}

public class ItemSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? Order { get; set; }
    public string? ItemName { get; set; }
}

public class ItemSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<ItemRecord> Record { get; set; } = new();
}

public class ItemRecord
{
    public int ItemID { get; set; }
    public string ItemName { get; set; } = string.Empty;
    public string? ItemDescription { get; set; }
    public decimal UnitCost { get; set; }
    public string? ItemType { get; set; }
}
