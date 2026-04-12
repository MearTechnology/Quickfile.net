using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class ClientCreateRequest
{
    public ClientDetails ClientDetails { get; set; } = new();
}

public class ClientDetails
{
    public string CompanyName { get; set; } = string.Empty;
    public string? AccountReference { get; set; }
    
    [XmlElement("ContactDetail")]
    public List<ContactDetail> ContactDetails { get; set; } = new();
}

public class ContactDetail
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
}

public class ClientCreateResponse
{
    public int ClientID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
}
