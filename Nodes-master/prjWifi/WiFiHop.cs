using System;
using System.Collections.Generic;
using System.Text;

namespace prjWifi
{
    public class WiFiHop
    {
        public MeshNode SourceNode {  get; set; }
        public MeshNode TargetNode { get; set; }
        public int PowerCost { get; set; }

        public WiFiHop(MeshNode sourceNode, MeshNode targetNode, int powerCost)
        {
            SourceNode = sourceNode;
            TargetNode = targetNode;
            PowerCost = powerCost;
        }
    }
}
