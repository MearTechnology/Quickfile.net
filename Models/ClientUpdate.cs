namespace Quickfile.Net.Models;

public class ClientUpdateRequest
{
    public int ClientID { get; set; }
    public ClientDetails ClientDetails { get; set; } = new();
}

public class ClientUpdateResponse
{
    public int ClientID { get; set; }
}
