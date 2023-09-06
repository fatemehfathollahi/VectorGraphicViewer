using System;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Converters;

namespace VectorGraphicViewer.Services;
public class SerializationrFactory
{
    public ISerialization CreateConverter(FileType fileType)
    {
        switch (fileType)
        {
            case FileType.Json:
               return  new JsonSerialization();
            case FileType.Xml:
               return new XmlSerialization();
            default:
                throw new ArgumentException("Invalid file type.");
        }
    }
}