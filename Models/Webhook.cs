using System.Text.Json.Serialization;

namespace Quickfile.Net.Models;

public class QuickfileWebhookPayload
{
    [JsonPropertyName("PayLoad")]
    public WebhookData Data { get; set; } = new();
}

public class WebhookData
{
    public List<InvoiceWebhookEvent>? InvoicesCreated { get; set; }
    public List<InvoiceWebhookEvent>? InvoicesUpdated { get; set; }
    public List<InvoiceWebhookEvent>? InvoicesDeleted { get; set; }
    public List<InvoiceWebhookEvent>? InvoicesViewed { get; set; }
    public List<InvoiceWebhookEvent>? InvoicesPaid { get; set; }

    public List<InvoiceWebhookEvent>? EstimatesCreated { get; set; }
    public List<InvoiceWebhookEvent>? EstimatesUpdated { get; set; }
    public List<InvoiceWebhookEvent>? EstimatesDeleted { get; set; }
    public List<InvoiceWebhookEvent>? EstimatesAccepted { get; set; }
    public List<InvoiceWebhookEvent>? EstimatesDeclined { get; set; }

    public List<ClientWebhookEvent>? ClientsCreated { get; set; }
    public List<ClientWebhookEvent>? ClientsUpdated { get; set; }
    public List<ClientWebhookEvent>? ClientsDeleted { get; set; }
    public List<ClientMergedWebhookEvent>? ClientsMerged { get; set; }

    public List<ContactWebhookEvent>? ClientContactsCreated { get; set; }
    public List<ContactWebhookEvent>? ClientContactsUpdated { get; set; }
    public List<ContactWebhookEvent>? ClientContactsDeleted { get; set; }

    public List<SupplierWebhookEvent>? SuppliersCreated { get; set; }
    public List<SupplierWebhookEvent>? SuppliersUpdated { get; set; }
    public List<SupplierWebhookEvent>? SuppliersDeleted { get; set; }
    public List<SupplierMergedWebhookEvent>? SuppliersMerged { get; set; }

    public List<PaymentWebhookEvent>? PaymentsCreated { get; set; }

    public DateTime Timestamp { get; set; }
    public string Signature { get; set; } = string.Empty;
    public string Hookid { get; set; } = string.Empty;
}

public class InvoiceWebhookEvent
{
    public long Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? InvoiceType { get; set; }
    public bool? FromRecurring { get; set; }
    public long? RecurringParentId { get; set; }
}

public class ClientWebhookEvent
{
    public long Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? AccountRef { get; set; }
    public string? CompanyName { get; set; }
}

public class ClientMergedWebhookEvent
{
    public long MasterId { get; set; }
    public long MergedId { get; set; }
    public DateTime TimeStamp { get; set; }
}

public class ContactWebhookEvent
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public class SupplierWebhookEvent
{
    public long Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? AccountRef { get; set; }
    public string? CompanyName { get; set; }
}

public class SupplierMergedWebhookEvent
{
    public long MasterId { get; set; }
    public long MergedId { get; set; }
    public DateTime TimeStamp { get; set; }
}

public class PaymentWebhookEvent
{
    public long Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }
}
