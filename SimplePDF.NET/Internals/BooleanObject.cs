namespace SimplePDF.NET.Internals
{
    /// <summary>
    /// Boolean objects represent the logical values of true and false and are represented ac‐ cordingly in the PDF, either as true or false.
    /// <para>When writing a PDF, you will always use true or false. However, if you are reading/parsing a PDF and wish to be tolerant, 
    /// be aware that poorly written PDFs may use other capatilization forms, including leading caps (True or False) or all caps (TRUE or FALSE).</para>
    /// </summary>
    internal class BooleanObject : PdfObject
    {

    }
}
