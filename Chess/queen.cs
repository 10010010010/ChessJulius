using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public class queen
    {

        private static int blackQueenValue = 9;
        private static int whiteQueenValue = 10;

        public static int BlackQueenValue
        {
            get => blackQueenValue;
            set => blackQueenValue = value;
        }

        public static int WhiteQueenValue
        {
            get => whiteQueenValue;
            set => whiteQueenValue = value;
        }

        public static void drawQueen( PaintEventArgs e, int x, int y)
        {
            
            Graphics g = e.Graphics;
                
            if (Form1.pubBoard[x,y]==WhiteQueenValue)
            {
                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/chess_queen_white.png"), x*50, y*50,50,50);
             
            }
            else if (Form1.pubBoard[x,y]==BlackQueenValue)
            {
                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/chess_queen_black.png"), x*50, y*50,50,50);
              
            }


            
            
        }
    }
}