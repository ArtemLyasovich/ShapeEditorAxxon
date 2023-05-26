namespace ShapeEditorAxxon;

public class Triangle : Figure
{
    private readonly Point _firstPoint;
    private readonly Point _secondPoint;
    private readonly Point _thirdPoint;

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
    {
        _firstPoint = firstPoint;
        _secondPoint = secondPoint;
        _thirdPoint = thirdPoint;
    }

    public override void DrawFigure(PictureBox pictureBox)
    {
        var gfx = pictureBox.CreateGraphics();

        var pen = new Pen(Color.Black);
        
        gfx.DrawLine(pen, _firstPoint, _secondPoint);
        gfx.DrawLine(pen, _firstPoint, _thirdPoint);
        gfx.DrawLine(pen, _secondPoint, _thirdPoint);
    }

    public override string ToString()
    {
        var result = $"Triangle:  " +
                     $"\tFirst Point: ({_firstPoint.X},{_firstPoint.Y})  " +
                     $"\tSecond Point: ({_secondPoint.X}, {_secondPoint.Y})  " +
                     $"\tThird Point: ({_thirdPoint.X}, {_thirdPoint.Y})  ";
        
        return result;
    }
}