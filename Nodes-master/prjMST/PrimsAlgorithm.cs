using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace prjMST
{
    public class PrimsAlgorithm
    {
        public void FindAndPrintMinimumSpanningTree(NetworkGraph graph)
        {
            var nodes = graph.Nodes;
            var matrix = graph.ConnectedCosts;

            //Pick the starting point (First in the list)
            Node startNode = nodes[0];
            startNode.MinimumCostToConnect = 0;

            //Loop until all nodes are connected 
            for(int step = 0; step < nodes.Count; step++)
            {
                //Pick the cheapest unconnected node to evaluate 
                Node currentNode = GetCheapestUnconnectedNode(nodes);

                //Add it to our final networks 
                currentNode.IsInNetwork = true;

                //Look at the possible paths leaving the current node
                for(int targetIndex = 0; targetIndex < nodes.Count; targetIndex++)
                {
                    int roadCost = matrix[currentNode.MatrixIndex, targetIndex];
                    Node targetNode = nodes[targetIndex];

                    if (roadCost > 0 && !targetNode.IsInNetwork && 
                        roadCost < targetNode.MinimumCostToConnect)
                    {
                        //Update the node with the new and cheaper connection 
                        targetNode.MinimumCostToConnect = roadCost;
                        targetNode.ConnectedVia = currentNode;
                    }
                }
            }
            PrintResults(nodes);

        }

        //Helper method to scan the list and find the lowest connecting node
        private Node GetCheapestUnconnectedNode(List<Node> nodes)
        {
            Node cheapestNode = null;
            int lowestCostFound = int.MaxValue;

            foreach(Node node in nodes)
            {
                if(!node.IsInNetwork && node.MinimumCostToConnect < lowestCostFound)
                {
                    lowestCostFound = node.MinimumCostToConnect;
                    cheapestNode = node;
                }
            }
            return cheapestNode;
        }

        private void PrintResults(List<Node> nodes)
        {
            Console.WriteLine("Minimum Spanning Tree Connections:");
            Console.WriteLine("----------------------------------");
            int totalCost = 0;
            //Skip the first node because it is the root (has no "connectedvia")
            foreach(Node node in nodes)
            {
                if(node.ConnectedVia != null)
                {
                    Console.WriteLine($"Edge: {node.ConnectedVia.Name} " +
                        $"-> {node.Name} \tCost: {node.MinimumCostToConnect}");
                    totalCost += node.MinimumCostToConnect;
                }
            }
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Total Cost to connect all nodes: {totalCost}");
        }
    }
}
