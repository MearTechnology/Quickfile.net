using System.Text;

namespace Quickfile.Net.Models;

public class QuickfileXmlPayload<T>
{
    public QuickfileHeader Header { get; set; } = null!;
    public T Body { get; set; } = default!;
}

public class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding => Encoding.UTF8;
}
