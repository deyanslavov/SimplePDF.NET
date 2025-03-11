namespace SimplePDF.NET.Internals.Objects;

/// <summary>
/// The core part of a PDF file is a collection of “things” that the PDF standard (ISO 32000) refers to as objects
/// </summary>
internal abstract class PdfObject
{
    internal T As<T>() where T: PdfObject
    {
        var self = this;

        return self is T tObj ? tObj :
            throw new ArgumentException($"{GetType().FullName} is not assignable to {typeof(T).FullName}");
    }

    /// <summary>
    /// Gets this <see cref="PdfObject"/>'s byte representation
    /// </summary>
    /// <returns></returns>
    internal abstract byte[] GetBytes();

    /// <summary>
    /// Returns the human readable representation of a pdf object
    /// </summary>
    /// <returns></returns>
    public abstract override string ToString();
}
