namespace ShapeEditorAxxon;

public class Quadrangle : Figure
{
    private Point _firstPoint;
    private Point _secondPoint;
    private Point _thirdPoint;
    private Point _fourthPoint;

    public Quadrangle()
    {
        
    }

    public Quadrangle(Point firstPoint, Point secondPoint, Point thirdPoint, Point fourthPoint)
    {
        _firstPoint = firstPoint;
        _secondPoint = secondPoint;
        _thirdPoint = thirdPoint;
        _fourthPoint = fourthPoint;
    }

    public override List<Point> GetPoints()
    {
        return new List<Point>()
        {
            _firstPoint, _secondPoint, _thirdPoint, _fourthPoint
        };
    }

    public override double CalculateArea()
    {
        var firstTriangle = new Triangle(_firstPoint, _secondPoint, _thirdPoint);
        var secondTriangle = new Triangle(_thirdPoint, _fourthPoint,_firstPoint);

        var area = firstTriangle.CalculateArea() + secondTriangle.CalculateArea();

        return area;
    }
    
    public override bool ContainsPoint(Point point)
    {
        var firstTriangle = new Triangle(_firstPoint, point, _secondPoint);
        var secondTriangle = new Triangle(_secondPoint, point, _thirdPoint);
        var thirdTriangle = new Triangle(_thirdPoint, point, _fourthPoint);
        var fourthTriangle = new Triangle(_fourthPoint, point, _firstPoint);

        var trianglesArea = firstTriangle.CalculateArea() + secondTriangle.CalculateArea() +
                            thirdTriangle.CalculateArea() + fourthTriangle.CalculateArea();
        var quadrangleArea = CalculateArea();
        
        var epsilon = 0.001;

        return Math.Abs(trianglesArea - quadrangleArea) < epsilon;
    }

    public override void FindCoordinatesAfterMoving(Point startPoint, Point finishPoint)
    {
        var deltaX1 = startPoint.X - _firstPoint.X;
        var deltaY1 = startPoint.Y - _firstPoint.Y;
        
        var deltaX2 =  _secondPoint.X - startPoint.X;
        var deltaY2 = startPoint.Y - _secondPoint.Y;
        
        var deltaX3 = _thirdPoint.X - startPoint.X;
        var deltaY3 = _thirdPoint.Y - startPoint.Y;
        
        var deltaX4 = startPoint.X - _fourthPoint.X;
        var deltaY4 = _fourthPoint.Y - startPoint.Y;

        _firstPoint = new Point(finishPoint.X - deltaX1, finishPoint.Y - deltaY1);
        _secondPoint = new Point(finishPoint.X + deltaX2, finishPoint.Y - deltaY2);
        _thirdPoint = new Point(finishPoint.X + deltaX3, finishPoint.Y + deltaY3);
        _fourthPoint = new Point(finishPoint.X - deltaX4, finishPoint.Y + deltaY4);
    }
    
    public override bool ContainsPointOnNode(Point point)
    {
        var pointRadius = 5;

        var distance1 = Mathematics.CalculateDistance(_firstPoint, point);
        var distance2 = Mathematics.CalculateDistance(_secondPoint, point);
        var distance3 = Mathematics.CalculateDistance(_thirdPoint, point);
        var distance4 = Mathematics.CalculateDistance(_fourthPoint, point);

        return distance1 <= pointRadius || distance2 <= pointRadius || distance3 <= pointRadius ||
               distance4 <= pointRadius;
    }

    public override void FindCoordinatesAfterChanging(Point startPoint, Point finishPoint)
    {
        var pointRadius = 5;

        var distance1 = Mathematics.CalculateDistance(_firstPoint, startPoint);
        var distance2 = Mathematics.CalculateDistance(_secondPoint, startPoint);
        var distance3 = Mathematics.CalculateDistance(_thirdPoint, startPoint);
        var distance4 = Mathematics.CalculateDistance(_fourthPoint, startPoint);

        if (distance1 <= pointRadius)
        {
            if (IsValidQuadrangle(finishPoint, _secondPoint, _thirdPoint, _fourthPoint))
                _firstPoint = finishPoint;
        }
        else if (distance2 <= pointRadius)
        {
            if (IsValidQuadrangle(_firstPoint, finishPoint, _thirdPoint, _fourthPoint))
                _secondPoint = finishPoint;
        }
        else if (distance3 <= pointRadius)
        {
            if(IsValidQuadrangle(_firstPoint,_secondPoint,finishPoint,_fourthPoint)) 
                _thirdPoint = finishPoint;
        }
        else if (distance4 <= pointRadius)
        {
            if (IsValidQuadrangle(_firstPoint, _secondPoint, _thirdPoint, finishPoint))
                _fourthPoint = finishPoint;
        }
    }

    public static bool IsValidQuadrangle(Point a, Point b, Point c, Point d)
    {
        var abcAngle = Mathematics.CalculateAngle(a, b, c);
        var bcdAngle = Mathematics.CalculateAngle(b, c, d);
        var cdaAngle = Mathematics.CalculateAngle(c, d, a);
        var dabAngle = Mathematics.CalculateAngle(d, a, b);

        var quadrangleAngles = 360;

        return Math.Abs((abcAngle + bcdAngle + cdaAngle + dabAngle) - quadrangleAngles) < double.Epsilon;
    }
    
    public override void ScalingCoordinates(float scaleX, float scaleY)
    {
        _firstPoint = new Point((int)(_firstPoint.X * scaleX), (int)(_firstPoint.Y * scaleY));
        _secondPoint = new Point((int)(_secondPoint.X * scaleX), (int)(_secondPoint.Y * scaleY));
        _thirdPoint = new Point((int)(_thirdPoint.X * scaleX), (int)(_thirdPoint.Y * scaleY));
        _fourthPoint = new Point((int)(_fourthPoint.X * scaleX), (int)(_fourthPoint.Y * scaleY));
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