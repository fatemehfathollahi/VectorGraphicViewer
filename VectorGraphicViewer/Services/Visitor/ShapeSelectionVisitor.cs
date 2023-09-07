using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Services.Visitor;
public class ShapeSelectionVisitor : IShapeVisitor
{
    public void Visit(CircleVisitor circle)
    {
        throw new System.NotImplementedException();
    }

    public void Visit(LineVisitor line)
    {
        throw new System.NotImplementedException();
    }

    public void Visit(TriangleVisitor triangle)
    {
        throw new System.NotImplementedException();
    }
}