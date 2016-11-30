using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    class Array
    {
        public int N { get; set; }
        Random rand = new Random();
        public Node[,] Arr { get; set; }

        public Array(int n)
        {
            int arrSum = 0;
            this.N = n;
            Arr = new Node[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Arr[i, j] = new Node();
                    Arr[i, j].IsWalkable = 0;
                    Arr[i, j].X = j;
                    Arr[i, j].Y = i;
                }
            }
            do
            {
                int i = rand.Next(0, n);
                int j = rand.Next(0, n);
                if (Arr[i, j].IsWalkable == 0)
                {
                    Arr[i, j].IsWalkable = 1;
                    arrSum++;
                }

            } while (arrSum < 0.4 * n * n);
        }

        public void ShowArray()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Arr[i, j].IsWalkable+" ");
                }
                Console.WriteLine();
            }
        }
        public int RetCoord(int x, int y)
        {
            return Arr[y, x].IsWalkable;
        }
    }
}
