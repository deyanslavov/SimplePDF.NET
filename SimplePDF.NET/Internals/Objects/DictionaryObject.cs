namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// As it serves as the basis for almost every higher-level object, the most common object in PDF is the dictionary object. 
    /// It is a collection of key/value pairs, also known as an associative table. Each key is always a name object, 
    /// but the value may be any other type of object, including another dictionary or even null.
    /// <para>When the value is null, it is treated as if the key is not present. Therefore, it is better to simply not write the key, to save processing time and file size.</para>
    /// <para>A dictionary is enclosed in double angle brackets (&lt;&lt; and &gt;&gt;). Within those brackets, the keys may appear in any order, 
    /// followed immediately by their values. Which keys appear in the dictionary will be determined by the definition (in ISO 32000) of the higher-level object that is being authored.</para>
    /// <para>While many existing implementations tend to write the keys sorted alphabetically, that is neither required nor expected. 
    /// In fact, no assumptions should be made about dictionary processing, either — the keys may be read and processed in any order.
    /// A dictionary that contains the same key twice is invalid, and which value is selected is undefined.</para>
    /// 
    /// </summary>
    internal class DictionaryObject : PdfObject
    {
        //NOTE to consider: name trees and number tree
    }
}
