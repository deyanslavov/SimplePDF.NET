using SimplePDF.NET.Internals.Objects;

namespace SimplePDF.NET.Internals.DocumentStructure
{
    internal class PdfPage : PdfWrapper<DictionaryObject>
    {
        //private int _pageNumber;
        private PdfPages? _parent;

        internal PdfPage() : base(new DictionaryObject())
        {

        }

        internal int PageNumber { get; set; }

        internal void AssignParent(PdfPages parent) => _parent = parent;
    }
}
