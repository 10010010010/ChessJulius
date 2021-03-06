using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

#nullable enable
namespace Chess
{
    public partial class Form1 : Form
    {
        public static int?[,] Board = new int?[8, 8];
        private int x;
        private int y;
        public static Bitmap boardMap = new Bitmap(400, 400);
        public static int moveCounter = 0;
        public static string projectDir = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        public static bool?[,] PossebleMoves = new bool?[8, 8];
        public int marker = 0;
        private bool showAvalebleMoves = false; 
        

        public Form1()
        {
            InitializeComponent();
            gameTimer.Start();
            panel1.Width = 1000;
            panel1.Height = 1000;
            button1.Text = "Reset";
            label1_Click(this, EventArgs.Empty);;
        }

        public static void board(object sender, EventArgs e)
        {  // skapar en bitmap som ser ut som en bräda, har gjort såhär för att undvika att måla om brädet vaje gång programmet körs
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

            // med hjälp av en två dimentionel array målar denna pjäserna på deras plats.
            // Varje pjäs har sitt egna värde som används för att veta vilken pjäs som ska vara på vilek plats platsen till exempel har en vit bonde värdet 2 och en vit häst har värdet 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Board[i, j] != null)
                    {
                        switch (Board[i, j])
                        {
                            case 1:
                                pawn.drawPawn(e, i, j);
                                break;
                            case 2:
                                pawn.drawPawn(e, i, j);
                                break;
                            case 3:
                                bishop.drawBishop(e, i, j);
                                break;
                            case 4:
                                bishop.drawBishop(e, i, j);
                                break;
                            case 5:
                                knight.drawknight(e, i, j);
                                break;
                            case 6:
                                knight.drawknight(e, i, j);
                                break;
                            case 7:
                                rook.drawRook(e, i, j);
                                break;
                            case 8:
                                rook.drawRook(e, i, j);
                                break;
                            case 9:
                                queen.drawQueen(e, i, j);
                                break;
                            case 10:
                                queen.drawQueen(e, i, j);
                                break;
                            case 11:
                                king.drawKing(e, i, j);
                                break;
                            case 12:
                                king.drawKing(e, i, j);
                                break;
                        }
                    }
                }
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {   // här ritas alla viktiga object till panelen
            Brush red = new SolidBrush(Color.Red);
            Graphics g = e.Graphics;
            g.DrawImage(boardMap, 0, 0);
            //Beroende på vilken mängd clicks som har gjorts på brädan får vi olika färger som signalerar olika saker
            // Röd är pjäsen som du försöker flytta
            // Grön visar platsen du vill hoppa till 
            // och du använder högerclick för att utföra draget
            if (movment.X1.Count > 0 && movment.Y1.Count > 0 && marker % 2 != 0)
            {
                g.FillRectangle(red, (movment.X1.Last() - 1) * 50, (movment.Y1.Last() - 1) * 50, 50, 50);
                showAvalebleMoves = true;
                Array.Clear(PossebleMoves,0,PossebleMoves.Length);
            }
            else if ((movment.X1.Count > 0 && movment.Y1.Count > 0 && marker % 2 == 0))
            {
                showAvalebleMoves = false;
                g.FillRectangle(Brushes.Green, (movment.X1.Last() - 1) * 50, (movment.Y1.Last() - 1) * 50, 50, 50);

            }
   // Här ritas alla möjliga drag efter possable moves arrayen
   // arrayen blir ränsad varje gång man byter pjäs så att den bara visar dem möjliga dragen för pjäsen i fokus
            if (showAvalebleMoves)
            {movment.drawPossableMoves(movment.X1.Last()-1,movment.Y1.Last()-1);
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (PossebleMoves[i,j]==true )
                        {
                            g.FillRectangle(Brushes.Aqua, (i)*50,(j)*50,50,50);
                        }
                        
                    }
                    
                }
                
            }


            this.BackColor = Color.Bisque;
            playerPawns(e);
        }

        private void gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            gameTimer.Interval = 500;
            panel1.Invalidate();
        }

       
    

    private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Brush brush = new SolidBrush(Color.Red);
            if (movment.X1.Count != 0 && movment.X1.Count % 2 ==0 && (e.Button&MouseButtons.Right)!=0)
            {
                movment mvnt = new movment();
                mvnt.pieceMovment();
               
            }
          // Denna koden kollar vart på skärmen musen är när du klickar och sätter in det i rutnätet som finns 
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    if ((i - 1) * 50 < e.X && e.X < i * 50 && (j - 1) * 50 < e.Y && e.Y < j * 50 && (e.Button & MouseButtons.Left) != 0)
                    {
                        movment.Y1.Add(j);
                        movment.X1.Add(i);
                        marker++; 
                        
                    }
                }
            }
        }

       
       // Koden som ränsar bärdan 
        public static void resetBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Board[i, j] = null;
                }
                
            }
            
            
        }
        
        
        /*
         *Sätter in alla pjäserna på brädan i deras korrekta startkordinat varje gång man lickar på knappen, i princip fungerar den som en reset knapp
         * 
         */
        private void button1_Click(object sender, EventArgs e)
        {
            
            resetBoard();
            moveCounter = 0;
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

        private void panel1_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.Text="1.Använd musen för att välja pjäsen du vill flytta" +Environment.NewLine+"2.Vänster clicka för att välja pjäsen du vill förflytta, den borde lysa up i rött" +Environment.NewLine+
                        "3. Välj platsen du vill flytta pjäsen till genom att vänster clicka på en annan position, platsen borde lysa grönt" +Environment.NewLine+
                        "4. För att utföra draget högerclickar du på valfri plats på skärmen";
        }
    }
}