namespace SimplePDF.NET.Internals
{
    /// <summary>
    /// Indirect objects are those that are referred to (indirectly!) by reference and a PDF reader will have to jump around the file to find the actual value. 
    /// In order to identify which object is being referred to, every indirect object has a unique (per-PDF) ID, which is expressed as a positive number, 
    /// and a generation number, which is always a nonnegative number and usually zero (0). These numbers are used both to define the object and to reference the object.
    /// </summary>
    internal class IndirectObject : PdfObject
    {

    }
}
