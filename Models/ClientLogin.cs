namespace Quickfile.Net.Models;

public class ClientLoginRequest
{
    public int ClientID { get; set; }
    public LandingPage LandingPage { get; set; } = new();
}

public class LandingPage
{
    public InvoiceView InvoiceView { get; set; } = new();
}

public class InvoiceView
{
    public int InvoiceID { get; set; }
}

public class ClientLoginResponse
{
    public string URL { get; set; } = string.Empty;
}
