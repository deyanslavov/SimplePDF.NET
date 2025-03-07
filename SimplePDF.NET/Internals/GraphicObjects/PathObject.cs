using System.Security.AccessControl;

namespace SimplePDF.NET.Internals.GraphicObjects
{
    /// <summary>
    /// A path object consists of a sequence of connected and disconnected points, lines, and curves that together describe shapes and their positions. 
    /// It is built up through the sequential application of path construction operators, each of which appends one or more new elements. 
    /// The path object is ended by a path-painting operator, which paints the path on the page in some way. The principal path painting operators are S (stroke), 
    /// which paints a line along the path, and f (fill), which paints the interior of the path.
    /// </summary>
    internal class PathObject
    {
    }
}
