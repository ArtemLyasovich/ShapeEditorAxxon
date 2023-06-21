using System.Runtime.Serialization;

namespace ShapeEditorAxxon;

[DataContract]
public class Circle : Figure
{
    [DataMember]
    private Point _diameterFirst;
    [DataMember]
    private Point _diameterSecond;
    [DataMember]
    private Point _center;
    [DataMember]
    private double _radius;

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
    
    public Point FindStartPoint()
    {
        var center = FindCenterCoordinates();

        var radius = FindRadiusLength();

        var xStartPoint = center.X - radius;
        var yStartPoint = center.Y - radius;

        return new Point((int)xStartPoint, (int)yStartPoint);
    }
    
    public double FindDiameterLength()
    {
        var diameterLength = Mathematics.CalculateDistance(_diameterFirst, _diameterSecond);
        return diameterLength;
    }

    private double FindRadiusLength() => FindDiameterLength() / 2;

    public override double CalculateArea()
    {
        return Math.PI * _radius * _radius;
    }
    
    public override bool ContainsPoint(Point point)
    {
        var distance = Mathematics.CalculateDistance(_center, point);

        return distance <= _radius;
    }

    public void FindCoordinatesAfterMoving(Point startPoint, Point finishPoint)
    {
        var start = FindStartPoint();
        
        var deltaX1 = startPoint.X - start.X;
        var deltaY1 = startPoint.Y - start.Y;

        var finishStart = new Point(finishPoint.X - deltaX1, finishPoint.Y - deltaY1);

        _diameterFirst.X = finishStart.X;
        _diameterFirst.Y = finishStart.Y + (int)_radius;

        _diameterSecond.X = finishStart.X + 2 * (int)_radius;
        _diameterSecond.Y = finishStart.Y + (int)_radius;

        _center = FindCenterCoordinates();
    }
    
    public override bool ContainsPointOnNode(Point point)
    {
        var distance = Mathematics.CalculateDistance(_center, point);
        return Math.Abs(distance - _radius) < 5;
    }
    
    public void FindCoordinatesAfterChanging(Point startPoint, Point finishPoint)
    {
        _diameterFirst = startPoint;
        
        double angle = Math.Atan2(_diameterFirst.Y - _center.Y, _diameterFirst.X - _center.X);
        
        _diameterSecond.X = (int)(_center.X + _radius * Math.Cos(angle + Math.PI));
        _diameterSecond.Y = (int)(_center.Y + _radius * Math.Sin(angle + Math.PI));

        _diameterFirst = finishPoint;
        _center = FindCenterCoordinates();
        _radius = FindRadiusLength();
    }
    
    public override string ToString()
    {
        var result = $"Circle:  " +
                     $"\tCenter point: ({_center.X},{_center.Y})  " +
                     $"\tRadius: {_radius}  ";
        
        return result;
    }
}