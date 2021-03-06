using System;
using System.Drawing;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Chess;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using Chess.Properties;

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
        { Assembly assembly = Assembly.GetExecutingAssembly();
            Graphics g = e.Graphics;

            if (Form1.Board[x,y]==pawnWhiteValue)
            {
                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/pawn_white.png"), x*50, y*50,50,50);
               
            }
            else if (Form1.Board[x,y]==pawnValueBlack)
            
                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/pwan_black.png"), x*50, y*50,50,50);
                
        }


            
        }
    }
