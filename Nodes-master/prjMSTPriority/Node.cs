using System;
using System.Collections.Generic;
using System.Text;

namespace prjMSTPriority
{
    public class Node
    {
        public string Name { get; set; }
        //prevents circular loop
        public bool IsInNetwork { get; set; }
        public List<Edge> AvailableEdges { get; set; } = new List<Edge>();
        public Node(string name) 
        {
            Name = name;
        }
        public void AddTwoWayConnection (Node neighbor, int cost)
        {
            this.AvailableEdges.Add(new Edge(neighbor, cost));
            neighbor.AvailableEdges.Add(new Edge(this, cost));
        }
    }
}
