using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using VectorGraphicViewer.Converters;
using VectorGraphicViewer.Services.Factory;
using VectorGraphicViewer.ViewModel;

namespace VectorGraphicViewer.View
{
    public partial class EditCircleDialog : Window
    {
        private Storyboard blinkStoryboard = null!;
        private Canvas Canvas;
        private Ellipse Ellipse;
        public EditCircleDialog(Ellipse ellipse, Canvas canvas)
        {
            InitializeComponent();
            Ellipse = ellipse;
            RenderAnimition(ellipse);
            Canvas = canvas;
            List<Color> colors = GetColors();
            comboBox.ItemsSource = colors;
        }
        private void RenderAnimition(Ellipse ellipse)
        {
            DoubleAnimation blinkAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            blinkStoryboard = new Storyboard();
            blinkStoryboard.Children.Add(blinkAnimation);
            Storyboard.SetTargetProperty(blinkAnimation, new PropertyPath("Opacity"));
            ellipse.BeginStoryboard(blinkStoryboard);
        }
        private List<Color> GetColors()
        {
           List<Color> colors = new List<Color>
           {
            Colors.Red,
            Colors.Green,
            Colors.Blue,
            Colors.Yellow,
           };
            return colors;
        }
        private void FillCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            fillCheckBox.IsChecked = true;
        }
        private void FillCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            fillCheckBox.IsChecked = false;
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            blinkStoryboard.Stop();
        }
        internal void OKButton_Click(object sender, RoutedEventArgs e)
        {
            RenderShape();
        }
        private void RenderShape()
        {
            CircleViewModel circleViewModel = DataContext as CircleViewModel;
            if (circleViewModel != null)
            {
                ShapeFactory shapeFactory = new();
                string color = ConvertHexColorToObject(circleViewModel.SelectedColor);
                var shapedto = new ShapeDTO
                {
                    A = null!,
                    B = null!,
                    C = null!,
                    Center = circleViewModel.CenterX + ";" + circleViewModel.CenterY,
                    Color = color,
                    Filled = circleViewModel.IsFillChecked,
                    Radius = circleViewModel.Radius,
                    Type = "circle"
                };
                Canvas.Children.Remove(Ellipse);
                shapeFactory.CreateShape(ShapeMapper.ToGraphic(shapedto)).Draw(Canvas);
            }

        }
        private string ConvertHexColorToObject(Color hexColor)
        {
            int alpha = hexColor.A;
            int red = hexColor.R;
            int green = hexColor.G;
            int blue = hexColor.B;
            string color = alpha + ";" + red + ";" + green + ";" + blue;
            return color;
        }
        internal bool OnClosed()
        {
            throw new NotImplementedException();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            blinkStoryboard.Stop(); // TODO
        }
    }
}