using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static Chess.pawnGraphics;
#nullable  enable
namespace Chess
{
    public partial class Form1 : Form
    {
        private static int?[,] Board = new int?[8, 8];
        private static char?[,] pieces = new char?[8, 8];
        public int x;
        public int y;
        public static Bitmap boardMap = new Bitmap(400,400);
        
      
        public static int?[,] pubBoard
        {
            get { return Board; }
            set { Board = value; }
            
        }
        public static char?[,] pubPieces
        {
            get { return pieces; }
            set { pieces = value; }
        }
        public Form1()
        {
            InitializeComponent();
            gameTimer.Start();
            panel1.Width = 1000;
            panel1.Height = 1000;
            board(this, EventArgs.Empty);
            
            
            

        }

        public static void board(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(boardMap))
            {


                Pen Black = new Pen(Color.Black, 2);
                Pen white = new Pen(Color.White, 2);
                Brush black = new SolidBrush(Color.Black);

                for (int i = 0; i < 8; i++)
                {
                    g.DrawLine(Black, i * 50, 0, i * 50, 400);
                    g.DrawLine(Black, 0, i * 50, 400, i * 50);
                    g.DrawRectangle(Black, 0, 0, 400, 400);
                    for (int j = 0; j < 8; j++)
                    {

                        if (i % 2 == 0 && j % 2 != 0)
                        {
                            g.FillRectangle(black, i * 50, j * 50, 50, 50);

                        }
                        else if (i % 2 != 0 && j % 2 == 0)
                        {
                            g.FillRectangle(black, i * 50, j * 50, 50, 50);

                        }

                    }
                }
            }
        }

        
        
        
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        { Brush red = new SolidBrush(Color.Red);
            Graphics g = e.Graphics;
            g.DrawImage(boardMap,0,0);
            g.FillRectangle(red,(x-1)*50,(y-1)*50,50,50);
            pawnGraphics pg = new pawnGraphics();
            pg.drawPawn(sender,e,0,1, Color.Black);
            
        }
      
        private void gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            gameTimer.Interval = 100;
            panel1.Invalidate();
        

        }

  
        private void panel1_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {  Brush brush = new SolidBrush(Color.Red);
            for (int i = 0; i < 8; i++)
            {
                
                for (int j = 0; j < 8; j++)
                {
                    if ((i - 1) * 50 < e.X && e.X < i * 50 && (j - 1) * 50 < e.Y && e.Y < j * 50)
                    {
                        y = j;
                        x = i;
                        

                    }
                   
                }
            }
        }
    }
    
}