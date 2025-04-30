using SimplePDF.NET.Helpers;
using SimplePDF.NET.Internals.DocumentStructure;
using SimplePDF.NET.Internals.FileStructure;
using SimplePDF.NET.Internals.Objects;

namespace SimplePDF.NET.Internals;

internal class PdfOutput : IDisposable
{
    internal event EventHandler<(int objectNumber, long offset)> OnObjectWritten = default!;

    private long _position;
    private long? _xrefPosition;

    private readonly MemoryStream output = new();

    internal byte[] GetBytes() => output.ToArray();

    private void Write(byte[] bytes)
    {
        output.Write(bytes);
        _position += bytes.Length;
    }

    private void WriteString(string value)
        => Write(ByteHelper.GetBytes(value));

    internal void WriteHeader()
    {
        PdfFileHeader header = new(true);
        var headerBytes = header.GetBytes();
        output.Write(headerBytes);
        _position += headerBytes.Length;
    }

    internal void WriteBody(PdfPages pages)
    {
        var pagesBytes = pages.GetBytes();
        output.Write(pagesBytes);
        _position += pagesBytes.Length;
        OnObjectWritten?.Invoke(this, (pages.ObjectNumber, _position));

        foreach (IndirectObject<PdfObject> pageKid in pages.GetKids())
        {
            WriteObject(pageKid);
        }
    }

    private void WriteObject(IndirectObject<PdfObject> pdfObject)
    {
        var pdfObjectBytes = pdfObject.GetBytes();
        output.Write(pdfObjectBytes);
        _position += pdfObjectBytes.Length;
        OnObjectWritten?.Invoke(this, (pdfObject.ObjectNumber, _position));
    }

    internal void WriteXrefTable(PdfFileXrefTable xref)
    {
        _xrefPosition = _position;
        var xrefBytes = xref.GetBytes();
        output.Write(xrefBytes);
        _position += xrefBytes.Length;
    }

    internal void WriteTrailer(PdfFileTrailer trailer)
    {

    }

    public void Dispose()
    {
        output.Dispose();
    }
}
