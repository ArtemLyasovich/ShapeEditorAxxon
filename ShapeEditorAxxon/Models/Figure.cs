namespace ShapeEditorAxxon;

public abstract class Figure
{
    public abstract bool ContainsPoint(Point point);

    public abstract double CalculateArea();

    public abstract bool ContainsPointOnNode(Point point);

    public abstract void FindCoordinatesAfterMoving(Point startPoint, Point finishPoint);

    public abstract void FindCoordinatesAfterChanging(Point startPoint, Point finishPoint);

    public abstract void ScalingCoordinates(float scaleX, float scaleY);

    public abstract List<Point> GetPoints();
}