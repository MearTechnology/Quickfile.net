using System.Text.Json.Serialization;

namespace Quickfile.Net.Models.Rest;

public class SupplierBaseModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("supplier_reference")]
    public string? SupplierReference { get; set; }

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

    [JsonPropertyName("default_currency")]
    public string? DefaultCurrency { get; set; }

    [JsonPropertyName("default_term")]
    public int? DefaultTerm { get; set; }

    [JsonPropertyName("default_vatrate")]
    public double? DefaultVatrate { get; set; }

    [JsonPropertyName("default_nominalcode")]
    public int? DefaultNominalcode { get; set; }

    [JsonPropertyName("credit_currency")]
    public string? CreditCurrency { get; set; }

    [JsonPropertyName("credit_amount")]
    public double? CreditAmount { get; set; }

    [JsonPropertyName("balance_currency")]
    public string? BalanceCurrency { get; set; }

    [JsonPropertyName("balance_amount")]
    public double? BalanceAmount { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("contacts")]
    public List<SupplierContactModel>? Contacts { get; set; }

}

public class SupplierContactCreateRequest
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("telephone")]
    public string? Telephone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

}

public class SupplierContactModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("telephone")]
    public string? Telephone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

}

public class SupplierContactUpdateRequest
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("telephone")]
    public string? Telephone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; set; }

}

public class SupplierCreateRequest
{
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("contact_first_name")]
    public string? ContactFirstName { get; set; }

    [JsonPropertyName("contact_surname")]
    public string? ContactSurname { get; set; }

    [JsonPropertyName("contact_telephone")]
    public string? ContactTelephone { get; set; }

    [JsonPropertyName("contact_email")]
    public string? ContactEmail { get; set; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("supplier_reference")]
    public string? SupplierReference { get; set; }

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

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("vat_number")]
    public string? VatNumber { get; set; }

    [JsonPropertyName("default_currency")]
    public string? DefaultCurrency { get; set; }

    [JsonPropertyName("default_term")]
    public int? DefaultTerm { get; set; }

    [JsonPropertyName("default_vatrate")]
    public double? DefaultVatrate { get; set; }

    [JsonPropertyName("default_nominalcode")]
    public int? DefaultNominalcode { get; set; }

}

public class SupplierSearchModel
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    [JsonPropertyName("supplier_reference")]
    public string? SupplierReference { get; set; }

    [JsonPropertyName("created_date")]
    public DateTimeOffset? CreatedDate { get; set; }

    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("telephone")]
    public string? Telephone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

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

public class SupplierUpdateRequest
{
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("supplier_reference")]
    public string? SupplierReference { get; set; }

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

    [JsonPropertyName("website")]
    public string? Website { get; set; }

    [JsonPropertyName("vat_number")]
    public string? VatNumber { get; set; }

    [JsonPropertyName("default_currency")]
    public string? DefaultCurrency { get; set; }

    [JsonPropertyName("default_term")]
    public int? DefaultTerm { get; set; }

    [JsonPropertyName("default_vatrate")]
    public double? DefaultVatrate { get; set; }

    [JsonPropertyName("default_nominalcode")]
    public int? DefaultNominalcode { get; set; }

}
