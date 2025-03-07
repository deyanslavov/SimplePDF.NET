using SimplePDF.NET.Internals.Objects;

namespace SimplePDF.NET.Internals.DocumentStructure
{
    internal class PdfPages : PdfWrapper<DictionaryObject>
    {
        private int _kidsCount = 0;
        private readonly ArrayObject _kids;
        private readonly PdfPages? _parent;

        public PdfPages(PdfPages? parent) :base(new DictionaryObject())
        {
            _parent = parent;
            _kids = new ArrayObject();

            GetUnderlyingPdfObject().Add(NameObject.Type, NameObject.Pages);
            GetUnderlyingPdfObject().Add(NameObject.Kids, _kids);//kids
            GetUnderlyingPdfObject().Add(NameObject.Count, new NumericObject());

            if(_parent is not null)
            {
                GetUnderlyingPdfObject().Add(NameObject.Parent, _parent.GetUnderlyingPdfObject());
            }
        }

        internal int GetChildrenCount() => _kidsCount;

        internal void AddPage(PdfPage page)
        {
            _kids.Add(page.GetUnderlyingPdfObject());
            page.AssignParent(this);
            IncrementChildrenCount();
        }

        internal void IncrementChildrenCount()
        {
            _kidsCount++;
            _parent?.IncrementChildrenCount();
        }
    }
}
