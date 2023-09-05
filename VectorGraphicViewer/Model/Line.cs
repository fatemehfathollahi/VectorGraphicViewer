using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Model;
public class Line : Shape
{
    public Point A { get; set; } = null!;
    public Point B { get; set; } = null!;
    public override void Draw(Canvas canvas, double zoomLevel = 1.0)
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