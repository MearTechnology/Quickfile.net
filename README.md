# Quickfile.Net

A comprehensive .NET 10 wrapper for the Quickfile API (v1.2) supporting both **JSON** and **XML**. This library provides 100% coverage of the Quickfile API endpoints with strongly-typed models and automated authentication.

## Features

- **.NET 10.0** optimized.
- **Dual Format Support**: Switch between JSON and XML seamlessly via configuration.
- **Full API Coverage**: Includes Clients, Invoices, Banks, Purchases, Suppliers, Items, Journals, Projects, Ledgers, Payments, Reports, and more.
- **Dependency Injection** support.
- **Strongly typed** requests and responses.
- **Automated Authentication**: Handles MD5 submission number hashing automatically.

## Installation

```bash
dotnet add package Quickfile.Net
```

## Configuration

Add to your `Program.cs` or `Startup.cs`:

```csharp
builder.Services.AddQuickfile(options =>
{
    options.AccountNumber = "YOUR_ACCOUNT_NUMBER";
    options.ApiKey = "YOUR_API_KEY";
    options.ApplicationId = "YOUR_APPLICATION_ID";
    options.Format = QuickfileFormat.Json; // Optional: Default is Json. Use QuickfileFormat.Xml for XML.
});
```

## Available Endpoints

The `QuickfileClient` provides the following methods categorized by API section:

### Client Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `SearchClientAsync` | `Client_Search` | Search for clients by name or account reference. |
| `CreateClientAsync` | `Client_Create` | Create a new client record. |
| `GetClientAsync` | `Client_Get` | Retrieve full details for a specific client. |
| `UpdateClientAsync` | `Client_Update` | Update an existing client record. |
| `DeleteClientAsync` | `Client_Delete` | Delete a client record. |
| `InsertClientContactsAsync` | `Client_InsertContacts` | Add contacts to an existing client. |
| `ClientLoginAsync` | `Client_LogIn` | Generate a temporary login URL for a client. |
| `NewDirectDebitCollectionAsync` | `Client_NewDirectDebitCollection` | Initiate a Direct Debit collection. |

### Invoice & Estimate Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreateInvoiceAsync` | `Invoice_Create` | Create a new sales invoice or estimate. |
| `GetInvoiceAsync` | `Invoice_Get` | Retrieve details for a specific invoice. |
| `GetInvoicePdfAsync` | `Invoice_GetPDF` | Retrieve a PDF URI for a specific invoice. |
| `SearchInvoiceAsync` | `Invoice_Search` | Search for invoices based on criteria. |
| `DeleteInvoiceAsync` | `Invoice_Delete` | Delete a specific invoice. |
| `SendInvoiceAsync` | `Invoice_Send` | Send an invoice via email. |
| `AcceptDeclineEstimateAsync` | `Estimate_AcceptDecline` | Accept or decline an estimate. |
| `ConvertEstimateToInvoiceAsync` | `Estimate_ConvertToInvoice` | Convert an estimate to a live invoice. |

### Bank Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `SearchBankAsync` | `Bank_Search` | Search for bank transactions. |
| `GetBankAsync` | `Bank_Get` | Retrieve details for a specific bank account. |
| `GetBankAccountsAsync` | `Bank_GetAccounts` | List all bank accounts and their balances. |
| `CreateBankAccountAsync` | `Bank_CreateAccount` | Create a new bank account. |
| `CreateBankTransactionAsync` | `Bank_CreateTransaction` | Log a new bank transaction. |
| `GetBankBalancesAsync` | `Bank_GetAccountBalances` | Retrieve balances for multiple accounts. |

### Purchase Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreatePurchaseAsync` | `Purchase_Create` | Log a new purchase/receipt. |
| `UpdatePurchaseAsync` | `Purchase_Update` | Update an existing purchase record. |
| `SearchPurchaseAsync` | `Purchase_Search` | Search for purchase records. |
| `GetPurchaseAsync` | `Purchase_Get` | Retrieve full details for a purchase. |
| `DeletePurchaseAsync` | `Purchase_Delete` | Delete a purchase record. |

### Supplier Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreateSupplierAsync` | `Supplier_Create` | Create a new supplier record. |
| `UpdateSupplierAsync` | `Supplier_Update` | Update an existing supplier. |
| `SearchSupplierAsync` | `Supplier_Search` | Search for suppliers. |
| `GetSupplierAsync` | `Supplier_Get` | Retrieve full details for a supplier. |
| `DeleteSupplierAsync` | `Supplier_Delete` | Delete a supplier record. |

### Item & Inventory Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreateItemAsync` | `Item_Create` | Create a new inventory item or task. |
| `GetItemAsync` | `Item_Get` | Retrieve details for an item. |
| `SearchItemAsync` | `Item_Search` | Search inventory items. |
| `DeleteItemAsync` | `Item_Delete` | Delete an item. |

### Journal & Ledger Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreateJournalAsync` | `Journal_Create` | Create a new manual journal entry. |
| `GetJournalAsync` | `Journal_Get` | Retrieve journal details. |
| `SearchJournalAsync` | `Journal_Search` | Search manual journals. |
| `DeleteJournalAsync` | `Journal_Delete` | Delete a journal entry. |
| `SearchLedgerAsync` | `Ledger_Search` | Query a nominal ledger. |
| `GetLedgerAsync` | `Ledger_Get` | Retrieve activity for a nominal code. |
| `GetNominalLedgersAsync` | `Ledger_GetNominalLedgers` | List nominal ledgers. |

### Payment Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreatePaymentAsync` | `Payment_Create` | Log a new payment. |
| `GetPaymentAsync` | `Payment_Get` | Retrieve payment details. |
| `SearchPaymentAsync` | `Payment_Search` | Search for payments. |
| `DeletePaymentAsync` | `Payment_Delete` | Delete a payment record. |
| `AllocatePaymentAsync` | `Payment_Allocate` | Allocate an unassigned payment. |
| `GetPaymentMethodsAsync` | `Payment_GetPayMethods` | List available payment methods. |

### Project & Document Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreateProjectTagAsync` | `Project_TagCreate` | Attach a project tag. |
| `SearchProjectTagAsync` | `Project_TagSearch` | Search project tags. |
| `DeleteProjectTagAsync` | `Project_TagDelete` | Remove a project tag. |
| `UploadDocumentAsync` | `Document_Upload` | Upload a file to Document Management. |

### Report & System Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `GetAgeingReportAsync` | `Report_Ageing` | Retrieve ageing report (Debtors/Creditors). |
| `GetBalanceSheetAsync` | `Report_BalanceSheet` | Retrieve Balance Sheet. |
| `GetProfitAndLossAsync` | `Report_ProfitAndLoss` | Retrieve Profit & Loss report. |
| `GetChartOfAccountsAsync` | `Report_ChartOfAccounts` | Retrieve Chart of Accounts. |
| `GetVatObligationsAsync` | `Report_VatObligations` | Retrieve VAT returns. |
| `GetSubscriptionsAsync` | `Report_Subscriptions` | Retrieve list of subscriptions. |
| `GetAccountDetailsAsync` | `System_GetAccountDetails` | Retrieve account meta-data. |
| `SearchSystemEventsAsync` | `System_SearchEvents` | Query the system event log. |
| `CreateSystemNoteAsync` | `System_CreateNote` | Create a system-wide note. |

---

## Endpoint Samples

### 1. Client Search (`Client_Search`)

#### Request (JSON)
```json
{
  "payload": {
    "Header": { "AppID": "...", "AccountNumber": "...", "SubmissionNumber": "...", "Authentication": "..." },
    "Body": {
      "SearchParameters": { "CompanyName": "Mear Technology" }
    }
  }
}
```

#### Request (XML)
```xml
<?xml version="1.0" encoding="utf-8"?>
<Client_Search xmlns="http://www.quickfile.co.uk/schemas/1_2/Client_Search">
  <Header>
    <MessageType>Request</MessageType>
    <AppID>...</AppID>
    <AccountNumber>...</AccountNumber>
    <SubmissionNumber>...</SubmissionNumber>
    <Authentication>...</Authentication>
  </Header>
  <Body>
    <SearchParameters>
      <CompanyName>Mear Technology</CompanyName>
    </SearchParameters>
  </Body>
</Client_Search>
```

---

## Usage Example

```csharp
public class MyAccountingService
{
    private readonly QuickfileClient _client;

    public MyAccountingService(QuickfileClient client)
    {
        _client = client;
    }

    public async Task ProcessInvoices()
    {
        // 1. Search for a client
        var searchResult = await _client.SearchClientAsync(new ClientSearchRequest
        {
            SearchParameters = new ClientSearchParameters { CompanyName = "Mear Technology" }
        });

        // 2. Create an invoice
        if (searchResult?.Record.Count > 0)
        {
            var clientId = searchResult.Record[0].ClientID;
            var invoice = await _client.CreateInvoiceAsync(new InvoiceCreateRequest
            {
                InvoiceData = new InvoiceData
                {
                    ClientID = clientId,
                    IssueDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    InvoiceLines = new InvoiceLines
                    {
                        Item = new List<InvoiceItem>
                        {
                            new InvoiceItem { ItemDescription = "Services", UnitCost = 100, Qty = 1 }
                        }
                    }
                }
            });
        }
    }
}
```

## License

MIT
