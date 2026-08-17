using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class ClientBaseModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("account_reference")]
    public string? AccountReference { get; set; }

    [JsonPropertyName("address_line1")]
    public string? AddressLine1 { get; set; }

    [JsonPropertyName("address_line2")]
    public string? AddressLine2 { get; set; }

    [JsonPropertyName("address_line3")]
    public string? AddressLine3 { get; set; }

    [JsonPropertyName("town")]
    public string? Town { get; set; }

    [JsonPropertyName("country_iso")]
    public string? CountryIso { get; set; }

    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    [JsonPropertyName("post_code")]
    public string? PostCode { get; set; }

    [JsonPropertyName("vat_number")]
    public string? VatNumber { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("allow_attach_pdf")]
    public bool? AllowAttachPdf { get; set; }

    [JsonPropertyName("credit_limit")]
    public double? CreditLimit { get; set; }

    [JsonPropertyName("preferences")]
    public ClientPreferences? Preferences { get; set; }

}

public class ClientContactCreateRequest
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("telephone1")]
    public string? Telephone1 { get; set; }

    [JsonPropertyName("telephone2")]
    public string? Telephone2 { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("job_title")]
    public string? JobTitle { get; set; }

}

public class ClientContactExModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("telephone1")]
    public string? Telephone1 { get; set; }

    [JsonPropertyName("telephone2")]
    public string? Telephone2 { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("job_title")]
    public string? JobTitle { get; set; }

}

public class ClientContactModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("telephone1")]
    public string? Telephone1 { get; set; }

    [JsonPropertyName("telephone2")]
    public string? Telephone2 { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

}

public class ClientContactUpdateRequest
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

    [JsonPropertyName("telephone1")]
    public string? Telephone1 { get; set; }

    [JsonPropertyName("telephone2")]
    public string? Telephone2 { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("job_title")]
    public string? JobTitle { get; set; }

}

public class ClientCreateRequest
{
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("account_reference")]
    public string? AccountReference { get; set; }

    [JsonPropertyName("address_line1")]
    public string? AddressLine1 { get; set; }

    [JsonPropertyName("address_line2")]
    public string? AddressLine2 { get; set; }

    [JsonPropertyName("address_line3")]
    public string? AddressLine3 { get; set; }

    [JsonPropertyName("town")]
    public string? Town { get; set; }

    [JsonPropertyName("country_iso")]
    public string? CountryIso { get; set; }

    [JsonPropertyName("post_code")]
    public string? PostCode { get; set; }

    [JsonPropertyName("vat_number")]
    public string? VatNumber { get; set; }

    [JsonPropertyName("go_cardless_mandate")]
    public string? GoCardlessMandate { get; set; }

    [JsonPropertyName("allow_attach_pdf")]
    public bool? AllowAttachPdf { get; set; }

    [JsonPropertyName("default_send_method")]
    public string? DefaultSendMethod { get; set; }

    [JsonPropertyName("default_currency")]
    public string? DefaultCurrency { get; set; }

    [JsonPropertyName("default_term")]
    public int? DefaultTerm { get; set; }

    [JsonPropertyName("trading_style")]
    public int? TradingStyle { get; set; }

    [JsonPropertyName("payment_restrictions")]
    public List<string>? PaymentRestrictions { get; set; }

}

public class ClientFinacialBalanceModel
{
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

}

public class ClientFinacialCreditModel
{
    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

}

public class ClientFinacialModel
{
    [JsonPropertyName("credits")]
    public List<ClientFinacialCreditModel>? Credits { get; set; }

    [JsonPropertyName("balances")]
    public List<ClientFinacialBalanceModel>? Balances { get; set; }

}

public class ClientLoginRequest
{
    [JsonPropertyName("landing_page")]
    public LandingPageModel? LandingPage { get; set; }

}

public class ClientLoginResponse
{
    [JsonPropertyName("redirect_url")]
    public string? RedirectUrl { get; set; }

}

public class ClientModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("account_reference")]
    public string? AccountReference { get; set; }

    [JsonPropertyName("address_line1")]
    public string? AddressLine1 { get; set; }

    [JsonPropertyName("address_line2")]
    public string? AddressLine2 { get; set; }

    [JsonPropertyName("address_line3")]
    public string? AddressLine3 { get; set; }

    [JsonPropertyName("town")]
    public string? Town { get; set; }

    [JsonPropertyName("country_iso")]
    public string? CountryIso { get; set; }

    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    [JsonPropertyName("post_code")]
    public string? PostCode { get; set; }

    [JsonPropertyName("vat_number")]
    public string? VatNumber { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("allow_attach_pdf")]
    public bool? AllowAttachPdf { get; set; }

    [JsonPropertyName("credit_limit")]
    public double? CreditLimit { get; set; }

    [JsonPropertyName("preferences")]
    public ClientPreferences? Preferences { get; set; }

    [JsonPropertyName("direct_debit_mandate_id")]
    public string? DirectDebitMandateId { get; set; }

    [JsonPropertyName("direct_debit_new_mandate_url")]
    public string? DirectDebitNewMandateUrl { get; set; }

    [JsonPropertyName("contacts")]
    public List<ClientContactExModel>? Contacts { get; set; }

    [JsonPropertyName("financial")]
    public ClientFinacialModel? Financial { get; set; }

}

public class ClientNewDDAccount
{
    [JsonPropertyName("payment_name")]
    public string? PaymentName { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}

public class ClientNewDDInvoice
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("amount")]
    public double? Amount { get; set; }

}

public class ClientNewDDRequest
{
    [JsonPropertyName("invoice")]
    public ClientNewDDInvoice? Invoice { get; set; }

    [JsonPropertyName("account")]
    public ClientNewDDAccount? Account { get; set; }

    [JsonPropertyName("charge_at_date")]
    public DateTimeOffset? ChargeAtDate { get; set; }

}

public class ClientNewDDResponse
{
    [JsonPropertyName("bill_id")]
    public string? BillId { get; set; }

}

public class ClientPreferences
{
    [JsonPropertyName("default_send_method")]
    public string? DefaultSendMethod { get; set; }

    [JsonPropertyName("default_currency")]
    public string? DefaultCurrency { get; set; }

    [JsonPropertyName("default_term")]
    public int? DefaultTerm { get; set; }

    [JsonPropertyName("trading_style")]
    public long? TradingStyle { get; set; }

}

public class ClientSearchModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("account_reference")]
    public string? AccountReference { get; set; }

    [JsonPropertyName("created_date")]
    public DateTimeOffset? CreatedDate { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("primary_contact")]
    public ClientContactModel? PrimaryContact { get; set; }

    [JsonPropertyName("account_balance")]
    public double? AccountBalance { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("total_invoiced")]
    public double? TotalInvoiced { get; set; }

    [JsonPropertyName("total_paid")]
    public double? TotalPaid { get; set; }

    [JsonPropertyName("total_credits")]
    public double? TotalCredits { get; set; }

}

public class ClientTradingStylesResponse
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("created_date")]
    public DateTimeOffset? CreatedDate { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("business_name")]
    public string? BusinessName { get; set; }

    [JsonPropertyName("sender_address")]
    public string? SenderAddress { get; set; }

    [JsonPropertyName("web_address")]
    public string? WebAddress { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("invoice_template")]
    public long? InvoiceTemplate { get; set; }

    [JsonPropertyName("client_area_template")]
    public string? ClientAreaTemplate { get; set; }

}

public class ClientUpdateRequest
{
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("account_reference")]
    public string? AccountReference { get; set; }

    [JsonPropertyName("address_line1")]
    public string? AddressLine1 { get; set; }

    [JsonPropertyName("address_line2")]
    public string? AddressLine2 { get; set; }

    [JsonPropertyName("address_line3")]
    public string? AddressLine3 { get; set; }

    [JsonPropertyName("town")]
    public string? Town { get; set; }

    [JsonPropertyName("country_iso")]
    public string? CountryIso { get; set; }

    [JsonPropertyName("post_code")]
    public string? PostCode { get; set; }

    [JsonPropertyName("vat_number")]
    public string? VatNumber { get; set; }

    [JsonPropertyName("go_cardless_mandate")]
    public string? GoCardlessMandate { get; set; }

    [JsonPropertyName("allow_attach_pdf")]
    public bool? AllowAttachPdf { get; set; }

    [JsonPropertyName("default_send_method")]
    public string? DefaultSendMethod { get; set; }

    [JsonPropertyName("default_currency")]
    public string? DefaultCurrency { get; set; }

    [JsonPropertyName("default_term")]
    public int? DefaultTerm { get; set; }

    [JsonPropertyName("trading_style")]
    public int? TradingStyle { get; set; }

    [JsonPropertyName("payment_restrictions")]
    public List<string>? PaymentRestrictions { get; set; }

}

public class Consent
{
    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

    [JsonPropertyName("expiry_date")]
    public string? ExpiryDate { get; set; }

}

public class LandingPageModel
{
    [JsonPropertyName("dashboard")]
    public bool? Dashboard { get; set; }

    [JsonPropertyName("invoice_id")]
    public long? InvoiceId { get; set; }

}
