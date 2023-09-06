using System.Windows.Controls;

namespace VectorGraphicViewer.Contract;

public interface IShapeFactory
{
    void Draw(Canvas canvas, double zoomLevel = 1.0);
}