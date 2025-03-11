using SimplePDF.NET.Helpers;
using SimplePDF.NET.Internals.DocumentStructure;
using SimplePDF.NET.Internals.Objects;
using System.Text;


string pdfText = File.ReadAllText("D:\\pdf as text.txt");
var bytes = ByteHelper.GetBytes(pdfText);
File.WriteAllBytes("D:\\pdf as text.pdf", bytes);
Console.WriteLine("Hello, World!");
var tree = new PdfPageTree();
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());
tree.AddPage(new PdfPage());

var n = new NameObject("Tree");
var User = Encoding.UTF8.GetBytes("\\Tree");
var res = n.GetBytes();
Console.ReadKey();