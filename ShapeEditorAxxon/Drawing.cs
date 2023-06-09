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
}