namespace ShapeEditorAxxon;

public static class Mathematics
{
    public static double CalculateDistance(Point point1, Point point2)
    {
        double deltaX = point2.X - point1.X;
        double deltaY = point2.Y - point1.Y;

        double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

        return distance;
    }

    private static double RadiansToDegrees(double radians)
    {
        return radians * (180 / Math.PI);
    }
    
    public static double CalculateAngle(Point a, Point b, Point c)
    {
        var ab = new Point(b.X - a.X, b.Y - a.Y);
        var bc = new Point(c.X - b.X, c.Y - b.Y);
        
        var dotProduct = ab.X * bc.X + ab.Y * bc.Y;

        var AbVectorLength = Math.Sqrt(ab.X * ab.X + ab.Y * ab.Y);
        var BcVectorLength = Math.Sqrt(bc.X * bc.X + bc.Y * bc.Y);

        var angle = Math.Acos(dotProduct / (AbVectorLength * BcVectorLength));
        var degrees = RadiansToDegrees(angle);

        return degrees;
    }
    
    public static bool IsPointOnRay(Point firstPoint, Point secondPoint, Point testPoint)
    {
        return (testPoint.X - firstPoint.X) * (secondPoint.Y - firstPoint.Y) -
            (secondPoint.X - firstPoint.X) * (testPoint.Y - firstPoint.Y) == 0;
    }
}