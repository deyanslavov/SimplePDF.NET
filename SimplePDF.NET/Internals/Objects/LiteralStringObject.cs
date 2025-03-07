using SimplePDF.NET.Utilities;

namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// A literal string is written as an arbitrary number of characters enclosed in parentheses. 
    /// Any characters may appear in a string except unbalanced parentheses and the backslash, which must be treated specially. 
    /// Balanced pairs of parentheses within a string require no special treatment.
    /// <para>Within a literal string, the backslash (\) is used as an escape character for various purposes, 
    /// such as to include newline characters, nonprinting ASCII characters, unbalanced parentheses, or the backslash character itself in the string.</para>
    /// <para>The character immediately following the backslash determines its precise interpretation (see bullets below).
    /// If the character following the backslash is not one of those shown in the table, the backslash is ignored.</para>
    /// <list type="bullet">
    /// <item>\n - Line feed (LF)</item>
    /// <item>\r - Carriage return (CR)</item>
    /// <item>\t - Horizontal tab (HT)</item>
    /// <item>\b - Backspace (BS)</item>
    /// <item>\f - Form feed (FF)</item>
    /// <item>\( - Left parenthesis</item>
    /// <item>\) - Right parenthesis</item>
    /// <item>\\ - Backslash</item>
    /// <item>\ddd - Character code ddd (octal)</item>
    /// </list>
    /// </summary>
    internal class LiteralStringObject : StringObject
    {
        //The following are valid literal strings: 

        //1. (This is a string)
        //2. (Strings may contain newlines
        //and such.)
        //3. (Strings may contain balanced parentheses() and
        //special characters(*!&}^% and so on).)
        //4. (The following is an empty string.)
        //5. ()
        //6. (It has zero(0) length.

        //If a string is too long to be conveniently placed on a single line, it may be split
        //across multiple lines by using the backslash character at the end of a line to
        //indicate that the string continues on the following line.The backslash and the
        //end-of-line marker following it are not considered part of the string. For example: 
        //1. (These \
        //two strings \
        //are the same.)
        //2. (These two strings are the same.)

        //If an end-of-line marker appears within a literal string without a preceding
        //backslash, the result is equivalent to \n(regardless of whether the end-of-line
        //marker was a carriage return, a line feed, or both). For example: 
        //(This string has an end−of−line at the end of it.
        //)
        //(So does this one.\n)

        private readonly string _content;

        internal LiteralStringObject(string text)
            : base(ByteHelper.GetBytes(text))
        {
            _content = text;
        }

        internal string GetText() => _content;
    }
}
