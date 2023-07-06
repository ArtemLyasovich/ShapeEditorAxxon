using System.Runtime.Serialization;

namespace ShapeEditorAxxon;

[DataContract]
public class Triangle : Figure
{
    [DataMember]
    private Point _firstPoint;
    [DataMember]
    private Point _secondPoint;
    [DataMember]
    private Point _thirdPoint;

    public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
    {
        _firstPoint = firstPoint;
        _secondPoint = secondPoint;
        _thirdPoint = thirdPoint;
    }

    public Point GetFirstPoint()
    {
        return _firstPoint;
    }

    public Point GetSecondPoint()
    {
        return _secondPoint;
    }

    public Point GetThirdPoint()
    {
        return _thirdPoint;
    }
    
    public override double CalculateArea()
    {
        var side1 = Mathematics.CalculateDistance(_firstPoint, _secondPoint);
        var side2 = Mathematics.CalculateDistance(_secondPoint, _thirdPoint);
        var side3 = Mathematics.CalculateDistance(_thirdPoint, _firstPoint);

        var semiPerimeter = (side1 + side2 + side3) / 2;
        
        var area = Math.Sqrt(semiPerimeter * (semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));

        return area;
    }
    
    public override bool ContainsPoint(Point point)
    {
        var firstTriangle = new Triangle(_firstPoint, point, _secondPoint);
        var secondTriangle = new Triangle(_secondPoint, point, _thirdPoint);
        var thirdTriangle = new Triangle(_thirdPoint, point, _firstPoint);
        
        var trianglesArea = firstTriangle.CalculateArea() + secondTriangle.CalculateArea() +
                            thirdTriangle.CalculateArea();
        var triangleArea = CalculateArea();
        
        var epsilon = 0.001;

        return Math.Abs(trianglesArea - triangleArea) < epsilon;
    }

    public void FindCoordinatesAfterMoving(Point startPoint, Point finishPoint)
    {
        var deltaX1 = startPoint.X - _firstPoint.X;
        var deltaY1 = startPoint.Y - _firstPoint.Y;
        
        var deltaX2 = startPoint.X - _secondPoint.X;
        var deltaY2 = startPoint.Y - _secondPoint.Y;
        
        var deltaX3 = startPoint.X - _thirdPoint.X;
        var deltaY3 = startPoint.Y - _thirdPoint.Y;

        _firstPoint.X = finishPoint.X - deltaX1;
        _firstPoint.Y = finishPoint.Y - deltaY1;
        
        _secondPoint.X = finishPoint.X - deltaX2;
        _secondPoint.Y = finishPoint.Y - deltaY2;
        
        _thirdPoint.X = finishPoint.X - deltaX3;
        _thirdPoint.Y = finishPoint.Y - deltaY3;
    }

    public override bool ContainsPointOnNode(Point point)
    {
        var pointRadius = 5;

        var distance1 = Mathematics.CalculateDistance(_firstPoint, point);
        var distance2 = Mathematics.CalculateDistance(_secondPoint, point);
        var distance3 = Mathematics.CalculateDistance(_thirdPoint, point);

        return distance1 <= pointRadius || distance2 <= pointRadius || distance3 <= pointRadius;
    }

    public void FindCoordinatesAfterChanging(Point startPoint, Point finishPoint)
    {
        var pointRadius = 5;

        var distance1 = Mathematics.CalculateDistance(_firstPoint, startPoint);
        var distance2 = Mathematics.CalculateDistance(_secondPoint, startPoint);

        if (distance1 <= pointRadius)
            _firstPoint = finishPoint;
        else if (distance2 <= pointRadius)
            _secondPoint = finishPoint;
        else _thirdPoint = finishPoint;
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