using SimplePDF.NET.Internals.DocumentStructure;

Console.WriteLine("Hello, World!");
var tree = new PdfPageTree();
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
Console.ReadKey();