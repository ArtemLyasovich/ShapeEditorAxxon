namespace ShapeEditorAxxon;

public class Quadrangle : IRichTextBoxWriter
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

    public static void DrawQuadrangle(PictureBox pictureBox, Quadrangle quadrangle)
    {
        Graphics gfx = pictureBox.CreateGraphics();

        var pen = new Pen(Color.Black);
        
        gfx.DrawLine(pen, quadrangle._firstPoint, quadrangle._secondPoint);
        gfx.DrawLine(pen, quadrangle._secondPoint, quadrangle._thirdPoint);
        gfx.DrawLine(pen, quadrangle._thirdPoint, quadrangle._fourthPoint);
        gfx.DrawLine(pen, quadrangle._fourthPoint, quadrangle._firstPoint);
    }

    public void WriteRichTextBox(RichTextBox richTextBox, string text)
    {
        richTextBox.AppendText(text.Replace("  ",Environment.NewLine));
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