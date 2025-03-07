namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// A hexadecimal string is written as a sequence of hexadecimal digits (0–9 and either A–F or a–f) enclosed within angle brackets (&lt; and &gt;):
    /// <list type="bullet">
    /// <item>&lt;4E6F762073686D6F7A206B6120706F702E&gt;</item>
    /// </list>
    /// <para>Each pair of hexadecimal digits defines one byte of the string. 
    /// White-space characters (such as space, tab, carriage return, line feed, and form feed) are ignored.</para>
    /// <para>If the final digit of a hexadecimal string is missing—that is, if there is an odd number of digits—the final digit is assumed to be 0. 
    /// For example: &lt;901FA3&gt; is a 3-byte string consisting of the characters whose hexadecimal codes are 90, 1F, and A3, but &lt;901FA&gt;
    /// is a 3-byte string containing the characters whose hexadecimal codes are 90, 1F, and A0.</para>
    /// </summary>
    internal class HexadecimalStringObject : StringObject
    {
        //TODO: implement
        internal HexadecimalStringObject(byte[] contentBytes) : base(contentBytes)
        {
        }
    }
}
