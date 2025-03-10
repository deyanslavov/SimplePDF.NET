﻿namespace SimplePDF.NET.Internals.Objects
{
    /// <summary>
    /// PDF supports two different types of numeric objects—integer and real—representing their mathematical equivalents.
    /// </summary>
    internal class NumericObject : PdfObject
    {
        private double _value;//this can hold integers, doubles, floats, longs, shorts

        internal override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }
    }
}
