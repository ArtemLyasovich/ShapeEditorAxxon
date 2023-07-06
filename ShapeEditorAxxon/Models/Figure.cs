using Newtonsoft.Json.Linq;

namespace ShapeEditorAxxon;

public abstract class Figure
{
    public abstract bool ContainsPoint(Point point);

    public abstract double CalculateArea();

    public abstract bool ContainsPointOnNode(Point point);
}