using SimplePDF.NET.Helpers;

namespace SimplePDF.NET.Internals.Objects;

/// <summary>
/// Boolean objects represent the logical values of true and false and are represented accordingly in the PDF, either as true or false.
/// <para>When writing a PDF, you will always use true or false. However, if you are reading/parsing a PDF and wish to be tolerant, 
/// be aware that poorly written PDFs may use other capatilization forms, including leading caps (True or False) or all caps (TRUE or FALSE).</para>
/// </summary>
internal class BooleanObject : PdfObject, IComparable<BooleanObject>
{
    private readonly bool _value;

    internal BooleanObject(bool value)
    {
        _value = value;
    }

    internal override byte[] GetBytes()
    {
        return ByteHelper.GetBytes(ToString());
    }

    public int CompareTo(BooleanObject? other)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return _value.ToString().ToLower();
    }
}
