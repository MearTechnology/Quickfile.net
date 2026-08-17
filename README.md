# Quickfile.Net

A comprehensive .NET 10 wrapper for the Quickfile API supporting both the modern **v2 REST API** (with Bearer token authentication) and the legacy **v1.2 API** (supporting JSON and XML across all endpoints), plus Webhook consumption and signature validation.

## Features

- **.NET 10.0** optimized.
- **REST API (v2) Support**: Complete coverage of all 45 REST endpoints with Bearer token authentication, pagination, and multi-part document uploads.
- **Dual Format Legacy (v1.2) Support**: Switch between JSON and XML seamlessly via configuration.
- **Full API Coverage**: Clients, Invoices, Banks, Purchases, Purchase Orders, Suppliers, Inventory, Journals, Projects, Ledgers, Payments (Client & Supplier), Reports, and Account Management.
- **Dependency Injection**: First-class support for `Microsoft.Extensions.DependencyInjection`.
- **Strongly Typed**: Strongly-typed request/response and parameter models.
- **Webhooks**: Built-in webhook payload parsing and MD5 HMAC validation.

## Installation

```bash
dotnet add package Quickfile.Net
```

## Configuration

Add to your `Program.cs` or `Startup.cs`:

```csharp
builder.Services.AddQuickfile(options =>
{
    // --- Modern REST API (v2) ---
    options.BearerToken = "YOUR_REST_BEARER_TOKEN";
    // Optional: defaults to "https://api-beta.quickfile.co.uk"
    // options.RestBaseUrl = "https://api-beta.quickfile.co.uk";

    // --- Legacy API (v1.2) ---
    options.AccountNumber = "YOUR_ACCOUNT_NUMBER";
    options.ApiKey = "YOUR_API_KEY";
    options.ApplicationId = "YOUR_APPLICATION_ID";
    options.Format = QuickfileFormat.Json; // Optional: Default is Json. Use QuickfileFormat.Xml for XML.

    // --- Webhooks ---
    options.WebhookSecret = "YOUR_WEBHOOK_SECRET";
});
```

## REST API (v2) Endpoints

The unified `QuickfileClient` exposes all v2 REST endpoints (prefixed with `Rest...`):

### Account
- `RestGetAccountMeAsync()`: Get connected account business details and stats.

### Bank
- `RestGetBankAccountsAsync(parameters)`: List bank accounts with optional nominal/type filters.
- `RestCreateBankAccountAsync(request)`: Create a new bank account.
- `RestGetBankBalanceAsync(accountId)`: Get bank balance for an account.
- `RestGetBankTransactionsAsync(accountId, parameters)`: Query bank transactions with date, nominal, amount filters.
- `RestCreateBankTransactionsAsync(accountId, request)`: Create untagged bank transactions.
- `RestGetSupportedBanksAsync()`: List supported bank institutions.

### Clients
- `RestSearchClientsAsync(parameters)`: Search client records with pagination.
- `RestCreateClientAsync(request)`: Create a client.
- `RestGetClientAsync(id, parameters)`: Retrieve full client & contact details.
- `RestUpdateClientAsync(id, request)`: Update an existing client.
- `RestDeleteClientAsync(id)`: Delete a client record.
- `RestGetClientContactsAsync(id)`: Get client contacts.
- `RestCreateClientContactAsync(id, request)`: Add a client contact.
- `RestUpdateClientContactAsync(id, contactId, request)`: Update a client contact.
- `RestDeleteClientContactAsync(id, contactId)`: Delete a client contact.
- `RestCreateClientLoginUrlAsync(id, request)`: Generate tokenized client login URL.
- `RestCreateClientDirectDebitAsync(id, request)`: Initiate Direct Debit collection.
- `RestGetClientTradingStylesAsync()`: Retrieve client trading styles.

### Client & Supplier Payments
- `RestSearchClientPaymentsAsync(parameters)` / `RestSearchSupplierPaymentsAsync(parameters)`: Search payments with filters & pagination.
- `RestCreateClientPaymentAsync(request)` / `RestCreateSupplierPaymentAsync(request)`: Create payment records.
- `RestGetClientPaymentAsync(id)` / `RestGetSupplierPaymentAsync(id)`: Retrieve payment details.
- `RestDeleteClientPaymentAsync(id)` / `RestDeleteSupplierPaymentAsync(id)`: Delete payment records.

### Documents & Receipt Hub
- `RestUploadReceiptAsync(stream, fileName, captureDate, purchaseId, receiptName)`: Upload receipt to Receipt Hub.
- `RestUploadSalesDocumentAsync(stream, fileName, invoiceId, notes)`: Attach document to sales invoice.
- `RestUploadGeneralDocumentAsync(stream, fileName, collectionName)`: Upload document to Document Management.

### Inventory
- `RestSearchInventoryAsync(parameters)`: Search inventory items.
- `RestCreateInventoryItemAsync(request)`: Create inventory item.
- `RestGetInventoryItemAsync(id)`: Get inventory item.
- `RestDeleteInventoryItemAsync(id)`: Delete inventory item.

### Invoices & Estimates
- `RestSearchInvoicesAsync(parameters)`: Search invoices/estimates with filters and pagination.
- `RestCreateInvoiceAsync(request)`: Create invoice, estimate, or recurring template.
- `RestGetInvoiceAsync(id)`: Retrieve invoice/estimate details.
- `RestUpdateInvoiceAsync(id, request)`: Update invoice/estimate.
- `RestDeleteInvoiceAsync(id, request)`: Delete invoice/estimate.
- `RestGetInvoicePdfAsync(id)`: Get PDF document URL for invoice.
- `RestSendInvoiceAsync(request)`: Send invoice/estimate via email.

### Journals & Ledgers
- `RestSearchJournalsAsync(parameters)`: Search manual journals.
- `RestCreateJournalAsync(request)`: Create a journal entry.
- `RestGetJournalAsync(id)`: Retrieve journal by ID.
- `RestDeleteJournalAsync(id)`: Delete a journal entry.
- `RestQueryLedgerAsync(parameters)`: Query nominal ledger.
- `RestGetNominalsAsync(parameters)`: List chart of accounts nominal ledgers.

### Projects
- `RestSearchProjectsAsync(parameters)`: Search project tags.
- `RestAttachProjectTagsAsync(request)`: Attach tag to invoice/purchase/estimate.
- `RestDeleteProjectTagsAsync(request)`: Delete project tag.

### Purchases & Purchase Orders
- `RestSearchPurchasesAsync(parameters)` / `RestSearchPurchaseOrdersAsync(parameters)`: Search purchases or purchase orders.
- `RestCreatePurchaseAsync(request)` / `RestCreatePurchaseOrderAsync(request)`: Create purchase / purchase order.
- `RestGetPurchaseAsync(id)` / `RestGetPurchaseOrderAsync(id)`: Retrieve purchase / purchase order.
- `RestUpdatePurchaseAsync(id, request)` / `RestUpdatePurchaseOrderAsync(id, request)`: Update purchase / purchase order.
- `RestDeletePurchaseAsync(id, request)` / `RestDeletePurchaseOrderAsync(id)`: Delete purchase / purchase order.

### Reports
- `RestGetChartOfAccountsReportAsync(parameters)`: Retrieve Chart of Accounts.
- `RestGetBalanceSheetReportAsync(dateTo)`: Retrieve Balance Sheet report.
- `RestGetAgeingReportAsync(parameters)`: Retrieve aged debtors/creditors report.
- `RestGetProfitAndLossReportAsync(parameters)`: Retrieve Profit & Loss report.
- `RestGetVatObligationsReportAsync(parameters)`: Retrieve HMRC VAT returns.
- `RestGetSubscriptionsReportAsync()`: Retrieve account subscriptions.
- `RestGetEventLogReportAsync(parameters)`: Query system event log.

### Suppliers
- `RestSearchSuppliersAsync(parameters)`: Search supplier records.
- `RestCreateSupplierAsync(request)`: Create a supplier.
- `RestGetSupplierAsync(id)`: Retrieve supplier details.
- `RestUpdateSupplierAsync(id, request)`: Update supplier.
- `RestDeleteSupplierAsync(id)`: Delete supplier.
- `RestGetSupplierContactsAsync(id)`: Retrieve supplier contacts.
- `RestCreateSupplierContactAsync(id, request)`: Create supplier contact.
- `RestUpdateSupplierContactAsync(id, contactId, request)`: Update supplier contact.
- `RestDeleteSupplierContactAsync(id, contactId)`: Delete supplier contact.

---

## Legacy API (v1.2) Endpoints

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
