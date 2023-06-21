using System.Timers;

namespace ShapeEditorAxxon;

public partial class Form1 : Form
{
    private List<Figure> _figures = new List<Figure>();

    private Figure _selectedFigure;
    private bool _isDragging;
    private bool _isFigureChanging;
    
    private Point _startLocation;
    private Point _finishLocation;

    public Form1()
    {
        InitializeComponent();
    }
    
    private void squareButton_Click(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_First;
    }

    private void pictureBox1_MouseClick_First(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;
        
        Drawing.DrawPoint(pictureBox1,firstPoint, Color.Black);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_First;
        pictureBox1.MouseClick += pictureBox1_MouseClick_Second;
    }

    private void pictureBox1_MouseClick_Second(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;

        var square = Square.FindAllCoordinates(firstPoint, secondPoint);
        Drawing.DrawSquare(pictureBox1, square, Color.Black);
        Writing.WriteRichTextBox(richTextBox,square.ToString());
        _figures.Add(square);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_Second;
    }
    
    private void triangleButton_Click(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstTriangle;
    }
    
    private void pictureBox1_MouseClick_FirstTriangle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;
        
        Drawing.DrawPoint(pictureBox1,firstPoint, Color.Black);

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstTriangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondTriangle;
    }

    private void pictureBox1_MouseClick_SecondTriangle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;

        Drawing.DrawPoint(pictureBox1, secondPoint, Color.Black);
        Drawing.DrawLine(pictureBox1, firstPoint, secondPoint, Color.Black);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondTriangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_ThirdTriangle;
    }
    
    private void pictureBox1_MouseClick_ThirdTriangle(object sender, MouseEventArgs e)
    {
        thirdPoint = e.Location;

        var triangle = new Triangle(firstPoint, secondPoint, thirdPoint);
        Drawing.DrawTriangle(pictureBox1, triangle, Color.Black);
        Writing.WriteRichTextBox(richTextBox,triangle.ToString());
        _figures.Add(triangle);

        pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdTriangle;
    }
    
    private void circleButton_Click(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstCircle;
    }

    private void pictureBox1_MouseClick_FirstCircle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;

        Drawing.DrawPoint(pictureBox1, firstPoint, Color.Black);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstCircle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondCircle;
    }

    private void pictureBox1_MouseClick_SecondCircle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;
        
        Drawing.DrawPoint(pictureBox1, firstPoint, Color.White);

        var circle = new Circle(firstPoint, secondPoint);
        Drawing.DrawCircle(pictureBox1,circle,Color.Black);
        Writing.WriteRichTextBox(richTextBox,circle.ToString());
        _figures.Add(circle);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondCircle;
    }
    
    private void QuadrangleButtonClick(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstQuadrangle;
    }
    
    private void pictureBox1_MouseClick_FirstQuadrangle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;
        
        Drawing.DrawPoint(pictureBox1, firstPoint, Color.Black);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstQuadrangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondQuadrangle;
    }
    
    private void pictureBox1_MouseClick_SecondQuadrangle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;
        
        Drawing.DrawPoint(pictureBox1, secondPoint, Color.Black);
        Drawing.DrawLine(pictureBox1, firstPoint, secondPoint, Color.Black);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondQuadrangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_ThirdQuadrangle;
    }
    
    private void pictureBox1_MouseClick_ThirdQuadrangle(object sender, MouseEventArgs e)
    {
        thirdPoint = e.Location;

        Drawing.DrawPoint(pictureBox1, thirdPoint, Color.Black);
        Drawing.DrawLine(pictureBox1, secondPoint, thirdPoint, Color.Black);
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdQuadrangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_FourthQuadrangle;
    }
    
    private void pictureBox1_MouseClick_FourthQuadrangle(object sender, MouseEventArgs e)
    {
        fourthPoint = e.Location;

        if (Quadrangle.IsValidQuadrangle(firstPoint, secondPoint, thirdPoint, fourthPoint))
        {
            var quadrangle = new Quadrangle(firstPoint, secondPoint, thirdPoint, fourthPoint);
            Drawing.DrawQuadrangle(pictureBox1, quadrangle, Color.Black);
            Writing.WriteRichTextBox(richTextBox, quadrangle.ToString());
            _figures.Add(quadrangle);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_FourthQuadrangle;
        }
        else
            MessageBox.Show(@"Put the correct point");
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var folderBrowserDialog = new FolderBrowserDialog();

        var result = folderBrowserDialog.ShowDialog();
        if( result == DialogResult.OK )
        {
            var folderPath = folderBrowserDialog.SelectedPath;
            
            var directoryName = "Figures";
            var fullPath = Path.Combine(folderPath, directoryName);
            var directoryInfo = Directory.CreateDirectory(fullPath);

            var directoryPath = directoryInfo.FullName;
            
            FigureConverter.SerializeFigures(directoryPath, _figures);
            
            MessageBox.Show(@"The data was successfully saved");
        }
    }

    private void loadButton_Click(object sender, EventArgs e)
    {
        var folderBrowserDialog = new FolderBrowserDialog();

        var result = folderBrowserDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            var folderPath = folderBrowserDialog.SelectedPath;
            try
            {
                _figures = FigureConverter.DeserializeFigures(folderPath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        var point = e.Location;

        for (var i = _figures.Count - 1; i >= 0; i--)
        {
            var figure = _figures[i] as Figure;
            if(figure.ContainsPointOnNode(point))
            {
                _selectedFigure = figure;
                _isFigureChanging = true;
                _startLocation = point;
                return;
            }
        }

        for (var i = _figures.Count - 1; i >= 0; i--)
        {

            if (_figures[i].ContainsPoint(point))
            {
                _selectedFigure = _figures[i];
                _isDragging = true;
                _startLocation = point;
                
                break;
            }
        }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (_isFigureChanging)
        {
            _finishLocation = e.Location;

            switch (_selectedFigure)
            {
                case Square square:
                    Moving.MoveSquareNode(pictureBox1,_startLocation,_finishLocation, square);
                    _startLocation = _finishLocation;
                    break;
                case Triangle triangle:
                    Moving.MoveTriangleNode(pictureBox1, _startLocation, _finishLocation, triangle);
                    _startLocation = _finishLocation;
                    break;
                case Circle circle:
                    Moving.MoveCircleNode(pictureBox1, _startLocation, _finishLocation, circle);
                    _startLocation = _finishLocation;
                    break;
                case Quadrangle quadrangle:
                    Moving.MoveQuadrangleNode(pictureBox1, _startLocation, _finishLocation, quadrangle);
                    _startLocation = _finishLocation;
                    break;
            }
        }
        
        if (_isDragging)
        {
            _finishLocation = e.Location;
            
            switch (_selectedFigure)
            {
                case Square square:
                    Moving.MoveSquare(pictureBox1,_startLocation,_finishLocation, square);
                    _startLocation = _finishLocation;
                    break;
                case Triangle triangle:
                    Moving.MoveTriangle(pictureBox1, _startLocation, _finishLocation, triangle);
                    _startLocation = _finishLocation;
                    break;
                case Circle circle:
                    Moving.MoveCircle(pictureBox1, _startLocation, _finishLocation, circle);
                    _startLocation = _finishLocation;
                    break;
                case Quadrangle quadrangle:
                    Moving.MoveQuadrangle(pictureBox1, _startLocation, _finishLocation, quadrangle);
                    _startLocation = _finishLocation;
                    break;
            }
        }
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        if (_isFigureChanging)
        {
            _isFigureChanging = false;
            _selectedFigure = null;
        }
        if (_isDragging)
        {
            _isDragging = false;
            _selectedFigure = null;
        }
    }

    private void Timer_Elapsed(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        Writing.UpdateRichTextBox(_figures, richTextBox);

        if (_selectedFigure == null)
            Drawing.RedrawFigures(_figures, pictureBox1);
    }
}