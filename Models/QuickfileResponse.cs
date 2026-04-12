using System.Text.Json.Serialization;

namespace Quickfile.Net.Models;

public class QuickfileResponseWrapper<T>
{
    // Client Methods
    [JsonPropertyName("Client_Search")] public QuickfileResponse<T>? ClientSearch { get; set; }
    [JsonPropertyName("Client_Create")] public QuickfileResponse<T>? ClientCreate { get; set; }
    [JsonPropertyName("Client_Get")] public QuickfileResponse<T>? ClientGet { get; set; }
    [JsonPropertyName("Client_Update")] public QuickfileResponse<T>? ClientUpdate { get; set; }
    [JsonPropertyName("Client_Delete")] public QuickfileResponse<T>? ClientDelete { get; set; }
    [JsonPropertyName("Client_InsertContacts")] public QuickfileResponse<T>? ClientInsertContacts { get; set; }
    [JsonPropertyName("Client_LogIn")] public QuickfileResponse<T>? ClientLogin { get; set; }
    [JsonPropertyName("Client_NewDirectDebitCollection")] public QuickfileResponse<T>? ClientNewDirectDebitCollection { get; set; }

    // Invoice & Estimate Methods
    [JsonPropertyName("Invoice_Create")] public QuickfileResponse<T>? InvoiceCreate { get; set; }
    [JsonPropertyName("Invoice_Get")] public QuickfileResponse<T>? InvoiceGet { get; set; }
    [JsonPropertyName("Invoice_GetPDF")] public QuickfileResponse<T>? InvoiceGetPdf { get; set; }
    [JsonPropertyName("Invoice_Search")] public QuickfileResponse<T>? InvoiceSearch { get; set; }
    [JsonPropertyName("Invoice_Delete")] public QuickfileResponse<T>? InvoiceDelete { get; set; }
    [JsonPropertyName("Invoice_Send")] public QuickfileResponse<T>? InvoiceSend { get; set; }
    [JsonPropertyName("Estimate_AcceptDecline")] public QuickfileResponse<T>? EstimateAcceptDecline { get; set; }
    [JsonPropertyName("Estimate_ConvertToInvoice")] public QuickfileResponse<T>? EstimateConvertToInvoice { get; set; }

    // Bank Methods
    [JsonPropertyName("Bank_Search")] public QuickfileResponse<T>? BankSearch { get; set; }
    [JsonPropertyName("Bank_Get")] public QuickfileResponse<T>? BankGet { get; set; }
    [JsonPropertyName("Bank_GetAccounts")] public QuickfileResponse<T>? BankGetAccounts { get; set; }
    [JsonPropertyName("Bank_CreateAccount")] public QuickfileResponse<T>? BankCreateAccount { get; set; }
    [JsonPropertyName("Bank_CreateTransaction")] public QuickfileResponse<T>? BankCreateTransaction { get; set; }
    [JsonPropertyName("Bank_GetAccountBalances")] public QuickfileResponse<T>? BankGetAccountBalances { get; set; }

    // Item Methods
    [JsonPropertyName("Item_Create")] public QuickfileResponse<T>? ItemCreate { get; set; }
    [JsonPropertyName("Item_Delete")] public QuickfileResponse<T>? ItemDelete { get; set; }
    [JsonPropertyName("Item_Get")] public QuickfileResponse<T>? ItemGet { get; set; }
    [JsonPropertyName("Item_Search")] public QuickfileResponse<T>? ItemSearch { get; set; }

    // Journal Methods
    [JsonPropertyName("Journal_Create")] public QuickfileResponse<T>? JournalCreate { get; set; }
    [JsonPropertyName("Journal_Delete")] public QuickfileResponse<T>? JournalDelete { get; set; }
    [JsonPropertyName("Journal_Get")] public QuickfileResponse<T>? JournalGet { get; set; }
    [JsonPropertyName("Journal_Search")] public QuickfileResponse<T>? JournalSearch { get; set; }

    // Project Methods
    [JsonPropertyName("Project_TagCreate")] public QuickfileResponse<T>? ProjectTagCreate { get; set; }
    [JsonPropertyName("Project_TagDelete")] public QuickfileResponse<T>? ProjectTagDelete { get; set; }
    [JsonPropertyName("Project_TagSearch")] public QuickfileResponse<T>? ProjectTagSearch { get; set; }

    // Ledger Methods
    [JsonPropertyName("Ledger_Search")] public QuickfileResponse<T>? LedgerSearch { get; set; }
    [JsonPropertyName("Ledger_Get")] public QuickfileResponse<T>? LedgerGet { get; set; }
    [JsonPropertyName("Ledger_GetNominalLedgers")] public QuickfileResponse<T>? LedgerGetNominalLedgers { get; set; }

    // Payment Methods
    [JsonPropertyName("Payment_Create")] public QuickfileResponse<T>? PaymentCreate { get; set; }
    [JsonPropertyName("Payment_Delete")] public QuickfileResponse<T>? PaymentDelete { get; set; }
    [JsonPropertyName("Payment_Get")] public QuickfileResponse<T>? PaymentGet { get; set; }
    [JsonPropertyName("Payment_GetPayMethods")] public QuickfileResponse<T>? PaymentGetPayMethods { get; set; }
    [JsonPropertyName("Payment_Search")] public QuickfileResponse<T>? PaymentSearch { get; set; }
    [JsonPropertyName("Payment_Allocate")] public QuickfileResponse<T>? PaymentAllocate { get; set; }

    // Purchase Methods
    [JsonPropertyName("Purchase_Create")] public QuickfileResponse<T>? PurchaseCreate { get; set; }
    [JsonPropertyName("Purchase_Search")] public QuickfileResponse<T>? PurchaseSearch { get; set; }
    [JsonPropertyName("Purchase_Get")] public QuickfileResponse<T>? PurchaseGet { get; set; }
    [JsonPropertyName("Purchase_Delete")] public QuickfileResponse<T>? PurchaseDelete { get; set; }
    [JsonPropertyName("Purchase_Update")] public QuickfileResponse<T>? PurchaseUpdate { get; set; }

    // PurchaseOrder Methods
    [JsonPropertyName("PurchaseOrder_Create")] public QuickfileResponse<T>? PurchaseOrderCreate { get; set; }
    [JsonPropertyName("PurchaseOrder_Delete")] public QuickfileResponse<T>? PurchaseOrderDelete { get; set; }
    [JsonPropertyName("PurchaseOrder_Get")] public QuickfileResponse<T>? PurchaseOrderGet { get; set; }
    [JsonPropertyName("PurchaseOrder_Search")] public QuickfileResponse<T>? PurchaseOrderSearch { get; set; }

    // Supplier Methods
    [JsonPropertyName("Supplier_Create")] public QuickfileResponse<T>? SupplierCreate { get; set; }
    [JsonPropertyName("Supplier_Search")] public QuickfileResponse<T>? SupplierSearch { get; set; }
    [JsonPropertyName("Supplier_Get")] public QuickfileResponse<T>? SupplierGet { get; set; }
    [JsonPropertyName("Supplier_Delete")] public QuickfileResponse<T>? SupplierDelete { get; set; }
    [JsonPropertyName("Supplier_Update")] public QuickfileResponse<T>? SupplierUpdate { get; set; }

    // Document Methods
    [JsonPropertyName("Document_Upload")] public QuickfileResponse<T>? DocumentUpload { get; set; }

    // Report Methods
    [JsonPropertyName("Report_Ageing")] public QuickfileResponse<T>? ReportAgeing { get; set; }
    [JsonPropertyName("Report_BalanceSheet")] public QuickfileResponse<T>? ReportBalanceSheet { get; set; }
    [JsonPropertyName("Report_ChartOfAccounts")] public QuickfileResponse<T>? ReportChartOfAccounts { get; set; }
    [JsonPropertyName("Report_ProfitAndLoss")] public QuickfileResponse<T>? ReportProfitAndLoss { get; set; }
    [JsonPropertyName("Report_VatObligations")] public QuickfileResponse<T>? ReportVatObligations { get; set; }
    [JsonPropertyName("Report_Subscriptions")] public QuickfileResponse<T>? ReportSubscriptions { get; set; }

    // System Methods
    [JsonPropertyName("System_CreateNote")] public QuickfileResponse<T>? SystemCreateNote { get; set; }
    [JsonPropertyName("System_SearchEvents")] public QuickfileResponse<T>? SystemSearchEvents { get; set; }
    [JsonPropertyName("System_GetAccountDetails")] public QuickfileResponse<T>? SystemGetAccountDetails { get; set; }
}

public class QuickfileResponse<TBody>
{
    public QuickfileResponseHeader Header { get; set; } = null!;
    public TBody Body { get; set; } = default!;
}

public class QuickfileResponseHeader
{
    public string Message { get; set; } = string.Empty;
    public string MessageType { get; set; } = string.Empty;
}

public class BaseResponseBody
{
    public int ReturnItemCount { get; set; }
}
