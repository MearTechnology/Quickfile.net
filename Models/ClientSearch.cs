using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class ClientSearchRequest
{
    public ClientSearchParameters SearchParameters { get; set; } = new();
}

public class ClientSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? Order { get; set; }
    public string? CompanyName { get; set; }
    public string? AccountReference { get; set; }
}

public class ClientSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<ClientRecord> Record { get; set; } = new();
}

public class ClientRecord
{
    public int ClientID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public string AccountReference { get; set; } = string.Empty;
}
