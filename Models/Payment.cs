using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class PaymentCreateRequest
{
    public PaymentData PaymentData { get; set; } = new();
}

public class PaymentData
{
    public int? ClientID { get; set; }
    public int? SupplierID { get; set; }
    public decimal Amount { get; set; }
    public string Date { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public int? BankAccountID { get; set; }
}

public class PaymentCreateResponse
{
    public int PaymentID { get; set; }
}

public class PaymentDeleteRequest
{
    public int PaymentID { get; set; }
}

public class PaymentDeleteResponse
{
}

public class PaymentGetRequest
{
    public int PaymentID { get; set; }
}

public class PaymentGetResponse
{
    public PaymentRecord PaymentData { get; set; } = new();
}

public class PaymentGetPayMethodsRequest
{
}

public class PaymentGetPayMethodsResponse
{
    [XmlElement("PaymentMethod")]
    public List<string> PaymentMethod { get; set; } = new();
}

public class PaymentSearchRequest
{
    public PaymentSearchParameters SearchParameters { get; set; } = new();
}

public class PaymentSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
    public int? ClientID { get; set; }
    public int? SupplierID { get; set; }
}

public class PaymentSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<PaymentRecord> Record { get; set; } = new();
}

public class PaymentRecord
{
    public int PaymentID { get; set; }
    public int? ClientID { get; set; }
    public int? SupplierID { get; set; }
    public decimal Amount { get; set; }
    public string Date { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
}

public class PaymentAllocateRequest
{
    public int PaymentID { get; set; }
    public int InvoiceID { get; set; }
    public decimal Amount { get; set; }
}

public class PaymentAllocateResponse
{
}
