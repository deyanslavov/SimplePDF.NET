namespace SimplePDF.NET.Helpers;

public static class ByteHelper
{
    public static byte[] GetBytes(string text) => text.Select(c => (byte)c).ToArray();

    public static byte GetBytes(bool value) => Convert.ToByte(value);
}