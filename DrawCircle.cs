using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HeapSortVisualization
{
    public class DrawCircle
    {
        public Point Position { get; set; }
        public Point Position1 { get; set; }
        public Point Position2 { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public Color Color { get; set; }
        public Color Brush { get; set; }
        public string drawString { get; set; }
        public Point pointCircle { get; set; }

        public void Paint(Graphics graphics)
        {
            Font drawFont = new Font("Italic", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

            using (Brush brush = new SolidBrush(Color.FromArgb(
                Math.Min(byte.MaxValue, Color.R + 100),
                Math.Min(byte.MaxValue, Color.G + 100),
                Math.Min(byte.MaxValue, Color.B + 100))))
            {
                graphics.FillEllipse(brush, Position.X, Position.Y, Height, Width);
            }
            using (Brush brush = new SolidBrush(Brush))
            {
                graphics.FillEllipse(brush, Position.X, Position.Y, Height, Width);
            }


            using (Pen pen = new Pen(Color, 2))
            {
                graphics.DrawEllipse(pen, Position.X, Position.Y, Height, Width);
                graphics.DrawString(drawString, drawFont, drawBrush, pointCircle.X, pointCircle.Y, drawFormat);
                graphics.DrawLine(pen, Position1, Position2);
            }

            
        }


    }
}
