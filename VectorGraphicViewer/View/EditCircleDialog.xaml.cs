using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace VectorGraphicViewer.View
{
    public partial class EditCircleDialog : Window
    {
        private Storyboard blinkStoryboard = null!;
        public EditCircleDialog(Ellipse ellipse)
        {
            InitializeComponent();
            RenderAnimition(ellipse);
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
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            blinkStoryboard.Stop(); // TODO
        }
    }
}