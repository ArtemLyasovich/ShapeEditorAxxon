﻿using System.Runtime.Serialization;

namespace ShapeEditorAxxon;

[DataContract]
public class Quadrangle : Figure
{
    [DataMember]
    private Point _firstPoint;
    [DataMember]
    private Point _secondPoint;
    [DataMember]
    private Point _thirdPoint;
    [DataMember]
    private Point _fourthPoint;

    public Quadrangle(Point firstPoint, Point secondPoint, Point thirdPoint, Point fourthPoint)
    {
        _firstPoint = firstPoint;
        _secondPoint = secondPoint;
        _thirdPoint = thirdPoint;
        _fourthPoint = fourthPoint;
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

    public override void FinishDrawingFigure(PictureBox pictureBox)
    {
        Drawing.DrawPoint(pictureBox,_fourthPoint, Color.Black);
        
        Drawing.DrawLine(pictureBox,_thirdPoint,_fourthPoint, Color.Black);
        Drawing.DrawLine(pictureBox, _fourthPoint, _firstPoint, Color.Black);
    }

    public override void MoveFigure(PictureBox pictureBox, Point startPoint, Point finishPoint)
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
        
        Drawing.DrawPoint(pictureBox,_firstPoint,Color.Black);
        Drawing.DrawPoint(pictureBox,_secondPoint,Color.Black);
        Drawing.DrawPoint(pictureBox,_thirdPoint,Color.Black);
        
        Drawing.DrawLine(pictureBox,_firstPoint,_secondPoint,Color.Black);
        Drawing.DrawLine(pictureBox,_secondPoint,_thirdPoint,Color.Black);

        FinishDrawingFigure(pictureBox);
    }

    public override void PaintOverFigure(PictureBox pictureBox)
    {
        Drawing.DrawPoint(pictureBox, _firstPoint, Color.White);
        Drawing.DrawPoint(pictureBox, _secondPoint, Color.White);
        Drawing.DrawPoint(pictureBox, _thirdPoint, Color.White);
        Drawing.DrawPoint(pictureBox, _fourthPoint, Color.White);

        Drawing.DrawLine(pictureBox, _firstPoint, _secondPoint, Color.White);
        Drawing.DrawLine(pictureBox, _secondPoint, _thirdPoint, Color.White);
        Drawing.DrawLine(pictureBox, _thirdPoint, _fourthPoint, Color.White);
        Drawing.DrawLine(pictureBox, _fourthPoint, _firstPoint, Color.White);
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