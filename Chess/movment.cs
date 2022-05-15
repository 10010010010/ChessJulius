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

        private static List<int> X = new List<int>();
        private static List<int> Y = new List<int>();

        public void pieceMovment()
        {
            int? temp = 0; 

            if (X.Count % 2 == 0)
            {
                temp = Form1.Board[X[X.Count - 2] - 1, Y[Y.Count - 2] - 1]; //två steg bak i listan
                Form1.Board[X[X.Count - 1] - 1, Y[Y.Count - 1] - 1] = temp;
                Form1.Board[X[X.Count - 2] - 1, Y[Y.Count - 2] - 1] =  0 ;
            }
        }
    }
}