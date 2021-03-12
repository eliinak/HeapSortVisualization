using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeapSortVisualization
{
    public partial class Visualization : Form
    {
        public Visualization()
        {
            InitializeComponent();

            this.SetStyle(
             ControlStyles.UserPaint |
             ControlStyles.AllPaintingInWmPaint |
             ControlStyles.OptimizedDoubleBuffer, true
             );
        }

        private List<Point> pointsForCircles = new List<Point>();
        private List<DrawCircle> drawCircles = new List<DrawCircle>();
        private List<DrawCircle> secondDrawCircles = new List<DrawCircle>();
        private List<Point> pointsForString = new List<Point>();
        private List<Point> pointsForLines = new List<Point>();
        private List<Point> pointsForSquares = new List<Point>();
        private List<Point> pointsForString1 = new List<Point>();
        private List<DrawSquare> drawSquares = new List<DrawSquare>();
        private List<int> unSortedNumbers1 = new List<int>();

        string enteredNumbers;
        private int once = 0;
        private int temp = 0;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var graphics in drawCircles)
            {
                graphics.Paint(e.Graphics);
            }
            foreach (var graphics in secondDrawCircles)
            {
                graphics.Paint(e.Graphics);
            }
            foreach (var graphics in drawSquares)
            {
                graphics.Paint(e.Graphics);
            }

        }
        public List<Point> NeededPoints()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X = 300, Y = 100 });
            points.Add(new Point() { X = 200, Y = 200 });
            points.Add(new Point() { X = 400, Y = 200 });
            points.Add(new Point() { X = 150, Y = 300 });
            points.Add(new Point() { X = 250, Y = 300 });
            return points;
        }
        public List<Point> NeededPointsForSquare()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X = 400, Y = 100 });
            points.Add(new Point() { X = 430, Y = 100 });
            points.Add(new Point() { X = 460, Y = 100 });
            points.Add(new Point() { X = 490, Y = 100 });
            points.Add(new Point() { X = 520, Y = 100 });
            return points;
        }

        public List<Point> NeededCircles()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X = 275, Y = 100 });
            points.Add(new Point() { X = 175, Y = 200 });
            points.Add(new Point() { X = 375, Y = 200 });
            points.Add(new Point() { X = 125, Y = 300 });
            points.Add(new Point() { X = 225, Y = 300 });
            return points;
        }
        public List<Point> NeededSquares()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X = 375, Y = 100 });
            points.Add(new Point() { X = 405, Y = 100 });
            points.Add(new Point() { X = 435, Y = 100 });
            points.Add(new Point() { X = 465, Y = 100 });
            points.Add(new Point() { X = 495, Y = 100 });
            return points;
        }

        private List<Point> NeededLines()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point() { X = 290, Y = 133 });
            points.Add(new Point() { X = 380, Y = 200 });
            points.Add(new Point() { X = 290, Y = 133 });
            points.Add(new Point() { X = 200, Y = 225 });
            points.Add(new Point() { X = 140, Y = 300 });
            points.Add(new Point() { X = 200, Y = 225 });
            points.Add(new Point() { X = 240, Y = 300 });
            return points;
        }
        private void GO_Click(object sender, EventArgs e)
        {
            if (textBoxValues.Text != "")
            {
                if (once != 1 && once != 2 && once != 3 && once != 4 && once != 5 && once != 6 && once != 7 && once != 8)
                {
                    enteredNumbers = textBoxValues.Text;

                    string[] text = textBoxValues.Text.Split(',');
                    foreach (string num in text)
                    {
                        unSortedNumbers1.Add(int.Parse(num));
                    }
                    if (unSortedNumbers1.Count != 3 && unSortedNumbers1.Count != 4 && unSortedNumbers1.Count != 5)
                    {
                        unSortedNumbers1.Clear();
                        MessageBox.Show("Enter 3, 4 or 5 numbers!");
                    }

                    else if (unSortedNumbers1.Count == 5 || unSortedNumbers1.Count == 4 || unSortedNumbers1.Count == 3)
                    {
                        if (temp == 0)
                        {
                            pointsForCircles = NeededCircles();
                            pointsForString = NeededPoints();
                            pointsForLines = NeededLines();
                            pointsForSquares = NeededSquares();
                            pointsForString1 = NeededPointsForSquare();

                            for (int i = 0; i < unSortedNumbers1.Count; i++)
                            {
                                DrawCircle drawCircle = new DrawCircle();
                                drawCircle.Color = Color.Red;
                                drawCircle.Position = pointsForCircles[i];
                                drawCircle.Height = 30;
                                drawCircle.Width = 30;

                                drawCircle.drawString = unSortedNumbers1[i].ToString();
                                drawCircle.pointCircle = pointsForString[i];

                                drawCircle.Position1 = pointsForLines[i];
                                drawCircle.Position2 = pointsForLines[i + 1];

                                drawCircles.Add(drawCircle);
                            }
                            
                            for (int i = 0; i < unSortedNumbers1.Count; i++)
                            {
                                DrawSquare drawSquare = new DrawSquare();
                                drawSquare.Position = pointsForSquares[i];
                                drawSquare.Color = Color.Blue;
                                drawSquare.Height = 30;
                                drawSquare.Width = 30;
                                drawSquare.drawString = unSortedNumbers1[i].ToString();
                                drawSquare.pointSquare = pointsForString1[i];
                                drawSquares.Add(drawSquare);
                            }
                            textBox1.Text = "This is our heap.";
                            textBox2.Text = "Now we have to reduce this to max heap.";

                            Invalidate();
                        }
                    }
                }              
            }

            else if (textBoxValues.Text == "" || textBoxValues.Text == ",")
            {
                MessageBox.Show("Enter values!");
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            drawCircles.Clear();
            secondDrawCircles.Clear();
            unSortedNumbers1.Clear();
            drawSquares.Clear();
            enteredNumbers = "Enter new values..";
            textBoxValues.Text = enteredNumbers;
            enteredNumbers = String.Empty;
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            Invalidate();
            temp = 0;
            once = 0;
        }
        public void Heapify(List<int> arr)
        {
            if(once == 1)
            {
                textBox1.Text = "In a max heap parent node is always grater(equal) than to child nodes";
                textBox2.Text = "We swap them";
                int parent = 0;
                int l = 1;
                int r = 2;
                if (unSortedNumbers1.Count == 3)
                {
                    DrawCircle drawCircle2 = new DrawCircle();
                    drawCircle2.Position = pointsForCircles[unSortedNumbers1.Count - 2];
                    drawCircle2.Color = SystemColors.InactiveCaption;
                    drawCircle2.Brush = SystemColors.InactiveCaption;
                    drawCircle2.Height = 30;
                    drawCircle2.Width = 30;
                    drawCircle2.Position1 = pointsForLines[unSortedNumbers1.Count - 1];
                    drawCircle2.Position2 = pointsForLines[unSortedNumbers1.Count - 0];
                    secondDrawCircles.Add(drawCircle2);

                    if (unSortedNumbers1[0] > unSortedNumbers1[1])
                    {
                        DrawCircle drawCircle3 = new DrawCircle();
                        drawCircle3.Position = pointsForCircles[unSortedNumbers1.Count - 3];
                        drawCircle3.Color = Color.Red;
                        drawCircle3.Height = 30;
                        drawCircle3.Width = 30;
                        drawCircle3.drawString = unSortedNumbers1[1].ToString();
                        drawCircle3.pointCircle = pointsForString[0];
                        secondDrawCircles.Add(drawCircle3);

                        DrawSquare drawSquare = new DrawSquare();
                        drawSquare.Position = pointsForSquares[0];
                        drawSquare.Color = Color.Blue;
                        drawSquare.Height = 30;
                        drawSquare.Width = 30;
                        drawSquare.drawString = unSortedNumbers1[1].ToString();
                        drawSquare.pointSquare = pointsForString1[0];
                        drawSquares.Add(drawSquare);

                        DrawSquare drawSquare1 = new DrawSquare();
                        drawSquare1.Position = pointsForSquares[1];
                        drawSquare1.Color = Color.Blue;
                        drawSquare1.Height = 30;
                        drawSquare1.Width = 30;
                        drawSquare1.drawString = unSortedNumbers1[0].ToString();
                        drawSquare1.pointSquare = pointsForString1[1];
                        drawSquares.Add(drawSquare1);
                    }

                    Invalidate();
                    textBox1.Text = "Only one element left in the heap!";
                    textBox2.Text = "Algorithm ends :)";
                }
                if (unSortedNumbers1.Count != 3)
                {
                    if (arr[l] > arr[parent])
                        parent = l;
                    
                    if (arr[r] > arr[parent])
                        parent = r;

                    if (parent != 0)
                    {
                        DrawCircle drawCircle = new DrawCircle();
                        drawCircle.Color = Color.Red;
                        drawCircle.Position = pointsForCircles[0];
                        drawCircle.Height = 30;
                        drawCircle.Width = 30;
                        drawCircle.drawString = unSortedNumbers1[parent].ToString();
                        drawCircle.pointCircle = pointsForString[0];
                        secondDrawCircles.Add(drawCircle);

                        DrawCircle drawCircle1 = new DrawCircle();
                        drawCircle1.Color = Color.Red;
                        drawCircle1.Position = pointsForCircles[parent];
                        drawCircle1.Height = 30;
                        drawCircle1.Width = 30;
                        drawCircle1.drawString = unSortedNumbers1[0].ToString();
                        drawCircle1.pointCircle = pointsForString[parent];
                        secondDrawCircles.Add(drawCircle1);

                        DrawSquare drawSquare = new DrawSquare();
                        drawSquare.Position = pointsForSquares[0];
                        drawSquare.Color = Color.Blue;
                        drawSquare.Height = 30;
                        drawSquare.Width = 30;
                        drawSquare.drawString = unSortedNumbers1[parent].ToString();
                        drawSquare.pointSquare = pointsForString1[0];
                        drawSquares.Add(drawSquare);

                        DrawSquare drawSquare1 = new DrawSquare();
                        drawSquare1.Position = pointsForSquares[parent];
                        drawSquare1.Color = Color.Blue;
                        drawSquare1.Height = 30;
                        drawSquare1.Width = 30;
                        drawSquare1.drawString = unSortedNumbers1[0].ToString();
                        drawSquare1.pointSquare = pointsForString1[parent];
                        drawSquares.Add(drawSquare1);

                        Invalidate();

                        int temp = unSortedNumbers1[0];
                        unSortedNumbers1[0] = unSortedNumbers1[parent];
                        unSortedNumbers1[parent] = temp;
                    }
                }                    
            }
            if (once == 2)
            {    
                if(unSortedNumbers1.Count == 4)
                {
                    if (unSortedNumbers1[0] > unSortedNumbers1[1])
                    {
                        DrawCircle drawCircle = new DrawCircle();
                        drawCircle.Color = Color.Red;
                        drawCircle.Position = pointsForCircles[0];
                        drawCircle.Height = 30;
                        drawCircle.Width = 30;
                        drawCircle.drawString = unSortedNumbers1[unSortedNumbers1.Count - 2].ToString();
                        drawCircle.pointCircle = pointsForString[0];
                        secondDrawCircles.Add(drawCircle);

                        DrawSquare drawSquare = new DrawSquare();
                        drawSquare.Position = pointsForSquares[0];
                        drawSquare.Color = Color.Blue;
                        drawSquare.Height = 30;
                        drawSquare.Width = 30;
                        drawSquare.drawString = unSortedNumbers1[unSortedNumbers1.Count - 2].ToString();
                        drawSquare.pointSquare = pointsForString1[0];
                        drawSquares.Add(drawSquare);

                        DrawSquare drawSquare1 = new DrawSquare();
                        drawSquare1.Position = pointsForSquares[unSortedNumbers1.Count - 2];
                        drawSquare1.Color = Color.Blue;
                        drawSquare1.Height = 30;
                        drawSquare1.Width = 30;
                        drawSquare1.drawString = unSortedNumbers1[0].ToString();
                        drawSquare1.pointSquare = pointsForString1[unSortedNumbers1.Count - 2];
                        drawSquares.Add(drawSquare1);

                        DrawCircle drawCircle1 = new DrawCircle();
                        drawCircle1.Color = SystemColors.InactiveCaption;
                        drawCircle1.Brush = SystemColors.InactiveCaption;
                        drawCircle1.Position1 = pointsForLines[1];
                        drawCircle1.Position2 = pointsForLines[0];
                        drawCircle1.Position = pointsForCircles[2];
                        drawCircle1.Height = 30;
                        drawCircle1.Width = 30;
                        drawCircle1.pointCircle = pointsForString[2];
                        secondDrawCircles.Add(drawCircle1);

                        int temp = unSortedNumbers1[0];
                        unSortedNumbers1[0] = unSortedNumbers1[2];
                        unSortedNumbers1[2] = temp;
                        Invalidate();
                    }
                  
                }
                if(unSortedNumbers1.Count != 3 && unSortedNumbers1.Count != 4)
                {
                    textBox1.Text = "In a max heap parent node is always grater(equal) than to child nodes";
                    textBox2.Text = "We swap them";
                    int parent = 1;
                    int l = 3;
                    if (arr[l] > arr[parent])
                        parent = l;

                    if (parent != 1)
                    {
                        DrawCircle drawCircle = new DrawCircle();
                        drawCircle.Color = Color.Red;
                        drawCircle.Position = pointsForCircles[1];
                        drawCircle.Height = 30;
                        drawCircle.Width = 30;
                        drawCircle.drawString = unSortedNumbers1[parent].ToString();
                        drawCircle.pointCircle = pointsForString[1];
                        secondDrawCircles.Add(drawCircle);

                        DrawCircle drawCircle1 = new DrawCircle();
                        drawCircle1.Color = Color.Red;
                        drawCircle1.Position = pointsForCircles[parent];
                        drawCircle1.Height = 30;
                        drawCircle1.Width = 30;
                        drawCircle1.drawString = unSortedNumbers1[1].ToString();
                        drawCircle1.pointCircle = pointsForString[parent];
                        secondDrawCircles.Add(drawCircle1);

                        DrawSquare drawSquare = new DrawSquare();
                        drawSquare.Position = pointsForSquares[1];
                        drawSquare.Color = Color.Blue;
                        drawSquare.Height = 30;
                        drawSquare.Width = 30;
                        drawSquare.drawString = unSortedNumbers1[parent].ToString();
                        drawSquare.pointSquare = pointsForString1[1];
                        drawSquares.Add(drawSquare);

                        DrawSquare drawSquare1 = new DrawSquare();
                        drawSquare1.Position = pointsForSquares[parent];
                        drawSquare1.Color = Color.Blue;
                        drawSquare1.Height = 30;
                        drawSquare1.Width = 30;
                        drawSquare1.drawString = unSortedNumbers1[1].ToString();
                        drawSquare1.pointSquare = pointsForString1[parent];
                        drawSquares.Add(drawSquare1);

                        Invalidate();

                        int temp = unSortedNumbers1[1];
                        unSortedNumbers1[1] = unSortedNumbers1[parent];
                        unSortedNumbers1[parent] = temp;
                    }
                }               
            }
            if (once == 4)
            {
                textBox1.Text = "In a max heap parent node is always grater(equal) than to child nodes";
                textBox2.Text = "We swap them";
                int parent = 0;
                int l = 1;
                int r = 2;
                if (arr[l] > arr[parent])
                    parent = l;
                if (arr[r] > arr[parent])
                    parent = r;

                if (parent != 0)
                {
                    DrawCircle drawCircle = new DrawCircle();
                    drawCircle.Color = Color.Red;
                    drawCircle.Position = pointsForCircles[0];
                    drawCircle.Height = 30;
                    drawCircle.Width = 30;
                    drawCircle.drawString = unSortedNumbers1[parent].ToString();
                    drawCircle.pointCircle = pointsForString[0];
                    secondDrawCircles.Add(drawCircle);

                    DrawCircle drawCircle1 = new DrawCircle();
                    drawCircle1.Color = Color.Red;
                    drawCircle1.Position = pointsForCircles[parent];
                    drawCircle1.Height = 30;
                    drawCircle1.Width = 30;
                    drawCircle1.drawString = unSortedNumbers1[0].ToString();
                    drawCircle1.pointCircle = pointsForString[parent];
                    secondDrawCircles.Add(drawCircle1);

                    DrawSquare drawSquare = new DrawSquare();
                    drawSquare.Position = pointsForSquares[0];
                    drawSquare.Color = Color.Blue;
                    drawSquare.Height = 30;
                    drawSquare.Width = 30;
                    drawSquare.drawString = unSortedNumbers1[parent].ToString();
                    drawSquare.pointSquare = pointsForString1[0];
                    drawSquares.Add(drawSquare);

                    DrawSquare drawSquare1 = new DrawSquare();
                    drawSquare1.Position = pointsForSquares[parent];
                    drawSquare1.Color = Color.Blue;
                    drawSquare1.Height = 30;
                    drawSquare1.Width = 30;
                    drawSquare1.drawString = unSortedNumbers1[0].ToString();
                    drawSquare1.pointSquare = pointsForString1[parent];
                    drawSquares.Add(drawSquare1);

                    Invalidate();

                    int temp = unSortedNumbers1[0];
                    unSortedNumbers1[0] = unSortedNumbers1[parent];
                    unSortedNumbers1[parent] = temp;
                }
            }
        }
        public List<int> SortHeap(List<int> arr)
        {            
            if(once == 0)
            {
                textBox1.Text = "1.Swap first and last node and delete the last node from the heap.";
                textBox2.Text = "2.In a max heap parent node is always grater(equal) than to child nodes";
                DrawCircle drawCircle = new DrawCircle();
                drawCircle.Color = Color.Red;
                drawCircle.Position = pointsForCircles[0];
                drawCircle.Height = 30;
                drawCircle.Width = 30;
                drawCircle.drawString = unSortedNumbers1[unSortedNumbers1.Count-1].ToString();
                drawCircle.pointCircle = pointsForString[0];
                secondDrawCircles.Add(drawCircle);

                DrawCircle drawCircle1 = new DrawCircle();
                drawCircle1.Position = pointsForCircles[unSortedNumbers1.Count-1];
                drawCircle1.Color = SystemColors.InactiveCaption;
                drawCircle1.Brush = SystemColors.InactiveCaption;
                drawCircle1.Height = 30;
                drawCircle1.Width = 30;
                if(unSortedNumbers1.Count == 4)
                {
                    drawCircle1.Position1 = pointsForLines[5];
                    drawCircle1.Position2 = pointsForLines[4];
                }
                secondDrawCircles.Add(drawCircle1);

                DrawSquare drawSquare = new DrawSquare();
                drawSquare.Position = pointsForSquares[0];
                drawSquare.Color = Color.Blue;
                drawSquare.Height = 30;
                drawSquare.Width = 30;
                drawSquare.drawString = unSortedNumbers1[unSortedNumbers1.Count-1].ToString();
                drawSquare.pointSquare = pointsForString1[0];
                drawSquares.Add(drawSquare);

                DrawSquare drawSquare1 = new DrawSquare();
                drawSquare1.Position = pointsForSquares[unSortedNumbers1.Count-1];
                drawSquare1.Color = Color.Blue;
                drawSquare1.Height = 30;
                drawSquare1.Width = 30;
                drawSquare1.drawString = unSortedNumbers1[0].ToString();
                drawSquare1.pointSquare = pointsForString1[unSortedNumbers1.Count - 1];
                drawSquares.Add(drawSquare1);
                if (unSortedNumbers1.Count == 3)
                {
                    DrawCircle drawCircle2 = new DrawCircle();
                    drawCircle2.Color = SystemColors.InactiveCaption;
                    drawCircle2.Brush = SystemColors.InactiveCaption;
                    drawCircle2.Height = 30;
                    drawCircle2.Width = 30;
                    drawCircle2.Position1 = pointsForLines[unSortedNumbers1.Count - 2];
                    drawCircle2.Position2 = pointsForLines[unSortedNumbers1.Count - 1];
                    secondDrawCircles.Add(drawCircle2);
                }

                Invalidate();

                int temp = unSortedNumbers1[0];
                unSortedNumbers1[0] = unSortedNumbers1[unSortedNumbers1.Count-1];
                unSortedNumbers1[unSortedNumbers1.Count-1] = temp;
            }    
            if(once == 3)
            {
                if(unSortedNumbers1.Count == 4)
                {
                    textBox1.Text = "Only one element left in the heap!";
                    textBox2.Text = "Algorith ends! :)";
                    if(unSortedNumbers1[0] > unSortedNumbers1[1])
                    {
                        DrawCircle drawCircle2 = new DrawCircle();
                        drawCircle2.Color = Color.Red;
                        drawCircle2.Position = pointsForCircles[0];
                        drawCircle2.Height = 30;
                        drawCircle2.Width = 30;
                        drawCircle2.drawString = unSortedNumbers1[unSortedNumbers1.Count - 3].ToString();
                        drawCircle2.pointCircle = pointsForString[0];
                        secondDrawCircles.Add(drawCircle2);


                        DrawSquare drawSquare2 = new DrawSquare();
                        drawSquare2.Position = pointsForSquares[0];
                        drawSquare2.Color = Color.Blue;
                        drawSquare2.Height = 30;
                        drawSquare2.Width = 30;
                        drawSquare2.drawString = unSortedNumbers1[unSortedNumbers1.Count - 3].ToString();
                        drawSquare2.pointSquare = pointsForString1[0];
                        drawSquares.Add(drawSquare2);

                        DrawSquare drawSquare3 = new DrawSquare();
                        drawSquare3.Position = pointsForSquares[unSortedNumbers1.Count - 3];
                        drawSquare3.Color = Color.Blue;
                        drawSquare3.Height = 30;
                        drawSquare3.Width = 30;
                        drawSquare3.drawString = unSortedNumbers1[0].ToString();
                        drawSquare3.pointSquare = pointsForString1[unSortedNumbers1.Count - 3];
                        drawSquares.Add(drawSquare3);

                        Invalidate();
                    }                       
                    DrawCircle drawCircle3 = new DrawCircle();
                    drawCircle3.Position = pointsForCircles[unSortedNumbers1.Count - 3];
                    drawCircle3.Color = SystemColors.InactiveCaption;
                    drawCircle3.Brush = SystemColors.InactiveCaption;
                    drawCircle3.Height = 30;
                    drawCircle3.Width = 30;
                    drawCircle3.Position1 = pointsForLines[3];
                    drawCircle3.Position2 = pointsForLines[2];
                    secondDrawCircles.Add(drawCircle3);

                    Invalidate();

                    int temp1 = unSortedNumbers1[0];
                    unSortedNumbers1[0] = unSortedNumbers1[unSortedNumbers1.Count - 4];
                    unSortedNumbers1[unSortedNumbers1.Count - 4] = temp1;                    
                }
                if(unSortedNumbers1.Count != 4 && unSortedNumbers1.Count != 3)
                {
                    textBox1.Text = "1.Swap first and last node and delete the last node from the heap.";
                    textBox2.Text = "2.In a max heap parent node is always grater(equal) than to child nodes";
                    DrawCircle drawCircle = new DrawCircle();
                    drawCircle.Color = Color.Red;
                    drawCircle.Position = pointsForCircles[0];
                    drawCircle.Height = 30;
                    drawCircle.Width = 30;
                    drawCircle.drawString = unSortedNumbers1[unSortedNumbers1.Count - 2].ToString();
                    drawCircle.pointCircle = pointsForString[0];
                    secondDrawCircles.Add(drawCircle);

                    DrawCircle drawCircle1 = new DrawCircle();
                    drawCircle1.Position = pointsForCircles[unSortedNumbers1.Count - 2];
                    drawCircle1.Color = SystemColors.InactiveCaption;
                    drawCircle1.Brush = SystemColors.InactiveCaption;
                    drawCircle1.Height = 30;
                    drawCircle1.Width = 30;
                    drawCircle1.Position1 = pointsForLines[unSortedNumbers1.Count - 2];
                    drawCircle1.Position2 = pointsForLines[unSortedNumbers1.Count - 1];
                    secondDrawCircles.Add(drawCircle1);

                    DrawSquare drawSquare = new DrawSquare();
                    drawSquare.Position = pointsForSquares[0];
                    drawSquare.Color = Color.Blue;
                    drawSquare.Height = 30;
                    drawSquare.Width = 30;
                    drawSquare.drawString = unSortedNumbers1[unSortedNumbers1.Count - 2].ToString();
                    drawSquare.pointSquare = pointsForString1[0];
                    drawSquares.Add(drawSquare);

                    DrawSquare drawSquare1 = new DrawSquare();
                    drawSquare1.Position = pointsForSquares[unSortedNumbers1.Count - 2];
                    drawSquare1.Color = Color.Blue;
                    drawSquare1.Height = 30;
                    drawSquare1.Width = 30;
                    drawSquare1.drawString = unSortedNumbers1[0].ToString();
                    drawSquare1.pointSquare = pointsForString1[unSortedNumbers1.Count - 2];
                    drawSquares.Add(drawSquare1);

                    Invalidate();

                    int temp = unSortedNumbers1[0];
                    unSortedNumbers1[0] = unSortedNumbers1[unSortedNumbers1.Count - 2];
                    unSortedNumbers1[unSortedNumbers1.Count - 2] = temp;
                }
               
            }
            if(once == 5 && unSortedNumbers1.Count == 5)
            {
                if(unSortedNumbers1[0] > unSortedNumbers1[1])
                {
                    textBox1.Text = "1.Swap first and last node and delete the last node from the heap.";
                    textBox2.Text = "2.In a max heap parent node is always grater(equal) than to child nodes";
                        DrawCircle drawCircle = new DrawCircle();
                        drawCircle.Color = Color.Red;
                        drawCircle.Position = pointsForCircles[0];
                        drawCircle.Height = 30;
                        drawCircle.Width = 30;
                        drawCircle.drawString = unSortedNumbers1[unSortedNumbers1.Count - 3].ToString();
                        drawCircle.pointCircle = pointsForString[0];
                        secondDrawCircles.Add(drawCircle);

                        DrawSquare drawSquare = new DrawSquare();
                        drawSquare.Position = pointsForSquares[0];
                        drawSquare.Color = Color.Blue;
                        drawSquare.Height = 30;
                        drawSquare.Width = 30;
                        drawSquare.drawString = unSortedNumbers1[unSortedNumbers1.Count - 3].ToString();
                        drawSquare.pointSquare = pointsForString1[0];
                        drawSquares.Add(drawSquare);

                        DrawSquare drawSquare1 = new DrawSquare();
                        drawSquare1.Position = pointsForSquares[unSortedNumbers1.Count - 3];
                        drawSquare1.Color = Color.Blue;
                        drawSquare1.Height = 30;
                        drawSquare1.Width = 30;
                        drawSquare1.drawString = unSortedNumbers1[0].ToString();
                        drawSquare1.pointSquare = pointsForString1[unSortedNumbers1.Count - 3];
                        drawSquares.Add(drawSquare1);

                    DrawCircle drawCircle1 = new DrawCircle();
                    drawCircle1.Position = pointsForCircles[unSortedNumbers1.Count - 3];
                    drawCircle1.Color = SystemColors.InactiveCaption;
                    drawCircle1.Brush = SystemColors.InactiveCaption;
                    drawCircle1.Height = 30;
                    drawCircle1.Width = 30;
                    drawCircle1.Position1 = pointsForLines[unSortedNumbers1.Count - 4];
                    drawCircle1.Position2 = pointsForLines[unSortedNumbers1.Count - 3];
                    secondDrawCircles.Add(drawCircle1);

                    Invalidate();

                    int temp = unSortedNumbers1[0];
                    unSortedNumbers1[0] = unSortedNumbers1[unSortedNumbers1.Count - 3];
                    unSortedNumbers1[unSortedNumbers1.Count - 3] = temp;
                }
               
            }
            if (once == 6 && unSortedNumbers1.Count == 5)
            {
                textBox1.Text = "Only one element left in the heap!";
                textBox2.Text = "Algorithm ends :)";
                if(unSortedNumbers1[0] > unSortedNumbers1[1])
                {
                    DrawCircle drawCircle = new DrawCircle();
                    drawCircle.Color = Color.Red;
                    drawCircle.Position = pointsForCircles[0];
                    drawCircle.Height = 30;
                    drawCircle.Width = 30;
                    drawCircle.drawString = unSortedNumbers1[unSortedNumbers1.Count - 4].ToString();
                    drawCircle.pointCircle = pointsForString[0];
                    secondDrawCircles.Add(drawCircle);
                }
             
                DrawCircle drawCircle1 = new DrawCircle();
                drawCircle1.Position = pointsForCircles[unSortedNumbers1.Count - 4];
                drawCircle1.Color = SystemColors.InactiveCaption;
                drawCircle1.Brush = SystemColors.InactiveCaption;
                drawCircle1.Height = 30;
                drawCircle1.Width = 30;
                drawCircle1.Position1 = pointsForLines[unSortedNumbers1.Count - 3];
                drawCircle1.Position2 = pointsForLines[unSortedNumbers1.Count - 2];
                secondDrawCircles.Add(drawCircle1);

                if(unSortedNumbers1[0] < unSortedNumbers1[1])
                {
                    int temp1 = unSortedNumbers1[0];
                    unSortedNumbers1[0] = unSortedNumbers1[unSortedNumbers1.Count - 4];
                    unSortedNumbers1[unSortedNumbers1.Count - 4] = temp1;
                }

                DrawSquare drawSquare = new DrawSquare();
                drawSquare.Position = pointsForSquares[0];
                drawSquare.Color = Color.Blue;
                drawSquare.Height = 30;
                drawSquare.Width = 30;
                drawSquare.drawString = unSortedNumbers1[unSortedNumbers1.Count - 4].ToString();
                drawSquare.pointSquare = pointsForString1[0];
                drawSquares.Add(drawSquare);

                DrawSquare drawSquare1 = new DrawSquare();
                drawSquare1.Position = pointsForSquares[unSortedNumbers1.Count - 4];
                drawSquare1.Color = Color.Blue;
                drawSquare1.Height = 30;
                drawSquare1.Width = 30;
                drawSquare1.drawString = unSortedNumbers1[0].ToString();
                drawSquare1.pointSquare = pointsForString1[unSortedNumbers1.Count - 4];
                drawSquares.Add(drawSquare1);

                Invalidate();

                int temp = unSortedNumbers1[0];
                unSortedNumbers1[0] = unSortedNumbers1[unSortedNumbers1.Count - 4];
                unSortedNumbers1[unSortedNumbers1.Count - 4] = temp;
            }
            if (once == 1)
            {
                Heapify(arr);
            }
            if(once == 2)
            {
                Heapify(arr);
            }
            if(once == 4 && unSortedNumbers1.Count == 5)
            {
                Heapify(arr);
            }
               
            
            return arr;
        }
        private void StartVisualization_Click(object sender, EventArgs e)
        {
            if (once == 0 && unSortedNumbers1.Count == 0)
            {
                MessageBox.Show("Clear and enter new value!");
            }
            if (once == 7)
            {
                MessageBox.Show("Algorithm ends! Enter button Clear or close the program!");
                once = 0;
                unSortedNumbers1.Clear();
            }
            else if(unSortedNumbers1.Count > 0)
            {
                SortHeap(unSortedNumbers1);
                once++;

            }       
        }

        private void textBoxValues_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != ','))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ReduceHeap_Click(object sender, EventArgs e)
        {
            if(unSortedNumbers1.Count == 3 || unSortedNumbers1.Count == 4 || unSortedNumbers1.Count == 5)
            {
                temp++;
                pointsForCircles = NeededCircles();
                pointsForString = NeededPoints();
                pointsForSquares = NeededSquares();
                pointsForString1 = NeededPointsForSquare();

                if (temp == 1)
                {
                    textBox1.Text = "We have to create Max Heap.";
                    textBox2.Text = "In a max heap parent node is always grater(equal) than to child nodes";

                    int parent = 1;
                    int r;
                    int l = 0;
                    if (unSortedNumbers1.Count != 3)
                    {

                        if (unSortedNumbers1.Count != 3 && unSortedNumbers1.Count != 4)
                        {
                            l = unSortedNumbers1.Count - 2;
                            r = unSortedNumbers1.Count - 1;
                            if (unSortedNumbers1[r] > unSortedNumbers1[parent])
                                parent = r;
                        }
                        if (unSortedNumbers1.Count == 4)
                        {
                            l = unSortedNumbers1.Count - 1;
                        }
                        if (unSortedNumbers1[l] > unSortedNumbers1[parent])
                            parent = l;

                        if (unSortedNumbers1[parent] != unSortedNumbers1[1])
                        {
                            DrawCircle drawCircle = new DrawCircle();
                            drawCircle.Color = Color.Red;
                            drawCircle.Position = pointsForCircles[1];
                            drawCircle.Height = 30;
                            drawCircle.Width = 30;
                            drawCircle.drawString = unSortedNumbers1[parent].ToString();
                            drawCircle.pointCircle = pointsForString[1];
                            secondDrawCircles.Add(drawCircle);

                            DrawCircle drawCircle1 = new DrawCircle();
                            drawCircle1.Color = Color.Red;
                            drawCircle1.Position = pointsForCircles[parent];
                            drawCircle1.Height = 30;
                            drawCircle1.Width = 30;
                            drawCircle1.drawString = unSortedNumbers1[1].ToString();
                            drawCircle1.pointCircle = pointsForString[parent];
                            secondDrawCircles.Add(drawCircle1);

                            DrawSquare drawSquare = new DrawSquare();
                            drawSquare.Position = pointsForSquares[1];
                            drawSquare.Color = Color.Blue;
                            drawSquare.Height = 30;
                            drawSquare.Width = 30;
                            drawSquare.drawString = unSortedNumbers1[parent].ToString();
                            drawSquare.pointSquare = pointsForString1[1];
                            drawSquares.Add(drawSquare);

                            DrawSquare drawSquare1 = new DrawSquare();
                            drawSquare1.Position = pointsForSquares[parent];
                            drawSquare1.Color = Color.Blue;
                            drawSquare1.Height = 30;
                            drawSquare1.Width = 30;
                            drawSquare1.drawString = unSortedNumbers1[1].ToString();
                            drawSquare1.pointSquare = pointsForString1[parent];
                            drawSquares.Add(drawSquare1);

                            Invalidate();
                            int temp = unSortedNumbers1[parent];
                            unSortedNumbers1[parent] = unSortedNumbers1[1];
                            unSortedNumbers1[1] = temp;

                        }
                    }
                }
                if (temp == 2)
                {
                    textBox1.Text = "We have to create Max Heap.";
                    textBox2.Text = "In a max heap parent node is always grater(equal) than to child nodes";
                    int parent = 0;
                    int l = 1;
                    int r = 2;
                    if (unSortedNumbers1[l] > unSortedNumbers1[parent])
                        parent = l;

                    if (unSortedNumbers1[r] > unSortedNumbers1[parent])
                        parent = r;

                    if (unSortedNumbers1[parent] != unSortedNumbers1[0])
                    {
                        DrawCircle drawCircle = new DrawCircle();
                        drawCircle.Color = Color.Red;
                        drawCircle.Position = pointsForCircles[0];
                        drawCircle.Height = 30;
                        drawCircle.Width = 30;
                        drawCircle.drawString = unSortedNumbers1[parent].ToString();
                        drawCircle.pointCircle = pointsForString[0];
                        secondDrawCircles.Add(drawCircle);

                        DrawCircle drawCircle1 = new DrawCircle();
                        drawCircle1.Color = Color.Red;
                        drawCircle1.Position = pointsForCircles[parent];
                        drawCircle1.Height = 30;
                        drawCircle1.Width = 30;
                        drawCircle1.drawString = unSortedNumbers1[0].ToString();
                        drawCircle1.pointCircle = pointsForString[parent];
                        secondDrawCircles.Add(drawCircle1);

                        DrawSquare drawSquare = new DrawSquare();
                        drawSquare.Position = pointsForSquares[0];
                        drawSquare.Color = Color.Blue;
                        drawSquare.Height = 30;
                        drawSquare.Width = 30;
                        drawSquare.drawString = unSortedNumbers1[parent].ToString();
                        drawSquare.pointSquare = pointsForString1[0];
                        drawSquares.Add(drawSquare);

                        DrawSquare drawSquare1 = new DrawSquare();
                        drawSquare1.Position = pointsForSquares[parent];
                        drawSquare1.Color = Color.Blue;
                        drawSquare1.Height = 30;
                        drawSquare1.Width = 30;
                        drawSquare1.drawString = unSortedNumbers1[0].ToString();
                        drawSquare1.pointSquare = pointsForString1[parent];
                        drawSquares.Add(drawSquare1);
                        Invalidate();

                        int temp = unSortedNumbers1[0];
                        unSortedNumbers1[0] = unSortedNumbers1[parent];
                        unSortedNumbers1[parent] = temp;
                    }
                }
                if (temp == 3 && unSortedNumbers1.Count != 4)
                {
                    textBox1.Text = "We have to create Max Heap.";
                    textBox2.Text = "In a max heap parent node is always grater(equal) than to child nodes";
                    int parent = 1;
                    if (unSortedNumbers1.Count != 3)
                    {
                        int l = unSortedNumbers1.Count - 2;

                        if (unSortedNumbers1[l] > unSortedNumbers1[parent])
                            parent = l;
                        if (unSortedNumbers1.Count != 4)
                        {
                            int r = unSortedNumbers1.Count - 1;
                            if (unSortedNumbers1[r] > unSortedNumbers1[parent])
                                parent = r;
                        }
                        if (unSortedNumbers1[parent] != unSortedNumbers1[1])
                        {
                            DrawCircle drawCircle = new DrawCircle();
                            drawCircle.Color = Color.Red;
                            drawCircle.Position = pointsForCircles[1];
                            drawCircle.Height = 30;
                            drawCircle.Width = 30;
                            drawCircle.drawString = unSortedNumbers1[parent].ToString();
                            drawCircle.pointCircle = pointsForString[1];
                            secondDrawCircles.Add(drawCircle);

                            DrawCircle drawCircle1 = new DrawCircle();
                            drawCircle1.Color = Color.Red;
                            drawCircle1.Position = pointsForCircles[parent];
                            drawCircle1.Height = 30;
                            drawCircle1.Width = 30;
                            drawCircle1.drawString = unSortedNumbers1[1].ToString();
                            drawCircle1.pointCircle = pointsForString[parent];
                            secondDrawCircles.Add(drawCircle1);

                            DrawSquare drawSquare = new DrawSquare();
                            drawSquare.Position = pointsForSquares[1];
                            drawSquare.Color = Color.Blue;
                            drawSquare.Height = 30;
                            drawSquare.Width = 30;
                            drawSquare.drawString = unSortedNumbers1[parent].ToString();
                            drawSquare.pointSquare = pointsForString1[1];
                            drawSquares.Add(drawSquare);

                            DrawSquare drawSquare1 = new DrawSquare();
                            drawSquare1.Position = pointsForSquares[parent];
                            drawSquare1.Color = Color.Blue;
                            drawSquare1.Height = 30;
                            drawSquare1.Width = 30;
                            drawSquare1.drawString = unSortedNumbers1[1].ToString();
                            drawSquare1.pointSquare = pointsForString1[parent];
                            drawSquares.Add(drawSquare1);
                            Invalidate();

                            int temp = unSortedNumbers1[1];
                            unSortedNumbers1[1] = unSortedNumbers1[parent];
                            unSortedNumbers1[parent] = temp;
                        }
                    }
                }
                if (temp == 3 && unSortedNumbers1.Count == 4)
                {
                    if (unSortedNumbers1[1] < unSortedNumbers1[3])
                    {
                        DrawCircle drawCircle = new DrawCircle();
                        drawCircle.Color = Color.Red;
                        drawCircle.Position = pointsForCircles[3];
                        drawCircle.Height = 30;
                        drawCircle.Width = 30;
                        drawCircle.drawString = unSortedNumbers1[1].ToString();
                        drawCircle.pointCircle = pointsForString[3];
                        secondDrawCircles.Add(drawCircle);

                        DrawCircle drawCircle1 = new DrawCircle();
                        drawCircle1.Color = Color.Red;
                        drawCircle1.Position = pointsForCircles[1];
                        drawCircle1.Height = 30;
                        drawCircle1.Width = 30;
                        drawCircle1.drawString = unSortedNumbers1[3].ToString();
                        drawCircle1.pointCircle = pointsForString[1];
                        secondDrawCircles.Add(drawCircle1);

                        DrawSquare drawSquare = new DrawSquare();
                        drawSquare.Position = pointsForSquares[1];
                        drawSquare.Color = Color.Blue;
                        drawSquare.Height = 30;
                        drawSquare.Width = 30;
                        drawSquare.drawString = unSortedNumbers1[3].ToString();
                        drawSquare.pointSquare = pointsForString1[1];
                        drawSquares.Add(drawSquare);

                        DrawSquare drawSquare1 = new DrawSquare();
                        drawSquare1.Position = pointsForSquares[3];
                        drawSquare1.Color = Color.Blue;
                        drawSquare1.Height = 30;
                        drawSquare1.Width = 30;
                        drawSquare1.drawString = unSortedNumbers1[1].ToString();
                        drawSquare1.pointSquare = pointsForString1[3];
                        drawSquares.Add(drawSquare1);
                        Invalidate();

                        int temp = unSortedNumbers1[1];
                        unSortedNumbers1[1] = unSortedNumbers1[3];
                        unSortedNumbers1[3] = temp;
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter 3,4, or 5 numbers!");
            }              
        }
    }
}
