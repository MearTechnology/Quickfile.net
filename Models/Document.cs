namespace Quickfile.Net.Models;

public class DocumentUploadRequest
{
    public string FileName { get; set; } = string.Empty;
    public string FileData { get; set; } = string.Empty; // Base64
    public string Folder { get; set; } = "General"; // Hub or General
}

public class DocumentUploadResponse
{
    public int DocumentID { get; set; }
}
