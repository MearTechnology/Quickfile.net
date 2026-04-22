using System.Text.Json;
using Quickfile.Net.Models;

namespace Quickfile.Net.Webhook;

public class QuickfileWebhookParser
{
    private readonly QuickfileOptions _options;

    public QuickfileWebhookParser(QuickfileOptions options)
    {
        _options = options;
    }

    /// <summary>
    /// Parses a JSON webhook payload from a stream and validates its signature.
    /// </summary>
    /// <param name="stream">The request body stream.</param>
    /// <returns>The validated webhook data.</returns>
    /// <exception cref="QuickfileWebhookException">Thrown if validation or parsing fails.</exception>
    public async Task<WebhookData> ParseAndValidateAsync(Stream stream)
    {
        try
        {
            var payload = await JsonSerializer.DeserializeAsync<QuickfileWebhookPayload>(stream);
            if (payload?.Data == null)
            {
                throw new QuickfileWebhookException("Invalid webhook payload: Data is missing.");
            }

            if (!QuickfileWebhookValidator.IsValidSignature(payload.Data.Hookid, payload.Data.Signature, _options))
            {
                throw new QuickfileWebhookException("Invalid webhook signature.");
            }

            return payload.Data;
        }
        catch (JsonException ex)
        {
            throw new QuickfileWebhookException("Failed to deserialize webhook payload.", ex);
        }
    }
}

public class QuickfileWebhookException : Exception
{
    public QuickfileWebhookException(string message) : base(message) { }
    public QuickfileWebhookException(string message, Exception innerException) : base(message, innerException) { }
}
