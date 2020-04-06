using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etapa_5__Dijkstra_
{
    class DijkstraItem
    {
        public Vertex original;
        public Vertex proveniente;

        public bool isDefinitive;

        public int acumulateWeight;

        public DijkstraItem(Vertex origen)
        {
            this.original = origen;

            isDefinitive = false;
            acumulateWeight = int.MaxValue;
        }
    }
}
