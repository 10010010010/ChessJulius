﻿using System;
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
using static Chess.pawnGraphics;
#nullable  enable
namespace Chess
{
    public partial class Form1 : Form
    {
        private static int?[,] Board = new int?[8, 8];
        private static char?[,] pieces = new char?[8, 8];
        public static int[] pos;

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

        public static void board(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen Black = new Pen(Color.Black, 2);
            Pen white = new Pen(Color.White, 2);
            Brush black = new SolidBrush(Color.Black);
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(Black, i * 50, 0, i * 50, 400);
                g.DrawLine(Black, 0, i * 50, 400,i * 50);
                g.DrawRectangle(Black,0,0,400,400);
                for (int j = 0; j < 8; j++)
                {
                   
                    if (i % 2 == 0 && j%2 != 0)
                    {
                        g.FillRectangle(black,i*50,j*50,50,50);
                        
                    } else if (i % 2 != 0 && j % 2 == 0)
                    {
                        g.FillRectangle (black,i*50,j*50,50,50);
                        
                    }
                    
                }
            }
        }

        
        
        
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pawnGraphics pg = new pawnGraphics();
            pg.drawPawn(sender,e,0,0, Color.Black);
            Brush red = new SolidBrush(Color.Red);
            board(sender,e);
            // nullable int for the position of the piece 
            g.FillRectangle(red,pos[0]*50,pos[1]*50,50,50);



        }
        private void gameStart(object sender, EventArgs e)
        {
            gameTimer.Start();
            
        }

        private void gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
        gameTimer.Interval = 10000;
        gameTimer.Enabled = true;
        panel1.Invalidate();
        
        
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e, PaintEventArgs a)
        {
            movment mv = new movment();
             pos = mv.pieceMovment(sender, e);
            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
          
        }
    }
    
}