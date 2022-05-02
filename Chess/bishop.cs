using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{

    public class bishop
    {


        private static int bishopValueBlack = 3;

        public static int BishopValueBlack
        {
            get => bishopValueBlack;
            set => bishopValueBlack = value;
        }
        
        private static int bishopValueWhite = 4;
        public static int BishopValueWhite
        {
            get => bishopValueWhite;
            set => bishopValueWhite = value;
        }

        
        public static void drawBishop( PaintEventArgs e, int x, int y)
        {
            
            Graphics g = e.Graphics;
                
            if (Form1.pubBoard[x,y]==BishopValueWhite)
            {
                g.DrawImage(Image.FromFile(@"C:\Users\Juliu\Pictures\gameImg\chess_bishop_white.png"), x*50, y*50,50,50);
             
            }
            else if (Form1.pubBoard[x,y]==BishopValueBlack)
            {
                g.DrawImage(Image.FromFile(@"C:\Users\Juliu\Pictures\gameImg\chess_bishop_black.png"), x*50, y*50,50,50);
              
            }


            
            
        }
    }
}