namespace ShapeEditorAxxon;

public class Square : Figure
{
    private Point _upperLeft;
    private Point _upperRight;
    private Point _lowerLeft;
    private Point _lowerRight;

    private Square(Point upperLeft, Point upperRight, Point lowerLeft, Point lowerRight)
    {
        _upperLeft = upperLeft;
        _upperRight = upperRight;
        _lowerLeft = lowerLeft;
        _lowerRight = lowerRight;
    }

    public Square(Square square)
    {
        _upperLeft = square._upperLeft;
        _upperRight = square._upperRight;
        _lowerLeft = square._lowerLeft;
        _lowerRight = square._lowerRight;
    }

    public static Square FindAllCoordinates(Point upperLeft, Point lowerRight)
    {
        var xCenter = (upperLeft.X + lowerRight.X) / 2;
        var yCenter = (upperLeft.Y + lowerRight.Y) / 2;

        var xVector = lowerRight.X - upperLeft.X;
        var yVector = lowerRight.Y - upperLeft.Y;

        var xPerpendicular = -yVector/2;
        var yPerpendicular = xVector/2;

        var upperRight = new Point(xCenter + xPerpendicular, yCenter + yPerpendicular);
        var lowerLeft = new Point(xCenter - xPerpendicular, yCenter - yPerpendicular);

        return new Square(upperLeft, upperRight, lowerLeft, lowerRight);
    }

    public override void DrawFigure(PictureBox pictureBox)
    {
        var gfx = pictureBox.CreateGraphics();

        var pen = new Pen(Color.Black);
        
        gfx.DrawLine(pen, _upperLeft, _upperRight);
        gfx.DrawLine(pen, _upperLeft, _lowerLeft);
        gfx.DrawLine(pen, _upperRight, _lowerRight);
        gfx.DrawLine(pen, _lowerLeft, _lowerRight);
    }

    public override string ToString()
    {
        var result = $"Square:  " +
                     $"\tFirst Point: ({_upperLeft.X},{_upperLeft.Y})  " +
                     $"\tSecond Point: ({_upperRight.X}, {_upperRight.Y})  " +
                     $"\tThird Point: ({_lowerLeft.X}, {_lowerLeft.Y})  " +
                     $"\tFourth Point: ({_lowerRight.X}, {_lowerRight.Y})  ";
        
        return result;
    }
}