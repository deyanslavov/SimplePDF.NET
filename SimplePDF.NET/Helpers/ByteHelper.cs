using System;
namespace SimplePDF.NET.Utilities
{
    public static class ByteHelper
    {
        public static byte[] GetBytes(string text) => text.Select(c => (byte)c).ToArray();
    }
}

