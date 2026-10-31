using System;
using System.Collections.Generic;
using System.Text;

namespace prjMST
{
    public class Node
    {   
        public string Name { get; set; }
        //where it is in the graph
        public int MatrixIndex { get; set; }
        //Tracks cheapest path found to the node
        public int MinimumCostToConnect { get; set; } = int.MaxValue;
        //which node is it connected to
        public Node ConnectedVia {  get; set; }
        //Prevents loops from making loops
        public bool IsInNetwork { get; set; }

        public Node(string name, int matrixIndex)
        {
            Name = name;
            MatrixIndex = matrixIndex;
        }


    }
}
