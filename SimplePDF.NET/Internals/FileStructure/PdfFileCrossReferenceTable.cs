namespace SimplePDF.NET.Internals.FileStructure
{
    /// <summary>
    /// The cross-reference table is simple in concept and implementation, but it is one of the core attributes of PDF. 
    /// This table provides the binary offset from the beginning of the file for each and every indirect object in the file, 
    /// allowing a PDF processor to quickly seek to and then read any object at any time. 
    /// This model for random access means that a PDF can be opened and processed quickly, without having to load the entire document into memory.
    /// <para>Additionally, navigation between pages is quick, regardless of how large the “numeric jump” in the page numbers is.
    /// Having the cross-reference table at the end of the file also provides two additional benefits: 
    /// creation of the PDF in a single pass (no backtracking) is possible, and support for incremental updates of the document is facilitated.</para>
    /// </summary>
    internal class PdfFileCrossReferenceTable
    {

    }
}
