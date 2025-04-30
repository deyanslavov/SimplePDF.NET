using SimplePDF.NET.Helpers;
using SimplePDF.NET.Internals.Tokens;

namespace SimplePDF.NET.Internals.Objects;

/// <summary>
/// Indirect objects are those that are referred to (indirectly!) by reference and a PDF reader will have to jump around the file to find the actual value. 
/// In order to identify which object is being referred to, every indirect object has a unique (per-PDF) ID, which is expressed as a positive number, 
/// and a generation number, which is always a nonnegative number and usually zero (0). These numbers are used both to define the object and to reference the object.
/// </summary>
internal class IndirectObject<T> : PdfObject where T : PdfObject
{
    internal T Object { get; }

    internal int ObjectNumber { get; }

    internal short GenerationNumber { get; }

    internal IndirectObject(T objRef)
    {
        Object = objRef;

        ObjectNumber = ObjectNumberGenerator.New();
        GenerationNumber = 0;
    }

    internal byte[] GetBytesIndirect()
    {
        return
            [
            ..ByteHelper.GetBytes(ObjectNumber.ToString()),
            ..Whitespaces.SPACE,
            ..ByteHelper.GetBytes(GenerationNumber.ToString()),
            ..Whitespaces.SPACE,
            ..ByteHelper.GetBytes(Constants.IndirectReferenceObjectKeyword),
            ];
        return
            [
            ..BitConverter.GetBytes(ObjectNumber),
            ..Whitespaces.SPACE,
            ..BitConverter.GetBytes(GenerationNumber),
            ..Whitespaces.SPACE,
            ..ByteHelper.GetBytes(Constants.IndirectReferenceObjectKeyword)
            ];
        return ByteHelper.GetBytes(ToString());
    }

    internal override byte[] GetBytes()
    {
        return
            [
            ..ByteHelper.GetBytes(ObjectNumber.ToString()),
            ..Whitespaces.SPACE,
            ..ByteHelper.GetBytes(GenerationNumber.ToString()),
            ..Whitespaces.SPACE,
            ..PdfWriter.OBJ,
            ..Object.GetBytes(),
            ..PdfWriter.ENDOBJ,
            ];
    }

    public override string ToString()
    {
        return $"{ObjectNumber} {GenerationNumber} {Constants.IndirectReferenceObjectKeyword}";
    }
}
