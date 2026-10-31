using System;
using System.Collections.Generic;
using System.Text;

namespace prjMSTPriority
{
    public class Edge
    {
        public int Cost {  get; set; }
        public Node TargetNode { get; set; }

        public Edge(Node target, int cost)
        {
            Cost = cost;
            TargetNode = target;
        }
    }
}
