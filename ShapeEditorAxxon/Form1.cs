namespace ShapeEditorAxxon;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void squareButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show(@"Put the points of the main diagonal");
        
        pictureBox1.MouseClick += pictureBox1_MouseClick_First;
    }

    private void pictureBox1_MouseClick_First(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_First;
        pictureBox1.MouseClick += pictureBox1_MouseClick_Second;
    }

    private void pictureBox1_MouseClick_Second(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;

        var square = Square.FindAllCoordinates(firstPoint, secondPoint);
        Square.DrawSquare(pictureBox1,square);
        square.WriteRichTextBox(richTextBox,square.ToString());

        pictureBox1.MouseClick -= pictureBox1_MouseClick_Second;
    }
    
    private void triangleButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Put 3 points");
        
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstTriangle;
    }
    
    private void pictureBox1_MouseClick_FirstTriangle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstTriangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondTriangle;
    }

    private void pictureBox1_MouseClick_SecondTriangle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;

        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondTriangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_ThirdTriangle;
    }
    
    private void pictureBox1_MouseClick_ThirdTriangle(object sender, MouseEventArgs e)
    {
        thirdPoint = e.Location;

        var triangle = new Triangle(firstPoint, secondPoint, thirdPoint);
        Triangle.DrawTriangle(pictureBox1, triangle);
        triangle.WriteRichTextBox(richTextBox,triangle.ToString());
        
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdTriangle;
    }
    
    private void circleButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show(@"Put 2 points defining the diameter");
        
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstCircle;
    }

    private void pictureBox1_MouseClick_FirstCircle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstCircle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondCircle;
    }

    private void pictureBox1_MouseClick_SecondCircle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;

        var circle = new Circle(firstPoint, secondPoint);
        Circle.DrawCircle(pictureBox1,circle);
        circle.WriteRichTextBox(richTextBox,circle.ToString());
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondCircle;
    }
    
    private void QuadrangleButtonClick(object sender, EventArgs e)
    {
        MessageBox.Show("Put 4 points");
        
        pictureBox1.MouseClick += pictureBox1_MouseClick_FirstQuadrangle;
    }
    
    private void pictureBox1_MouseClick_FirstQuadrangle(object sender, MouseEventArgs e)
    {
        firstPoint = e.Location;
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_FirstQuadrangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_SecondQuadrangle;
    }
    
    private void pictureBox1_MouseClick_SecondQuadrangle(object sender, MouseEventArgs e)
    {
        secondPoint = e.Location;
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_SecondQuadrangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_ThirdQuadrangle;
    }
    
    private void pictureBox1_MouseClick_ThirdQuadrangle(object sender, MouseEventArgs e)
    {
        thirdPoint = e.Location;
        
        pictureBox1.MouseClick -= pictureBox1_MouseClick_ThirdQuadrangle;
        pictureBox1.MouseClick += pictureBox1_MouseClick_FourthQuadrangle;
    }
    
    private void pictureBox1_MouseClick_FourthQuadrangle(object sender, MouseEventArgs e)
    {
        fourthPoint = e.Location;

        var quadrangle = new Quadrangle(firstPoint, secondPoint, thirdPoint, fourthPoint);
        Quadrangle.DrawQuadrangle(pictureBox1, quadrangle);
        quadrangle.WriteRichTextBox(richTextBox,quadrangle.ToString());

        pictureBox1.MouseClick -= pictureBox1_MouseClick_FourthQuadrangle;
    }

    private void saveButton_Click(object sender, EventArgs e)
    {

    }

    private void loadButton_Click(object sender, EventArgs e)
    {

    }

    /*private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        drawing = false;
        pictureBox1.Invalidate();
    }
 
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        drawing = true;
    }
 
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!drawing) return;
        var start = new Point(e.X-200, e.Y-80);
        bm2 = new Bitmap(bm);
        pictureBox1.Image = bm2;
        var g = Graphics.FromImage(bm2);
        Pen pen = new Pen(Color.Black);
        g.DrawLine(pen, start.X + 200, start.Y + 100, start.X + 400, start.Y + 100);//верх
        g.DrawLine(pen, start.X + 400, start.Y + 100, start.X + 400, start.Y + 300);//право
        g.DrawLine(pen, start.X + 200, start.Y + 100, start.X + 200, start.Y + 300);//лево
        g.DrawLine(pen, start.X + 200, start.Y + 300, start.X + 400, start.Y + 300);//вниз
        g.DrawLine(pen, start.X + 250, start.Y + 80, start.X + 450, start.Y + 80);//верх2
        g.DrawLine(pen, start.X + 450, start.Y + 80, start.X + 450, start.Y + 280);//право2
        g.DrawLine(pen, start.X + 250, start.Y + 80, start.X + 250, start.Y + 280);//лево2
        g.DrawLine(pen, start.X + 250, start.Y + 280, start.X + 450, start.Y + 280);//вниз
        g.DrawLine(pen, start.X + 200, start.Y + 100, start.X + 250, start.Y + 80);
        g.DrawLine(pen, start.X + 400, start.Y + 100, start.X + 450, start.Y + 80);
        g.DrawLine(pen, start.X + 200, start.Y + 300, start.X + 250, start.Y + 280);
        g.DrawLine(pen, start.X + 400, start.Y + 300, start.X + 450, start.Y + 280);
        g.Dispose(); 
        pictureBox1.Invalidate();
    }*/
}