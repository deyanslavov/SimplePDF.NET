using SimplePDF.NET.Internals.Objects;

namespace SimplePDF.NET.Internals.FileStructure
{
    /// <summary>
    /// The trailer is primarily a dictionary with keys and values that provides document-level information that is necessary to understand in order to process the document itself.
    /// <para>The two most important keys, and the only two that are required, are Size and Root. 
    /// <list type="bullet">
    /// <item>The Size key tells us how many entries you should expect to find in the cross-reference table that precedes the trailer dictionary.</item>
    /// <item>The Root key has as its value the document’s catalog dictionary, which is where you will start in order to find all the objects in the PDF.</item>
    /// </list></para>
    /// </summary>
    internal class PdfFileTrailer
    {
        private DictionaryObject _root = new();
    }
}
