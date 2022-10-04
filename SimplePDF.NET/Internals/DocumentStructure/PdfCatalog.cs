namespace SimplePDF.NET.Internals.DocumentStructure
{
    /// <summary>
    /// A PDF document is a collection of objects, starting with the Root object. The reason that it is called the root is that 
    /// if you think of the objects in a PDF as a tree (or a directed graph), this object is at the root of the tree/graph. 
    /// From this object, you can find all the other objects that are needed to process the pages of the PDF and their content.
    /// <para>The Root is always an object of type Catalog and is known as the document’s catalog dictionary. It has two required keys:
    /// <list type="number">
    /// <item>Type, whose value will always be the name object Catalog.</item>
    /// <item>Pages, whose value is an indirect reference to the page tree.</item>
    /// </list></para>
    /// </summary>
    internal class PdfCatalog
    {
        private readonly PdfPageTree _pageTree;
    }
}
