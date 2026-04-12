using System.Net.Http.Json;
using System.Text;
using System.Xml.Serialization;
using Quickfile.Net.Models;

namespace Quickfile.Net;

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

    public Task<ClientSearchResponse?> SearchClientAsync(ClientSearchRequest request)
        => PostAsync<ClientSearchRequest, ClientSearchResponse>("Client_Search", request, w => w.ClientSearch);

    public Task<ClientCreateResponse?> CreateClientAsync(ClientCreateRequest request)
        => PostAsync<ClientCreateRequest, ClientCreateResponse>("Client_Create", request, w => w.ClientCreate);

    public Task<ClientGetResponse?> GetClientAsync(ClientGetRequest request)
        => PostAsync<ClientGetRequest, ClientGetResponse>("Client_Get", request, w => w.ClientGet);

    public Task<ClientUpdateResponse?> UpdateClientAsync(ClientUpdateRequest request)
        => PostAsync<ClientUpdateRequest, ClientUpdateResponse>("Client_Update", request, w => w.ClientUpdate);

    public Task<ClientDeleteResponse?> DeleteClientAsync(ClientDeleteRequest request)
        => PostAsync<ClientDeleteRequest, ClientDeleteResponse>("Client_Delete", request, w => w.ClientDelete);

    public Task<ClientInsertContactsResponse?> InsertClientContactsAsync(ClientInsertContactsRequest request)
        => PostAsync<ClientInsertContactsRequest, ClientInsertContactsResponse>("Client_InsertContacts", request, w => w.ClientInsertContacts);

    public Task<InvoiceCreateResponse?> CreateInvoiceAsync(InvoiceCreateRequest request)
        => PostAsync<InvoiceCreateRequest, InvoiceCreateResponse>("Invoice_Create", request, w => w.InvoiceCreate);

    public Task<InvoiceGetResponse?> GetInvoiceAsync(InvoiceGetRequest request)
        => PostAsync<InvoiceGetRequest, InvoiceGetResponse>("Invoice_Get", request, w => w.InvoiceGet);

    public Task<InvoiceGetPdfResponse?> GetInvoicePdfAsync(InvoiceGetRequest request)
        => PostAsync<InvoiceGetRequest, InvoiceGetPdfResponse>("Invoice_GetPDF", request, w => w.InvoiceGetPdf);

    public Task<InvoiceSearchResponse?> SearchInvoiceAsync(InvoiceSearchRequest request)
        => PostAsync<InvoiceSearchRequest, InvoiceSearchResponse>("Invoice_Search", request, w => w.InvoiceSearch);

    public Task<InvoiceDeleteResponse?> DeleteInvoiceAsync(InvoiceDeleteRequest request)
        => PostAsync<InvoiceDeleteRequest, InvoiceDeleteResponse>("Invoice_Delete", request, w => w.InvoiceDelete);

    public Task<InvoiceSendResponse?> SendInvoiceAsync(InvoiceSendRequest request)
        => PostAsync<InvoiceSendRequest, InvoiceSendResponse>("Invoice_Send", request, w => w.InvoiceSend);

    public Task<ClientLoginResponse?> ClientLoginAsync(ClientLoginRequest request)
        => PostAsync<ClientLoginRequest, ClientLoginResponse>("Client_LogIn", request, w => w.ClientLogin);

    public Task<ClientNewDirectDebitCollectionResponse?> NewDirectDebitCollectionAsync(ClientNewDirectDebitCollectionRequest request)
        => PostAsync<ClientNewDirectDebitCollectionRequest, ClientNewDirectDebitCollectionResponse>("Client_NewDirectDebitCollection", request, w => w.ClientNewDirectDebitCollection);

    public Task<BankSearchResponse?> SearchBankAsync(BankSearchRequest request)
        => PostAsync<BankSearchRequest, BankSearchResponse>("Bank_Search", request, w => w.BankSearch);

    public Task<BankGetResponse?> GetBankAsync(BankGetRequest request)
        => PostAsync<BankGetRequest, BankGetResponse>("Bank_Get", request, w => w.BankGet);

    public Task<BankGetAccountsResponse?> GetBankAccountsAsync(BankGetAccountsRequest request)
        => PostAsync<BankGetAccountsRequest, BankGetAccountsResponse>("Bank_GetAccounts", request, w => w.BankGetAccounts);

    public Task<BankCreateAccountResponse?> CreateBankAccountAsync(BankCreateAccountRequest request)
        => PostAsync<BankCreateAccountRequest, BankCreateAccountResponse>("Bank_CreateAccount", request, w => w.BankCreateAccount);

    public Task<BankCreateTransactionResponse?> CreateBankTransactionAsync(BankCreateTransactionRequest request)
        => PostAsync<BankCreateTransactionRequest, BankCreateTransactionResponse>("Bank_CreateTransaction", request, w => w.BankCreateTransaction);

    public Task<BankGetAccountBalancesResponse?> GetBankBalancesAsync(BankGetAccountBalancesRequest request)
        => PostAsync<BankGetAccountBalancesRequest, BankGetAccountBalancesResponse>("Bank_GetAccountBalances", request, w => w.BankGetAccountBalances);

    public Task<EstimateAcceptDeclineResponse?> AcceptDeclineEstimateAsync(EstimateAcceptDeclineRequest request)
        => PostAsync<EstimateAcceptDeclineRequest, EstimateAcceptDeclineResponse>("Estimate_AcceptDecline", request, w => w.EstimateAcceptDecline);

    public Task<EstimateConvertToInvoiceResponse?> ConvertEstimateToInvoiceAsync(EstimateConvertToInvoiceRequest request)
        => PostAsync<EstimateConvertToInvoiceRequest, EstimateConvertToInvoiceResponse>("Estimate_ConvertToInvoice", request, w => w.EstimateConvertToInvoice);

    public Task<PurchaseCreateResponse?> CreatePurchaseAsync(PurchaseCreateRequest request)
        => PostAsync<PurchaseCreateRequest, PurchaseCreateResponse>("Purchase_Create", request, w => w.PurchaseCreate);

    public Task<PurchaseSearchResponse?> SearchPurchaseAsync(PurchaseSearchRequest request)
        => PostAsync<PurchaseSearchRequest, PurchaseSearchResponse>("Purchase_Search", request, w => w.PurchaseSearch);

    public Task<PurchaseGetResponse?> GetPurchaseAsync(PurchaseGetRequest request)
        => PostAsync<PurchaseGetRequest, PurchaseGetResponse>("Purchase_Get", request, w => w.PurchaseGet);

    public Task<PurchaseDeleteResponse?> DeletePurchaseAsync(PurchaseDeleteRequest request)
        => PostAsync<PurchaseDeleteRequest, PurchaseDeleteResponse>("Purchase_Delete", request, w => w.PurchaseDelete);

    public Task<SupplierCreateResponse?> CreateSupplierAsync(SupplierCreateRequest request)
        => PostAsync<SupplierCreateRequest, SupplierCreateResponse>("Supplier_Create", request, w => w.SupplierCreate);

    public Task<SupplierSearchResponse?> SearchSupplierAsync(SupplierSearchRequest request)
        => PostAsync<SupplierSearchRequest, SupplierSearchResponse>("Supplier_Search", request, w => w.SupplierSearch);

    public Task<SupplierGetResponse?> GetSupplierAsync(SupplierGetRequest request)
        => PostAsync<SupplierGetRequest, SupplierGetResponse>("Supplier_Get", request, w => w.SupplierGet);

    public Task<SupplierDeleteResponse?> DeleteSupplierAsync(SupplierDeleteRequest request)
        => PostAsync<SupplierDeleteRequest, SupplierDeleteResponse>("Supplier_Delete", request, w => w.SupplierDelete);

    // Item Methods
    public Task<ItemCreateResponse?> CreateItemAsync(ItemCreateRequest request)
        => PostAsync<ItemCreateRequest, ItemCreateResponse>("Item_Create", request, w => w.ItemCreate);

    public Task<ItemDeleteResponse?> DeleteItemAsync(ItemDeleteRequest request)
        => PostAsync<ItemDeleteRequest, ItemDeleteResponse>("Item_Delete", request, w => w.ItemDelete);

    public Task<ItemGetResponse?> GetItemAsync(ItemGetRequest request)
        => PostAsync<ItemGetRequest, ItemGetResponse>("Item_Get", request, w => w.ItemGet);

    public Task<ItemSearchResponse?> SearchItemAsync(ItemSearchRequest request)
        => PostAsync<ItemSearchRequest, ItemSearchResponse>("Item_Search", request, w => w.ItemSearch);

    // Journal Methods
    public Task<JournalCreateResponse?> CreateJournalAsync(JournalCreateRequest request)
        => PostAsync<JournalCreateRequest, JournalCreateResponse>("Journal_Create", request, w => w.JournalCreate);

    public Task<JournalDeleteResponse?> DeleteJournalAsync(JournalDeleteRequest request)
        => PostAsync<JournalDeleteRequest, JournalDeleteResponse>("Journal_Delete", request, w => w.JournalDelete);

    public Task<JournalGetResponse?> GetJournalAsync(JournalGetRequest request)
        => PostAsync<JournalGetRequest, JournalGetResponse>("Journal_Get", request, w => w.JournalGet);

    public Task<JournalSearchResponse?> SearchJournalAsync(JournalSearchRequest request)
        => PostAsync<JournalSearchRequest, JournalSearchResponse>("Journal_Search", request, w => w.JournalSearch);

    // Project Methods
    public Task<ProjectTagCreateResponse?> CreateProjectTagAsync(ProjectTagCreateRequest request)
        => PostAsync<ProjectTagCreateRequest, ProjectTagCreateResponse>("Project_TagCreate", request, w => w.ProjectTagCreate);

    public Task<ProjectTagDeleteResponse?> DeleteProjectTagAsync(ProjectTagDeleteRequest request)
        => PostAsync<ProjectTagDeleteRequest, ProjectTagDeleteResponse>("Project_TagDelete", request, w => w.ProjectTagDelete);

    public Task<ProjectTagSearchResponse?> SearchProjectTagAsync(ProjectTagSearchRequest request)
        => PostAsync<ProjectTagSearchRequest, ProjectTagSearchResponse>("Project_TagSearch", request, w => w.ProjectTagSearch);

    // Ledger Methods
    public Task<LedgerSearchResponse?> SearchLedgerAsync(LedgerSearchRequest request)
        => PostAsync<LedgerSearchRequest, LedgerSearchResponse>("Ledger_Search", request, w => w.LedgerSearch);

    public Task<LedgerGetNominalLedgersResponse?> GetNominalLedgersAsync(LedgerGetNominalLedgersRequest request)
        => PostAsync<LedgerGetNominalLedgersRequest, LedgerGetNominalLedgersResponse>("Ledger_GetNominalLedgers", request, w => w.LedgerGetNominalLedgers);

    public Task<LedgerGetResponse?> GetLedgerAsync(LedgerGetRequest request)
        => PostAsync<LedgerGetRequest, LedgerGetResponse>("Ledger_Get", request, w => w.LedgerGet);

    // Payment Methods
    public Task<PaymentCreateResponse?> CreatePaymentAsync(PaymentCreateRequest request)
        => PostAsync<PaymentCreateRequest, PaymentCreateResponse>("Payment_Create", request, w => w.PaymentCreate);

    public Task<PaymentDeleteResponse?> DeletePaymentAsync(PaymentDeleteRequest request)
        => PostAsync<PaymentDeleteRequest, PaymentDeleteResponse>("Payment_Delete", request, w => w.PaymentDelete);

    public Task<PaymentGetResponse?> GetPaymentAsync(PaymentGetRequest request)
        => PostAsync<PaymentGetRequest, PaymentGetResponse>("Payment_Get", request, w => w.PaymentGet);

    public Task<PaymentGetPayMethodsResponse?> GetPaymentMethodsAsync(PaymentGetPayMethodsRequest request)
        => PostAsync<PaymentGetPayMethodsRequest, PaymentGetPayMethodsResponse>("Payment_GetPayMethods", request, w => w.PaymentGetPayMethods);

    public Task<PaymentSearchResponse?> SearchPaymentAsync(PaymentSearchRequest request)
        => PostAsync<PaymentSearchRequest, PaymentSearchResponse>("Payment_Search", request, w => w.PaymentSearch);

    public Task<PaymentAllocateResponse?> AllocatePaymentAsync(PaymentAllocateRequest request)
        => PostAsync<PaymentAllocateRequest, PaymentAllocateResponse>("Payment_Allocate", request, w => w.PaymentAllocate);

    // PurchaseOrder Methods
    public Task<PurchaseOrderCreateResponse?> CreatePurchaseOrderAsync(PurchaseOrderCreateRequest request)
        => PostAsync<PurchaseOrderCreateRequest, PurchaseOrderCreateResponse>("PurchaseOrder_Create", request, w => w.PurchaseOrderCreate);

    public Task<PurchaseOrderDeleteResponse?> DeletePurchaseOrderAsync(PurchaseOrderDeleteRequest request)
        => PostAsync<PurchaseOrderDeleteRequest, PurchaseOrderDeleteResponse>("PurchaseOrder_Delete", request, w => w.PurchaseOrderDelete);

    public Task<PurchaseOrderGetResponse?> GetPurchaseOrderAsync(PurchaseOrderGetRequest request)
        => PostAsync<PurchaseOrderGetRequest, PurchaseOrderGetResponse>("PurchaseOrder_Get", request, w => w.PurchaseOrderGet);

    public Task<PurchaseOrderSearchResponse?> SearchPurchaseOrderAsync(PurchaseOrderSearchRequest request)
        => PostAsync<PurchaseOrderSearchRequest, PurchaseOrderSearchResponse>("PurchaseOrder_Search", request, w => w.PurchaseOrderSearch);

    public Task<PurchaseUpdateResponse?> UpdatePurchaseAsync(PurchaseUpdateRequest request)
        => PostAsync<PurchaseUpdateRequest, PurchaseUpdateResponse>("Purchase_Update", request, w => w.PurchaseUpdate);

    public Task<SupplierUpdateResponse?> UpdateSupplierAsync(SupplierUpdateRequest request)
        => PostAsync<SupplierUpdateRequest, SupplierUpdateResponse>("Supplier_Update", request, w => w.SupplierUpdate);

    // Document Methods
    public Task<DocumentUploadResponse?> UploadDocumentAsync(DocumentUploadRequest request)
        => PostAsync<DocumentUploadRequest, DocumentUploadResponse>("Document_Upload", request, w => w.DocumentUpload);

    // Report Methods
    public Task<ReportAgeingResponse?> GetAgeingReportAsync(ReportAgeingRequest request)
        => PostAsync<ReportAgeingRequest, ReportAgeingResponse>("Report_Ageing", request, w => w.ReportAgeing);

    public Task<ReportBalanceSheetResponse?> GetBalanceSheetAsync(ReportBalanceSheetRequest request)
        => PostAsync<ReportBalanceSheetRequest, ReportBalanceSheetResponse>("Report_BalanceSheet", request, w => w.ReportBalanceSheet);

    public Task<ReportChartOfAccountsResponse?> GetChartOfAccountsAsync(ReportChartOfAccountsRequest request)
        => PostAsync<ReportChartOfAccountsRequest, ReportChartOfAccountsResponse>("Report_ChartOfAccounts", request, w => w.ReportChartOfAccounts);

    public Task<ReportProfitAndLossResponse?> GetProfitAndLossAsync(ReportProfitAndLossRequest request)
        => PostAsync<ReportProfitAndLossRequest, ReportProfitAndLossResponse>("Report_ProfitAndLoss", request, w => w.ReportProfitAndLoss);

    public Task<ReportVatObligationsResponse?> GetVatObligationsAsync(ReportVatObligationsRequest request)
        => PostAsync<ReportVatObligationsRequest, ReportVatObligationsResponse>("Report_VatObligations", request, w => w.ReportVatObligations);

    public Task<ReportSubscriptionsResponse?> GetSubscriptionsAsync(ReportSubscriptionsRequest request)
        => PostAsync<ReportSubscriptionsRequest, ReportSubscriptionsResponse>("Report_Subscriptions", request, w => w.ReportSubscriptions);

    // System Methods
    public Task<SystemCreateNoteResponse?> CreateSystemNoteAsync(SystemCreateNoteRequest request)
        => PostAsync<SystemCreateNoteRequest, SystemCreateNoteResponse>("System_CreateNote", request, w => w.SystemCreateNote);

    public Task<SystemSearchEventsResponse?> SearchSystemEventsAsync(SystemSearchEventsRequest request)
        => PostAsync<SystemSearchEventsRequest, SystemSearchEventsResponse>("System_SearchEvents", request, w => w.SystemSearchEvents);

    public Task<SystemGetAccountDetailsResponse?> GetAccountDetailsAsync(SystemGetAccountDetailsRequest request)
        => PostAsync<SystemGetAccountDetailsRequest, SystemGetAccountDetailsResponse>("System_GetAccountDetails", request, w => w.SystemGetAccountDetails);
}
