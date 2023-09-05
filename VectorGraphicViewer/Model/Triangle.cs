using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model;
public class Triangle : Shape
{
    public Point A { get; set; } = null!;
    public Point B { get; set; } = null!;
    public Point C { get; set; } = null!;
    public double Radius { get; set; }
    public bool Filled { get; set; }

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