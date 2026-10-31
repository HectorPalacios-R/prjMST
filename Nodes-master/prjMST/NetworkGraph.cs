using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace prjMST
{
    public class NetworkGraph
    {   
        //Holds all the nodes
        public List<Node> Nodes { get; set; }
        //Stores the weights (such as the costs or cable length)   
        public int[,] ConnectedCosts { get; set; }

        public NetworkGraph(int[,] connectionCosts, string[] nodeNames)
        {
            ConnectedCosts = connectionCosts;
            Nodes = new List<Node>();

            for (int i = 0; i < nodeNames.Length; i++)
            {
                Nodes.Add(new Node(nodeNames[i], i));
            }
        }
    }
}
