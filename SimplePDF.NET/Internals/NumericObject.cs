namespace SimplePDF.NET.Internals
{
    /// <summary>
    /// PDF supports two different types of numeric objects—integer and real—representing their mathematical equivalents.
    /// </summary>
    internal class NumericObject : PdfObject
    {
        private double _value;//this can hold integers, doubles, floats, longs, shorts
    }
}
