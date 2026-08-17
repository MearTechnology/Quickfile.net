using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Quickfile.Net.Models.Rest;

namespace Quickfile.Net;

public partial class QuickfileClient
{
    private static readonly JsonSerializerOptions RestJsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    private HttpRequestMessage CreateRestRequest(HttpMethod method, string path, Dictionary<string, string?>? queryParams = null)
    {
        var baseUrl = (_options.RestBaseUrl ?? "https://api-beta.quickfile.co.uk").TrimEnd('/');
        var trimmedPath = path.TrimStart('/');
        var url = $"{baseUrl}/{trimmedPath}";

        if (queryParams != null && queryParams.Count > 0)
        {
            var nonNullParams = queryParams
                .Where(kvp => !string.IsNullOrEmpty(kvp.Value))
                .Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value!)}")
                .ToList();

            if (nonNullParams.Count > 0)
            {
                url += "?" + string.Join("&", nonNullParams);
            }
        }

        var request = new HttpRequestMessage(method, url);
        var token = !string.IsNullOrWhiteSpace(_options.BearerToken) ? _options.BearerToken : _options.ApiKey;
        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        return request;
    }

    private async Task<TResponse?> SendRestAsync<TResponse>(HttpMethod method, string path, object? body = null, Dictionary<string, string?>? queryParams = null, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        using var request = CreateRestRequest(method, path, queryParams);
        if (body != null)
        {
            var json = JsonSerializer.Serialize(body, body.GetType(), RestJsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errContent = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new QuickfileRestException(response.StatusCode, $"Quickfile REST API error ({response.StatusCode}): {errContent}", errContent);
        }

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return null;
        }

        return await response.Content.ReadFromJsonAsync<TResponse>(RestJsonOptions, cancellationToken);
    }

    private async Task SendRestNoContentAsync(HttpMethod method, string path, object? body = null, Dictionary<string, string?>? queryParams = null, CancellationToken cancellationToken = default)
    {
        using var request = CreateRestRequest(method, path, queryParams);
        if (body != null)
        {
            var json = JsonSerializer.Serialize(body, body.GetType(), RestJsonOptions);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        var response = await _httpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errContent = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new QuickfileRestException(response.StatusCode, $"Quickfile REST API error ({response.StatusCode}): {errContent}", errContent);
        }
    }

    private async Task<TResponse?> SendRestMultipartAsync<TResponse>(string path, MultipartFormDataContent formContent, CancellationToken cancellationToken = default)
        where TResponse : class
    {
        using var request = CreateRestRequest(HttpMethod.Post, path);
        request.Content = formContent;

        var response = await _httpClient.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            var errContent = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new QuickfileRestException(response.StatusCode, $"Quickfile REST API error ({response.StatusCode}): {errContent}", errContent);
        }

        return await response.Content.ReadFromJsonAsync<TResponse>(RestJsonOptions, cancellationToken);
    }

    #region Account

    /// <summary>
    /// Get the business details for the connected user, e.g. business name, type, address, year end date, vat status and account size statistics.
    /// </summary>
    public Task<AccountDto?> RestGetAccountMeAsync(CancellationToken cancellationToken = default)
        => SendRestAsync<AccountDto>(HttpMethod.Get, "/account/me", cancellationToken: cancellationToken);

    #endregion

    #region Bank

    /// <summary>
    /// Query bank account transactions by date range, nominal code, reference or amount.
    /// </summary>
    public Task<RestPagedResponse<BanksTransactionDetailedResponse>?> RestGetBankTransactionsAsync(long accountId, RestBankTransactionSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<BanksTransactionDetailedResponse>>(HttpMethod.Get, $"/bank_accounts/{accountId}/transactions", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create untagged bank transactions.
    /// </summary>
    public Task<BanksTransactionResponse?> RestCreateBankTransactionsAsync(long accountId, BanksCreateTransactionRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<BanksTransactionResponse>(HttpMethod.Post, $"/bank_accounts/{accountId}/transactions", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Returns a list of bank accounts with optional nominal code and type filtering.
    /// </summary>
    public Task<RestArrayResponse<BanksAccountsDetailResponse>?> RestGetBankAccountsAsync(RestBankAccountSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestArrayResponse<BanksAccountsDetailResponse>>(HttpMethod.Get, "/bank_accounts", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new bank account.
    /// </summary>
    public Task<BanksAccountsResponse?> RestCreateBankAccountAsync(BanksAccountsCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<BanksAccountsResponse>(HttpMethod.Post, "/bank_accounts", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Returns a bank balance for a specific bank account.
    /// </summary>
    public Task<BanksAccountsBalancesResponse?> RestGetBankBalanceAsync(long accountId, CancellationToken cancellationToken = default)
        => SendRestAsync<BanksAccountsBalancesResponse>(HttpMethod.Get, $"/bank_accounts/{accountId}/balance", cancellationToken: cancellationToken);

    /// <summary>
    /// Returns a list of supported banks.
    /// </summary>
    public Task<RestArrayResponse<BanksIdsResponse>?> RestGetSupportedBanksAsync(CancellationToken cancellationToken = default)
        => SendRestAsync<RestArrayResponse<BanksIdsResponse>>(HttpMethod.Get, "/banks", cancellationToken: cancellationToken);

    #endregion

    #region Clients

    /// <summary>
    /// Retrieve client trading styles.
    /// </summary>
    public Task<RestArrayResponse<ClientTradingStylesResponse>?> RestGetClientTradingStylesAsync(CancellationToken cancellationToken = default)
        => SendRestAsync<RestArrayResponse<ClientTradingStylesResponse>>(HttpMethod.Get, "/clients/styles", cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve client records based on a set of search parameters.
    /// </summary>
    public Task<RestPagedResponse<ClientSearchModel>?> RestSearchClientsAsync(RestClientSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<ClientSearchModel>>(HttpMethod.Get, "/clients", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new client record.
    /// </summary>
    public Task<ClientBaseModel?> RestCreateClientAsync(ClientCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<ClientBaseModel>(HttpMethod.Post, "/clients", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve client and contact data.
    /// </summary>
    public Task<ClientModel?> RestGetClientAsync(long id, RestClientGetParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<ClientModel>(HttpMethod.Get, $"/clients/{id}", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Update an existing client record.
    /// </summary>
    public Task<ClientBaseModel?> RestUpdateClientAsync(long id, ClientUpdateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<ClientBaseModel>(HttpMethod.Put, $"/clients/{id}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a client record.
    /// </summary>
    public Task RestDeleteClientAsync(long id, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/clients/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve client contact data.
    /// </summary>
    public Task<List<ClientContactExModel>?> RestGetClientContactsAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<List<ClientContactExModel>>(HttpMethod.Get, $"/clients/{id}/contacts", cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new client contact record.
    /// </summary>
    public Task<ClientContactExModel?> RestCreateClientContactAsync(long id, ClientContactCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<ClientContactExModel>(HttpMethod.Post, $"/clients/{id}/contacts", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Update an existing client contact record.
    /// </summary>
    public Task<ClientContactExModel?> RestUpdateClientContactAsync(long id, long contactId, ClientContactUpdateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<ClientContactExModel>(HttpMethod.Put, $"/clients/{id}/contacts/{contactId}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a client contact record.
    /// </summary>
    public Task RestDeleteClientContactAsync(long id, long contactId, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/clients/{id}/contacts/{contactId}", cancellationToken: cancellationToken);

    /// <summary>
    /// Generate a secure tokenised login URL for a client.
    /// </summary>
    public Task<ClientLoginResponse?> RestCreateClientLoginUrlAsync(long id, ClientLoginRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<ClientLoginResponse>(HttpMethod.Post, $"/clients/{id}/login", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Initiate a new Direct Debit collection request.
    /// </summary>
    public Task<ClientNewDDResponse?> RestCreateClientDirectDebitAsync(long id, ClientNewDDRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<ClientNewDDResponse>(HttpMethod.Post, $"/clients/{id}/new-direct-debit", body: request, cancellationToken: cancellationToken);

    #endregion

    #region Client Payments

    /// <summary>
    /// Search for a client payment based on specific search parameters.
    /// </summary>
    public Task<RestPagedResponse<PaymentsClientSearchResponse>?> RestSearchClientPaymentsAsync(RestClientPaymentSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<PaymentsClientSearchResponse>>(HttpMethod.Get, "/client_payments", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new client payment record.
    /// </summary>
    public Task<PaymentsClientPostResponse?> RestCreateClientPaymentAsync(PaymentsClientPostRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<PaymentsClientPostResponse>(HttpMethod.Post, "/client_payments", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve a client payment record.
    /// </summary>
    public Task<PaymentsClientGetResponse?> RestGetClientPaymentAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<PaymentsClientGetResponse>(HttpMethod.Get, $"/client_payments/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a client payment record.
    /// </summary>
    public Task RestDeleteClientPaymentAsync(long id, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/client_payments/{id}", cancellationToken: cancellationToken);

    #endregion

    #region Documents

    /// <summary>
    /// Upload a receipt to the Receipt Hub.
    /// </summary>
    public async Task<DocumentUploadResponse?> RestUploadReceiptAsync(Stream fileStream, string fileName, string captureDate, long? purchaseId = null, string? receiptName = null, CancellationToken cancellationToken = default)
    {
        using var form = new MultipartFormDataContent();
        var fileContent = new StreamContent(fileStream);
        form.Add(fileContent, "file", fileName);
        form.Add(new StringContent(captureDate), "capture_date");

        if (purchaseId.HasValue)
        {
            form.Add(new StringContent(purchaseId.Value.ToString()), "purchase_id");
        }
        if (!string.IsNullOrEmpty(receiptName))
        {
            form.Add(new StringContent(receiptName), "receipt_name");
        }

        return await SendRestMultipartAsync<DocumentUploadResponse>("/documents/receipt", form, cancellationToken);
    }

    /// <summary>
    /// Upload a file attachment to a sales invoice.
    /// </summary>
    public async Task<DocumentUploadResponse?> RestUploadSalesDocumentAsync(Stream fileStream, string fileName, long invoiceId, string? notes = null, CancellationToken cancellationToken = default)
    {
        using var form = new MultipartFormDataContent();
        var fileContent = new StreamContent(fileStream);
        form.Add(fileContent, "file", fileName);
        form.Add(new StringContent(invoiceId.ToString()), "invoice_id");

        if (!string.IsNullOrEmpty(notes))
        {
            form.Add(new StringContent(notes), "notes");
        }

        return await SendRestMultipartAsync<DocumentUploadResponse>("/documents/sales", form, cancellationToken);
    }

    /// <summary>
    /// Upload a document to the Document Management area.
    /// </summary>
    public async Task<DocumentUploadResponse?> RestUploadGeneralDocumentAsync(Stream fileStream, string fileName, string? collectionName = null, CancellationToken cancellationToken = default)
    {
        using var form = new MultipartFormDataContent();
        var fileContent = new StreamContent(fileStream);
        form.Add(fileContent, "file", fileName);

        if (!string.IsNullOrEmpty(collectionName))
        {
            form.Add(new StringContent(collectionName), "collection_name");
        }

        return await SendRestMultipartAsync<DocumentUploadResponse>("/documents/general", form, cancellationToken);
    }

    #endregion

    #region Inventory

    /// <summary>
    /// Search for an inventory item.
    /// </summary>
    public Task<RestPagedResponse<InventoryItemModel>?> RestSearchInventoryAsync(RestInventorySearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<InventoryItemModel>>(HttpMethod.Get, "/inventory", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new inventory item.
    /// </summary>
    public Task<InventoryItemModel?> RestCreateInventoryItemAsync(InventoryCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<InventoryItemModel>(HttpMethod.Post, "/inventory", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Get an inventory item by ID.
    /// </summary>
    public Task<InventoryItemModel?> RestGetInventoryItemAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<InventoryItemModel>(HttpMethod.Get, $"/inventory/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Delete an existing inventory item.
    /// </summary>
    public Task RestDeleteInventoryItemAsync(long id, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/inventory/{id}", cancellationToken: cancellationToken);

    #endregion

    #region Invoices

    /// <summary>
    /// Search for invoices and estimates using a specific set of search parameters.
    /// </summary>
    public Task<RestPagedResponse<InvoiceModel>?> RestSearchInvoicesAsync(RestInvoiceSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<InvoiceModel>>(HttpMethod.Get, "/invoices", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new invoice, estimate or recurring invoice template.
    /// </summary>
    public Task<InvoiceSingleModel?> RestCreateInvoiceAsync(InvoicesCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<InvoiceSingleModel>(HttpMethod.Post, "/invoices", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve a single invoice, estimate or recurring invoice template.
    /// </summary>
    public Task<InvoiceSingleModel?> RestGetInvoiceAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<InvoiceSingleModel>(HttpMethod.Get, $"/invoices/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Update an existing invoice, estimate or recurring invoice template.
    /// </summary>
    public Task<InvoiceSingleModel?> RestUpdateInvoiceAsync(long id, InvoicesUpdateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<InvoiceSingleModel>(HttpMethod.Put, $"/invoices/{id}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete an invoice, estimate or recurring invoice template.
    /// </summary>
    public Task RestDeleteInvoiceAsync(long id, InvoiceDeleteRequest request, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/invoices/{id}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve a URL for an invoice or estimate PDF document.
    /// </summary>
    public Task<InvoiceGetPdfResponse?> RestGetInvoicePdfAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<InvoiceGetPdfResponse>(HttpMethod.Get, $"/invoices/{id}/get-pdf", cancellationToken: cancellationToken);

    /// <summary>
    /// Send an invoice, estimate or recurring invoice template.
    /// </summary>
    public Task<InvoiceSendResponse?> RestSendInvoiceAsync(List<InvoiceSendRequest> request, CancellationToken cancellationToken = default)
        => SendRestAsync<InvoiceSendResponse>(HttpMethod.Post, "/invoices/send", body: request, cancellationToken: cancellationToken);

    #endregion

    #region Journals

    /// <summary>
    /// Search for a journal based on specific parameters.
    /// </summary>
    public Task<RestPagedResponse<JournalSearchResponseItem>?> RestSearchJournalsAsync(RestJournalSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<JournalSearchResponseItem>>(HttpMethod.Get, "/journals", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new journal entry.
    /// </summary>
    public Task<JournalCreateResponse?> RestCreateJournalAsync(JournalCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<JournalCreateResponse>(HttpMethod.Post, "/journals", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve an existing journal by ID.
    /// </summary>
    public Task<JournalGetResponse?> RestGetJournalAsync(string id, CancellationToken cancellationToken = default)
        => SendRestAsync<JournalGetResponse>(HttpMethod.Get, $"/journals/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Delete an existing journal entry.
    /// </summary>
    public Task RestDeleteJournalAsync(string id, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/journals/{id}", cancellationToken: cancellationToken);

    #endregion

    #region Ledgers

    /// <summary>
    /// Query a nominal ledger based on a specific date or amount range.
    /// </summary>
    public Task<LedgersSearchResponse?> RestQueryLedgerAsync(RestLedgerSearchParameters parameters, CancellationToken cancellationToken = default)
        => SendRestAsync<LedgersSearchResponse>(HttpMethod.Get, "/ledgers", queryParams: parameters.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Returns information on a specified range of nominal ledgers from the chart of accounts.
    /// </summary>
    public Task<List<LedgersNominalsResponse>?> RestGetNominalsAsync(RestLedgerNominalsParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<List<LedgersNominalsResponse>>(HttpMethod.Get, "/ledgers/nominals", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    #endregion

    #region Projects

    /// <summary>
    /// Search for a project tag based on partial or complete string query.
    /// </summary>
    public Task<List<string>?> RestSearchProjectsAsync(RestProjectSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<List<string>>(HttpMethod.Get, "/projects", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create and attach a project tag to a sales invoice, purchase invoice, estimate or purchase order.
    /// </summary>
    public Task<List<string>?> RestAttachProjectTagsAsync(ProjectsCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<List<string>>(HttpMethod.Post, "/projects", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a project tag from a sales invoice, purchase invoice, estimate or purchase order.
    /// </summary>
    public Task<List<string>?> RestDeleteProjectTagsAsync(ProjectsDeleteRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<List<string>>(HttpMethod.Delete, "/projects", body: request, cancellationToken: cancellationToken);

    #endregion

    #region Purchases

    /// <summary>
    /// Search for purchases using a specific set of search parameters.
    /// </summary>
    public Task<RestPagedResponse<PurchasesSearchResponse>?> RestSearchPurchasesAsync(RestPurchaseSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<PurchasesSearchResponse>>(HttpMethod.Get, "/purchases", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new purchase.
    /// </summary>
    public Task<PurchasesGetResponse?> RestCreatePurchaseAsync(PurchasesPostRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<PurchasesGetResponse>(HttpMethod.Post, "/purchases", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve a single purchase.
    /// </summary>
    public Task<PurchasesGetResponse?> RestGetPurchaseAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<PurchasesGetResponse>(HttpMethod.Get, $"/purchases/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Update a purchase.
    /// </summary>
    public Task<PurchasesGetResponse?> RestUpdatePurchaseAsync(long id, PurchasesPutRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<PurchasesGetResponse>(HttpMethod.Put, $"/purchases/{id}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a purchase.
    /// </summary>
    public Task RestDeletePurchaseAsync(long id, InvoiceDeleteRequest request, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/purchases/{id}", body: request, cancellationToken: cancellationToken);

    #endregion

    #region Purchase Orders

    /// <summary>
    /// Retrieve a single purchase order.
    /// </summary>
    public Task<PurchaseOrdersGetResponse?> RestGetPurchaseOrderAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<PurchaseOrdersGetResponse>(HttpMethod.Get, $"/purchase-orders/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Update a purchase order.
    /// </summary>
    public Task<PurchasesGetResponse?> RestUpdatePurchaseOrderAsync(long id, PurchaseOrderPutRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<PurchasesGetResponse>(HttpMethod.Put, $"/purchase-orders/{id}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a purchase order.
    /// </summary>
    public Task RestDeletePurchaseOrderAsync(long id, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/purchase-orders/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new purchase order.
    /// </summary>
    public Task<PurchaseOrdersGetResponse?> RestCreatePurchaseOrderAsync(PurchaseOrderPostRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<PurchaseOrdersGetResponse>(HttpMethod.Post, "/purchase-orders", body: request, cancellationToken: cancellationToken);

    #endregion

    #region Reports

    /// <summary>
    /// Retrieves a chart of nominal accounts report.
    /// </summary>
    public Task<RestArrayResponse<ChartOfAccountsResponse>?> RestGetChartOfAccountsReportAsync(RestChartOfAccountsParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestArrayResponse<ChartOfAccountsResponse>>(HttpMethod.Get, "/reports/chart-of-accounts", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieves a balance sheet report.
    /// </summary>
    public Task<BalanceSheetResponse?> RestGetBalanceSheetReportAsync(string? dateTo = null, CancellationToken cancellationToken = default)
    {
        var query = !string.IsNullOrEmpty(dateTo) ? new Dictionary<string, string?> { ["date_to"] = dateTo } : null;
        return SendRestAsync<BalanceSheetResponse>(HttpMethod.Get, "/reports/balance-sheet", queryParams: query, cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Retrieves a report of aged debtor or creditor invoices.
    /// </summary>
    public Task<RestPagedResponse<AgeingResponse>?> RestGetAgeingReportAsync(RestAgeingParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<AgeingResponse>>(HttpMethod.Get, "/reports/ageing", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieves a profit and loss report.
    /// </summary>
    public Task<ProfitAndLossResponse?> RestGetProfitAndLossReportAsync(RestProfitAndLossParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<ProfitAndLossResponse>(HttpMethod.Get, "/reports/profit-and-loss", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieves a list of filed and open VAT returns.
    /// </summary>
    public Task<RestArrayResponse<VatObligationsResponse>?> RestGetVatObligationsReportAsync(RestVatObligationsParameters parameters, CancellationToken cancellationToken = default)
        => SendRestAsync<RestArrayResponse<VatObligationsResponse>>(HttpMethod.Get, "/reports/vat-obligations", queryParams: parameters.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieves a list of subscriptions.
    /// </summary>
    public Task<RestArrayResponse<SubscriptionsResponse>?> RestGetSubscriptionsReportAsync(CancellationToken cancellationToken = default)
        => SendRestAsync<RestArrayResponse<SubscriptionsResponse>>(HttpMethod.Get, "/reports/subscriptions", cancellationToken: cancellationToken);

    /// <summary>
    /// Query the system event log.
    /// </summary>
    public Task<EventLogResponse?> RestGetEventLogReportAsync(RestEventLogParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<EventLogResponse>(HttpMethod.Get, "/reports/eventlog", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    #endregion

    #region Suppliers

    /// <summary>
    /// Retrieve supplier records based on a set of search parameters.
    /// </summary>
    public Task<RestPagedResponse<SupplierSearchModel>?> RestSearchSuppliersAsync(RestSupplierSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<SupplierSearchModel>>(HttpMethod.Get, "/suppliers", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new supplier record.
    /// </summary>
    public Task<SupplierBaseModel?> RestCreateSupplierAsync(SupplierCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<SupplierBaseModel>(HttpMethod.Post, "/suppliers", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve supplier and contact data.
    /// </summary>
    public Task<SupplierBaseModel?> RestGetSupplierAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<SupplierBaseModel>(HttpMethod.Get, $"/suppliers/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Update a supplier record.
    /// </summary>
    public Task<SupplierBaseModel?> RestUpdateSupplierAsync(long id, SupplierUpdateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<SupplierBaseModel>(HttpMethod.Put, $"/suppliers/{id}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a supplier record.
    /// </summary>
    public Task RestDeleteSupplierAsync(long id, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/suppliers/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve supplier contact data.
    /// </summary>
    public Task<List<SupplierContactModel>?> RestGetSupplierContactsAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<List<SupplierContactModel>>(HttpMethod.Get, $"/suppliers/{id}/contacts", cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new supplier contact record.
    /// </summary>
    public Task<SupplierContactModel?> RestCreateSupplierContactAsync(long id, SupplierContactCreateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<SupplierContactModel>(HttpMethod.Post, $"/suppliers/{id}/contacts", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Update an existing supplier contact record.
    /// </summary>
    public Task<SupplierContactModel?> RestUpdateSupplierContactAsync(long id, long contactId, SupplierContactUpdateRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<SupplierContactModel>(HttpMethod.Put, $"/suppliers/{id}/contacts/{contactId}", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a supplier contact record.
    /// </summary>
    public Task RestDeleteSupplierContactAsync(long id, long contactId, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/suppliers/{id}/contacts/{contactId}", cancellationToken: cancellationToken);

    #endregion

    #region Supplier Payments

    /// <summary>
    /// Search for a supplier payment based on specific search parameters.
    /// </summary>
    public Task<RestPagedResponse<PaymentsSupplierSearchResponse>?> RestSearchSupplierPaymentsAsync(RestSupplierPaymentSearchParameters? parameters = null, CancellationToken cancellationToken = default)
        => SendRestAsync<RestPagedResponse<PaymentsSupplierSearchResponse>>(HttpMethod.Get, "/supplier_payments", queryParams: parameters?.ToDictionary(), cancellationToken: cancellationToken);

    /// <summary>
    /// Create a new supplier payment record.
    /// </summary>
    public Task<PaymentsSupplierPostResponse?> RestCreateSupplierPaymentAsync(PaymentsSupplierPostRequest request, CancellationToken cancellationToken = default)
        => SendRestAsync<PaymentsSupplierPostResponse>(HttpMethod.Post, "/supplier_payments", body: request, cancellationToken: cancellationToken);

    /// <summary>
    /// Retrieve a supplier payment record.
    /// </summary>
    public Task<PaymentsSupplierGetResponse?> RestGetSupplierPaymentAsync(long id, CancellationToken cancellationToken = default)
        => SendRestAsync<PaymentsSupplierGetResponse>(HttpMethod.Get, $"/supplier_payments/{id}", cancellationToken: cancellationToken);

    /// <summary>
    /// Delete a supplier payment record.
    /// </summary>
    public Task RestDeleteSupplierPaymentAsync(long id, CancellationToken cancellationToken = default)
        => SendRestNoContentAsync(HttpMethod.Delete, $"/supplier_payments/{id}", cancellationToken: cancellationToken);

    #endregion
}
