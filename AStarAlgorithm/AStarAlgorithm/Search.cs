using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStarAlgorithm
{
    class Search
    {
        
        public static int SerchMin(List<Node> someList)
        {
            int min = 0;
            for (int i = 1; i < someList.Count; i++)
            {
                if (someList[i].F < someList[min].F) min = i;
            }
            return min;
        }
    }
}
