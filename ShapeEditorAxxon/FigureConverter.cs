using System.Reflection;
using System.Text.Json;

namespace ShapeEditorAxxon;

public static class FigureConverter
{
    public static void SerializeFigures(string filePath, List<Figure> figures)
    {
        var jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var jsonData = new List<Dictionary<string, object>>();
        foreach (var figure in figures)
        {
            var figureData = new Dictionary<string, object>
            {
                { "type", figure.GetType().Name },
                { "data", SerializeFigureData(figure) }
            };
            jsonData.Add(figureData);
        }

        var jsonString = JsonSerializer.Serialize(jsonData, jsonOptions);
        File.WriteAllText(filePath, jsonString);
    }

    private static Dictionary<string, object> SerializeFigureData(Figure figure)
    {
        var figureData = new Dictionary<string, object>();

        var type = figure.GetType();
        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var field in fields)
        {
            var fieldName = field.Name;
            var fieldValue = field.GetValue(figure);
            figureData[fieldName] = fieldValue;
        }

        return figureData;
    }
    
    public static List<Figure> DeserializeFigures(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        var jsonData = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonString);

        var figures = new List<Figure>();
        foreach (var figureData in jsonData)
        {
            if (figureData.TryGetValue("type", out var figureTypeValue) && figureTypeValue is JsonElement typeElement && typeElement.ValueKind == JsonValueKind.String)
            {
                var figureType = Type.GetType($"ShapeEditorAxxon.{typeElement.GetString()}");
                if (figureType != null)
                {
                    var figure = (Figure)Activator.CreateInstance(figureType);
                    DeserializeFigureData(figure, figureData["data"]);
                    figures.Add(figure);
                }
            }
        }

        return figures;
    }

    private static void DeserializeFigureData(Figure figure, object data)
    {
        if (data is JsonElement jsonData)
        {
            var type = figure.GetType();
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                var fieldName = field.Name;
                if (jsonData.TryGetProperty(fieldName, out var jsonValue))
                {
                    var fieldValue = ConvertJsonValue(jsonValue, field.FieldType);
                    field.SetValue(figure, fieldValue);
                }
            }
        }
        else
        {
            MessageBox.Show($"Object is of type {data.GetType()}, expected JsonElement");
        }
    }

    private static object ConvertJsonValue(JsonElement jsonValue, Type targetType)
    {
        if (targetType == typeof(double))
        {
            return jsonValue.GetDouble();
        }
        if (targetType == typeof(Point))
        {
            return ConvertJsonToPoint(jsonValue);
        }
        
        return null;
    }

    private static Point ConvertJsonToPoint(JsonElement jsonValue)
    {
        if (jsonValue.ValueKind == JsonValueKind.Object)
        {
            var x = jsonValue.GetProperty("X").GetInt32();
            var y = jsonValue.GetProperty("Y").GetInt32();
            return new Point(x, y);
        }
        
        return Point.Empty;
    }
}