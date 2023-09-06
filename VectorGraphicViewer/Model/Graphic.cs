using System.Windows.Media;

namespace VectorGraphicViewer.Model;
public class Graphic
{
    public Graphic(string type, Point a, Point b, Point c, Point center, double radius, bool filled, Color color)
    {
        Type = type;
        A = a;
        B = b;
        C = c;
        Center = center;
        Radius = radius;
        Filled = filled;
        Color = color;
    }
    public string Type { get; init; } = null!;
    public Point A { get; init; } = null!;
    public Point B { get; init; } = null!;
    public Point C { get; init; } = null!;
    public Point Center { get; init; } = null!;
    public double Radius { get; init; }
    public bool Filled { get; init; }
    public Color Color { get; init; }
}