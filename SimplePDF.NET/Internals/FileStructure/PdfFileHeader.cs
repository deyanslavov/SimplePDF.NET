namespace SimplePDF.NET.Internals.FileStructure
{
    /// <summary>
    /// The header of a PDF starts at byte 0 of the file and consists of at least 8 bytes followed by an end-of-line marker. 
    /// These 8 bytes serve to clearly identify that the file is a PDF (%PDF-) and suggest a version number of the standard that the file complies with (e.g., 1.4).
    /// <para>If your PDF contains actual binary data (and these days, pretty much all of them do) a second line will follow,
    /// which also starts with the PDF comment character, % (PERCENT SIGN). Following the % on the second line will be at least four characters 
    /// whose ASCII values are greater than 127. Although any four (or more) values are fine, the most commonly used are âãÏÓ (0xE2E3CFD3).</para>
    /// <para>NOTE: The second line is there to trick programs that do ASCII vs. binary detection by simply counting high-order ASCII values.
    /// Including those values ensures that PDFs will always be considered as binary.</para>
    /// </summary>
    internal class PdfFileHeader
    {

    }
}
