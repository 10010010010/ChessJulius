using System.Drawing;
using System.Windows.Forms;
using Chess;

namespace Chess
{
    public class movment
    {
     
        public int[] pieceMovment(object sender,   MouseEventArgs e)
        {
            
           


            for (int i = 0; i < 8; i++)
            {
                
                for (int j = 0; j < 8; j++)
                {
                    if ((i - 1) * 50 < e.X && e.X < i * 50 && (j - 1) * 50 < e.Y && e.Y < j * 50)
                    {
                        int[] arr = new int[2];
                        arr[0] = i;
                        arr[1] = j;
                        return arr;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return null;
        }
    }
}