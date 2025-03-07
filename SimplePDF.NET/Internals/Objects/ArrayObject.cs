namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// An array object is a heterogeneous collection of other objects enclosed in square brackets ([ and ]) and separated by white space. 
    /// You can mix and match any objects of any type together in a single array, and PDF takes advantage of this in a variety of places. 
    /// An array may also be empty (i.e., contain zero elements).
    /// <para>There is no limit to the number of elements in a PDF array. However, if you find an alternative to a large array 
    /// (such as the page tree for a single Kids array), it is always better to avoid them for performance reasons.</para>
    /// </summary>
    internal class ArrayObject : PdfObject
    {
        private readonly IList<PdfObject> _objects;

        public ArrayObject()
        {
            _objects = [];
        }

        internal void Add(PdfObject pdfObject) => _objects.Add(pdfObject);

        internal override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}
