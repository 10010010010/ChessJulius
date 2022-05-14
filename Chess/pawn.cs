using System;
using System.Drawing;
using System;
using System.Drawing;
using System.Windows.Forms;
using Chess;

namespace Chess
{
    class pawn
    {
        private static int reach = 1;
        private static int pawnValueWhite=2;
        private static int pawnValueBlack=1;
        
        public static int pawnWhiteValue
        {
            get { return pawnValueWhite; }
            set { pawnValueWhite = value; }
        }
        
        public static int pawnBlackValue{
            get { return pawnValueBlack; }
            set { pawnValueBlack = value; }
        }
        
        public static int pawnReach
        {
            get { return reach; }
            set { reach = value; }
        }

        public static void drawPawn( PaintEventArgs e, int x, int y)
        {
            Graphics g = e.Graphics;

            if (Form1.pubBoard[x,y]==pawnWhiteValue)
            {
                g.DrawImage(Image.FromFile("\\GameImages\\pawn_white.png"), x*50, y*50,50,50);
               
            }
            else if (Form1.pubBoard[x,y]==pawnValueBlack)
            
                g.DrawImage(Image.FromFile(), x*50, y*50,50,50);
                
        }

            
        }
    }
