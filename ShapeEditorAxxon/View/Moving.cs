namespace ShapeEditorAxxon.View;

public static class Moving
{
    public static void MoveFigure(DoubleBufferedPictureBox pictureBox, Point startPoint, Point finishPoint, 
        Figure figure, List<Figure> figures)
    {
        var buffer = new Bitmap(pictureBox.Width, pictureBox.Height);
    
        using (var g = Graphics.FromImage(buffer))
        {
            Drawing.PaintOverFigure(pictureBox, figure);
            
            var offsetX = finishPoint.X - startPoint.X;
            var offsetY = finishPoint.Y - startPoint.Y;

            if (figure is Circle circle)
            {
                var newLocation = new Point((int)(circle.Center.X + offsetX + circle.Radius),
                    (int)(circle.Center.Y + offsetY + circle.Radius));
                var newLocation1 = new Point((int)(circle.Center.X + offsetX - circle.Radius),
                    (int)(circle.Center.Y + offsetY - circle.Radius));
                
                if (newLocation1.X <= 0 || newLocation1.Y <= 0 || 
                    newLocation.X >= pictureBox.Width || newLocation.Y >= pictureBox.Height)
                {
                    pictureBox.Image = buffer;
                    return;
                }
            }
            
            foreach (var point in figure.GetPoints())
            {
                var newLocation = new Point(point.X + offsetX, point.Y + offsetY);
                if (newLocation.X < 0 || newLocation.Y < 0 || 
                    newLocation.X >= pictureBox.Width || newLocation.Y >= pictureBox.Height)
                {
                    pictureBox.Image = buffer;
                    return;
                }
            }
            figure.FindCoordinatesAfterMoving(startPoint, finishPoint);

            var figuresWithoutCurrent = new List<Figure>(figures);
            figuresWithoutCurrent.Remove(figure);
            Drawing.RedrawFigures(figuresWithoutCurrent, pictureBox);
            Drawing.DrawFigure(pictureBox, figure, Color.Black);
        }
        
        pictureBox.Image = buffer;
    }

    public static void MoveFigureNode(DoubleBufferedPictureBox pictureBox, Point startPoint, Point finishPoint,
        Figure figure, List<Figure> figures)
    {
        var buffer = new Bitmap(pictureBox.Width, pictureBox.Height);
    
        using (var g = Graphics.FromImage(buffer))
        {
            Drawing.PaintOverFigure(pictureBox, figure);

            if (finishPoint.X > 0 && finishPoint.X < pictureBox.Width && finishPoint.Y > 0 &&
                finishPoint.Y < pictureBox.Height)
            {
                figure.FindCoordinatesAfterChanging(startPoint, finishPoint);
            
                var figuresWithoutCurrent = new List<Figure>(figures);
                figuresWithoutCurrent.Remove(figure);
                Drawing.RedrawFigures(figuresWithoutCurrent, pictureBox);
                Drawing.DrawFigure(pictureBox, figure, Color.Black);
            }
        }
        
        pictureBox.Image = buffer;
    }
}