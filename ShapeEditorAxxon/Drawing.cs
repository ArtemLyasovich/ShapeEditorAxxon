using System.Reflection;

namespace ShapeEditorAxxon;

public class Drawing
{
    public static void DrawPoint(PictureBox pictureBox, Point point,Color color)
    {
        var gfx = pictureBox.CreateGraphics();
        
        var solidBrush = new SolidBrush(color);
        
        gfx.FillEllipse(solidBrush,point.X-3,point.Y-3,6,6);
    }

    public static void DrawLine(PictureBox pictureBox, Point firstPoint, Point secondPoint, Color color)
    {
        var gfx = pictureBox.CreateGraphics();
        
        var pen = new Pen(color,2);
        
        gfx.DrawLine(pen, firstPoint, secondPoint);
    }

    public static void DrawSquare(PictureBox pictureBox, Square square, Color color)
    {
        var upperLeft = square.GetUpperLeft();
        var upperRight = square.GetUpperRight();
        var lowerLeft = square.GetLowerLeft();
        var lowerRight = square.GetLowerRight();
        
        DrawPoint(pictureBox, upperLeft, color);
        DrawPoint(pictureBox, upperRight, color);
        DrawPoint(pictureBox,lowerRight, color);
        DrawPoint(pictureBox,lowerLeft, color);
        
        DrawLine(pictureBox, upperLeft, upperRight, color);
        DrawLine(pictureBox, upperLeft, lowerLeft, color);
        DrawLine(pictureBox, upperRight, lowerRight, color);
        DrawLine(pictureBox, lowerLeft, lowerRight, color);
    }

    public static void DrawTriangle(PictureBox pictureBox, Triangle triangle, Color color)
    {
        var firstPoint = triangle.GetFirstPoint();
        var secondPoint = triangle.GetSecondPoint();
        var thirdPoint = triangle.GetThirdPoint();
        
        DrawPoint(pictureBox, firstPoint, color);
        DrawPoint(pictureBox, secondPoint, color);
        DrawPoint(pictureBox, thirdPoint, color);

        DrawLine(pictureBox, firstPoint, secondPoint, color);
        DrawLine(pictureBox, secondPoint, thirdPoint, color);
        DrawLine(pictureBox, thirdPoint, firstPoint, color);
    }

    public static void DrawCircle(PictureBox pictureBox, Circle circle, Color color)
    {
        var gfx = pictureBox.CreateGraphics();

        var pen = new Pen(color, 2);

        var startPoint = circle.FindStartPoint();
        var diameterLength = circle.FindDiameterLength();
        
        gfx.DrawEllipse(pen, startPoint.X,startPoint.Y,(float)diameterLength,(float)diameterLength);
    }

    public static void DrawQuadrangle(PictureBox pictureBox, Quadrangle quadrangle, Color color)
    {
        var firstPoint = quadrangle.GetFirstPoint();
        var secondPoint = quadrangle.GetSecondPoint();
        var thirdPoint = quadrangle.GetThirdPoint();
        var fourthPoint = quadrangle.GetFourthPoint();
        
        DrawPoint(pictureBox, firstPoint, color);
        DrawPoint(pictureBox, secondPoint, color);
        DrawPoint(pictureBox, thirdPoint, color);
        DrawPoint(pictureBox, fourthPoint, color);

        DrawLine(pictureBox, firstPoint, secondPoint, color);
        DrawLine(pictureBox, secondPoint, thirdPoint, color);
        DrawLine(pictureBox, thirdPoint, fourthPoint, color);
        DrawLine(pictureBox, fourthPoint, firstPoint, color);
    }

    public static void PaintOverSquare(PictureBox pictureBox, Figure figure)
    {
        DrawSquare(pictureBox, (Square)figure, Color.White);
    }

    public static void PaintOverTriangle(PictureBox pictureBox, Figure figure)
    {
        DrawTriangle(pictureBox, (Triangle)figure, Color.White);
    }

    public static void PaintOverCircle(PictureBox pictureBox, Figure figure)
    {
        DrawCircle(pictureBox, (Circle)figure, Color.White);
    }

    public static void PaintOverQuadrangle(PictureBox pictureBox, Figure figure)
    {
        DrawQuadrangle(pictureBox, (Quadrangle)figure, Color.White);
    }

    public static void RedrawFigures(List<Figure> figures, PictureBox pictureBox)
    {
        foreach (var figure in figures)
        {
            switch (figure)
            {
                case Square square:
                    DrawSquare(pictureBox, square, Color.Black);
                    break;
                case Triangle triangle:
                    DrawTriangle(pictureBox, triangle, Color.Black);
                    break;
                case Circle circle:
                    DrawCircle(pictureBox, circle, Color.Black);
                    break;
                case Quadrangle quadrangle:
                    DrawQuadrangle(pictureBox, quadrangle, Color.Black);
                    break;
            }
        }
    }
}