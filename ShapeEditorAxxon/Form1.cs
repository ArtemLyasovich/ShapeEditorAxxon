using System.Timers;
using ShapeEditorAxxon.View;

namespace ShapeEditorAxxon;

public partial class Form1 : Form
{
    private List<Figure> _figures = new List<Figure>();

    private Figure _selectedFigure;
    private bool _isDragging;
    private bool _isFigureChanging;

    private Point _startLocation;
    private Point _finishLocation;

    private bool _isDrawing;

    public Form1()
    {
        InitializeComponent();
    }

    private void squareButton_Click(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_First;

        circleButton.Enabled = false;
        triangleButton.Enabled = false;
        squareButton.Enabled = false;
        quadrangleButton.Enabled = false;
        loadButton.Enabled = false;
        saveButton.Enabled = false;

        _isDrawing = true;
    }

    private void pictureBox1_MouseClick_First(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;

        Drawing.DrawPoint(pictureBox1, firstPoint, Color.Black);

        pictureBox1.MouseClick -= pictureBox1_MouseClick_First;
        pictureBox1.MouseClick += pictureBox1_MouseClick_Second;

        stopDrawingButton.Enabled = false;
    }

    private void pictureBox1_MouseClick_Second(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;
        
        if (firstPoint != secondPoint)
        {
            var square = Square.FindAllCoordinates(firstPoint, secondPoint);
            Drawing.DrawFigure(pictureBox1, square, Color.Black);
            Writing.WriteRichTextBox(richTextBox, square.ToString());
            _figures.Add(square);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_Second;
            pictureBox1.MouseClick += pictureBox1_MouseClick_First;

            stopDrawingButton.Enabled = true;
        }
        else
            MessageBox.Show(@"You have set 2 identical points. Please put a point other than the first one");
    }

    private void triangleButton_Click(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstTriangle;

        circleButton.Enabled = false;
        triangleButton.Enabled = false;
        squareButton.Enabled = false;
        quadrangleButton.Enabled = false;
        loadButton.Enabled = false;
        saveButton.Enabled = false;

        _isDrawing = true;
    }

    private void pictureBox1_MouseClick_FirstTriangle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;

        Drawing.DrawPoint(pictureBox1, firstPoint, Color.Black);

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstTriangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondTriangle;

        stopDrawingButton.Enabled = false;
    }

    private void pictureBox1_MouseClick_SecondTriangle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;
        
        if (firstPoint != secondPoint)
        {
            Drawing.DrawPoint(pictureBox1, secondPoint, Color.Black);
            Drawing.DrawLine(pictureBox1, firstPoint, secondPoint, Color.Black);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondTriangle;
            pictureBox1.MouseClick += pictureBox1_MouseClick_ThirdTriangle;
        }
        else
            MessageBox.Show(@"You have set 2 identical points. Please put a point other than the first one");
    }

    private void pictureBox1_MouseClick_ThirdTriangle(object sender, MouseEventArgs e)
    {
        thirdPoint = e.Location;
        
        if (!Mathematics.IsPointOnRay(firstPoint, secondPoint, thirdPoint))
        {
            var triangle = new Triangle(firstPoint, secondPoint, thirdPoint);
            Drawing.DrawFigure(pictureBox1, triangle, Color.Black);
            Writing.WriteRichTextBox(richTextBox, triangle.ToString());
            _figures.Add(triangle);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdTriangle;
            pictureBox1.MouseClick += pictureBox1_MouseClick_FirstTriangle;

            stopDrawingButton.Enabled = true;
        }
        else
            MessageBox.Show(
                @"The third point lies on the ray formed by the first two points. Please put another point.");
    }

    private void circleButton_Click(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstCircle;

        circleButton.Enabled = false;
        triangleButton.Enabled = false;
        squareButton.Enabled = false;
        quadrangleButton.Enabled = false;
        loadButton.Enabled = false;
        saveButton.Enabled = false;

        _isDrawing = true;
    }

    private void pictureBox1_MouseClick_FirstCircle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;

        Drawing.DrawPoint(pictureBox1, firstPoint, Color.Black);

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstCircle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondCircle;

        stopDrawingButton.Enabled = false;
    }

    private void pictureBox1_MouseClick_SecondCircle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;

        if (firstPoint != secondPoint)
        {
            Drawing.DrawPoint(pictureBox1, firstPoint, Color.White);

            var circle = new Circle(firstPoint, secondPoint);
            Drawing.DrawFigure(pictureBox1, circle, Color.Black);
            Writing.WriteRichTextBox(richTextBox, circle.ToString());
            _figures.Add(circle);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondCircle;
            pictureBox1.MouseClick += pictureBox1_MouseClick_FirstCircle;

            stopDrawingButton.Enabled = true;
        }
        else
            MessageBox.Show(@"You have set 2 identical points. Please put a point other than the first one");
    }

    private void QuadrangleButtonClick(object sender, EventArgs e)
    {
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstQuadrangle;

        circleButton.Enabled = false;
        triangleButton.Enabled = false;
        squareButton.Enabled = false;
        quadrangleButton.Enabled = false;
        loadButton.Enabled = false;
        saveButton.Enabled = false;

        _isDrawing = true;
    }

    private void pictureBox1_MouseClick_FirstQuadrangle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;

        Drawing.DrawPoint(pictureBox1, firstPoint, Color.Black);

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstQuadrangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondQuadrangle;

        stopDrawingButton.Enabled = false;
    }

    private void pictureBox1_MouseClick_SecondQuadrangle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;

        if (firstPoint != secondPoint)
        {
            Drawing.DrawPoint(pictureBox1, secondPoint, Color.Black);
            Drawing.DrawLine(pictureBox1, firstPoint, secondPoint, Color.Black);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondQuadrangle;
            pictureBox1.MouseClick += pictureBox1_MouseClick_ThirdQuadrangle;
        }
        else
            MessageBox.Show(@"You have set 2 identical points. Please put a point other than the first one");
    }

    private void pictureBox1_MouseClick_ThirdQuadrangle(object sender, MouseEventArgs e)
    {
        thirdPoint = e.Location;

        if (!Mathematics.IsPointOnRay(firstPoint, secondPoint, thirdPoint))
        {
            Drawing.DrawPoint(pictureBox1, thirdPoint, Color.Black);
            Drawing.DrawLine(pictureBox1, secondPoint, thirdPoint, Color.Black);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdQuadrangle;
            pictureBox1.MouseClick += pictureBox1_MouseClick_FourthQuadrangle;
        }
        else
            MessageBox.Show(
                @"The third point lies on the ray formed by the first two points. Please put another point.");
    }

    private void pictureBox1_MouseClick_FourthQuadrangle(object sender, MouseEventArgs e)
    {
        fourthPoint = e.Location;

        if (Quadrangle.IsValidQuadrangle(firstPoint, secondPoint, thirdPoint, fourthPoint))
        {
            var quadrangle = new Quadrangle(firstPoint, secondPoint, thirdPoint, fourthPoint);
            Drawing.DrawFigure(pictureBox1, quadrangle, Color.Black);
            Writing.WriteRichTextBox(richTextBox, quadrangle.ToString());
            _figures.Add(quadrangle);

            pictureBox1.MouseClick -= pictureBox1_MouseClick_FourthQuadrangle;
            pictureBox1.MouseClick += pictureBox1_MouseClick_FirstQuadrangle;

            stopDrawingButton.Enabled = true;
        }
        else
            MessageBox.Show(
                @"One of the angles of the quadrangle has an angle greater than 180 degrees. Please put the correct point");
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        var saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "JSON Files|*.json";
        saveFileDialog.Title = "Save Figures";

        var result = saveFileDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            var filePath = saveFileDialog.FileName;

            FigureConverter.SerializeFigures(filePath, _figures);

            MessageBox.Show(@"The data was successfully saved");
        }
    }

    private void loadButton_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = @"JSON Files|*.json";
        openFileDialog.Title = @"Load Figures";

        var result = openFileDialog.ShowDialog();
        if (result == DialogResult.OK)
        {
            var filePath = openFileDialog.FileName;
            try
            {
                _figures = FigureConverter.DeserializeFigures(filePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
    }

    private void stopDrawingButton_Click(object sender, EventArgs e)
    {
        pictureBox1.MouseClick -= pictureBox1_MouseClick_First;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstCircle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstQuadrangle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstTriangle;

        stopDrawingButton.Enabled = false;
        circleButton.Enabled = true;
        triangleButton.Enabled = true;
        squareButton.Enabled = true;
        quadrangleButton.Enabled = true;
        loadButton.Enabled = true;
        saveButton.Enabled = true;

        _isDrawing = false;
    }

    private void clearButton_Click(object sender, EventArgs e)
    {
        _figures = new List<Figure>();

        richTextBox.Clear();
        pictureBox1.Refresh();

        pictureBox1.MouseClick -= pictureBox1_MouseClick_First;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_Second;

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstCircle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondCircle;

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstQuadrangle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondQuadrangle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdQuadrangle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FourthQuadrangle;

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstTriangle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondTriangle;
        pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdTriangle;

        stopDrawingButton.Enabled = false;
        circleButton.Enabled = true;
        triangleButton.Enabled = true;
        squareButton.Enabled = true;
        quadrangleButton.Enabled = true;
        loadButton.Enabled = true;
        saveButton.Enabled = true;

        _isDrawing = false;
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (!_isDrawing)
        {
            var point = e.Location;

            for (var i = _figures.Count - 1; i >= 0; i--)
            {
                if (_figures[i].ContainsPointOnNode(point))
                {
                    _selectedFigure = _figures[i];
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

                    return;
                }
            }
        }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        timer2.Stop();
        timer2.Start();
        
        if (_isFigureChanging)
        {
            _finishLocation = e.Location;
            Moving.MoveFigureNode(pictureBox1, _startLocation, _finishLocation, _selectedFigure, _figures);
            _startLocation = _finishLocation;
        }

        if (_isDragging)
        {
            _finishLocation = e.Location;
            if (_finishLocation.X < 0) _finishLocation.X = 0;
            if (_finishLocation.X > pictureBox1.Width) _finishLocation.X = pictureBox1.Width;
            if (_finishLocation.Y < 0) _finishLocation.Y = 0;
            if (_finishLocation.Y > pictureBox1.Height) _finishLocation.Y = pictureBox1.Height;

            Moving.MoveFigure(pictureBox1, _startLocation, _finishLocation, _selectedFigure, _figures);
            _startLocation = _finishLocation;
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
    }
    
    private void Timer2_Elapsed(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        timer2.Stop();
        Drawing.RedrawFigures(_figures, pictureBox1);
    }
    
    private void Form_Resize(object sender, EventArgs e)
    {
        var newWidth = pictureBox1.Width;
        var newHeight = pictureBox1.Height;

        var scaleX = (float)newWidth / formWidth;
        var scaleY = (float)newHeight / formHeight;

        foreach (var figure in _figures)
        {
            Drawing.PaintOverFigure(pictureBox1,figure);
            figure.ScalingCoordinates(scaleX, scaleY);
            Drawing.DrawFigure(pictureBox1,figure, Color.Black);
        }

        formWidth = newWidth;
        formHeight = newHeight;
    }
}