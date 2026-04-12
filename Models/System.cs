using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class SystemCreateNoteRequest
{
    public string NoteText { get; set; } = string.Empty;
    public int? ClientID { get; set; }
    public int? SupplierID { get; set; }
}

public class SystemCreateNoteResponse
{
    public int NoteID { get; set; }
}

public class SystemSearchEventsRequest
{
    public SystemSearchEventsParameters SearchParameters { get; set; } = new();
}

public class SystemSearchEventsParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public string? EventType { get; set; }
}

public class SystemSearchEventsResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<SystemEventRecord> Record { get; set; } = new();
}

public class SystemEventRecord
{
    public int EventID { get; set; }
    public string EventDate { get; set; } = string.Empty;
    public string EventType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

public class SystemGetAccountDetailsRequest
{
}

public class SystemGetAccountDetailsResponse
{
    public string CompanyName { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string VATNumber { get; set; } = string.Empty;
    public string CompanyRegistrationNumber { get; set; } = string.Empty;
}
