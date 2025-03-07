using SimplePDF.NET.Internals.Objects;

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
        private readonly PdfPages _root;
        private readonly IList<IndirectObject> _pageRefs;
        private readonly IList<PdfPage> _pages;
        private readonly IList<PdfPages> _parents;
        private readonly PdfSettings _settings;

        internal PdfPageTree()
        {
            _pageRefs = new List<IndirectObject>();
            _pages = new List<PdfPage>();
            _root = new PdfPages(null);
            _parents = new List<PdfPages>();
            _parents.Add(_root);
            _settings = new PdfSettings();
        }

        /// <summary>
        /// Gets a page by its number (1-based index)
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        internal PdfPage? GetPage(int pageNumber)
        {
            //validate page number
            if (!_pages.Any())
            {
                throw new ArgumentException($"Page list is empty.");
            }
            if (pageNumber <= 0 || pageNumber - 1 > _pages.Count)
            {
                throw new ArgumentException($"Page number (1-based) must be greater than or equal to 1 and less than or equal the total number of pages.");
            }

            var pageIndex = pageNumber - 1;
            return _pages.ElementAtOrDefault(pageIndex);
        }

        internal void AddPage(PdfPage page)
        {
            PdfPages pdfPages;
            //TODO: revise at later point regarding page tree structure
            //if (_root != null)
            //{
            //    // in this case we save tree structure
            //    if (_pageRefs.Count == 0)
            //    {
            //        pdfPages = _root;
            //    }
            //    else
            //    {
            //        //LoadPage(pageRefs.Count - 1);
            //        pdfPages = _parents[_parents.Count - 1];
            //    }
            //}
            //else
            //{
            pdfPages = _parents[_parents.Count - 1];
            if (pdfPages.GetChildrenCount() % _settings.MaxLeafSize == 0 && _pages.Count > 0)
            {
                pdfPages = new PdfPages(null);//TODO: check null?
                _parents.Add(pdfPages);
            }
            //}

            page.PageNumber = _pages.Count + 1;
            pdfPages.AddPage(page);
            //_pageRefs.Add(page.GetUnderlyingPdfObject().AsIndirectReference());
            _pages.Add(page);
        }
    }
}
