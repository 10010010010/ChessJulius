using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public class king
    {

        private static int kingValueBlack = 11;
        private static int kingValueWhite = 12;

        public static int KingValueBlack
        {
            get => kingValueBlack;
            set => kingValueBlack = value;
        }

        public static int KingValueWhite
        {
            get => kingValueWhite;
            set => kingValueWhite = value;
        }

        public static void drawKing( PaintEventArgs e, int x, int y)
        {
            
            Graphics g = e.Graphics;
                
            if (Form1.pubBoard[x,y]==KingValueWhite)
            {
                g.DrawImage(Image.FromFile(@"C:\Users\Juliu\Pictures\gameImg\chess_king_white.png"), x*50, y*50,50,50);
             
            }
            else if (Form1.pubBoard[x,y]==KingValueBlack)
            {
                g.DrawImage(Image.FromFile(@"C:\Users\Juliu\Pictures\gameImg\chess_king_black.png"), x*50, y*50,50,50);
              
            }


            
            
        }
    }
}