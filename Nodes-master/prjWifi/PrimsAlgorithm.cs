using System;
using System.Collections.Generic;
using System.Text;

namespace prjWifi
{
    public class PrimsAlgorithm
    {
        public int CalculateEfficientRouting(List<MeshNode> allNodes)
        {
            var pq = new PriorityQueue<WiFiHop, int>();
            int totalPowerUsed = 0;

            //Always start the network at the Central Server
            MeshNode server = allNodes[0];
            pq.Enqueue(new WiFiHop(server, server, 0), 0);

            Console.WriteLine($"Initializing network at {server.Name}\n");

            while (pq.Count > 0)
            {
                WiFiHop currentSignal = pq.Dequeue();
                MeshNode dest = currentSignal.TargetNode;
                MeshNode src = currentSignal.SourceNode;

                if (src != dest)
                {
                    Console.WriteLine($"Signal from " +
                        $"{src.Name} -> {dest.Name} (Power Cost:" +
                        $" {currentSignal.PowerCost})");
                }
                if (dest.IsInNetwork)
                {
                    if (src != dest)
                        Console.WriteLine("Node already connected (Prevents " +
                            "broadcast loop)\n");
                    continue;
                }

                dest.IsInNetwork = true;
                totalPowerUsed += currentSignal.PowerCost;

                if (currentSignal.PowerCost > 0)
                {
                    Console.WriteLine($" {src.Name} -> {dest.Name} " +
                        $"(Total Network Power: {totalPowerUsed})\n");
                }

                foreach (WiFiHop hop in dest.AvailableSignals)
                {
                    if(!hop.TargetNode.IsInNetwork)
                    {
                        pq.Enqueue(hop, hop.PowerCost);
                    }
                }
            }
            return totalPowerUsed;
        }
    }
}
