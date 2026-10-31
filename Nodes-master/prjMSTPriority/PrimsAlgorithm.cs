using System;
using System.Collections.Generic;
using System.Text;

namespace prjMSTPriority
{
    internal class PrimsAlgorithm
    {
        public int CalculateMinimumSpanningTreeCost(List<Node> allNodes)
        {
            var pq = new PriorityQueue<Edge, int>();
            int totalCost = 0;

            Node startNode = allNodes[0];
            pq.Enqueue(new Edge(startNode, 0), 0);

            Console.WriteLine($"[START] Began at {startNode.Name}\n");
            while (pq.Count > 0)
            {
                Edge current = pq.Dequeue();
                Node dest = current.TargetNode;

                Console.WriteLine($"[CHECKING] {dest.Name} (Cost: {current.Cost})");

                if (dest.IsInNetwork)
                {
                    Console.WriteLine("    -> SKIP: Already connected (Avoid loop)");
                    continue;
                }

                dest.IsInNetwork = true;
                totalCost += current.Cost;

                if (current.Cost > 0)
                {
                    Console.WriteLine($"    -> ADDED to network: (Total cost: {totalCost})");
                }

                foreach(Edge edge in dest.AvailableEdges)
                {
                    if(!edge.TargetNode.IsInNetwork)
                    {
                        Console.WriteLine($"    -> Found road to {edge.TargetNode.Name} " +
                            $"(Cost: {edge.Cost}). Queued.");
                        pq.Enqueue(edge, edge.Cost);
                    }
                }
                Console.WriteLine();
            }
            return totalCost;
        }
    }
}
