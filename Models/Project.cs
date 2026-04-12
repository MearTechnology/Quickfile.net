using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class ProjectTagCreateRequest
{
    public TagDetails TagDetails { get; set; } = new();
}

public class TagDetails
{
    public string TagName { get; set; } = string.Empty;
    public int InvoiceID { get; set; }
}

public class ProjectTagCreateResponse
{
    public int TagID { get; set; }
}

public class ProjectTagDeleteRequest
{
    public int TagID { get; set; }
}

public class ProjectTagDeleteResponse
{
}

public class ProjectTagSearchRequest
{
    public ProjectTagSearchParameters SearchParameters { get; set; } = new();
}

public class ProjectTagSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? TagName { get; set; }
}

public class ProjectTagSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<ProjectTagRecord> Record { get; set; } = new();
}

public class ProjectTagRecord
{
    public int TagID { get; set; }
    public string TagName { get; set; } = string.Empty;
}
