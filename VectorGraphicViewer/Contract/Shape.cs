using System.Windows.Controls;
using System.Windows.Media;

namespace VectorGraphicViewer.Contract;
public abstract class Shape
{
    public Color Color { get; set; }
    public abstract void Draw(Canvas canvas, double zoomLevel = 1.0);
}