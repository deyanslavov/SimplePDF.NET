using SimplePDF.NET.Internals.DocumentStructure;

namespace SimplePDF.NET.Internals.FileStructure;

internal class PdfFile
{
    private bool _hasBinaryData;
    private readonly PdfCatalog _catalog;
    private readonly PdfFileHeader _header;
    private readonly PdfFileBody _body;
    private readonly PdfFileXrefTable _crossRefTable;
    private readonly PdfFileTrailer _trailer;

    internal PdfFile(PdfFileBody body, PdfFileXrefTable crossRefTable, PdfFileTrailer trailer, bool hasBinaryData)
    {
        _hasBinaryData = hasBinaryData;
        _header = new PdfFileHeader(hasBinaryData);
        _body = body;
        _crossRefTable = crossRefTable;
        _trailer = trailer;
    }

    internal PdfFile(PdfCatalog catalog)
    {
        _hasBinaryData = true;
        _header = new PdfFileHeader(true);
        _catalog = catalog;
        _crossRefTable = new PdfFileXrefTable();
        _trailer = new PdfFileTrailer();
    }

    internal byte[] GetBytes()
    {
        using var output = new PdfOutput();
        output.OnObjectWritten += (_, data) => _crossRefTable.AddObjectRef(data.objectNumber, data.offset, 0, false);

        output.WriteHeader();
        output.WriteBody(_catalog.PageTree.Root);
        output.WriteXrefTable(_crossRefTable);
        output.WriteTrailer(_trailer);

        return output.GetBytes();
    }
}
