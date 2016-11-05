using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    class SetCell
    {
        public static void SetDoughterCells(Array nodeArray, List<Node> openList, List<Node> closedList, int x, int y, int x2, int y2)
        {
            //создаем вспомогательный массив, значения которого мы в разных комбинациях 
            //прибавляем к входным координатам
            int[] helper = new int[] { 1, -1, 0 };
            //циклы прибавления
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //проверяем, что х и у допустмы, и исключаем случай, 
                    //когда мы остаемся в стартовой точке, и элемент содержится в закрытом листе 
                    if (x + helper[i] < Math.Sqrt(nodeArray.Arr.Length) && x + helper[i] >= 0 && y + helper[j] >= 0 &&
                        y + helper[j] < Math.Sqrt(nodeArray.Arr.Length) &&
                        nodeArray.Arr[y + helper[j], x + helper[i]].IsWalkable == 0 &&
                        nodeArray.Arr[y, x] != nodeArray.Arr[y + helper[j], x + helper[i]] &&
                        !closedList.Contains(nodeArray.Arr[y + helper[j], x + helper[i]]))
                    {
                        if (!openList.Contains(nodeArray.Arr[y + helper[j], x + helper[i]]))
                        {
                            //добавляем узел в опен лист и присваеваем ему стартовый как родительский
                            openList.Add(nodeArray.Arr[y + helper[j], x + helper[i]]);
                            nodeArray.Arr[y + helper[j], x + helper[i]].Parent = nodeArray.Arr[y, x];
                            //задаем значение G и H
                            if (Math.Abs(helper[i]) == Math.Abs(helper[j])) nodeArray.Arr[y + helper[j], x + helper[i]].G = nodeArray.Arr[y, x].G + 14;
                            else nodeArray.Arr[y + helper[j], x + helper[i]].G = 10;
                            nodeArray.Arr[y + helper[j], x + helper[i]].H = 10 * (Math.Abs(x2 - x - helper[i]) + Math.Abs(y2 - y - helper[j]));
                        }
                        else
                        {
                            if (nodeArray.Arr[y + helper[j], x + helper[i]].G > nodeArray.Arr[y, x].G + (Math.Abs(helper[i]) == Math.Abs(helper[j]) ? 14 : 10))
                            {
                                nodeArray.Arr[y + helper[j], x + helper[i]].Parent = nodeArray.Arr[y, x];
                                nodeArray.Arr[y + helper[j], x + helper[i]].G = nodeArray.Arr[y, x].G + (Math.Abs(helper[i]) == Math.Abs(helper[j]) ? 14 : 10);
                            }
                        }

                    }

                }
            }
        }
    }
}
