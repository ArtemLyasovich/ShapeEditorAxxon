namespace ShapeEditorAxxon;

public class Mathematics
{
    public static double CalculateDistance(Point point1, Point point2)
    {
        double deltaX = point2.X - point1.X;
        double deltaY = point2.Y - point1.Y;

        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        return distance;
    }
}