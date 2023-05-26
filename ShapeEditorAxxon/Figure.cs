namespace ShapeEditorAxxon;

public abstract class Figure
{
    public void WriteRichTextBox(RichTextBox richTextBox, string text) 
        => richTextBox.AppendText(text.Replace("  ",Environment.NewLine));

    public abstract void DrawFigure(PictureBox pictureBox);
}