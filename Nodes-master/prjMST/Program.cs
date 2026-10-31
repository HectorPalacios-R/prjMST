namespace prjMST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //The Adjacency Matrix:
            //Defines the cost of the wires/roads between nodes
            int[,] costMatrix = new int[,]
            {
                { 0, 2, 0, 6, 0 }, // Node A's connections
                { 2, 0, 3, 8, 5 }, //Node B's connection
                { 0, 3, 0, 0, 7 }, // Node C's connections
                { 6, 8, 0, 0, 9 }, //Node D's connection
                { 0, 5, 7, 9, 0 }, // Node E's connections
            };

            string[] nodeNames = { "Node A", "Node B", "Node C",
                "Node D", "Node E" };
            NetworkGraph graph = new NetworkGraph(costMatrix, nodeNames);
            PrimsAlgorithm algorithm = new PrimsAlgorithm();
            algorithm.FindAndPrintMinimumSpanningTree(graph);
        }
    }
}
