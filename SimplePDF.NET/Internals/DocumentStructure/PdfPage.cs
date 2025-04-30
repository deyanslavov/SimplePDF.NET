using SimplePDF.NET.Internals.Objects;

namespace SimplePDF.NET.Internals.DocumentStructure;

internal class PdfPage : IndirectObject<DictionaryObject>
{
    //private int _pageNumber;
    private PdfPages? _parent;

    internal PdfPage() : base(new DictionaryObject())
    {
        Object.Add(NameObject.Type, NameObject.Page);
    }

    internal int PageNumber { get; set; }

    internal void AssignParent(PdfPages parent)
    {
        _parent = parent;
        Object.Add(NameObject.Parent, _parent);
    }

    internal void AssignContents(PdfObject content)
    {
        Object.Add(new NameObject("Contents"), new IndirectObject<PdfObject>(content));
    }
}
