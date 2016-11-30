using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //инициализируем координаты еще не введенных точек, создаем открытый и закрытый листы
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0, index = 0;

            List<Node> OpenNodeList = new List<Node>();
            List<Node> CloseNodeLIst = new List<Node>();

            Array nodeArray = new Array(10);
            nodeArray.ShowArray();
            //ввод координат, проверка на существование и на то, что это не стены
            do
            {
                Console.WriteLine("Input coordinates(from 0 to 9): ");
                Console.Write("x1 = ");
                x1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("y1 = ");
                y1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(nodeArray.RetCoord(x1, y1));
                Console.Write("x2 = ");
                x2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("y2 = ");
                y2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(nodeArray.RetCoord(x2, y2));
            } while (nodeArray.RetCoord(x1, y1) != 0 || nodeArray.RetCoord(x2, y2) != 0);

            SetCell.SetDoughterCells(nodeArray, OpenNodeList, CloseNodeLIst, x1, y1, x2, y2);//определили дочерние 
                                                                                     //точки начального узла
            CloseNodeLIst.Add(nodeArray.Arr[y1, x1]);//добавляем ее в закрытый

            while (!OpenNodeList.Contains(nodeArray.Arr[y2, x2]))
            {
                if (OpenNodeList.Count == 0)
                {
                    Console.WriteLine("There is no way");
                    return;
                }
                int min = Search.SerchMin(OpenNodeList);
                CloseNodeLIst.Add(OpenNodeList[min]);//добавляем в закрытый лист элемент с индексом, 
                                                     //значение которого минимальное
                OpenNodeList.RemoveAt(min);//удаляем из открытого
                index = CloseNodeLIst.Count - 1;

                x1 = CloseNodeLIst[index].X;
                y1 = CloseNodeLIst[index].Y;
                SetCell.SetDoughterCells(nodeArray, OpenNodeList, CloseNodeLIst, x1, y1, x2, y2);
            }
            Node temp = nodeArray.Arr[y2, x2];
            while (temp != null)
            {
                temp.IsWalkable = 2;
                //nodeArray.ShowArray();
                temp = temp.Parent;
            }
            nodeArray.ShowArray();
        }
        
    }
}
