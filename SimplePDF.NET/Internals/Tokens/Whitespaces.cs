namespace SimplePDF.NET.Internals.Tokens
{
    /// <summary>
    /// The carriage return (CR) and line feed (LF) characters, also called newline characters, are treated as end-of-line (EOL) markers. 
    /// The combination of a carriage return followed immediately by a line feed is treated as one EOL marker. For the most part,
    /// EOL markers are treated the same as any other white-space characters. However, sometimes an EOL marker is required or recommended — that is, 
    /// the following token must appear at the beginning of a line.
    /// </summary>
    internal static class Whitespaces
    {
        internal static readonly byte[] NULL = new byte[] { 0x00 };
        internal static readonly byte[] TAB = new byte[] { 0x09 };
        internal static readonly byte[] LINE_FEED = new byte[] { 0x0A };
        internal static readonly byte[] FORM_FEED = new byte[] { 0x0C };
        internal static readonly byte[] CARRIAGE_RETURN = new byte[] { 0x0D };
        internal static readonly byte[] SPACE = new byte[] { 0x20 };
    }
}
