using SimplePDF.NET.Internals.Objects;

namespace SimplePDF.NET.Internals.DocumentStructure
{
    internal class PdfPages : DictionaryObject
    {
        //Array kids must contain either PdfPage or PdfPages
        private ArrayObject _kids;

        private PdfPages _parent;
    }
}
