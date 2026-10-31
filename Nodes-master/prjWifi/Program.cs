namespace prjWifi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MeshNode server = new MeshNode("Central Server");
            MeshNode nodeA = new MeshNode("Node A");
            MeshNode nodeB = new MeshNode("Node B");
            MeshNode nodeC = new MeshNode("Node C");

            server.AddTwoWaySignal(nodeA, 2);
            server.AddTwoWaySignal(nodeB, 6);
            nodeA.AddTwoWaySignal(nodeC, 5);
            nodeB.AddTwoWaySignal(nodeC, 1);

            List<MeshNode> meshNetwork = new List<MeshNode>
            {
                server,
                nodeA,
                nodeB,
                nodeC
            };

            PrimsAlgorithm routing = new PrimsAlgorithm();
            int minimumPower = routing.CalculateEfficientRouting(meshNetwork);

            Console.WriteLine($"\n Minimum power required for full mesh: " +
                $"{minimumPower}");
        }
    }
}
