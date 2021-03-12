using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HeapSortVisualization
{
    public class DrawSquare
    {
        public Color Color { get; set; }
        public Point Position { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public string drawString { get; set; }
        public Point pointSquare { get; set; }
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
                graphics.FillRectangle(brush, Position.X, Position.Y, Width, Height);
            }

            using (Pen pen = new Pen(Color, 2))
            {
                graphics.DrawRectangle(pen, Position.X, Position.Y, Width, Height);
                graphics.DrawString(drawString, drawFont, drawBrush, pointSquare.X, pointSquare.Y, drawFormat);
            }
        }
    }
}
