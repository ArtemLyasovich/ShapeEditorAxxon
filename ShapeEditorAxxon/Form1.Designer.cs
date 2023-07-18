using System.Timers;
using Timer = System.Timers.Timer;

namespace ShapeEditorAxxon;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        saveButton = new Button();
        loadButton = new Button();
        stopDrawingButton = new Button();
        clearButton = new Button();
        saveLoadTable = new TableLayoutPanel();
        squareButton = new Button();
        triangleButton = new Button();
        circleButton = new Button();
        quadrangleButton = new Button();
        figureTable = new TableLayoutPanel();
        richTextBox = new RichTextBox();
        pictureBox1 = new DoubleBufferedPictureBox();
        drawingTable = new TableLayoutPanel();
        table = new TableLayoutPanel();
        timer = new Timer();
        timer2 = new Timer();
        formWidth = 1200;
        formHeight = 800;
        saveLoadTable.SuspendLayout();
        figureTable.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        drawingTable.SuspendLayout();
        table.SuspendLayout();
        SuspendLayout();
        //
        // RichTextBoxTimer
        // 
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.Start();
        //
        // PictureBoxTimerTimer
        // 
        timer2.Interval = 50;
        timer2.Elapsed += Timer2_Elapsed;
        timer2.Start();
        //
        // saveButton
        // 
        saveButton.Dock = DockStyle.Fill;
        saveButton.Location = new Point(3, 3);
        saveButton.Name = "saveButton";
        saveButton.Size = new Size(287, 40);
        saveButton.TabIndex = 0;
        saveButton.Text = "Save";
        saveButton.BackColor = Color.White;
        saveButton.Click += saveButton_Click;
        // 
        // loadButton
        // 
        loadButton.Dock = DockStyle.Fill;
        loadButton.Location = new Point(296, 3);
        loadButton.Name = "loadButton";
        loadButton.Size = new Size(287, 40);
        loadButton.TabIndex = 1;
        loadButton.Text = "Load";
        loadButton.BackColor = Color.White;
        loadButton.Click += loadButton_Click;
        // 
        // stopDrawingButton
        // 
        stopDrawingButton.Dock = DockStyle.Fill;
        stopDrawingButton.Location = new Point(589, 3);
        stopDrawingButton.Name = "stopDrawingButton";
        stopDrawingButton.Size = new Size(287, 40);
        stopDrawingButton.TabIndex = 1;
        stopDrawingButton.Text = "Stop Drawing";
        stopDrawingButton.BackColor = Color.White;
        stopDrawingButton.Click += stopDrawingButton_Click;
        // 
        // clearButton
        // 
        clearButton.Dock = DockStyle.Fill;
        clearButton.Location = new Point(882, 3);
        clearButton.Name = "clearButton";
        clearButton.Size = new Size(287, 40);
        clearButton.TabIndex = 1;
        clearButton.Text = "Clear";
        clearButton.BackColor = Color.White;
        clearButton.Click += clearButton_Click;
        // 
        // saveLoadTable
        // 
        saveLoadTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        saveLoadTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        saveLoadTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        saveLoadTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        saveLoadTable.Controls.Add(saveButton, 0, 0);
        saveLoadTable.Controls.Add(loadButton, 1, 0);
        saveLoadTable.Controls.Add(stopDrawingButton, 2, 0);
        saveLoadTable.Controls.Add(clearButton, 3, 0);
        saveLoadTable.Dock = DockStyle.Fill;
        saveLoadTable.Location = new Point(3, 3);
        saveLoadTable.Name = "saveLoadTable";
        saveLoadTable.RowStyles.Add(new RowStyle());
        saveLoadTable.Size = new Size(1172, 46);
        saveLoadTable.TabIndex = 0;
        // 
        // squareButton
        // 
        squareButton.Dock = DockStyle.Fill;
        squareButton.Location = new Point(3, 3);
        squareButton.Name = "squareButton";
        squareButton.Size = new Size(287, 40);
        squareButton.TabIndex = 0;
        squareButton.Text = "Square";
        squareButton.BackColor = Color.White;
        squareButton.Click += squareButton_Click;
        // 
        // triangleButton
        // 
        triangleButton.Dock = DockStyle.Fill;
        triangleButton.Location = new Point(296, 3);
        triangleButton.Name = "triangleButton";
        triangleButton.Size = new Size(287, 40);
        triangleButton.TabIndex = 1;
        triangleButton.Text = "Triangle";
        triangleButton.BackColor = Color.White;
        triangleButton.Click += triangleButton_Click;
        // 
        // circleButton
        // 
        circleButton.Dock = DockStyle.Fill;
        circleButton.Location = new Point(589, 3);
        circleButton.Name = "circleButton";
        circleButton.Size = new Size(287, 40);
        circleButton.TabIndex = 2;
        circleButton.Text = "Circle";
        circleButton.BackColor = Color.White;
        circleButton.Click += circleButton_Click;
        // 
        // quadrangleButton
        // 
        quadrangleButton.Dock = DockStyle.Fill;
        quadrangleButton.Location = new Point(882, 3);
        quadrangleButton.Name = "quadrangleButton";
        quadrangleButton.Size = new Size(287, 40);
        quadrangleButton.TabIndex = 3;
        quadrangleButton.Text = "Quadrangle";
        quadrangleButton.BackColor = Color.White;
        quadrangleButton.Click += QuadrangleButtonClick;
        // 
        // figureTable
        // 
        figureTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        figureTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        figureTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        figureTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        figureTable.Controls.Add(squareButton, 0, 0);
        figureTable.Controls.Add(triangleButton, 1, 0);
        figureTable.Controls.Add(circleButton, 2, 0);
        figureTable.Controls.Add(quadrangleButton, 3, 0);
        figureTable.Dock = DockStyle.Fill;
        figureTable.Location = new Point(3, 55);
        figureTable.Name = "figureTable";
        figureTable.RowStyles.Add(new RowStyle());
        figureTable.Size = new Size(1172, 46);
        figureTable.TabIndex = 1;
        // 
        // richTextBox
        // 
        richTextBox.Dock = DockStyle.Fill;
        richTextBox.Location = new Point(823, 3);
        richTextBox.Name = "listBox";
        richTextBox.Size = new Size(346, 628);
        richTextBox.TabIndex = 1;
        richTextBox.Multiline = true;
        // 
        // pictureBox1
        // 
        pictureBox1.Dock = DockStyle.Fill;
        pictureBox1.Location = new Point(3, 3);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(814, 628);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        pictureBox1.BackColor = Color.White;
        pictureBox1.MouseDown += pictureBox1_MouseDown;
        pictureBox1.MouseMove += pictureBox1_MouseMove;
        pictureBox1.MouseUp += pictureBox1_MouseUp;
        // 
        // drawingTable
        // 
        drawingTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
        drawingTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        drawingTable.Controls.Add(pictureBox1, 0, 0);
        drawingTable.Controls.Add(richTextBox, 1, 0);
        drawingTable.Dock = DockStyle.Fill;
        drawingTable.Location = new Point(3, 107);
        drawingTable.Name = "drawingTable";
        drawingTable.RowStyles.Add(new RowStyle());
        drawingTable.Size = new Size(1172, 634);
        drawingTable.TabIndex = 2;
        // 
        // table
        // 
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        table.Controls.Add(saveLoadTable, 0, 0);
        table.Controls.Add(figureTable, 0, 1);
        table.Controls.Add(drawingTable, 0, 2);
        table.Dock = DockStyle.Fill;
        table.Location = new Point(0, 0);
        table.Name = "table";
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 7F));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 86F));
        table.Size = new Size(1178, 744);
        table.TabIndex = 0;
        // 
        // Form1
        // 
        ClientSize = new Size(1178, 744);
        Controls.Add(table);
        MinimumSize = new Size(1200, 800);
        Name = "Form1";
        BackColor = Color.Gray;
        Text = "Shape editor";
        Resize += Form_Resize;
        saveLoadTable.ResumeLayout(false);
        saveLoadTable.PerformLayout();
        figureTable.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        drawingTable.ResumeLayout(false);
        table.ResumeLayout(false);
        ResumeLayout(false);
    }

    private DoubleBufferedPictureBox pictureBox1;
    private Button squareButton;
    private Button saveButton;
    private Button loadButton;
    private Button stopDrawingButton;
    private Button clearButton;
    private TableLayoutPanel saveLoadTable;
    private Button triangleButton;
    private Button circleButton;
    private Button quadrangleButton;
    private TableLayoutPanel figureTable;
    private RichTextBox richTextBox;
    private TableLayoutPanel drawingTable;
    private TableLayoutPanel table;
    private Timer timer;
    private Timer timer2;

    private Point firstPoint;
    private Point secondPoint;
    private Point thirdPoint;
    private Point fourthPoint;

    private int formWidth;
    private int formHeight;
}