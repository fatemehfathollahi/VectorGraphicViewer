﻿using System;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Converters;

namespace VectorGraphicViewer.Services;
public class SerializationrFactory
{
    public ISerialization CreateConverter(string fileExtension)
    {
        switch (fileExtension)
        {
            case "json":
               return  new JsonSerialization();
            case "xml":
               return new XmlSerialization();
            default:
                throw new ArgumentException("Invalid file type.");
        }
    }
}