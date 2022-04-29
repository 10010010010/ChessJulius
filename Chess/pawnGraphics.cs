using System;
using System.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    class pawnGraphics
    {
        public void drawPawn(object sender, PaintEventArgs e, int x, int y, Color color)
        {
            Graphics g = e.Graphics;
            Pen Black = new Pen(Color.Black, 2);
            Pen white = new Pen(Color.White, 2);
            Brush Brush = new SolidBrush(color);
            g.FillEllipse(Brush, x, y, 50, 50);
        }
        
        
    }
}