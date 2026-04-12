# Changelog

## [1.8.0] - 2026-04-14

### Added
- Model files for missing Quickfile API endpoints:
  - Bank_Get: `BankGetRequest`, `BankGetResponse`.
  - Payment_Allocate: `PaymentAllocateRequest`, `PaymentAllocateResponse`.
  - Ledger_Get: `LedgerGetRequest`, `LedgerGetResponse`.
- New methods in `QuickfileClient`:
  - `GetBankAsync`
  - `AllocatePaymentAsync`
  - `GetLedgerAsync`

## [1.7.0] - 2026-04-14

### Added
- Updated `QuickfileClient` with methods for all newly created endpoints:
  - Item: `CreateItemAsync`, `DeleteItemAsync`, `GetItemAsync`, `SearchItemAsync`
  - Journal: `CreateJournalAsync`, `DeleteJournalAsync`, `GetJournalAsync`, `SearchJournalAsync`
  - Project: `CreateProjectTagAsync`, `DeleteProjectTagAsync`, `SearchProjectTagAsync`
  - Ledger: `SearchLedgerAsync`, `GetNominalLedgersAsync`
  - Payment: `CreatePaymentAsync`, `DeletePaymentAsync`, `GetPaymentAsync`, `GetPaymentMethodsAsync`, `SearchPaymentAsync`
  - PurchaseOrder: `CreatePurchaseOrderAsync`, `DeletePurchaseOrderAsync`, `GetPurchaseOrderAsync`, `SearchPurchaseOrderAsync`
  - Report: `GetAgeingReportAsync`, `GetBalanceSheetAsync`, `GetChartOfAccountsAsync`, `GetProfitAndLossAsync`, `GetVatObligationsAsync`, `GetSubscriptionsAsync`
  - System: `CreateSystemNoteAsync`, `SearchSystemEventsAsync`, `GetAccountDetailsAsync`
  - Bank: `CreateBankAccountAsync`, `CreateBankTransactionAsync`, `GetBankBalancesAsync`
  - Client: `NewDirectDebitCollectionAsync`
  - Document: `UploadDocumentAsync`
  - Invoice/Estimate: `AcceptDeclineEstimateAsync`, `ConvertEstimateToInvoiceAsync`
  - Purchase: `UpdatePurchaseAsync`
  - Supplier: `UpdateSupplierAsync`
- Updated `QuickfileResponseWrapper` to include missing properties for `Purchase_Update` and `Supplier_Update`.

## [1.6.0] - 2026-04-14

### Added
- Model files for Ledger methods: `Ledger_Search` and `Ledger_GetNominalLedgers`.
- Model files for Payment methods: `Payment_Create`, `Payment_Delete`, `Payment_Get`, `Payment_GetPayMethods`, and `Payment_Search`.
- Model files for PurchaseOrder methods: `PurchaseOrder_Create`, `PurchaseOrder_Delete`, `PurchaseOrder_Get`, and `PurchaseOrder_Search`.
- `LedgerSearchRequest`, `LedgerSearchResponse`, `LedgerGetNominalLedgersRequest`, `LedgerGetNominalLedgersResponse` models.
- `PaymentCreateRequest`, `PaymentCreateResponse`, `PaymentDeleteRequest`, `PaymentDeleteResponse`, `PaymentGetRequest`, `PaymentGetResponse`, `PaymentGetPayMethodsRequest`, `PaymentGetPayMethodsResponse`, `PaymentSearchRequest`, `PaymentSearchResponse` models.
- `PurchaseOrderCreateRequest`, `PurchaseOrderCreateResponse`, `PurchaseOrderDeleteRequest`, `PurchaseOrderDeleteResponse`, `PurchaseOrderGetRequest`, `PurchaseOrderGetResponse`, `PurchaseOrderSearchRequest`, `PurchaseOrderSearchResponse` models.

## [1.5.0] - 2026-04-13

### Added
- Model files for Item methods: `Item_Create`, `Item_Delete`, `Item_Get`, and `Item_Search`.
- Model files for Journal methods: `Journal_Create`, `Journal_Delete`, `Journal_Get`, and `Journal_Search`.
- Model files for Project methods: `Project_TagCreate`, `Project_TagDelete`, and `Project_TagSearch`.
- `ItemCreateRequest`, `ItemCreateResponse`, `ItemDeleteRequest`, `ItemDeleteResponse`, `ItemGetRequest`, `ItemGetResponse`, `ItemSearchRequest`, `ItemSearchResponse` models.
- `JournalCreateRequest`, `JournalCreateResponse`, `JournalDeleteRequest`, `JournalDeleteResponse`, `JournalGetRequest`, `JournalGetResponse`, `JournalSearchRequest`, `JournalSearchResponse` models.
- `ProjectTagCreateRequest`, `ProjectTagCreateResponse`, `ProjectTagDeleteRequest`, `ProjectTagDeleteResponse`, `ProjectTagSearchRequest`, `ProjectTagSearchResponse` models.

## [1.4.0] - 2026-04-12

### Added
- `ClientInsertContactsRequest` and `ClientInsertContactsResponse` models.
- New methods in `QuickfileClient` to support:
  - `Client_Get`, `Client_Update`, `Client_Delete`, `Client_InsertContacts`
  - `Invoice_Search`, `Invoice_Delete`, `Invoice_Send`
  - `Bank_Search`, `Bank_GetAccounts`
  - `Purchase_Create`, `Purchase_Search`, `Purchase_Get`, `Purchase_Delete`
  - `Supplier_Create`, `Supplier_Search`, `Supplier_Get`, `Supplier_Delete`

## [1.3.0] - 2026-04-12

### Added
- Model files for Bank methods: `Bank_Search` and `Bank_GetAccounts`.
- Model files for Purchase methods: `Purchase_Create`, `Purchase_Search`, `Purchase_Get`, and `Purchase_Delete`.
- Model files for Supplier methods: `Supplier_Create`, `Supplier_Search`, `Supplier_Get`, and `Supplier_Delete`.
- `BankSearchRequest`, `BankSearchResponse`, `BankGetAccountsRequest`, `BankGetAccountsResponse` models.
- `PurchaseCreateRequest`, `PurchaseCreateResponse`, `PurchaseSearchRequest`, `PurchaseSearchResponse`, `PurchaseGetRequest`, `PurchaseGetResponse`, `PurchaseDeleteRequest`, `PurchaseDeleteResponse` models.
- `SupplierCreateRequest`, `SupplierCreateResponse`, `SupplierSearchRequest`, `SupplierSearchResponse`, `SupplierGetRequest`, `SupplierGetResponse`, `SupplierDeleteRequest`, `SupplierDeleteResponse` models.

## [1.2.0] - 2026-04-12

### Added
- Model files for Client_Get, Client_Update, and Client_Delete.
- Model files for Invoice_Search, Invoice_Delete, and Invoice_Send.
- `ClientGetRequest`, `ClientGetResponse`, `ClientUpdateRequest`, `ClientUpdateResponse`, `ClientDeleteRequest`, `ClientDeleteResponse` models.
- `InvoiceSearchRequest`, `InvoiceSearchResponse`, `InvoiceDeleteRequest`, `InvoiceDeleteResponse`, `InvoiceSendRequest`, `InvoiceSendResponse` models.

## [1.1.0] - 2026-04-12

### Added
- Dual JSON and XML support for all API endpoints.
- `QuickfileFormat` enum to `QuickfileOptions` to allow switching between `Json` and `Xml`.
- `QuickfileXmlPayload<T>` and `Utf8StringWriter` helper classes for XML serialization.
- XML serialization attributes (`[XmlElement]`) to model list properties for proper Quickfile XML formatting.
- `MessageType` property to `QuickfileHeader` for XML compatibility.

### Changed
- Refactored `QuickfileClient` to support both formats dynamically.
- `PostAsync` now routes to either `PostJsonAsync` or `PostXmlAsync` based on configuration.
- Updated `QuickfileOptions` to include `Format` property (defaults to `Json`).
