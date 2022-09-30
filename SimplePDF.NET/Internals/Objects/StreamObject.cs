namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// Streams in PDF are arbitrary sequences of 8-bit bytes that may be of unlimited length and can be compressed or encoded. 
    /// As such, they are the object type used to store large blobs of data that are in some other standardized format, such as XML grammars, font files, and image data.
    /// <para>A stream object is represented by the data for the object preceded by a dictionary containing attributes of the stream and referred to as the stream dictionary. 
    /// The use of the words stream (followed by an end-of-line marker) and endstream (preceded by an end-of-line marker) serve to delineate the stream data from its dictionary,
    /// while also differentiating it from a standard dictionary object. The stream dictionary never exists on its own; it is always a part of the stream object.</para>
    /// <para>The stream dictionary always contains at least one key, Length, which represents the number of bytes from the beginning of the line following stream 
    /// until the last byte before the end-of-the-line character preceding endstream. In other words, it is the actual number of bytes serialized into the PDF file.
    /// In the case of a compressed stream, it is the number of compressed bytes. Although not commonly provided, 
    /// the original uncompressed length can be specified as the value of a DL key.</para>
    /// </summary>
    internal class StreamObject : PdfObject
    {

    }
}
