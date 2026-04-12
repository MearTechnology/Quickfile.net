using System.Xml.Serialization;

namespace Quickfile.Net.Models;

public class BankSearchRequest
{
    public BankSearchParameters SearchParameters { get; set; } = new();
}

public class BankSearchParameters
{
    public int ReturnCount { get; set; } = 20;
    public int Offset { get; set; } = 0;
    public string? AccountType { get; set; }
    public string? FromDate { get; set; }
    public string? ToDate { get; set; }
}

public class BankSearchResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<BankRecord> Record { get; set; } = new();
}

public class BankRecord
{
    public int BankID { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public string SortCode { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string AccountType { get; set; } = string.Empty;
    public decimal Balance { get; set; }
}

public class BankCreateAccountRequest
{
    public BankAccountDetails BankAccountDetails { get; set; } = new();
}

public class BankAccountDetails
{
    public string AccountName { get; set; } = string.Empty;
    public string? SortCode { get; set; }
    public string? AccountNumber { get; set; }
    public string AccountType { get; set; } = string.Empty; // CURRENT, SAVINGS, etc.
    public string CurrencyCode { get; set; } = "GBP";
}

public class BankCreateAccountResponse
{
    public int BankID { get; set; }
}

public class BankCreateTransactionRequest
{
    public int BankID { get; set; }
    public BankTransactionDetails TransactionDetails { get; set; } = new();
}

public class BankTransactionDetails
{
    public string Date { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string? Reference { get; set; }
}

public class BankCreateTransactionResponse
{
    public int TransactionID { get; set; }
}

public class BankGetAccountBalancesRequest
{
}

public class BankGetAccountBalancesResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<BankBalanceRecord> Record { get; set; } = new();
}

public class BankBalanceRecord
{
    public int BankID { get; set; }
    public string AccountName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
}

public class BankGetAccountsRequest
{
    public int? BankID { get; set; }
}

public class BankGetAccountsResponse : BaseResponseBody
{
    [XmlElement("Record")]
    public List<BankRecord> Record { get; set; } = new();
}

public class BankGetRequest
{
    public int BankID { get; set; }
}

public class BankGetResponse
{
    public BankRecord BankData { get; set; } = new();
}
