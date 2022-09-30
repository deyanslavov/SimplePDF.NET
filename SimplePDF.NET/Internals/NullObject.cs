namespace SimplePDF.NET.Internals
{
    /// <summary>
    /// The null object, if actually written to a file, is simply the four characters null. 
    /// It is synonymous with a missing value, which is why it’s extremely rare to see one in a PDF. 
    /// <para>If you have reason to work with the null value, be sure to consult ISO 32000 carefully about the subtleties involving its handling.</para>
    /// </summary>
    internal class NullObject : PdfObject
    {

    }
}
