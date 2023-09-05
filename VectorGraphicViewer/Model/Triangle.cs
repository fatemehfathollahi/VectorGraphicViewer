using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model;
public class Triangle : Shape
{
    public Triangle(Point a, Point b, Point c, bool filled, Color color)
    {
        A = a;
        B = b;
        C = c;
        Filled = filled;
        Color = color;
    }
    public Point A { get; init; } = null!;
    public Point B { get; init; } = null!;
    public Point C { get; init; } = null!;
    public bool Filled { get; init; }

    public override void Draw(Canvas canvas, double zoomLevel = 1.0)
    {
        var polygon = new System.Windows.Shapes.Polygon
        {
            Points = new PointCollection { new System.Windows.Point(A.X, A.Y), 
                new System.Windows.Point(B.X, B.Y), 
                new System.Windows.Point(C.X, C.Y) },
            Stroke = new SolidColorBrush(Color),
            StrokeThickness = 1
        };

        if (Filled)
        {
            polygon.Fill = new SolidColorBrush(Color);
        }

        canvas.Children.Add(polygon);
    }
}