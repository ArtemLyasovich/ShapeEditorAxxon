using Newtonsoft.Json;

namespace ShapeEditorAxxon;

public static class FigureConverter
{
    public static void SerializeFigures(string directoryPath, List<Figure> figures)
    {
        if (figures.Any())
        {
            var squares = figures.Where(p => p is Square);
            var triangles = figures.Where(p => p is Triangle);
            var circles = figures.Where(p => p is Circle);
            var quadrangles = figures.Where(p => p is Quadrangle);

            var filePath = Path.Combine(directoryPath, "squares.json");
            WriteFile(filePath, squares);
            
            filePath = Path.Combine(directoryPath, "triangles.json");
            WriteFile(filePath, triangles);

            filePath = Path.Combine(directoryPath, "circles.json");
            WriteFile(filePath, circles);

            filePath = Path.Combine(directoryPath, "quadrangles.json");
            WriteFile(filePath, quadrangles);
        }
    }

    public static List<Figure> DeserializeFigures(string directoryPath)
    {
        var filePath = Path.Combine(directoryPath, "squares.json");
        var jsonData = File.ReadAllText(filePath);

        var squares = JsonConvert.DeserializeObject<List<Square>>(jsonData);
        
        filePath = Path.Combine(directoryPath, "triangles.json");
        jsonData = File.ReadAllText(filePath);
            
        var triangles = JsonConvert.DeserializeObject<List<Triangle>>(jsonData);
        
        filePath = Path.Combine(directoryPath, "circles.json");
        jsonData = File.ReadAllText(filePath);
            
        var circles = JsonConvert.DeserializeObject<List<Circle>>(jsonData);
        
        filePath = Path.Combine(directoryPath, "quadrangles.json");
        jsonData = File.ReadAllText(filePath);
            
        var quadrangles = JsonConvert.DeserializeObject<List<Quadrangle>>(jsonData);
        
        var figures = squares.Concat<Figure>(triangles).Concat<Figure>(circles).Concat(quadrangles);
        
        return new List<Figure>(figures);
    }

    private static void WriteFile(string filePath, IEnumerable<Figure> figures)
    {
        var jsonData = JsonConvert.SerializeObject(figures);
        File.WriteAllText(filePath, jsonData);
    }
}