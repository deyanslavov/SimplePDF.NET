using SimplePDF.NET.Utilities;

namespace SimplePDF.NET.Internals.Tokens
{
    /// <summary>
    /// The delimiter characters are special. They delimit syntactic entities such as strings, arrays, names, and comments.
    /// Any of these characters terminates the entity preceding it and is not included in the entity. 
    /// <para>All characters except the white-space characters and delimiters are referred to as regular characters. 
    /// These characters include 8-bit binary characters that are outside the ASCII character set. 
    /// A sequence of consecutive regular characters comprises a single token.</para>
    /// </summary>
    internal static class Delimiters
    {
        internal static readonly byte[] LEFT_PARENTHESIS = ByteHelper.GetBytes("(");
        internal static readonly byte[] RIGHT_PARENTHESIS = ByteHelper.GetBytes(")");
        internal static readonly byte[] LEFT_ANGLE_BRACKET = ByteHelper.GetBytes("<");
        internal static readonly byte[] RIGHT_ANGLE_BRACKET = ByteHelper.GetBytes(">");
        internal static readonly byte[] LEFT_SQUARE_BRACKET = ByteHelper.GetBytes("[");
        internal static readonly byte[] RIGHT_SQUARE_BRACKET = ByteHelper.GetBytes("]");
        internal static readonly byte[] LEFT_CURLY_BRACKET = ByteHelper.GetBytes("{");
        internal static readonly byte[] RIGHT_CURLY_BRACKET = ByteHelper.GetBytes("}");
        internal static readonly byte[] FORWARD_SLASH = ByteHelper.GetBytes("/");

        /// <summary>
        /// Any occurrence of the percent sign character (%) outside a string or stream introduces a comment. 
        /// The comment consists of all characters between the percent sign and the end of the line, including regular, delimiter, space, and tab characters. 
        /// PDF ignores comments, treating them as if they were single whitespace characters.
        /// </summary>
        internal static readonly byte[] PERCENT = ByteHelper.GetBytes("%");
    }
}
