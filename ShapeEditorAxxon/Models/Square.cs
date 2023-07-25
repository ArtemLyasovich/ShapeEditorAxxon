namespace ShapeEditorAxxon;

public class Square : Figure
{
    private Point _upperLeft;
    private Point _upperRight;
    private Point _lowerLeft;
    private Point _lowerRight;

    public Square()
    {
        
    }

    public Square(Point upperLeft, Point upperRight, Point lowerLeft, Point lowerRight)
    {
        _upperLeft = upperLeft;
        _upperRight = upperRight;
        _lowerLeft = lowerLeft;
        _lowerRight = lowerRight;
    }

    public override List<Point> GetPoints()
    {
        return new List<Point>()
        {
            _upperLeft,_upperRight,_lowerRight,_lowerLeft
        };
    }

    public static Square FindAllCoordinates(Point upperLeft, Point lowerRight)
    {
        if (upperLeft.Y < lowerRight.Y)
            (upperLeft, lowerRight) = (lowerRight, upperLeft);
        
        var xCenter = (upperLeft.X + lowerRight.X) / 2;
        var yCenter = (upperLeft.Y + lowerRight.Y) / 2;

        var xVector = lowerRight.X - upperLeft.X;
        var yVector = lowerRight.Y - upperLeft.Y;

        var xPerpendicular = -yVector / 2; //Here;
        var yPerpendicular = xVector / 2; //Here

        var upperRight = new Point(xCenter - xPerpendicular, yCenter - yPerpendicular);
        var lowerLeft = new Point(xCenter + xPerpendicular, yCenter + yPerpendicular);

        return new Square(upperLeft, upperRight, lowerLeft, lowerRight);
    }

    public override double CalculateArea()
    {
        var firstTriangle = new Triangle(_upperLeft, _upperRight, _lowerRight);
        var secondTriangle = new Triangle(_lowerRight, _lowerLeft,_upperLeft);

        var area = firstTriangle.CalculateArea() + secondTriangle.CalculateArea();
        
        return area;
    }

    public override bool ContainsPoint(Point point)
    {
        var firstTriangle = new Triangle(_upperLeft, point, _upperRight);
        var secondTriangle = new Triangle(_upperRight, point, _lowerRight);
        var thirdTriangle = new Triangle(_lowerRight, point, _lowerLeft);
        var fourthTriangle = new Triangle(_lowerLeft, point, _upperLeft);
        
        var trianglesArea = firstTriangle.CalculateArea() + secondTriangle.CalculateArea() +
                            thirdTriangle.CalculateArea() + fourthTriangle.CalculateArea();
        var squareArea = CalculateArea();
        
        var epsilon = 0.001;
        
        return Math.Abs(trianglesArea - squareArea) < epsilon;
    }

    public override void FindCoordinatesAfterMoving(Point startPoint, Point finishPoint)
    {
        var deltaX1 = Math.Abs(_upperLeft.X - startPoint.X);
        var deltaY1 = Math.Abs(startPoint.Y - _upperLeft.Y);
        
        _upperLeft.X = finishPoint.X - deltaX1;
        _upperLeft.Y = finishPoint.Y - deltaY1;
        
        var deltaX2 = Math.Abs(_lowerRight.X - startPoint.X);
        var deltaY2 = Math.Abs(_lowerRight.Y - startPoint.Y);
        
        _lowerRight.X = finishPoint.X + deltaX2;
        _lowerRight.Y = finishPoint.Y + deltaY2;

        var newSquare = FindAllCoordinates(_upperLeft, _lowerRight);
        _upperRight = newSquare._upperRight;
        _lowerLeft = newSquare._lowerLeft;
    }

    public override bool ContainsPointOnNode(Point point)
    {
        var pointRadius = 5;

        var distance1 = Mathematics.CalculateDistance(_upperLeft, point);
        var distance2 = Mathematics.CalculateDistance(_upperRight, point);
        var distance3 = Mathematics.CalculateDistance(_lowerLeft, point);
        var distance4 = Mathematics.CalculateDistance(_upperLeft, point);

        return distance1 <= pointRadius || distance2 <= pointRadius || distance3 <= pointRadius ||
               distance4 <= pointRadius;
    }

    public override void FindCoordinatesAfterChanging(Point startPoint, Point finishPoint)
    {
        var pointRadius = 5;

        var distance1 = Mathematics.CalculateDistance(_upperLeft, startPoint);
        var distance2 = Mathematics.CalculateDistance(_upperRight, startPoint);
        var distance3 = Mathematics.CalculateDistance(_lowerLeft, startPoint);

        if (distance1 <= pointRadius)
        {
            _upperLeft = finishPoint;

            var tempSquare = FindAllCoordinates(_upperLeft, _lowerRight);

            _upperRight = tempSquare._upperRight;
            _lowerLeft = tempSquare._lowerLeft;
        }
        else if (distance2 <= pointRadius)
        {
            _upperRight = finishPoint;

            var tempSquare = FindAllCoordinates(_upperRight, _lowerLeft);

            _upperLeft = tempSquare._upperRight;
            _lowerRight = tempSquare._lowerLeft;
        }
        else if (distance3 <= pointRadius)
        {
            _lowerLeft = finishPoint;

            var tempSquare = FindAllCoordinates(_upperRight, _lowerLeft);

            _upperLeft = tempSquare._upperRight;
            _lowerRight = tempSquare._lowerLeft;
        }
        else
        {
            _lowerRight = finishPoint;

            var tempSquare = FindAllCoordinates(_upperLeft, _lowerRight);

            _upperRight = tempSquare._upperRight;
            _lowerLeft = tempSquare._lowerLeft;
        }
    }

    public override void ScalingCoordinates(float scaleX, float scaleY)
    {
        _upperLeft = new Point((int)(_upperLeft.X * scaleX), (int)(_upperLeft.Y * scaleY));
        _lowerRight = new Point((int)(_lowerRight.X * scaleX), (int)(_lowerRight.Y * scaleY));
        
        var tempSquare = FindAllCoordinates(_upperLeft, _lowerRight);
        
        _upperRight = tempSquare._upperRight;
        _lowerLeft = tempSquare._lowerLeft;
    }

    public override string ToString()
    {
        var result = $"Square:  " +
                     $"\tFirst Point: ({_upperLeft.X},{_upperLeft.Y})  " +
                     $"\tSecond Point: ({_upperRight.X}, {_upperRight.Y})  " +
                     $"\tThird Point: ({_lowerLeft.X}, {_lowerLeft.Y})  " +
                     $"\tFourth Point: ({_lowerRight.X}, {_lowerRight.Y})  ";

        return result;
    }
}