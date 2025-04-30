using SimplePDF.NET.Helpers;
using SimplePDF.NET.Internals.Objects;
using SimplePDF.NET.Internals.Tokens;

namespace SimplePDF.NET.Internals.DocumentStructure;

/// <summary>
/// A PDF document is a collection of objects, starting with the Root object. The reason that it is called the root is that 
/// if you think of the objects in a PDF as a tree (or a directed graph), this object is at the root of the tree/graph. 
/// From this object, you can find all the other objects that are needed to process the pages of the PDF and their content.
/// <para>The Root is always an object of type Catalog and is known as the document’s catalog dictionary. It has two required keys:
/// <list type="number">
/// <item>Type, whose value will always be the name object Catalog.</item>
/// <item>Pages, whose value is an indirect reference to the page tree.</item>
/// </list></para>
/// </summary>
internal class PdfCatalog : IndirectObject<DictionaryObject>
{
    //TODO: Metadata, AcroForm, ViewerPreferences and other properties to be added..

    internal PdfPageTree PageTree { get; }

    internal PdfCatalog() : base(new DictionaryObject())
    {
        PageTree = new PdfPageTree();

        Object.Add(NameObject.Type, new NameObject("Catalog")); 
    }


    internal override byte[] GetBytes()
    {
        return
            [
            ..ByteHelper.GetBytes(ObjectNumber.ToString()),
            ..Whitespaces.SPACE,
            ..ByteHelper.GetBytes(GenerationNumber.ToString()),
            ..PdfWriter.OBJ,
            ..Object.GetBytes(),
            ..PdfWriter.ENDOBJ,
            ];
    }
}
