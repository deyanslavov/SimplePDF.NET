using SimplePDF.NET.Internals.Objects;

namespace SimplePDF.NET.Internals
{
    internal class PdfWrapper<T> where T : PdfObject
    {
        private readonly T _underlyingValue;

        protected internal PdfWrapper(T value)
        {
            _underlyingValue = value;
        }

        internal T GetUnderlyingPdfObject() => _underlyingValue;
    }
}
