using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class RestBankTransactionSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public string? Reference { get; set; }
    public string? Notes { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public double? AmountFrom { get; set; }
    public double? AmountTo { get; set; }
    public string? Type { get; set; }
    public string? TagStatus { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["reference"] = Reference,
        ["notes"] = Notes,
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["amount_from"] = AmountFrom?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["amount_to"] = AmountTo?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["type"] = Type,
        ["tag_status"] = TagStatus,
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestBankAccountSearchParameters
{
    public int? NominalCode { get; set; }
    public List<string>? Types { get; set; }
    public bool? IncludeHidden { get; set; }
    public bool? IncludeConsents { get; set; }

    public Dictionary<string, string?> ToDictionary()
    {
        var dict = new Dictionary<string, string?>
        {
            ["nominal_code"] = NominalCode?.ToString(),
            ["include_hidden"] = IncludeHidden?.ToString()?.ToLowerInvariant(),
            ["include_consents"] = IncludeConsents?.ToString()?.ToLowerInvariant()
        };
        if (Types != null && Types.Count > 0)
        {
            dict["types"] = string.Join(",", Types);
        }
        return dict;
    }
}

public class RestClientSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public bool? IncludeDeleted { get; set; }
    public string? CompanyName { get; set; }
    public string? FirstName { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? AccountReference { get; set; }
    public string? Telephone { get; set; }
    public bool? IncludeTotalInvoiced { get; set; }
    public bool? IncludeTotalPaid { get; set; }
    public bool? IncludeTotalCredits { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["include_deleted"] = IncludeDeleted?.ToString()?.ToLowerInvariant(),
        ["company_name"] = CompanyName,
        ["first_name"] = FirstName,
        ["surname"] = Surname,
        ["email"] = Email,
        ["account_reference"] = AccountReference,
        ["telephone"] = Telephone,
        ["include_total_invoiced"] = IncludeTotalInvoiced?.ToString()?.ToLowerInvariant(),
        ["include_total_paid"] = IncludeTotalPaid?.ToString()?.ToLowerInvariant(),
        ["include_total_credits"] = IncludeTotalCredits?.ToString()?.ToLowerInvariant(),
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestClientGetParameters
{
    public bool? Contacts { get; set; }
    public bool? Financials { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["contacts"] = Contacts?.ToString()?.ToLowerInvariant(),
        ["financials"] = Financials?.ToString()?.ToLowerInvariant()
    };
}

public class RestClientPaymentSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public bool? IncludeDeleted { get; set; }
    public long? ClientId { get; set; }
    public string? ClientName { get; set; }
    public string? Type { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public double? AmountFrom { get; set; }
    public double? AmountTo { get; set; }
    public string? Currency { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["include_deleted"] = IncludeDeleted?.ToString()?.ToLowerInvariant(),
        ["client_id"] = ClientId?.ToString(),
        ["client_name"] = ClientName,
        ["type"] = Type,
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["amount_from"] = AmountFrom?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["amount_to"] = AmountTo?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["currency"] = Currency,
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestInventorySearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public bool? IncludeDeleted { get; set; }
    public string? ItemName { get; set; }
    public string? ItemDescription { get; set; }
    public string? ItemType { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["include_deleted"] = IncludeDeleted?.ToString()?.ToLowerInvariant(),
        ["item_name"] = ItemName,
        ["item_description"] = ItemDescription,
        ["item_type"] = ItemType,
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestInvoiceSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public string? Type { get; set; }
    public string? TagName { get; set; }
    public bool? IncludeDeleted { get; set; }
    public long? ClientId { get; set; }
    public string? ClientContactName { get; set; }
    public long? RecurringProfileId { get; set; }
    public string? InvoiceNumber { get; set; }
    public string? ItemName { get; set; }
    public string? ItemDesc { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public double? AmountFrom { get; set; }
    public double? AmountTo { get; set; }
    public string? Currency { get; set; }
    public string? Status { get; set; }
    public string? PurchaseRef { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["type"] = Type,
        ["tag_name"] = TagName,
        ["include_deleted"] = IncludeDeleted?.ToString()?.ToLowerInvariant(),
        ["client_id"] = ClientId?.ToString(),
        ["client_contact_name"] = ClientContactName,
        ["recurring_profile_id"] = RecurringProfileId?.ToString(),
        ["invoice_number"] = InvoiceNumber,
        ["item_name"] = ItemName,
        ["item_desc"] = ItemDesc,
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["amount_from"] = AmountFrom?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["amount_to"] = AmountTo?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["currency"] = Currency,
        ["status"] = Status,
        ["purchase_ref"] = PurchaseRef,
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestJournalSearchParameters
{
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestLedgerSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public int NominalCode { get; set; }
    public string? Description { get; set; }
    public string? Notes { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public double? AmountFrom { get; set; }
    public double? AmountTo { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["nominal_code"] = NominalCode.ToString(),
        ["description"] = Description,
        ["notes"] = Notes,
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["amount_from"] = AmountFrom?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["amount_to"] = AmountTo?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestLedgerNominalsParameters
{
    public int? NominalCodeStart { get; set; }
    public int? NominalCodeEnd { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["nominal_code_start"] = NominalCodeStart?.ToString(),
        ["nominal_code_end"] = NominalCodeEnd?.ToString()
    };
}

public class RestProjectSearchParameters
{
    public string? Tag { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["tag"] = Tag,
        ["limit"] = Limit?.ToString()
    };
}

public class RestPurchaseSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public bool? IncludeDeleted { get; set; }
    public string? TagName { get; set; }
    public string? SupplierName { get; set; }
    public long? SupplierId { get; set; }
    public string? SupplierReference { get; set; }
    public string? ReceiptNumber { get; set; }
    public string? ItemDesc { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public double? AmountFrom { get; set; }
    public double? AmountTo { get; set; }
    public string? Currency { get; set; }
    public string? Status { get; set; }
    public bool? HasReceipts { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["include_deleted"] = IncludeDeleted?.ToString()?.ToLowerInvariant(),
        ["tag_name"] = TagName,
        ["supplier_name"] = SupplierName,
        ["supplier_id"] = SupplierId?.ToString(),
        ["supplier_reference"] = SupplierReference,
        ["receipt_number"] = ReceiptNumber,
        ["item_desc"] = ItemDesc,
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["amount_from"] = AmountFrom?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["amount_to"] = AmountTo?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["currency"] = Currency,
        ["status"] = Status,
        ["has_receipts"] = HasReceipts?.ToString()?.ToLowerInvariant(),
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestChartOfAccountsParameters
{
    public int? NominalCodeStart { get; set; }
    public int? NominalCodeEnd { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public bool? ExcludeZeroBalanceLedgers { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["nominal_code_start"] = NominalCodeStart?.ToString(),
        ["nominal_code_end"] = NominalCodeEnd?.ToString(),
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["exclude_zero_balance_ledgers"] = ExcludeZeroBalanceLedgers?.ToString()?.ToLowerInvariant()
    };
}

public class RestAgeingParameters
{
    public string? Type { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["type"] = Type,
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestProfitAndLossParameters
{
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo
    };
}

public class RestVatObligationsParameters
{
    public long HmrcAccountId { get; set; }
    public string? HmrcAccountType { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["hmrc_account_id"] = HmrcAccountId.ToString(),
        ["hmrc_account_type"] = HmrcAccountType,
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo
    };
}

public class RestEventLogParameters
{
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public string? ReferenceType { get; set; }
    public string? ReferenceId { get; set; }
    public long? UserId { get; set; }
    public int? PageSize { get; set; }
    public string? NextToken { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["reference_type"] = ReferenceType,
        ["reference_id"] = ReferenceId,
        ["user_id"] = UserId?.ToString(),
        ["page_size"] = PageSize?.ToString(),
        ["next_token"] = NextToken
    };
}

public class RestSupplierSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public bool? IncludeDeleted { get; set; }
    public string? CompanyName { get; set; }
    public string? FirstName { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
    public string? SupplierReference { get; set; }
    public string? Telephone { get; set; }
    public bool? IncludeTotalInvoiced { get; set; }
    public bool? IncludeTotalPaid { get; set; }
    public bool? IncludeTotalCredits { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["include_deleted"] = IncludeDeleted?.ToString()?.ToLowerInvariant(),
        ["company_name"] = CompanyName,
        ["first_name"] = FirstName,
        ["surname"] = Surname,
        ["email"] = Email,
        ["supplier_reference"] = SupplierReference,
        ["telephone"] = Telephone,
        ["include_total_invoiced"] = IncludeTotalInvoiced?.ToString()?.ToLowerInvariant(),
        ["include_total_paid"] = IncludeTotalPaid?.ToString()?.ToLowerInvariant(),
        ["include_total_credits"] = IncludeTotalCredits?.ToString()?.ToLowerInvariant(),
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}

public class RestSupplierPaymentSearchParameters
{
    public string? OrderColumn { get; set; }
    public string? OrderDirection { get; set; }
    public bool? IncludeDeleted { get; set; }
    public long? SupplierId { get; set; }
    public string? SupplierName { get; set; }
    public string? Type { get; set; }
    public string? DateFrom { get; set; }
    public string? DateTo { get; set; }
    public double? AmountFrom { get; set; }
    public double? AmountTo { get; set; }
    public string? Currency { get; set; }
    public int? Offset { get; set; }
    public int? Limit { get; set; }

    public Dictionary<string, string?> ToDictionary() => new()
    {
        ["order_column"] = OrderColumn,
        ["order_direction"] = OrderDirection,
        ["include_deleted"] = IncludeDeleted?.ToString()?.ToLowerInvariant(),
        ["supplier_id"] = SupplierId?.ToString(),
        ["supplier_name"] = SupplierName,
        ["type"] = Type,
        ["date_from"] = DateFrom,
        ["date_to"] = DateTo,
        ["amount_from"] = AmountFrom?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["amount_to"] = AmountTo?.ToString(System.Globalization.CultureInfo.InvariantCulture),
        ["currency"] = Currency,
        ["offset"] = Offset?.ToString(),
        ["limit"] = Limit?.ToString()
    };
}
