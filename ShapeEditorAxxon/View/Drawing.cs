namespace ShapeEditorAxxon.View;

public static class Drawing
{
    public static void DrawPoint(DoubleBufferedPictureBox pictureBox, Point point, Color color)
    {
        var gfx = pictureBox.CreateGraphics();
        var solidBrush = new SolidBrush(color);

        gfx.FillEllipse(solidBrush, point.X - 5, point.Y - 5, 10, 10);
    }

    public static void DrawLine(DoubleBufferedPictureBox pictureBox, Point startPoint, Point endPoint, Color color)
    {
        var gfx = pictureBox.CreateGraphics();
        var pen = new Pen(color, 2);

        gfx.DrawLine(pen, startPoint, endPoint);
    }

    private static void DrawPoints(DoubleBufferedPictureBox pictureBox, List<Point> points, Color color)
    {
        foreach (var point in points)
            DrawPoint(pictureBox, point, color);
    }

    private static void DrawLines(DoubleBufferedPictureBox pictureBox, List<Point> points, Color color)
    {
        var gfx = pictureBox.CreateGraphics();
        var pen = new Pen(color, 2);

        for (int i = 0; i < points.Count - 1; i++)
        {
            gfx.DrawLine(pen, points[i], points[i + 1]);
        }

        gfx.DrawLine(pen, points[^1], points[0]);
    }
    
    private static void DrawCircle(DoubleBufferedPictureBox pictureBox, Circle circle, Color color)
    {
        var gfx = pictureBox.CreateGraphics();
        var pen = new Pen(color, 2);

        var startPoint = circle.FindStartPoint();
        var diameterLength = circle.FindDiameterLength();

        gfx.DrawEllipse(pen, startPoint.X, startPoint.Y, (float)diameterLength, (float)diameterLength);
    }
    
    public static void DrawFigure(DoubleBufferedPictureBox pictureBox, Figure figure, Color color)
    {
        if (figure is Circle circle)
            DrawCircle(pictureBox, circle, color);
        else
        {
            var points = figure.GetPoints();
            DrawPoints(pictureBox, points, color);
            DrawLines(pictureBox, points, color);
        }
    }

    public static void PaintOverFigure(DoubleBufferedPictureBox pictureBox, Figure figure)
    {
        if (figure is Circle circle)
            DrawCircle(pictureBox, circle, Color.White);
        else
            DrawFigure(pictureBox, figure, Color.White);
    }

    public static void RedrawFigures(List<Figure> figures, DoubleBufferedPictureBox pictureBox)
    {
        foreach (var figure in figures)
            DrawFigure(pictureBox, figure, Color.Black);
    }
}
