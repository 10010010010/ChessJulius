
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PawnGraphics
{
    public class pawn
    {
        void pawnGraphics(object sender, PaintEventArgs e, int x, int y,bool black)
        {  
                Graphics g = e.Graphics;
                Pen Black = new Pen(Color.Black, 2);
                Pen white = new Pen(Color.White, 2);
                Brush blackBrush = new SolidBrush(Color.Black);
                Brush whiteBrush = new SolidBrush(Color.White);
                if (black)
                {
                    g.FillEllipse(blackBrush, x, y, 50, 50);
                }
                else
                {
                    g.FillEllipse(whiteBrush, x, y, 50, 50);
                }
            }
            
        }
    }
