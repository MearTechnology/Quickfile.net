using System.Text.Json.Serialization;

namespace Quickfile.Net.Models;

public class QuickfilePayload<TBody>
{
    [JsonPropertyName("payload")]
    public QuickfilePayloadData<TBody> Data { get; set; } = new();

    public class QuickfilePayloadData<T>
    {
        public QuickfileHeader Header { get; set; } = null!;
        public T Body { get; set; } = default!;
    }

    public static QuickfilePayload<TBody> Create(QuickfileOptions options, TBody body)
    {
        return new QuickfilePayload<TBody>
        {
            Data = new QuickfilePayloadData<TBody>
            {
                Header = QuickfileHeader.Create(options),
                Body = body
            }
        };
    }
}
