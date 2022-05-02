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
            
        }

        public static void board(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(boardMap))
            {       

                
                Pen Black = new Pen(Color.Black, 2);
                Pen white = new Pen(Color.Bisque, 2);
                Brush black = new SolidBrush(Color.Brown);

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

        public static void playerPawns(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] != null)
                    {
                        switch (Board[i,j])
                        {
                            case 1:
                                pawn.drawPawn(e,i,j);
                                break;
                            case 2:
                                pawn.drawPawn(e,i,j);
                                break;
                            case 3:
                                bishop.drawBishop(e,i,j);
                                break;
                            case 4 :
                                bishop.drawBishop(e,i,j);
                                break;
                            case 5:
                                knight.drawknight(e,i,j);
                                break;
                            case 6:
                                knight.drawknight(e,i,j);
                                break;
                            case 7:
                                rook.drawRook(e,i,j);
                                break;
                            case 8:
                                rook.drawRook(e,i,j);
                                break;
                            case 9:
                                queen.drawQueen(e,i,j);
                                break;
                            case 10:
                                queen.drawQueen(e,i,j);
                                break;
                            case 11:
                                king.drawKing(e,i,j);
                                break;
                            case 12:
                                king.drawKing(e,i,j);
                                break;
                            

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
            this.BackColor = Color.Bisque;
            playerPawns(e);
            
            
        }
      
        private void gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            gameTimer.Interval = 200;
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

        private void button1_Click(object sender, EventArgs e)
        {
            board(this, EventArgs.Empty);
            Board[0, 1] = pawn.pawnBlackValue;
            Board[1, 1] = pawn.pawnBlackValue;
            Board[2, 1] = pawn.pawnBlackValue;
            Board[3, 1] = pawn.pawnBlackValue;
            Board[4, 1] = pawn.pawnBlackValue;
            Board[5, 1] = pawn.pawnBlackValue;
            Board[6, 1] = pawn.pawnBlackValue;
            Board[7, 1] = pawn.pawnBlackValue;
            Board[2, 0] = bishop.BishopValueBlack;
            Board[5, 0] = bishop.BishopValueBlack;
            Board[0, 6] = pawn.pawnWhiteValue;
            Board[1, 6] = pawn.pawnWhiteValue;
            Board[2, 6] = pawn.pawnWhiteValue;
            Board[3, 6] = pawn.pawnWhiteValue;
            Board[4, 6] = pawn.pawnWhiteValue;
            Board[5, 6] = pawn.pawnWhiteValue;
            Board[6, 6] = pawn.pawnWhiteValue;
            Board[7, 6] = pawn.pawnWhiteValue;
            Board[2, 7] = bishop.BishopValueWhite;
            Board[5, 7] = bishop.BishopValueWhite;
            Board[1, 7] = knight.KnightWhiteValue;
            Board[6, 7] = knight.KnightWhiteValue;
            Board[1, 0] = knight.KnightBlackValue;
            Board[6, 0] = knight.KnightBlackValue;
            Board[0, 0] = rook.RookBlack;
            Board[7, 0] = rook.RookBlack;
            Board[0, 7] = rook.RookWhite;
            Board[7, 7] = rook.RookWhite;
            Board[3, 0] = queen.BlackQueenValue;
            Board[3, 7] = queen.WhiteQueenValue;
            Board[4, 0] = king.KingValueBlack;
            Board[4, 7] = king.KingValueWhite;

            
            
            
        }
    }
    
}