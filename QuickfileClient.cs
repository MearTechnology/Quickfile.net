using System.Net.Http.Json;
using System.Text;
using System.Xml.Serialization;
using Quickfile.Net.Models;

namespace Quickfile.Net;

/// <summary>
/// A client for interacting with the Quickfile API (v1.2).
/// Supports both JSON and XML formats as configured in <see cref="QuickfileOptions"/>.
/// </summary>
public class QuickfileClient
{
    private readonly HttpClient _httpClient;
    private readonly QuickfileOptions _options;
    private const string JsonBaseUrl = "https://api.quickfile.co.uk/1_2/";
    private const string XmlUrl = "https://api.quickfile.co.uk/xml";

    public QuickfileClient(HttpClient httpClient, QuickfileOptions options)
    {
        _httpClient = httpClient;
        _options = options;
    }

    private async Task<TResponse?> PostAsync<TRequest, TResponse>(string endpoint, TRequest body, Func<QuickfileResponseWrapper<TResponse>, QuickfileResponse<TResponse>?> selector) 
        where TResponse : class
    {
        if (_options.Format == QuickfileFormat.Xml)
        {
            return await PostXmlAsync<TRequest, TResponse>(endpoint, body);
        }

        return await PostJsonAsync<TRequest, TResponse>(endpoint, body, selector);
    }

    private async Task<TResponse?> PostJsonAsync<TRequest, TResponse>(string endpoint, TRequest body, Func<QuickfileResponseWrapper<TResponse>, QuickfileResponse<TResponse>?> selector)
        where TResponse : class
    {
        var payload = QuickfilePayload<TRequest>.Create(_options, body);
        var response = await _httpClient.PostAsJsonAsync($"{JsonBaseUrl}{endpoint}", payload);
        response.EnsureSuccessStatusCode();
        
        var wrapper = await response.Content.ReadFromJsonAsync<QuickfileResponseWrapper<TResponse>>();
        return selector(wrapper!)?.Body;
    }

    private async Task<TResponse?> PostXmlAsync<TRequest, TResponse>(string endpoint, TRequest body)
        where TResponse : class
    {
        var header = QuickfileHeader.Create(_options);
        var payload = new QuickfileXmlPayload<TRequest> { Header = header, Body = body };

        var ns = new XmlSerializerNamespaces();
        string schemaNamespace = $"http://www.quickfile.co.uk/schemas/1_2/{endpoint}";
        ns.Add("", schemaNamespace);

        var root = new XmlRootAttribute(endpoint) { Namespace = schemaNamespace };
        var serializer = new XmlSerializer(typeof(QuickfileXmlPayload<TRequest>), root);

        string xml;
        using (var sw = new Utf8StringWriter())
        {
            serializer.Serialize(sw, payload, ns);
            xml = sw.ToString();
        }

        var content = new StringContent(xml, Encoding.UTF8, "text/xml");
        var response = await _httpClient.PostAsync(XmlUrl, content);
        response.EnsureSuccessStatusCode();

        string responseXml = await response.Content.ReadAsStringAsync();
        var responseSerializer = new XmlSerializer(typeof(QuickfileXmlPayload<TResponse>), root);
        using (var sr = new StringReader(responseXml))
        {
            var result = (QuickfileXmlPayload<TResponse>?)responseSerializer.Deserialize(sr);
            return result?.Body;
        }
    }

    /// <summary>
    /// Searches for clients based on specific parameters such as company name or account reference.
    /// </summary>
    public Task<ClientSearchResponse?> SearchClientAsync(ClientSearchRequest request)
        => PostAsync<ClientSearchRequest, ClientSearchResponse>("Client_Search", request, w => w.ClientSearch);

    /// <summary>
    /// Creates a new client record.
    /// </summary>
    public Task<ClientCreateResponse?> CreateClientAsync(ClientCreateRequest request)
        => PostAsync<ClientCreateRequest, ClientCreateResponse>("Client_Create", request, w => w.ClientCreate);

    /// <summary>
    /// Retrieves full details for a specific client and their contacts.
    /// </summary>
    public Task<ClientGetResponse?> GetClientAsync(ClientGetRequest request)
        => PostAsync<ClientGetRequest, ClientGetResponse>("Client_Get", request, w => w.ClientGet);

    /// <summary>
    /// Updates an existing client record.
    /// </summary>
    public Task<ClientUpdateResponse?> UpdateClientAsync(ClientUpdateRequest request)
        => PostAsync<ClientUpdateRequest, ClientUpdateResponse>("Client_Update", request, w => w.ClientUpdate);

    /// <summary>
    /// Deletes a client record.
    /// </summary>
    public Task<ClientDeleteResponse?> DeleteClientAsync(ClientDeleteRequest request)
        => PostAsync<ClientDeleteRequest, ClientDeleteResponse>("Client_Delete", request, w => w.ClientDelete);

    /// <summary>
    /// Adds a new contact to an existing client.
    /// </summary>
    public Task<ClientInsertContactsResponse?> InsertClientContactsAsync(ClientInsertContactsRequest request)
        => PostAsync<ClientInsertContactsRequest, ClientInsertContactsResponse>("Client_InsertContacts", request, w => w.ClientInsertContacts);

    /// <summary>
    /// Creates a new sales invoice or estimate.
    /// </summary>
    public Task<InvoiceCreateResponse?> CreateInvoiceAsync(InvoiceCreateRequest request)
        => PostAsync<InvoiceCreateRequest, InvoiceCreateResponse>("Invoice_Create", request, w => w.InvoiceCreate);

    /// <summary>
    /// Retrieves full details for a single invoice or estimate.
    /// </summary>
    public Task<InvoiceGetResponse?> GetInvoiceAsync(InvoiceGetRequest request)
        => PostAsync<InvoiceGetRequest, InvoiceGetResponse>("Invoice_Get", request, w => w.InvoiceGet);

    /// <summary>
    /// Retrieves a temporary URL to download the PDF version of an invoice.
    /// </summary>
    public Task<InvoiceGetPdfResponse?> GetInvoicePdfAsync(InvoiceGetRequest request)
        => PostAsync<InvoiceGetRequest, InvoiceGetPdfResponse>("Invoice_GetPDF", request, w => w.InvoiceGetPdf);

    /// <summary>
    /// Searches for invoices and estimates based on filters like date, status, or client.
    /// </summary>
    public Task<InvoiceSearchResponse?> SearchInvoiceAsync(InvoiceSearchRequest request)
        => PostAsync<InvoiceSearchRequest, InvoiceSearchResponse>("Invoice_Search", request, w => w.InvoiceSearch);

    /// <summary>
    /// Deletes an invoice, estimate, or recurring profile.
    /// </summary>
    public Task<InvoiceDeleteResponse?> DeleteInvoiceAsync(InvoiceDeleteRequest request)
        => PostAsync<InvoiceDeleteRequest, InvoiceDeleteResponse>("Invoice_Delete", request, w => w.InvoiceDelete);

    /// <summary>
    /// Sends an invoice or estimate via email.
    /// </summary>
    public Task<InvoiceSendResponse?> SendInvoiceAsync(InvoiceSendRequest request)
        => PostAsync<InvoiceSendRequest, InvoiceSendResponse>("Invoice_Send", request, w => w.InvoiceSend);

    /// <summary>
    /// Generates a passwordless login URL for the client control panel.
    /// </summary>
    public Task<ClientLoginResponse?> ClientLoginAsync(ClientLoginRequest request)
        => PostAsync<ClientLoginRequest, ClientLoginResponse>("Client_LogIn", request, w => w.ClientLogin);

    /// <summary>
    /// Initiates a new Direct Debit collection request for a client.
    /// </summary>
    public Task<ClientNewDirectDebitCollectionResponse?> NewDirectDebitCollectionAsync(ClientNewDirectDebitCollectionRequest request)
        => PostAsync<ClientNewDirectDebitCollectionRequest, ClientNewDirectDebitCollectionResponse>("Client_NewDirectDebitCollection", request, w => w.ClientNewDirectDebitCollection);

    /// <summary>
    /// Queries bank Transactions by date range, nominal code, reference, or amount.
    /// </summary>
    public Task<BankSearchResponse?> SearchBankAsync(BankSearchRequest request)
        => PostAsync<BankSearchRequest, BankSearchResponse>("Bank_Search", request, w => w.BankSearch);

    /// <summary>
    /// Retrieves detailed information for a specific bank account.
    /// </summary>
    public Task<BankGetResponse?> GetBankAsync(BankGetRequest request)
        => PostAsync<BankGetRequest, BankGetResponse>("Bank_Get", request, w => w.BankGet);

    /// <summary>
    /// Returns a list of all bank accounts grouped by type.
    /// </summary>
    public Task<BankGetAccountsResponse?> GetBankAccountsAsync(BankGetAccountsRequest request)
        => PostAsync<BankGetAccountsRequest, BankGetAccountsResponse>("Bank_GetAccounts", request, w => w.BankGetAccounts);

    /// <summary>
    /// Creates a new bank account in the system.
    /// </summary>
    public Task<BankCreateAccountResponse?> CreateBankAccountAsync(BankCreateAccountRequest request)
        => PostAsync<BankCreateAccountRequest, BankCreateAccountResponse>("Bank_CreateAccount", request, w => w.BankCreateAccount);

    /// <summary>
    /// Creates untagged bank Transactions (statement lines).
    /// </summary>
    public Task<BankCreateTransactionResponse?> CreateBankTransactionAsync(BankCreateTransactionRequest request)
        => PostAsync<BankCreateTransactionRequest, BankCreateTransactionResponse>("Bank_CreateTransaction", request, w => w.BankCreateTransaction);

    /// <summary>
    /// Returns current balances for a specific set of bank account IDs.
    /// </summary>
    public Task<BankGetAccountBalancesResponse?> GetBankBalancesAsync(BankGetAccountBalancesRequest request)
        => PostAsync<BankGetAccountBalancesRequest, BankGetAccountBalancesResponse>("Bank_GetAccountBalances", request, w => w.BankGetAccountBalances);

    /// <summary>
    /// Updates the status of an estimate (Accept or Decline).
    /// </summary>
    public Task<EstimateAcceptDeclineResponse?> AcceptDeclineEstimateAsync(EstimateAcceptDeclineRequest request)
        => PostAsync<EstimateAcceptDeclineRequest, EstimateAcceptDeclineResponse>("Estimate_AcceptDecline", request, w => w.EstimateAcceptDecline);

    /// <summary>
    /// Converts an existing estimate into a live sales invoice.
    /// </summary>
    public Task<EstimateConvertToInvoiceResponse?> ConvertEstimateToInvoiceAsync(EstimateConvertToInvoiceRequest request)
        => PostAsync<EstimateConvertToInvoiceRequest, EstimateConvertToInvoiceResponse>("Estimate_ConvertToInvoice", request, w => w.EstimateConvertToInvoice);

    /// <summary>
    /// Creates a new purchase invoice or receipt.
    /// </summary>
    public Task<PurchaseCreateResponse?> CreatePurchaseAsync(PurchaseCreateRequest request)
        => PostAsync<PurchaseCreateRequest, PurchaseCreateResponse>("Purchase_Create", request, w => w.PurchaseCreate);

    /// <summary>
    /// Searches for purchase records based on specific parameters.
    /// </summary>
    public Task<PurchaseSearchResponse?> SearchPurchaseAsync(PurchaseSearchRequest request)
        => PostAsync<PurchaseSearchRequest, PurchaseSearchResponse>("Purchase_Search", request, w => w.PurchaseSearch);

    /// <summary>
    /// Retrieves full details for a specific purchase.
    /// </summary>
    public Task<PurchaseGetResponse?> GetPurchaseAsync(PurchaseGetRequest request)
        => PostAsync<PurchaseGetRequest, PurchaseGetResponse>("Purchase_Get", request, w => w.PurchaseGet);

    /// <summary>
    /// Deletes a purchase record.
    /// </summary>
    public Task<PurchaseDeleteResponse?> DeletePurchaseAsync(PurchaseDeleteRequest request)
        => PostAsync<PurchaseDeleteRequest, PurchaseDeleteResponse>("Purchase_Delete", request, w => w.PurchaseDelete);

    /// <summary>
    /// Creates a new supplier record.
    /// </summary>
    public Task<SupplierCreateResponse?> CreateSupplierAsync(SupplierCreateRequest request)
        => PostAsync<SupplierCreateRequest, SupplierCreateResponse>("Supplier_Create", request, w => w.SupplierCreate);

    /// <summary>
    /// Searches for suppliers based on specific parameters.
    /// </summary>
    public Task<SupplierSearchResponse?> SearchSupplierAsync(SupplierSearchRequest request)
        => PostAsync<SupplierSearchRequest, SupplierSearchResponse>("Supplier_Search", request, w => w.SupplierSearch);

    /// <summary>
    /// Retrieves full details for a specific supplier.
    /// </summary>
    public Task<SupplierGetResponse?> GetSupplierAsync(SupplierGetRequest request)
        => PostAsync<SupplierGetRequest, SupplierGetResponse>("Supplier_Get", request, w => w.SupplierGet);

    /// <summary>
    /// Deletes a supplier record.
    /// </summary>
    public Task<SupplierDeleteResponse?> DeleteSupplierAsync(SupplierDeleteRequest request)
        => PostAsync<SupplierDeleteRequest, SupplierDeleteResponse>("Supplier_Delete", request, w => w.SupplierDelete);

    /// <summary>
    /// Creates a new inventory item or task.
    /// </summary>
    public Task<ItemCreateResponse?> CreateItemAsync(ItemCreateRequest request)
        => PostAsync<ItemCreateRequest, ItemCreateResponse>("Item_Create", request, w => w.ItemCreate);

    /// <summary>
    /// Deletes an inventory item or task.
    /// </summary>
    public Task<ItemDeleteResponse?> DeleteItemAsync(ItemDeleteRequest request)
        => PostAsync<ItemDeleteRequest, ItemDeleteResponse>("Item_Delete", request, w => w.ItemDelete);

    /// <summary>
    /// Retrieves details for a specific inventory item or task.
    /// </summary>
    public Task<ItemGetResponse?> GetItemAsync(ItemGetRequest request)
        => PostAsync<ItemGetRequest, ItemGetResponse>("Item_Get", request, w => w.ItemGet);

    /// <summary>
    /// Searches for inventory items or tasks based on search parameters.
    /// </summary>
    public Task<ItemSearchResponse?> SearchItemAsync(ItemSearchRequest request)
        => PostAsync<ItemSearchRequest, ItemSearchResponse>("Item_Search", request, w => w.ItemSearch);

    /// <summary>
    /// Creates a new manual journal entry.
    /// </summary>
    public Task<JournalCreateResponse?> CreateJournalAsync(JournalCreateRequest request)
        => PostAsync<JournalCreateRequest, JournalCreateResponse>("Journal_Create", request, w => w.JournalCreate);

    /// <summary>
    /// Deletes an existing manual journal entry.
    /// </summary>
    public Task<JournalDeleteResponse?> DeleteJournalAsync(JournalDeleteRequest request)
        => PostAsync<JournalDeleteRequest, JournalDeleteResponse>("Journal_Delete", request, w => w.JournalDelete);

    /// <summary>
    /// Retrieves full details for a specific journal entry.
    /// </summary>
    public Task<JournalGetResponse?> GetJournalAsync(JournalGetRequest request)
        => PostAsync<JournalGetRequest, JournalGetResponse>("Journal_Get", request, w => w.JournalGet);

    /// <summary>
    /// Searches for manual journals based on specific parameters.
    /// </summary>
    public Task<JournalSearchResponse?> SearchJournalAsync(JournalSearchRequest request)
        => PostAsync<JournalSearchRequest, JournalSearchResponse>("Journal_Search", request, w => w.JournalSearch);

    /// <summary>
    /// Creates and attaches a project tag to a sales/purchase invoice, estimate, or purchase order.
    /// </summary>
    public Task<ProjectTagCreateResponse?> CreateProjectTagAsync(ProjectTagCreateRequest request)
        => PostAsync<ProjectTagCreateRequest, ProjectTagCreateResponse>("Project_TagCreate", request, w => w.ProjectTagCreate);

    /// <summary>
    /// Deletes a project tag from an associated record.
    /// </summary>
    public Task<ProjectTagDeleteResponse?> DeleteProjectTagAsync(ProjectTagDeleteRequest request)
        => PostAsync<ProjectTagDeleteRequest, ProjectTagDeleteResponse>("Project_TagDelete", request, w => w.ProjectTagDelete);

    /// <summary>
    /// Searches for project tags based on a search query.
    /// </summary>
    public Task<ProjectTagSearchResponse?> SearchProjectTagAsync(ProjectTagSearchRequest request)
        => PostAsync<ProjectTagSearchRequest, ProjectTagSearchResponse>("Project_TagSearch", request, w => w.ProjectTagSearch);

    /// <summary>
    /// Queries the nominal ledger based on date or amount range.
    /// </summary>
    public Task<LedgerSearchResponse?> SearchLedgerAsync(LedgerSearchRequest request)
        => PostAsync<LedgerSearchRequest, LedgerSearchResponse>("Ledger_Search", request, w => w.LedgerSearch);

    /// <summary>
    /// Returns information on a specified range of nominal ledgers.
    /// </summary>
    public Task<LedgerGetNominalLedgersResponse?> GetNominalLedgersAsync(LedgerGetNominalLedgersRequest request)
        => PostAsync<LedgerGetNominalLedgersRequest, LedgerGetNominalLedgersResponse>("Ledger_GetNominalLedgers", request, w => w.LedgerGetNominalLedgers);

    /// <summary>
    /// Retrieves activity and Transactions for a specific nominal code.
    /// </summary>
    public Task<LedgerGetResponse?> GetLedgerAsync(LedgerGetRequest request)
        => PostAsync<LedgerGetRequest, LedgerGetResponse>("Ledger_Get", request, w => w.LedgerGet);

    /// <summary>
    /// Creates a new payment record and allocates it to an invoice or purchase.
    /// </summary>
    public Task<PaymentCreateResponse?> CreatePaymentAsync(PaymentCreateRequest request)
        => PostAsync<PaymentCreateRequest, PaymentCreateResponse>("Payment_Create", request, w => w.PaymentCreate);

    /// <summary>
    /// Deletes a payment record.
    /// </summary>
    public Task<PaymentDeleteResponse?> DeletePaymentAsync(PaymentDeleteRequest request)
        => PostAsync<PaymentDeleteRequest, PaymentDeleteResponse>("Payment_Delete", request, w => w.PaymentDelete);

    /// <summary>
    /// Retrieves full details for a specific payment record.
    /// </summary>
    public Task<PaymentGetResponse?> GetPaymentAsync(PaymentGetRequest request)
        => PostAsync<PaymentGetRequest, PaymentGetResponse>("Payment_Get", request, w => w.PaymentGet);

    /// <summary>
    /// Returns the collection of available payment method codes.
    /// </summary>
    public Task<PaymentGetPayMethodsResponse?> GetPaymentMethodsAsync(PaymentGetPayMethodsRequest request)
        => PostAsync<PaymentGetPayMethodsRequest, PaymentGetPayMethodsResponse>("Payment_GetPayMethods", request, w => w.PaymentGetPayMethods);

    /// <summary>
    /// Searches for payments based on specific parameters.
    /// </summary>
    public Task<PaymentSearchResponse?> SearchPaymentAsync(PaymentSearchRequest request)
        => PostAsync<PaymentSearchRequest, PaymentSearchResponse>("Payment_Search", request, w => w.PaymentSearch);

    /// <summary>
    /// Allocates an unassigned payment to a specific invoice or purchase.
    /// </summary>
    public Task<PaymentAllocateResponse?> AllocatePaymentAsync(PaymentAllocateRequest request)
        => PostAsync<PaymentAllocateRequest, PaymentAllocateResponse>("Payment_Allocate", request, w => w.PaymentAllocate);

    /// <summary>
    /// Creates a new purchase order.
    /// </summary>
    public Task<PurchaseOrderCreateResponse?> CreatePurchaseOrderAsync(PurchaseOrderCreateRequest request)
        => PostAsync<PurchaseOrderCreateRequest, PurchaseOrderCreateResponse>("PurchaseOrder_Create", request, w => w.PurchaseOrderCreate);

    /// <summary>
    /// Deletes an existing purchase order.
    /// </summary>
    public Task<PurchaseOrderDeleteResponse?> DeletePurchaseOrderAsync(PurchaseOrderDeleteRequest request)
        => PostAsync<PurchaseOrderDeleteRequest, PurchaseOrderDeleteResponse>("PurchaseOrder_Delete", request, w => w.PurchaseOrderDelete);

    /// <summary>
    /// Retrieves full details for a specific purchase order.
    /// </summary>
    public Task<PurchaseOrderGetResponse?> GetPurchaseOrderAsync(PurchaseOrderGetRequest request)
        => PostAsync<PurchaseOrderGetRequest, PurchaseOrderGetResponse>("PurchaseOrder_Get", request, w => w.PurchaseOrderGet);

    /// <summary>
    /// Searches for purchase orders based on specific parameters.
    /// </summary>
    public Task<PurchaseOrderSearchResponse?> SearchPurchaseOrderAsync(PurchaseOrderSearchRequest request)
        => PostAsync<PurchaseOrderSearchRequest, PurchaseOrderSearchResponse>("PurchaseOrder_Search", request, w => w.PurchaseOrderSearch);

    /// <summary>
    /// Updates an existing purchase invoice or receipt.
    /// </summary>
    public Task<PurchaseUpdateResponse?> UpdatePurchaseAsync(PurchaseUpdateRequest request)
        => PostAsync<PurchaseUpdateRequest, PurchaseUpdateResponse>("Purchase_Update", request, w => w.PurchaseUpdate);

    /// <summary>
    /// Updates an existing supplier record.
    /// </summary>
    public Task<SupplierUpdateResponse?> UpdateSupplierAsync(SupplierUpdateRequest request)
        => PostAsync<SupplierUpdateRequest, SupplierUpdateResponse>("Supplier_Update", request, w => w.SupplierUpdate);

    /// <summary>
    /// Uploads a document to the Document Management area or Receipt Hub.
    /// </summary>
    public Task<DocumentUploadResponse?> UploadDocumentAsync(DocumentUploadRequest request)
        => PostAsync<DocumentUploadRequest, DocumentUploadResponse>("Document_Upload", request, w => w.DocumentUpload);

    /// <summary>
    /// Retrieves a creditor or debtor ageing report.
    /// </summary>
    public Task<ReportAgeingResponse?> GetAgeingReportAsync(ReportAgeingRequest request)
        => PostAsync<ReportAgeingRequest, ReportAgeingResponse>("Report_Ageing", request, w => w.ReportAgeing);

    /// <summary>
    /// Retrieves a balance sheet report for a specific date.
    /// </summary>
    public Task<ReportBalanceSheetResponse?> GetBalanceSheetAsync(ReportBalanceSheetRequest request)
        => PostAsync<ReportBalanceSheetRequest, ReportBalanceSheetResponse>("Report_BalanceSheet", request, w => w.ReportBalanceSheet);

    /// <summary>
    /// Retrieves the full Chart of Accounts for the account.
    /// </summary>
    public Task<ReportChartOfAccountsResponse?> GetChartOfAccountsAsync(ReportChartOfAccountsRequest request)
        => PostAsync<ReportChartOfAccountsRequest, ReportChartOfAccountsResponse>("Report_ChartOfAccounts", request, w => w.ReportChartOfAccounts);

    /// <summary>
    /// Retrieves a Profit and Loss report for a specified date range.
    /// </summary>
    public Task<ReportProfitAndLossResponse?> GetProfitAndLossAsync(ReportProfitAndLossRequest request)
        => PostAsync<ReportProfitAndLossRequest, ReportProfitAndLossResponse>("Report_ProfitAndLoss", request, w => w.ReportProfitAndLoss);

    /// <summary>
    /// Retrieves a list of filed and open VAT returns.
    /// </summary>
    public Task<ReportVatObligationsResponse?> GetVatObligationsAsync(ReportVatObligationsRequest request)
        => PostAsync<ReportVatObligationsRequest, ReportVatObligationsResponse>("Report_VatObligations", request, w => w.ReportVatObligations);

    /// <summary>
    /// Retrieves a list of active subscriptions for the account.
    /// </summary>
    public Task<ReportSubscriptionsResponse?> GetSubscriptionsAsync(ReportSubscriptionsRequest request)
        => PostAsync<ReportSubscriptionsRequest, ReportSubscriptionsResponse>("Report_Subscriptions", request, w => w.ReportSubscriptions);

    /// <summary>
    /// Creates a note for an invoice, purchase, client, or supplier.
    /// </summary>
    public Task<SystemCreateNoteResponse?> CreateSystemNoteAsync(SystemCreateNoteRequest request)
        => PostAsync<SystemCreateNoteRequest, SystemCreateNoteResponse>("System_CreateNote", request, w => w.SystemCreateNote);

    /// <summary>
    /// Queries the system event log.
    /// </summary>
    public Task<SystemSearchEventsResponse?> SearchSystemEventsAsync(SystemSearchEventsRequest request)
        => PostAsync<SystemSearchEventsRequest, SystemSearchEventsResponse>("System_SearchEvents", request, w => w.SystemSearchEvents);

    /// <summary>
    /// Returns meta-details for the authorized account (e.g., account type, currency).
    /// </summary>
    public Task<SystemGetAccountDetailsResponse?> GetAccountDetailsAsync(SystemGetAccountDetailsRequest request)
        => PostAsync<SystemGetAccountDetailsRequest, SystemGetAccountDetailsResponse>("System_GetAccountDetails", request, w => w.SystemGetAccountDetails);
}
