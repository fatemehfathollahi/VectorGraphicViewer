using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model;
public class Line : Shape, IShapeFactory
{
    public Line(Point a, Point b, Color color)
    {
        A = a;
        B = b;
        Color = color;
    }
    public Point A { get; init; } = null!;
    public Point B { get; init; } = null!;

    public void Draw(Canvas canvas, double zoomLevel = 1.0)
    {
        var line = new System.Windows.Shapes.Line
        {
            X1 = A.X,
            Y1 = A.Y,
            X2 = B.X,
            Y2 = B.Y,
            Stroke = new SolidColorBrush(Color),
            StrokeThickness = 1
        };
        canvas.Children.Add(line);
    }
}