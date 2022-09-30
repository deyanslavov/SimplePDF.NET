namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// A name object in PDF is a unique sequence of characters (except character code 0, ASCII null) normally used in situations where there is a fixed set of values.
    /// <para>Names are written into a PDF with a / (SOLIDUS) character followed by a UTF-8 string, with a special encoding form for any nonregular character. 
    /// Nonregular characters are those defined to be outside the range of 0x21 (!) through 0x7E (~), as well as any white-space character. 
    /// These nonregular characters are encoded starting with a # (NUMBER SIGN) and then the two-digit hexadecimal code for the character.</para>
    /// <para>Because of their unique nature, most names that you will write into a PDF are predefined in ISO 32000 
    /// or will be derived from external data (such as a font or color name).</para>    
    /// </summary>
    internal class NameObject : PdfObject
    {
    }
}
