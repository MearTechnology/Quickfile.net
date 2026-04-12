using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class ClientInsertContactsRequest
{
    public int ClientID { get; set; }
    
    [XmlElement("ContactDetail")]
    public List<ContactDetail> ContactDetails { get; set; } = new();
}

public class ClientInsertContactsResponse
{
}
