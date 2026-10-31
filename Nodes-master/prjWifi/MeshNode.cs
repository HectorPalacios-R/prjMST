using System;
using System.Collections.Generic;
using System.Text;

namespace prjWifi
{
    public class MeshNode
    {
        public string Name { get; set; }
        public bool IsInNetwork { get; set; } = false;
        public List<WiFiHop> AvailableSignals { get; set; } = new List<WiFiHop>();  

        public MeshNode(string name)
        {
            Name = name;
        }

        public void AddTwoWaySignal(MeshNode neighbor, int powerCost)
        {
            this.AvailableSignals.Add(new WiFiHop(this, neighbor, powerCost));
            neighbor.AvailableSignals.Add(new WiFiHop(neighbor, this, powerCost));
        }
    }
}
