namespace SimplePDF.NET.Internals
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

    }
}
