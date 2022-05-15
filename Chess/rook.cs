using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public class rook
    {

        private static int rookBlack=7;
        private static int rookWhite=8;

        public static int RookBlack
        {
            get => rookBlack;
            set => rookBlack = value;
        }

        public static int RookWhite
        {
            get => rookWhite;
            set => rookWhite = value;
        }


        public static void drawRook(PaintEventArgs e, int x, int y)
        {

            Graphics g = e.Graphics;

            if (Form1.pubBoard[x,y]==rookWhite)
            {
                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/chess_rook_white.png"), x*50, y*50, 50, 50);

            }
            else if (Form1.pubBoard[x,y]==rookBlack)
            {


                g.DrawImage(Image.FromFile(Form1.projectDir + "/Chess/gameImages/chess_rook_black.png"), x*50, y*50, 50, 50);

            }
        }
    }
}