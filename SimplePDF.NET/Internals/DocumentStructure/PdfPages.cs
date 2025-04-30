using SimplePDF.NET.Helpers;
using SimplePDF.NET.Internals.Objects;
using SimplePDF.NET.Internals.Tokens;

namespace SimplePDF.NET.Internals.DocumentStructure;

internal class PdfPages : IndirectObject<DictionaryObject>
{
    private readonly ArrayObject _kids;
    private readonly PdfPages? _parent;

    //TODO: field for total kids count when using tree structure

    public PdfPages(PdfPages? parent) : base(new DictionaryObject())
    {
        _parent = parent;
        _kids = [];

        Object.Add(NameObject.Type, NameObject.Pages);

        if (_parent is not null)
        {
            Object.Add(NameObject.Parent, _parent);
        }
    }

    internal ArrayObject GetKids() => _kids;

    internal int GetChildrenCount() => _kids.Length;

    internal IndirectObject<DictionaryObject> AsIndirect() => this;

    internal void Add(PdfObject obj)
    {
        _kids.Add(obj);
    }

    internal override byte[] GetBytes()
    {
        Object.Add(NameObject.Kids, _kids);
        Object.Add(NameObject.Count, new NumericObject(_kids.Length));

        return
            [
            ..ByteHelper.GetBytes(ObjectNumber.ToString()),
            ..Whitespaces.SPACE,
            ..ByteHelper.GetBytes(GenerationNumber.ToString()),
            ..PdfWriter.OBJ,
            ..Object.GetBytes(),
            ..PdfWriter.ENDOBJ,
            ..GetKidsBytes(),
            ];
    }

    private byte[] GetKidsBytes()
    {
        var memoryStream = new MemoryStream();

        foreach (var kid in _kids)
        {
            memoryStream.Write(kid.GetBytes());
        }

        return memoryStream.ToArray();
    }
}
