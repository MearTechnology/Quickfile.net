using System.Security.Cryptography;
using System.Text;

namespace Quickfile.Net.Webhook;

public static class QuickfileWebhookValidator
{
    public static bool IsValidSignature(string hookId, string receivedSignature, QuickfileOptions options)
    {
        if (string.IsNullOrEmpty(options.WebhookSecret))
        {
            throw new InvalidOperationException("WebhookSecret is not configured in QuickfileOptions.");
        }

        var expectedSignature = CalculateSignature(hookId, options.WebhookSecret, options.AccountNumber);
        return string.Equals(expectedSignature, receivedSignature, StringComparison.OrdinalIgnoreCase);
    }

    private static string CalculateSignature(string hookId, string secretKey, string accountNumber)
    {
        var rawData = $"{hookId}{secretKey}{accountNumber}";
        
        using var md5 = MD5.Create();
        var bytes = Encoding.UTF8.GetBytes(rawData);
        var hash = md5.ComputeHash(bytes);

        var sb = new StringBuilder();
        foreach (var b in hash)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
}
