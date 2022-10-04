using System.Text;
using SimplePDF.NET.Utilities;

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
    internal class PdfFileXrefTable
    {
        private IList<CrossReference> _entries = new List<CrossReference>();

        internal void AddObjectRef(long offset, int generationNumber, bool isFree)
        {
            _entries.Add(new CrossReference(offset, generationNumber, isFree));
        }

        internal byte[] GetBytes()
        {
            var defaultXrefEntry = $"xref\n0 {_entries.Count}\n0000000000 65535 f\n";
            var stringBuilder = new StringBuilder();

            //Append xref defaults
            //xref
            //0 objects count
            //0000000000 65535 f
            stringBuilder.Append(defaultXrefEntry);

            foreach (var entry in _entries)
            {
                //append each entry in format 'nnnnnnnnnn ggggg n eol'
                stringBuilder.Append(entry.ToString());
            }

            return ByteHelper.GetBytes(stringBuilder.ToString());
        }

        /// <summary>
        /// Each entry is exactly 20 bytes long, including the end-of-line marker. There are two kinds of cross-reference entries: one for objects that are in use
        /// and another for objects that have been deleted and therefore are free. Both types of entries have similar basic formats, distinguished by
        /// the keyword n (for an in-use entry) or f (for a free entry). The format of an in-use entry is:
        /// <c>nnnnnnnnnn ggggg n eol</c> where
        /// <list type="bullet">
        ///<item><c>nnnnnnnnnn</c> is a 10-digit byte offset</item>
        ///<item><c>ggggg</c> is a 5-digit generation number</item>
        ///<item><c>n</c> is a literal keyword identifying this as an in-use/free entry</item>
        ///<item><c>eol</c> is a 2-character end-of-line sequence</item>
        /// </list>
        /// </summary>
        private class CrossReference
        {
            public CrossReference(long byteOffset, int generationNumber, bool isFree)
            {
                ByteOffset = byteOffset;
                GenerationNumber = generationNumber;
                IsFree = isFree;
            }

            public long ByteOffset { get; }

            public int GenerationNumber { get; }

            public bool IsFree { get; set; }

            public override string ToString()
            {
                return $"{ByteOffset,10} {GenerationNumber,5} {(IsFree ? "f \n" : "n \n")} ";
            }
        }
    }
}
