using System;
using System.Drawing;
using System.Windows.Forms;


namespace Chess
{
    public class knight
    {

        private static int knightBlackValue = 5;
        private static int knightWhiteValue = 6;

        public static int KnightBlackValue
        {
            get => knightBlackValue;
            set => knightBlackValue = value;
        }

        public static int KnightWhiteValue
        {
            get => knightWhiteValue;
            set => knightWhiteValue = value;
        }

        
        public static void drawknight(PaintEventArgs e, int x, int y)
        {

            Graphics g = e.Graphics;

            if (Form1.Board[x,y]==KnightWhiteValue)
            {
                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/chess_knigh_white.png"), x*50, y*50, 50, 50);

            }
            else if (Form1.Board[x,y]==KnightBlackValue)
            {
                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/chess-26774.png"), x*50, y*50, 50, 50);

            }
        }
    }
}