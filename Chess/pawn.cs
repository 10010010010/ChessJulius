using System;
using System.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;
using Chess;
namespace Chess
{
    class pawnGraphics
    {
     private static int reach = 1;

        public static int pawnReach
        {
            get { return reach;}
            set { reach = value; }

        }
        
        public void drawPawn(object sender,PaintEventArgs e, int x, int y, Color color)
        {
            
            Bitmap pawn = new Bitmap(@"C:\\Users\\Juliu\\RiderProjects\\Chess\\Chess\\Images\\chess-26774.png");
            Graphics g = e.Graphics;
            Brush Brush = new SolidBrush(color);
           g.DrawImage(pawn, 50, y, 50, 50);
            Form1.pubBoard[x, y] = 1;
            
          

        }
        
        
    }
}