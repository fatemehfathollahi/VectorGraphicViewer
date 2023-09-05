using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model;
public class Circle : Shape
{
    public Point Center { get; set; } = null!;
    public double Radius { get; set; }
    public bool Filled { get; set; }

    public override void Draw(Canvas canvas, double zoomLevel = 1.0)
    {
        double diameter = 2 * Radius;
        if (diameter >= 100)
            zoomLevel = diameter / 100;
        var circle = new System.Windows.Shapes.Ellipse
        {
            Width = diameter * zoomLevel,
            Height = diameter * zoomLevel,
            Stroke = new SolidColorBrush(Color),
            StrokeThickness = 1
        };

        if (Filled)
        {
            circle.Fill = new SolidColorBrush(Color);
        }

        Canvas.SetLeft(circle, Center.X - Radius);
        Canvas.SetTop(circle, Center.Y - Radius);
        canvas.Children.Add(circle);
    }
}