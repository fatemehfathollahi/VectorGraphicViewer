using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Services.Visitor;
public class TriangleVisitor : ShapeVisitorBase
{

    public override void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}