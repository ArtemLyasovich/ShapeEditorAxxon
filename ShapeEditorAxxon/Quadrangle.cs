namespace ShapeEditorAxxon;

public class Quadrangle : Figure
{
    private readonly Point _firstPoint;
    private readonly Point _secondPoint;
    private readonly Point _thirdPoint;
    private readonly Point _fourthPoint;

    public Quadrangle(Point firstPoint, Point secondPoint, Point thirdPoint, Point fourthPoint)
    {
        _firstPoint = firstPoint;
        _secondPoint = secondPoint;
        _thirdPoint = thirdPoint;
        _fourthPoint = fourthPoint;
    }

    public override void DrawFigure(PictureBox pictureBox)
    {
        var gfx = pictureBox.CreateGraphics();

        var pen = new Pen(Color.Black);
        
        gfx.DrawLine(pen, _firstPoint, _secondPoint);
        gfx.DrawLine(pen, _secondPoint, _thirdPoint);
        gfx.DrawLine(pen, _thirdPoint, _fourthPoint);
        gfx.DrawLine(pen, _fourthPoint, _firstPoint);
    }

    public override string ToString()
    {
        var result = $"Quadrangle:  " +
                     $"\tFirst Point: ({_firstPoint.X},{_firstPoint.Y})  " +
                     $"\tSecond Point: ({_secondPoint.X}, {_secondPoint.Y})  " +
                     $"\tThird Point: ({_thirdPoint.X}, {_thirdPoint.Y})  " +
                     $"\tFourth Point: ({_fourthPoint.X}, {_fourthPoint.Y})  ";
        
        return result;
    }
}