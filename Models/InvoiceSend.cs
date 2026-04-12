namespace Quickfile.Net.Models;

public class InvoiceSendRequest
{
    public int InvoiceID { get; set; }
    public EmailSettings EmailSettings { get; set; } = new();
}

public class EmailSettings
{
    public bool ToPrimaryContact { get; set; } = true;
    public string? CC { get; set; }
    public string? BCC { get; set; }
    public string? Subject { get; set; }
    public string? Body { get; set; }
}

public class InvoiceSendResponse
{
}
