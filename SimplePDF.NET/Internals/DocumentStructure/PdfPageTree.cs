namespace SimplePDF.NET.Internals.DocumentStructure
{
    /// <summary>
    /// The pages in a PDF are accessed through the page tree, which defines the ordering of the pages. 
    /// The page tree is usually implemented as a balanced tree but can also be just a simple array of pages.
    /// <para>There are two types of nodes in the page tree: intermediate nodes (of type Pages) and terminal or leaf nodes (of type Page). 
    /// <list type="number">
    /// <item>Intermediate nodes, which include the starting node of the tree, provide indirect references to their parents (if any) and children, 
    /// along with a count of the leaf nodes in their particular branches of the tree.</item>
    /// <item>The leaf node is the actual Page object.</item>
    /// </list></para>
    /// </summary>
    internal class PdfPageTree
    {

    } 
}
