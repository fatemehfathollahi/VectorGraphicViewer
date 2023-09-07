using VectorGraphicViewer.Contract;

namespace VectorGraphicViewer.Services.Visitor;
public class LineVisitor : ShapeVisitorBase
{

    public override void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}