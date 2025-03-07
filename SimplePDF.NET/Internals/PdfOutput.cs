using SimplePDF.NET.Internals.FileStructure;
using SimplePDF.NET.Internals.Objects;
using SimplePDF.NET.Utilities;

namespace SimplePDF.NET.Internals
{
    internal class PdfOutput : IDisposable
    {
        internal event EventHandler<long> OnObjectWritten = default!;

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

        internal void WriteHeader(PdfFileHeader header)
        {
            var headerBytes = header.GetBytes();
            output.Write(headerBytes);
            _position += headerBytes.Length;
        }

        internal void WriteBody(PdfFileBody body)
        {

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

        private void WriteObject(PdfObject pdfObject)
        {
            //get bytes and write to stream
            //emit ObjectWritten event to cross ref table with object byte offset position
            OnObjectWritten?.Invoke(this, _position);
        }

        public void Dispose()
        {
            output.Dispose();
        }
    }
}
