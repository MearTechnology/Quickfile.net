using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class SupplierCreateRequest
{
    public SupplierData SupplierData { get; set; } = new();
}

public class SupplierData
{
    public string CompanyName { get; set; } = string.Empty;
    public string? AccountReference { get; set; }
    public string? VATRegistrationNumber { get; set; }
    
    [XmlElement("ContactDetail")]
    public List<ContactDetail> ContactDetails { get; set; } = new();
}

public class SupplierCreateResponse
{
    public int SupplierID { get; set; }
}

public class SupplierUpdateRequest
{
    public int SupplierID { get; set; }
    public SupplierData SupplierData { get; set; } = new();
}

public class SupplierUpdateResponse
{
    public int SupplierID { get; set; }
}

public class SupplierSearchRequest
{
    public SupplierSearchParameters SearchParameters { get; set; } = new();
}

public class SupplierSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? CompanyName { get; set; }
    public string? AccountReference { get; set; }
}

public class SupplierSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<SupplierRecord> Record { get; set; } = new();
}

public class SupplierRecord
{
    public int SupplierID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string? AccountReference { get; set; }
}

public class SupplierGetRequest
{
    public int SupplierID { get; set; }
}

public class SupplierGetResponse
{
    public SupplierGetDetails SupplierDetails { get; set; } = new();
}

public class SupplierGetDetails
{
    public int SupplierID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string? AccountReference { get; set; }
    
    [XmlElement("ContactDetail")]
    public List<ContactDetail> ContactDetails { get; set; } = new();
}

public class SupplierDeleteRequest
{
    public int SupplierID { get; set; }
}

public class SupplierDeleteResponse
{
}
