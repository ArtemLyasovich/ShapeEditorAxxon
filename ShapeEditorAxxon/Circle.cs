namespace ShapeEditorAxxon;

public class Circle : Figure
{
    private readonly Point _diameterFirst;
    private readonly Point _diameterSecond;
    private readonly Point _center;
    private readonly float _radius;

    public Circle(Point diameterFirst, Point diameterSecond)
    {
        _diameterFirst = diameterFirst;
        _diameterSecond = diameterSecond;
        _center = FindCenterCoordinates();
        _radius = FindRadiusLength();
    }

    private Point FindCenterCoordinates()
    {
        var xCenter = (_diameterFirst.X + _diameterSecond.X) / 2;
        var yCenter = (_diameterFirst.Y + _diameterSecond.Y) / 2;

        return new Point(xCenter, yCenter);
    }
    
    private Point FindStartPoint()
    {
        var center = FindCenterCoordinates();

        var radius = FindRadiusLength();

        var xStartPoint = center.X - radius;
        var yStartPoint = center.Y - radius;

        return new Point((int)xStartPoint, (int)yStartPoint);
    }
    
    private float FindDiameterLength()
    {
        var diameterLength = Math.Sqrt((_diameterFirst.X - _diameterSecond.X) * (_diameterFirst.X - _diameterSecond.X) +
                                       (_diameterFirst.Y - _diameterSecond.Y) * (_diameterFirst.Y - _diameterSecond.Y));
        return (float)diameterLength;
    }

    private float FindRadiusLength() => FindDiameterLength() / 2;
    
    public override void DrawFigure(PictureBox pictureBox)
    {
        var gfx = pictureBox.CreateGraphics();

        var pen = new Pen(Color.Black);

        var startPoint = FindStartPoint();
        var diameterLength = FindDiameterLength();
        
        gfx.DrawEllipse(pen, startPoint.X,startPoint.Y,diameterLength,diameterLength);
    }

    public override string ToString()
    {
        var result = $"Circle:  " +
                     $"\tCenter point: ({_center.X},{_center.Y})  " +
                     $"\tRadius: {_radius}  ";
        
        return result;
    }
}