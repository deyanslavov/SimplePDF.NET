namespace SimplePDF.NET.Internals.DocumentStructure;

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
    private PdfPages _currentPagesNode;
    private readonly PdfPages _root;
    private readonly IList<PdfPage> _pages;
    private readonly PdfSettings _settings;

    internal PdfPages Root => _root;

    internal PdfPageTree()
    {
        _settings = new PdfSettings();

        _pages = [];
        _root = new PdfPages(null);

        PdfPages firstPagesNode = new(_root);
        _root.Add(firstPagesNode);
        _currentPagesNode = firstPagesNode;
    }

    /// <summary>
    /// Gets a page by its number (1-based index)
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    internal PdfPage GetPage(int pageNumber)
    {
        if (!_pages.Any())
        {
            throw new ArgumentException($"Page list is empty.");
        }

        if (pageNumber < 1)
        {
            throw new ArgumentException($"Page number (1-based) must be greater than or equal to 1.");
        }

        if (pageNumber > _pages.Count)
        {
            throw new ArgumentException($"Page number is invalid.");
        }

        return _pages[pageNumber - 1];
    }

    internal void AddPage(PdfPage page)
    {
        bool maxLeafSizeReached = _currentPagesNode.GetChildrenCount() == _settings.MaxLeafSize;
        if (maxLeafSizeReached)
        {
            PdfPages newPagesNode = new(_root);
            _root.Add(newPagesNode);
            _currentPagesNode = newPagesNode;
        }

        page.PageNumber = _pages.Count + 1;
        page.AssignParent(_currentPagesNode);
        _currentPagesNode.Add(page);
        _pages.Add(page);
    }
}
