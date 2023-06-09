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
    
    public override void FinishDrawingFigure(PictureBox pictureBox)
    {
        Drawing.DrawPoint(pictureBox, _thirdPoint, Color.Black);
        
        Drawing.DrawLine(pictureBox, _firstPoint, _thirdPoint, Color.Black);
        Drawing.DrawLine(pictureBox, _secondPoint, _thirdPoint, Color.Black);
    }

    public override void MoveFigure(PictureBox pictureBox, Point startPoint, Point finishPoint)
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
        
        Drawing.DrawPoint(pictureBox, _firstPoint, Color.Black);
        Drawing.DrawPoint(pictureBox, _secondPoint, Color.Black);

        Drawing.DrawLine(pictureBox, _firstPoint, _secondPoint, Color.Black);
        
        FinishDrawingFigure(pictureBox);
    }

    public override void PaintOverFigure(PictureBox pictureBox)
    {
        Drawing.DrawPoint(pictureBox, _firstPoint, Color.White);
        Drawing.DrawPoint(pictureBox, _secondPoint, Color.White);
        Drawing.DrawPoint(pictureBox, _thirdPoint, Color.White);
        
        Drawing.DrawLine(pictureBox, _firstPoint, _secondPoint, Color.White);
        Drawing.DrawLine(pictureBox, _secondPoint, _thirdPoint, Color.White);
        Drawing.DrawLine(pictureBox, _thirdPoint, _firstPoint, Color.White);
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