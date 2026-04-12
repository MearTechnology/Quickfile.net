namespace Quickfile.Net.Models;

public class InvoiceGetRequest
{
    public int InvoiceID { get; set; }
}

public class InvoiceGetResponse
{
    public InvoiceDetails InvoiceDetails { get; set; } = new();
}

public class InvoiceDetails
{
    public int InvoiceID { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
}

public class InvoiceGetPdfResponse
{
    public InvoicePdfDetails InvoiceDetails { get; set; } = new();
}

public class InvoicePdfDetails
{
    public string PDFUri { get; set; } = string.Empty;
}

public class EstimateAcceptDeclineRequest
{
    public int EstimateID { get; set; }
    public string Action { get; set; } = string.Empty; // Accept or Decline
}

public class EstimateAcceptDeclineResponse
{
}

public class EstimateConvertToInvoiceRequest
{
    public int EstimateID { get; set; }
}

public class EstimateConvertToInvoiceResponse
{
    public int InvoiceID { get; set; }
}
