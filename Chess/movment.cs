using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Chess;

namespace Chess
{
    public class movment
    {
        public static List<int> X1
        {
            get => X;
            set => X = value;
        }

        public static List<int> Y1
        {
            get => Y;
            set => Y = value;
        }
 // två listor som sparar x och y värdena som kommer in när man klickar
 // dem kommer från panel1_mouseClick funktionen
        private static List<int> X = new List<int>();
        private static List<int> Y = new List<int>();

        public void pieceMovment()
        {
            int? temp = 0; 
  // Dehär är koden som rör på pjäserna och fungerar genom att förflytta det första värdet på den andra vädets plats och sen sätta första platsen = 0
            if (X.Count % 2 == 0)
            {
                temp = Form1.Board[X[X.Count - 2] - 1, Y[Y.Count - 2] - 1]; //två steg bak i listan
                Form1.Board[X[X.Count - 1] - 1, Y[Y.Count - 1] - 1] = temp;
                Form1.Board[X[X.Count - 2] - 1, Y[Y.Count - 2] - 1] =  0 ;
            }
        }

        public static void drawPossableMoves(int X, int Y)
        {  // ritar ut möjliga drag efter spelregler, tar dock inte hänsyn om det finns en pjäs imellan
            int lastx = movment.X.Last() -1;
            int lasty = movment.Y.Last() -1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    switch (Form1.Board[X, Y])
                    {
                        case 1:
                            if (lastx == i && lasty == j - 1)
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }if (lastx == i && lasty == j -2 && Form1.moveCounter<3)
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 2:
                            if (lastx == i && lasty == j + 1)
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }if (lastx == i && lasty == j + 2 && Form1.moveCounter<3)
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 3:
                            if (Math.Abs(lastx - i) == Math.Abs(lasty - j))
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 4:
                            if (Math.Abs(lastx - i) == Math.Abs(lasty - j))
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 5:
                            if ((Math.Abs(lastx - i) == 1 && Math.Abs(lasty - j) == 2) )
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            if ((Math.Abs(lastx - i) == 2 && Math.Abs(lasty - j) == 1))
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }
                            break;
                        case 6:
                            if ((Math.Abs(lastx - i) == 1 && Math.Abs(lasty - j) == 2) )
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            if ((Math.Abs(lastx - i) == 2 && Math.Abs(lasty - j) == 1))
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 7:
                            if (lastx == i || lasty == j)
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 8:
                            if (lastx == i || lasty == j)
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 9:
                            if ((Math.Abs(lastx - i) == Math.Abs(lasty - j) )|| (lastx == i || lasty == j)){
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 10:
                            if (Math.Abs(lastx - i) == Math.Abs(lasty - j) ||
                                lastx == i || lasty == j)
                            {
                                Form1.PossebleMoves[i, j] = true;
                            }

                            break;
                        case 11:
                            
                            if (Math.Abs(i-lastx) == 1 && Math.Abs(j-lasty)==1)
                            {
                                Form1.PossebleMoves[i, j] = true;
                                
                            }

                            if (Math.Abs(j-lasty)==1 && i==lastx) 
                            {
                                Form1.PossebleMoves[i, j] =true;


                            }
                            if (Math.Abs(i-lastx)==1 && j==lasty) 
                            {
                                Form1.PossebleMoves[i, j] =true;


                            }

                            break;
                        case 12:
                            if (Math.Abs(i-lastx) == 1 && Math.Abs(j-lasty)==1)
                            {
                                Form1.PossebleMoves[i, j] = true;
                                
                            }

                            if (Math.Abs(j-lasty)==1 && i==lastx) 
                            {
                                Form1.PossebleMoves[i, j] =true;


                            }
                            if (Math.Abs(i-lastx)==1 && j==lasty) 
                            {
                                Form1.PossebleMoves[i, j] =true;


                            }

                            break;
                    }
                }
            }
        }
    }
}