namespace SimplePDF.NET.Internals.FileStructure
{
    internal class PdfFile
    {
        private readonly PdfFileHeader _header;
        private readonly PdfFileBody _body;
        private readonly PdfFileCrossReferenceTable _crossRefTable;
        private readonly PdfFileTrailer _trailer;
    }
}
