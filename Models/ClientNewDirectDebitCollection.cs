namespace Quickfile.Net.Models;

public class ClientNewDirectDebitCollectionRequest
{
    public int ClientID { get; set; }
    public decimal Amount { get; set; }
    public string? Reference { get; set; }
}

public class ClientNewDirectDebitCollectionResponse
{
    public int CollectionID { get; set; }
}
