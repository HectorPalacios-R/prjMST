namespace prjMSTPriority
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node nodeA = new Node("Node A");
            Node nodeB = new Node("Node B");
            Node nodeC = new Node("Node C");

            //A -> B (Cost 5)
            nodeA.AddTwoWayConnection(nodeB, 5);
            //B -> C (Cost 3)
            nodeB.AddTwoWayConnection(nodeC, 3);
            //A -> C (Cost 1)
            nodeA.AddTwoWayConnection(nodeC, 1);

            //group them into a list 
            List<Node> graph = new List<Node> { nodeA, nodeB, nodeC };

            PrimsAlgorithm algorithm = new PrimsAlgorithm();
            int finalMstCost = algorithm.CalculateMinimumSpanningTreeCost(graph);

            Console.WriteLine($"Total Cost of Minimum Spanning Tree: {finalMstCost}");

        }
    }
}
