namespace VectorGraphicViewer.ViewModel;
public class ShapeDTO
{
    public string Type { get; init; } = null!;
    public string A { get; init; } = null!;
    public string B { get; init; } = null!;
    public string C { get; init; } = null!;
    public string Center { get; init; } = null!;
    public double Radius { get; init; }
    public bool? Filled { get; init; }
    public string Color { get; init; } = null!;
}