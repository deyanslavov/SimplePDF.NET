namespace SimplePDF.NET.Internals.FileStructure
{
    internal class PdfFile
    {
        private bool _hasBinaryData;
        private readonly PdfFileHeader _header;
        private readonly PdfFileBody _body;
        private readonly PdfFileXrefTable _crossRefTable;
        private readonly PdfFileTrailer _trailer;

        public PdfFile(PdfFileBody body, PdfFileXrefTable crossRefTable, PdfFileTrailer trailer, bool hasBinaryData)
        {
            _hasBinaryData = hasBinaryData;
            _header = new PdfFileHeader(hasBinaryData);
            _body = body;
            _crossRefTable = crossRefTable;
            _trailer = trailer;
        }

        internal byte[] GetBytes()
        {
            using var output = new PdfOutput();
            output.OnObjectWritten += (_, offset) => _crossRefTable.AddObjectRef(offset, 0, false);

            output.WriteHeader(_header);
            output.WriteBody(_body);
            output.WriteXrefTable(_crossRefTable);
            output.WriteTrailer(_trailer);

            return output.GetBytes();
        }
    }
}
