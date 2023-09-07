using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.View;

namespace VectorGraphicViewer.Services.Visitor;
public class ShapeSelectionVisitor : IShapeVisitor
{
    public void Visit(CircleVisitor circleVisitor)
    {
        Ellipse circle = circleVisitor.Ellipse;
        EditCircleDialog dialog = new EditCircleDialog(circle);
        double circleCenterX = Canvas.GetLeft(circle) + circle.Width / 2;
        double circleCenterY = Canvas.GetTop(circle) + circle.Height / 2;
        double circleRadius = circle.Width / 2;
        var circleBorderBrush = circle.Stroke as SolidColorBrush;

        dialog.CenterXTextBox.Text = circleCenterX.ToString();
        dialog.CenterYTextBox.Text = circleCenterY.ToString();
        dialog.RadiusTextBox.Text = circleRadius.ToString();
        dialog.comboBox.SelectedItem = circleBorderBrush!.Color;
        if (circle.Fill != null)
            dialog.fillCheckBox.IsChecked = true;
        if (dialog.ShowDialog() == true) { }
    }

    public void Visit(LineVisitor line)
    {
        //TODO: Immplement EditLineDialog
    }

    public void Visit(TriangleVisitor triangle)
    {
        //TODO: Immplemnt EditTriangleDialog
    }
}