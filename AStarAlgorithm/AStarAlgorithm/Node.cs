using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AStarAlgorithm
{
    class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int IsWalkable { get; set; }
        public float G { get; set; }
        public float H { get; set; }
        public float F { get { return this.G + this.H; } }
        public Node Parent;
    }
}
