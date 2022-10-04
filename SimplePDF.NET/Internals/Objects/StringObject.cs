namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// Strings as they are serialized into PDF are simply series of (zero or more) 8-bit bytes written either as literal characters enclosed in parentheses, 
    /// ( and ), or hexadecimal data enclosed in angle brackets &lt; and &gt;.
    /// <para>A literal string consists of an arbitrary number of 8-bit characters enclosed in parentheses. 
    /// Because any 8-bit value may appear in the string, the unbalanced parentheses ( ) ) and the backslash (\) are treated specially 
    /// through the use of the backslash to escape special values. Additionally, the backslash can be used with the special \ddd notation to specify other character values.</para>
    /// <para>Literal strings come in a few different varieties: ASCII, PDFDocEncoded, Text, Date. Refer to ISO 32000 for further explanation.</para>
    /// </summary>
    internal class StringObject : PdfObject
    {
        //NOTE: consider creating child classes for LiteralStringObject and HexadecimalStringObject
    }
}
