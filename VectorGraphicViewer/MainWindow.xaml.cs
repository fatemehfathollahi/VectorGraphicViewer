using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows;
using VectorGraphicViewer.Model;
using VectorGraphicViewer.Services;

namespace VectorGraphicViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RenderGraphics();
        }
        private void RenderGraphics()
        {
            ShapeFactory shapeFactory = new();
            List<Graphic> graphics = ConvertGraphicsFile();
            if(graphics.Count > 0)
               graphics.ForEach(graphic => shapeFactory.CreateShape(graphic).Draw(canvas));
        }
        private List<Graphic> ConvertGraphicsFile()
        {
            string data = File.ReadAllText("graphics.json");
            string fileName = ConfigurationManager.AppSettings["FileName"]!;
            string fileExtension = Path.GetExtension(fileName);

            if (!string.IsNullOrEmpty(fileName))
            {
                fileExtension = fileExtension.TrimStart('.');
                SerializationrFactory serializationrFactory = new();
                var converter = serializationrFactory.CreateConverter(fileExtension);
                return converter.Deserialize(data);
            }
            return new List<Graphic>();
        }
    }
}
