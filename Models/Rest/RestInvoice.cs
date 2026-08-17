using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class Invoice
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("amount_in_currency")]
    public double? AmountInCurrency { get; set; }

    [JsonPropertyName("date")]
    public string? Date { get; set; }

}

public class InvoiceDeleteRequest
{
    [JsonPropertyName("delete_associated_payments")]
    public bool? DeleteAssociatedPayments { get; set; }

}

public class InvoiceGetPdfResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }

}

public class InvoiceModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("created_date")]
    public DateTimeOffset? CreatedDate { get; set; }

    [JsonPropertyName("issue_date")]
    public string? IssueDate { get; set; }

    [JsonPropertyName("due_date")]
    public string? DueDate { get; set; }

    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("purchase_reference")]
    public string? PurchaseReference { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("client_company_name")]
    public string? ClientCompanyName { get; set; }

    [JsonPropertyName("client_contact_name")]
    public string? ClientContactName { get; set; }

    [JsonPropertyName("gross_total")]
    public double? GrossTotal { get; set; }

    [JsonPropertyName("vat_total")]
    public double? VatTotal { get; set; }

    [JsonPropertyName("net_total")]
    public double? NetTotal { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("term_days")]
    public int? TermDays { get; set; }

    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("recurring_profile_id")]
    public long? RecurringProfileId { get; set; }

}

public class InvoiceSendErrorResponse
{
    [JsonPropertyName("invoice")]
    public string? Invoice { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

}

public class InvoiceSendRequest
{
    [JsonPropertyName("invoice_id")]
    public long? InvoiceId { get; set; }

    [JsonPropertyName("by_email")]
    public bool? ByEmail { get; set; }

    [JsonPropertyName("by_snail_mail")]
    public bool? BySnailMail { get; set; }

    [JsonPropertyName("client_contact_id")]
    public long? ClientContactId { get; set; }

}

public class InvoiceSendResponse
{
    [JsonPropertyName("success")]
    public bool? Success { get; set; }

}

public class InvoiceSingleLine
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("item_name")]
    public string? ItemName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("vat_rate")]
    public double? VatRate { get; set; }

    [JsonPropertyName("unit_cost")]
    public double? UnitCost { get; set; }

    [JsonPropertyName("qty")]
    public double? Qty { get; set; }

    [JsonPropertyName("line_total")]
    public double? LineTotal { get; set; }

    [JsonPropertyName("vat_amount")]
    public double? VatAmount { get; set; }

}

public class InvoiceSingleModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("created_date")]
    public DateTimeOffset? CreatedDate { get; set; }

    [JsonPropertyName("issue_date")]
    public string? IssueDate { get; set; }

    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("purchase_reference")]
    public string? PurchaseReference { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("client_company_name")]
    public string? ClientCompanyName { get; set; }

    [JsonPropertyName("client_contact_name")]
    public string? ClientContactName { get; set; }

    [JsonPropertyName("gross_total")]
    public double? GrossTotal { get; set; }

    [JsonPropertyName("vat_total")]
    public double? VatTotal { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("term_days")]
    public int? TermDays { get; set; }

    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("preview_uri")]
    public string? PreviewUri { get; set; }

    [JsonPropertyName("recurring_profile_id")]
    public long? RecurringProfileId { get; set; }

    [JsonPropertyName("client_email")]
    public string? ClientEmail { get; set; }

    [JsonPropertyName("client_address")]
    public string? ClientAddress { get; set; }

    [JsonPropertyName("client_country")]
    public string? ClientCountry { get; set; }

    [JsonPropertyName("client_vat_number")]
    public string? ClientVatNumber { get; set; }

    [JsonPropertyName("payee_company_name")]
    public string? PayeeCompanyName { get; set; }

    [JsonPropertyName("payee_address")]
    public string? PayeeAddress { get; set; }

    [JsonPropertyName("payee_vat_number")]
    public string? PayeeVatNumber { get; set; }

    [JsonPropertyName("discount_percentage")]
    public double? DiscountPercentage { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("viewed")]
    public bool? Viewed { get; set; }

    [JsonPropertyName("payment_term_notes")]
    public string? PaymentTermNotes { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("exchange_rate")]
    public double? ExchangeRate { get; set; }

    [JsonPropertyName("item_lines")]
    public List<InvoiceSingleLine>? ItemLines { get; set; }

    [JsonPropertyName("task_lines")]
    public List<InvoiceSingleLine>? TaskLines { get; set; }

    [JsonPropertyName("balance")]
    public double? Balance { get; set; }

    [JsonPropertyName("recurring_profile")]
    public RecurringProfileModel? RecurringProfile { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

}

public class InvoicesCreateLine
{
    [JsonPropertyName("item_id")]
    public int? ItemId { get; set; }

    [JsonPropertyName("item_name")]
    public string? ItemName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("vat_rate")]
    public double? VatRate { get; set; }

    [JsonPropertyName("vat_amount")]
    public double? VatAmount { get; set; }

    [JsonPropertyName("unit_cost")]
    public double? UnitCost { get; set; }

    [JsonPropertyName("qty")]
    public double? Qty { get; set; }

}

public class InvoicesCreateRequest
{
    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("client_contact_name")]
    public string? ClientContactName { get; set; }

    [JsonPropertyName("client_address")]
    public string? ClientAddress { get; set; }

    [JsonPropertyName("client_country")]
    public string? ClientCountry { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("discount_percentage")]
    public double? DiscountPercentage { get; set; }

    [JsonPropertyName("term_days")]
    public int? TermDays { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("payment_term_notes")]
    public string? PaymentTermNotes { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("ec_vat_exempt")]
    public bool? EcVatExempt { get; set; }

    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("issue_date")]
    public string? IssueDate { get; set; }

    [JsonPropertyName("purchase_reference")]
    public string? PurchaseReference { get; set; }

    [JsonPropertyName("vat_codes")]
    public List<string>? VatCodes { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("item_lines")]
    public List<InvoicesCreateLine>? ItemLines { get; set; }

    [JsonPropertyName("task_lines")]
    public List<InvoicesCreateTask>? TaskLines { get; set; }

    [JsonPropertyName("recurring")]
    public InvoicesCreateScheduleRecurring? Recurring { get; set; }

}

public class InvoicesCreateScheduleRecurring
{
    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("frequency")]
    public int? Frequency { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("pro_rata_days")]
    public int? ProRataDays { get; set; }

    [JsonPropertyName("dd_auto_bill")]
    public bool? DdAutoBill { get; set; }

    [JsonPropertyName("dd_delay")]
    public int? DdDelay { get; set; }

    [JsonPropertyName("send_by_email")]
    public bool? SendByEmail { get; set; }

    [JsonPropertyName("send_by_post")]
    public bool? SendByPost { get; set; }

    [JsonPropertyName("auto_activate")]
    public bool? AutoActivate { get; set; }

}

public class InvoicesCreateTask
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("item_name")]
    public string? ItemName { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("nominal_code")]
    public int? NominalCode { get; set; }

    [JsonPropertyName("hourly_rate")]
    public double? HourlyRate { get; set; }

    [JsonPropertyName("hours")]
    public double? Hours { get; set; }

    [JsonPropertyName("vat_rate")]
    public double? VatRate { get; set; }

    [JsonPropertyName("vat_amount")]
    public double? VatAmount { get; set; }

}

public class InvoicesUpdateRequest
{
    [JsonPropertyName("type")]
    public string? TypeValue { get; set; }

    [JsonPropertyName("client_id")]
    public long? ClientId { get; set; }

    [JsonPropertyName("client_contact_name")]
    public string? ClientContactName { get; set; }

    [JsonPropertyName("client_address")]
    public string? ClientAddress { get; set; }

    [JsonPropertyName("client_country")]
    public string? ClientCountry { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("discount_percentage")]
    public double? DiscountPercentage { get; set; }

    [JsonPropertyName("term_days")]
    public int? TermDays { get; set; }

    [JsonPropertyName("language")]
    public string? Language { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("payment_term_notes")]
    public string? PaymentTermNotes { get; set; }

    [JsonPropertyName("notes")]
    public string? Notes { get; set; }

    [JsonPropertyName("ec_vat_exempt")]
    public bool? EcVatExempt { get; set; }

    [JsonPropertyName("invoice_number")]
    public string? InvoiceNumber { get; set; }

    [JsonPropertyName("issue_date")]
    public string? IssueDate { get; set; }

    [JsonPropertyName("purchase_reference")]
    public string? PurchaseReference { get; set; }

    [JsonPropertyName("vat_codes")]
    public List<string>? VatCodes { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("item_lines")]
    public List<InvoicesCreateLine>? ItemLines { get; set; }

    [JsonPropertyName("task_lines")]
    public List<InvoicesCreateTask>? TaskLines { get; set; }

    [JsonPropertyName("recurring")]
    public InvoicesCreateScheduleRecurring? Recurring { get; set; }

}

public class RecurringProfileModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("interval")]
    public string? Interval { get; set; }

    [JsonPropertyName("frequency")]
    public int? Frequency { get; set; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("last_sent_date")]
    public string? LastSentDate { get; set; }

    [JsonPropertyName("next_due_date")]
    public string? NextDueDate { get; set; }

    [JsonPropertyName("number_sent")]
    public int? NumberSent { get; set; }

    [JsonPropertyName("pro_rata_days")]
    public int? ProRataDays { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("send_by_email")]
    public bool? SendByEmail { get; set; }

    [JsonPropertyName("send_by_post")]
    public bool? SendByPost { get; set; }

    [JsonPropertyName("dd_auto_bill")]
    public bool? DdAutoBill { get; set; }

    [JsonPropertyName("dd_delay")]
    public int? DdDelay { get; set; }

}
