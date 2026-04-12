using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class ClientGetRequest
{
    public int ClientID { get; set; }
}

public class ClientGetResponse
{
    public ClientGetDetails ClientDetails { get; set; } = new();
}

public class ClientGetDetails
{
    public int ClientID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string? AccountReference { get; set; }
    
    [XmlElement("ContactDetail")]
    public List<ContactDetail> ContactDetails { get; set; } = new();
}
