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
            int?[,] temp = new int?[1,1];
            Form1.Board[X[X.Count-1], Y[Y.Count-1]] = temp[0,0];
            Form1.Board[X[X.Count - 1], Y[Y.Count - 1]] = Form1.Board[X.Last(), Y.Last()];
            temp[0, 0] = Form1.Board[X.Last(), Y.Last()];




        }
    }
}