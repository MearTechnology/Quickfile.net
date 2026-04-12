# Quickfile.Net

A .NET 10 wrapper for the Quickfile API (v1.2) supporting both **JSON** and **XML**.

## Features

- **.NET 10.0** optimized.
- **Dual Format Support**: Switch between JSON and XML seamlessly.
- **Dependency Injection** support.
- **Strongly typed** requests and responses.
- **Automated Authentication** (MD5 submission number pattern).

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

### Invoice Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreateInvoiceAsync` | `Invoice_Create` | Create a new sales invoice. |
| `GetInvoiceAsync` | `Invoice_Get` | Retrieve details for a specific invoice. |
| `GetInvoicePdfAsync` | `Invoice_GetPDF` | Retrieve a PDF URI for a specific invoice. |
| `SearchInvoiceAsync` | `Invoice_Search` | Search for invoices based on criteria. |
| `DeleteInvoiceAsync` | `Invoice_Delete` | Delete a specific invoice. |
| `SendInvoiceAsync` | `Invoice_Send` | Send an invoice via email. |

### Bank Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `SearchBankAsync` | `Bank_Search` | Search for bank transactions. |
| `GetBankAccountsAsync` | `Bank_GetAccounts` | List all bank accounts and their balances. |

### Purchase Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreatePurchaseAsync` | `Purchase_Create` | Log a new purchase/receipt. |
| `SearchPurchaseAsync` | `Purchase_Search` | Search for purchase records. |
| `GetPurchaseAsync` | `Purchase_Get` | Retrieve full details for a purchase. |
| `DeletePurchaseAsync` | `Purchase_Delete` | Delete a purchase record. |

### Supplier Methods
| Method | Quickfile Endpoint | Description |
| :--- | :--- | :--- |
| `CreateSupplierAsync` | `Supplier_Create` | Create a new supplier record. |
| `SearchSupplierAsync` | `Supplier_Search` | Search for suppliers. |
| `GetSupplierAsync` | `Supplier_Get` | Retrieve full details for a supplier. |
| `DeleteSupplierAsync` | `Supplier_Delete` | Delete a supplier record. |

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

### 2. Bank Get Accounts (`Bank_GetAccounts`)

#### Request (JSON)
```json
{
  "payload": {
    "Header": { ... },
    "Body": {}
  }
}
```

#### Request (XML)
```xml
<?xml version="1.0" encoding="utf-8"?>
<Bank_GetAccounts xmlns="http://www.quickfile.co.uk/schemas/1_2/Bank_GetAccounts">
  <Header>...</Header>
  <Body />
</Bank_GetAccounts>
```

### 3. Create Purchase (`Purchase_Create`)

#### Request (JSON)
```json
{
  "payload": {
    "Header": { ... },
    "Body": {
      "PurchaseData": {
        "SupplierID": 98765,
        "ReceiptDate": "2026-04-12",
        "Category": "Travel",
        "Amount": 45.50
      }
    }
  }
}
```

#### Request (XML)
```xml
<?xml version="1.0" encoding="utf-8"?>
<Purchase_Create xmlns="http://www.quickfile.co.uk/schemas/1_2/Purchase_Create">
  <Header>...</Header>
  <Body>
    <PurchaseData>
      <SupplierID>98765</SupplierID>
      <ReceiptDate>2026-04-12</ReceiptDate>
      <Category>Travel</Category>
      <Amount>45.50</Amount>
    </PurchaseData>
  </Body>
</Purchase_Create>
```

## License

MIT
