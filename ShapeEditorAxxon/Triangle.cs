namespace ShapeEditorAxxon;

public class Triangle : IRichTextBoxWriter
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

    public static void DrawTriangle(PictureBox pictureBox, Triangle triangle)
    {
        Graphics gfx = pictureBox.CreateGraphics();

        var pen = new Pen(Color.Black);
        
        gfx.DrawLine(pen, triangle._firstPoint,triangle._secondPoint);
        gfx.DrawLine(pen, triangle._firstPoint,triangle._thirdPoint);
        gfx.DrawLine(pen, triangle._secondPoint,triangle._thirdPoint);
    }
    
    public void WriteRichTextBox(RichTextBox richTextBox, string result)
    {
        richTextBox.AppendText(result.Replace("  ",Environment.NewLine));
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