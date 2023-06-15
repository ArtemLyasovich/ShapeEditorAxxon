namespace ShapeEditorAxxon;

public class Moving
{
    public static void MoveSquare(PictureBox pictureBox, Point startPoint, Point finishPoint, Square square)
    {
        Drawing.PaintOverSquare(pictureBox, square);
        
        square.FindCoordinatesAfterMoving(startPoint, finishPoint);

        Drawing.DrawSquare(pictureBox, square, Color.Black);
    }

    public static void MoveTriangle(PictureBox pictureBox, Point startPoint, Point finishPoint, Triangle triangle)
    {
        Drawing.PaintOverTriangle(pictureBox, triangle);
        
        triangle.FindCoordinatesAfterMoving(startPoint, finishPoint);

        Drawing.DrawTriangle(pictureBox, triangle, Color.Black);
    }

    public static void MoveCircle(PictureBox pictureBox, Point startPoint, Point finishPoint, Circle circle)
    {
        Drawing.PaintOverCircle(pictureBox, circle);
        
        circle.FindCoordinatesfterMoving(startPoint, finishPoint);

        Drawing.DrawCircle(pictureBox, circle, Color.Black);
    }

    public static void MoveQuadrangle(PictureBox pictureBox, Point startPoint, Point finishPoint, Quadrangle quadrangle)
    {
        Drawing.PaintOverQuadrangle(pictureBox, quadrangle);
        
        quadrangle.FindCoordinatesAfterMoving(startPoint, finishPoint);
        
        Drawing.DrawQuadrangle(pictureBox, quadrangle, Color.Black);
    }
}