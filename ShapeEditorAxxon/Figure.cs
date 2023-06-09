namespace ShapeEditorAxxon;

public abstract class Figure
{
    public void WriteRichTextBox(RichTextBox richTextBox, string text) 
        => richTextBox.AppendText(text.Replace("  ",Environment.NewLine));

    public abstract void FinishDrawingFigure(PictureBox pictureBox);
    public abstract void MoveFigure(PictureBox pictureBox,Point startLocation, Point finishLocation);

    public abstract void PaintOverFigure(PictureBox pictureBox);

    public abstract bool ContainsPoint(Point point);

    public abstract double CalculateArea();
}