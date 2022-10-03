using System;
using SimplePDF.NET.Utilities;

namespace SimplePDF.NET.Internals
{
    internal class PdfWriter
    {
        internal static readonly byte[] OBJ = ByteHelper.GetBytes(" obj\n");

        internal static readonly byte[] ENDOBJ = ByteHelper.GetBytes("\nendobj\n");

        internal static readonly byte[] EOL = ByteHelper.GetBytes("\n");

        public PdfWriter()
        {
        }
    }
}

