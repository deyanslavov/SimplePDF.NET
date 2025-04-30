namespace SimplePDF.NET.Internals;

internal static class ObjectNumberGenerator
{
    private static int ObjNumber { get; set; } = 0;

    internal static int New()
    {
        return ++ObjNumber;
    }
}

