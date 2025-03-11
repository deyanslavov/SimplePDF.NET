using SimplePDF.NET.Helpers;
using System.Globalization;

namespace SimplePDF.NET.Internals.Objects;

/// <summary>
/// PDF supports two different types of numeric objects—integer and real—representing their mathematical equivalents.
/// </summary>
internal class NumericObject : PdfObject
{
    private readonly bool isInteger = false;
    private readonly double _value;//this can hold integers, doubles, floats, longs, shorts

    internal NumericObject(long value)
        : this(Convert.ToDouble(value))
    {
        isInteger = true;
    }

    internal NumericObject(int value)
        : this(Convert.ToDouble(value))
    {
        isInteger = true;
    }

    internal NumericObject(double value)
    {
        _value = value;
    }

    internal override byte[] GetBytes()
    {
        return ByteHelper.GetBytes(ToString());
    }

    public override string ToString()
    {
        return isInteger
            ? _value.ToString("F0", CultureInfo.InvariantCulture)
            : _value.ToString();
    }
}
