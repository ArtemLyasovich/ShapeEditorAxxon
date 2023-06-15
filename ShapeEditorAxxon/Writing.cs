namespace ShapeEditorAxxon;

public class Writing
{
    public static void WriteRichTextBox(RichTextBox richTextBox, string text) 
        => richTextBox.AppendText(text.Replace("  ",Environment.NewLine));

    public static void UpdateRichTextBox(List<Figure> figures, RichTextBox richTextBox)
    {
        richTextBox.Clear();

        foreach (var figure in figures)
        {
            WriteRichTextBox(richTextBox, figure.ToString());
        }
    }
}