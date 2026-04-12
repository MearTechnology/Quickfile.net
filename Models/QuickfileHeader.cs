using System.Security.Cryptography;
using System.Text;

namespace Quickfile.Net.Models;

public class QuickfileHeader
{
    public string MessageType { get; set; } = "Request";
    public string AppID { get; set; } = string.Empty;
    public string AccountNumber { get; set; } = string.Empty;
    public string SubmissionNumber { get; set; } = string.Empty;
    public string Authentication { get; set; } = string.Empty;

    public static QuickfileHeader Create(QuickfileOptions options)
    {
        string submissionNumber = Guid.NewGuid().ToString();
        string input = options.AccountNumber + options.ApiKey + submissionNumber;
        byte[] hashBytes = MD5.HashData(Encoding.UTF8.GetBytes(input));
        string md5Hash = Convert.ToHexString(hashBytes).ToLower();

        return new QuickfileHeader
        {
            AppID = options.ApplicationId,
            AccountNumber = options.AccountNumber,
            SubmissionNumber = submissionNumber,
            Authentication = md5Hash
        };
    }
}
