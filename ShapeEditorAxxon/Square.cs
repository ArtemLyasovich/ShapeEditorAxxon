namespace ShapeEditorAxxon;

public class Square : IRichTextBoxWriter
{
    private readonly Point _upperLeft;
    private readonly Point _upperRight;
    private readonly Point _lowerLeft;
    private readonly Point _lowerRight;

    private Square(Point upperLeft, Point upperRight, Point lowerLeft, Point lowerRight)
    {
        _upperLeft = upperLeft;
        _upperRight = upperRight;
        _lowerLeft = lowerLeft;
        _lowerRight = lowerRight;
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

    public static void DrawSquare(PictureBox pictureBox, Square square)
    {
        Graphics gfx = pictureBox.CreateGraphics();

        var pen = new Pen(Color.Black);
        
        gfx.DrawLine(pen, square._upperLeft, square._upperRight);
        gfx.DrawLine(pen, square._upperLeft, square._lowerLeft);
        gfx.DrawLine(pen, square._upperRight, square._lowerRight);
        gfx.DrawLine(pen, square._lowerLeft, square._lowerRight);
    }

    public void WriteRichTextBox(RichTextBox richTextBox, string result)
    {
        richTextBox.AppendText(result.Replace("  ",Environment.NewLine));
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