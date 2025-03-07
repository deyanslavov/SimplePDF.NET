using SimplePDF.NET.Utilities;

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
    internal class NameObject : PdfObject, IComparable<NameObject>
    {
        //A name object is an atomic symbol uniquely defined by a sequence of characters.
        //Uniquely defined means that any two name objects made up of the same sequence
        //of characters are identically the same object. Atomic means that a name has no
        //internal structure; although it is defined by a sequence of characters, those
        //characters are not considered elements of the name.

        //A slash character (/) introduces a name.The slash is not part of the name but is a
        //prefix indicating that the following sequence of characters constitutes a name.
        //There can be no white-space characters between the slash and the first character
        //in the name.The name may include any regular characters, but not delimiter or
        //white-space characters. Uppercase and lowercase letters are considered distinct:
        //A and /a are different names.The following examples are valid literal names:

        // /Name1
        // /ASomewhatLongerName
        // /A;Name_With−Various*** Characters?
        // /1.2
        // /$$
        // /@pattern
        // /.notdef
        //Note: The token / (a slash followed by no regular characters) is a valid name.

        //Beginning with PDF 1.2, any character except null (character code 0) may be
        //included in a name by writing its 2-digit hexadecimal code, preceded by the number sign character(#).
        //This syntax is required to represent any of the delimiter or white-space characters
        //or the number sign character itself; it is recommended but not required for 
        //characters whose codes are outside the range 33 (!) to 126 (~). Examples:

        // LITERAL NAME               RESULT
        // /Adobe#20Green             Adobe Green
        // /PANTONE#205757#20CV       PANTONE 5757 CV
        // /paired#28#29parentheses   paired()parentheses
        // /The_Key_of_F#23_Minor     The_Key_of_F#_Minor
        // /A#42                      AB

        //TODO: add more default names
        internal static readonly NameObject Type = new("Type");
        internal static readonly NameObject Kids = new("Kids");
        internal static readonly NameObject Count = new("Count");
        internal static readonly NameObject Page = new("Page");
        internal static readonly NameObject Pages = new("Pages");
        internal static readonly NameObject Parent = new("Parent");
        internal static readonly NameObject Metadata = new("Metadata");
        internal static readonly NameObject PageLabels = new("PageLabels");
        internal static readonly NameObject PageLayout = new("PageLayout");
        internal static readonly NameObject ViewerPreferences = new("ViewerPreferences");

        private readonly string _name;

        internal NameObject(string name)
        {
            _name = name;
        }

        internal override byte[] GetBytes()
        {
            return ByteHelper.GetBytes($"\\{_name}");
        }

        public int CompareTo(NameObject? other)
        {
            if (other == this)
            {
                return 0;
            }

            return _objectNumber > other?.GetObjectNumber() ? 1 : -1;
        }        
    }
}
