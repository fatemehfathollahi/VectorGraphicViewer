using System.Collections.Generic;
using System.Text.Json;
using VectorGraphicViewer.Contract;
using VectorGraphicViewer.Model;

namespace VectorGraphicViewer.Converters;

public class JsonSerialization : ISerialization
{
    public List<Graphic> Deserialize(string data)
    {
      return  JsonSerializer.Deserialize<List<Graphic>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
    }
}
