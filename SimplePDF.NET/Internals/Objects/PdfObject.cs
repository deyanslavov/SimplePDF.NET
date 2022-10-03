namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// The core part of a PDF file is a collection of “things” that the PDF standard (ISO 32000) refers to as objects
    /// </summary>
    internal abstract class PdfObject
    {
        protected int _objectNumber;

        protected int _generationNumber;

        protected long _byteOffsetPosition;

        /// <summary>
        /// Gets the object's number
        /// </summary>
        /// <returns></returns>
        internal int GetObjectNumber() => _objectNumber;

        /// <summary>
        /// Gets the object's generation number
        /// </summary>
        /// <returns></returns>
        internal int GetGenerationNumber() => _generationNumber;
    }
}
