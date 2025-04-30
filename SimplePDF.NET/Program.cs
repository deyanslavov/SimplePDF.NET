using SimplePDF.NET.Helpers;
using SimplePDF.NET.Internals;
using SimplePDF.NET.Internals.DocumentStructure;
using SimplePDF.NET.Internals.FileStructure;
using SimplePDF.NET.Internals.Objects;
using System.Text;


//string pdfText = File.ReadAllText("D:\\pdf as text.txt");
//var bytes = ByteHelper.GetBytes(pdfText);
//File.WriteAllBytes("D:\\pdf as text.pdf", bytes);
//Console.WriteLine("Hello, World!");
//var tree = new PdfPageTree();
//tree.AddPage(new PdfPage());
//tree.AddPage(new PdfPage());
//tree.AddPage(new PdfPage());
//tree.AddPage(new PdfPage());
//tree.AddPage(new PdfPage());
//tree.AddPage(new PdfPage());


var catalog = new PdfCatalog();
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());
catalog.PageTree.AddPage(new PdfPage());

var file = new PdfFile(catalog);
//var bb = pages.GetBytes().Concat(catalog.GetBytes());
Console.ReadKey();