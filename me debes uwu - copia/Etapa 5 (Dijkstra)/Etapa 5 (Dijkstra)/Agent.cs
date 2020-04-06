using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Etapa_5__Dijkstra_
{
    class Agent
    {
        public Vertex lastVertex;
        public Vertex objective;
        public Vertex origen;

        public Edge e_act;

        public DijkstraItem djItm;

        public List<Point> precomputed;

        List<Vertex> pathDFS;
        //public List<Edge> caminoPrecomputado = new List<Edge>;

        public int walkingIndex;
        public int vel;
        public int rad;
        public int id;

        public Agent(Vertex o, int id)
        {
            this.origen = o;
            this.id = id;

            vel = 15;
            walkingIndex = 0;

            lastVertex = null;

            e_act = null;
            this.rad = origen.getR();

            djItm = null;
            precomputed = new List<Point>();
            pathDFS = new List<Vertex>();
            pathDFS.Add(origen);
        }
        public List<DijkstraItem> Dijkstra(Graph g) 
        {
            List<DijkstraItem> candidates = new List<DijkstraItem>();
            foreach (var v in g.vL) 
            {
                candidates.Add(new DijkstraItem(v));         
                if(v.id == origen.id)
                {
                    candidates.Last().acumulateWeight = 0;
                    candidates.Last().proveniente = v;
                    candidates.Last().isDefinitive = true;
                }
            }
            foreach(var a in origen.eL) 
                foreach(var dj in candidates)
                    if(a.getDestiny() == dj.original)
                    {
                        dj.acumulateWeight = a.getEdgeW();
                        dj.proveniente = origen;
                    }
            int iteraciones = 0;
            while (!solution(candidates)) 
            {
                
                iteraciones++;
                if (iteraciones>candidates.Count() )
                {
                    return candidates;
                }
                DijkstraItem minitem = minmunWeight(candidates, g); 
                    minitem.isDefinitive = true; 
                    foreach (var a in minitem.original.eL) 
                        foreach (var dj in candidates) 
                            if (a.getDestiny() == dj.original) 
                                if (minitem.acumulateWeight + a.getEdgeW() < dj.acumulateWeight) 
                                {
                                    dj.acumulateWeight = minitem.acumulateWeight + a.getEdgeW(); 
                                    dj.proveniente = minitem.original;
                                }
            }
            return candidates; 

        }        
        public DijkstraItem minmunWeight(List<DijkstraItem> canidates, Graph g)
        {
           int minvalue; 
            minvalue = int.MaxValue;
            DijkstraItem mindij = null; 

            foreach(var dj in canidates) 
            {
                if (dj.acumulateWeight < minvalue && !dj.isDefinitive) 
                {
                    minvalue = dj.acumulateWeight; 
                    mindij = dj; 
                }
                    
            }
         Point p=new Point(-1,-1);
            Vertex fa = new Vertex(-1,-1,-1,-1);
            DijkstraItem nuevo = new DijkstraItem(fa);
            if (mindij == null)
                mindij = nuevo;
            nuevo.acumulateWeight = -1;

            return mindij;
        }
        public bool solution(List<DijkstraItem> cand)
        {
            foreach (var d in cand) 
                if (!d.isDefinitive)
                    return false;
            return true;
        }
        public bool DFS(Vertex orig, Vertex obj)
        {
            bool found = false;
            //Point paux;
            if (orig == obj)
                return true;

            if (!pathDFS.Contains(orig))
                pathDFS.Add(orig);

            origen = pathDFS.Last();

            if (pathDFS.Count > 1)//si el contador de vertices es mayor a uno
                lastVertex = pathDFS[pathDFS.Count - 2]; //el ultimo vertice va ser igual a 

            found = false;
            foreach (Edge e in origen.eL) //para cara arsita dentro del origen
            {
                if (found)
                    return true;

                if (pathDFS.Count > 1 && e.getDestiny().getId() == lastVertex.getId())
                    continue;

                if (e.pL[0].X == e.getOrigin().getX())
                    foreach (Point p in e.pL)
                        precomputed.Add(p);
                else
                {
                    List<Point> reversed = new List<Point>(e.pL);
                    reversed.Reverse();

                    foreach (Point p in reversed)
                        precomputed.Add(p);
                }
                found = DFS(e.getDestiny(), this.objective);
            }
            if (!found)
            {
                if (lastVertex != null)
                {
                    Edge aux = Vertex.findEdgeByVector(lastVertex, orig);
                    if ((aux.pL[0].X == orig.getX()) && (aux.pL[0].Y == orig.getY()))
                        foreach (Point p in aux.pL)
                            precomputed.Add(p);
                    else
                    {
                        List<Point> reversed = new List<Point>(aux.pL);
                        reversed.Reverse();

                        foreach (Point p in reversed)
                            precomputed.Add(p);
                    }

                    pathDFS.Remove(pathDFS.Last());
                    origen = pathDFS.Last();
                    if (pathDFS.Count > 1)
                        lastVertex = pathDFS[pathDFS.Count - 2];
                    else
                        lastVertex = null;
                }
            }
            return found;
        }
        public void ChooseEdge(Point bait)
        {
            List<Edge> list_temp = new List<Edge>();

            Edge edge_temp = origen.eL[0];

            double angleBait = CalculateAngleBait(bait);
            double angleEdge;
            double angleMin = 360;

            foreach (Edge e in origen.eL)
                if (e.getDestiny().findRastrosById(id) <= edge_temp.getDestiny().findRastrosById(id))
                    edge_temp = e;

            list_temp.Add(edge_temp);

            foreach (Edge e in origen.eL)
                if (edge_temp.getDestiny().findRastrosById(id) == e.getDestiny().findRastrosById(id))
                    list_temp.Add(e);

            foreach (Edge e in list_temp)
            {
                angleEdge = CalculateAngleVertex(e.getDestiny());

                if ((angleEdge > angleBait ? angleEdge : angleBait) - (angleEdge < angleBait ? angleEdge : angleBait) >= 180)
                {
                    if ((angleEdge > angleBait ? angleEdge : angleBait) - (angleEdge < angleBait ? angleEdge : angleBait) < angleMin)
                    {
                        angleMin = Math.Min(angleEdge, angleBait) + Math.Abs(Math.Max(angleEdge, angleBait) - 360);
                        e_act = e;
                    }
                }
                else if ((angleEdge > angleBait ? angleEdge : angleBait) - (angleEdge < angleBait ? angleEdge : angleBait) < angleMin)
                {
                    angleMin = Math.Max(angleEdge, angleBait) - Math.Min(angleEdge, angleBait);
                    e_act = e;
                }
            }
            origen = null;
        }

        public void Walk(Point bait)
        {
            if (origen != null)
                ChooseEdge(bait);

            if (walkingIndex + vel < e_act.pL.Count)
                walkingIndex += vel;
            else
            {
                origen = e_act.getDestiny();
                origen.flags.Add(id);
                walkingIndex = 0;
                e_act = null;
            }
        }

        public double CalculateAngleBait(Point bait)
        {
            int x_i = origen.getX();
            int y_i = origen.getY();
            int x_f = bait.X;
            int y_f = bait.Y;

            double angleBait = Math.Atan2(y_f - y_i, x_f - x_i) * 180 / Math.PI;

            if (angleBait < 0)
                angleBait = Math.Abs(angleBait);
            else if (angleBait == 360 || angleBait == 0)
                angleBait = 0;

            return angleBait;
        }

        public double CalculateAngleVertex(Vertex v_f)
        {
            int x_i = origen.getX();
            int y_i = origen.getY();
            int x_f = v_f.getX();
            int y_f = v_f.getY();

            double angleVertex = Math.Atan2(y_f - y_i, x_f - x_i) * 180 / Math.PI;

            if (angleVertex < 0)
                angleVertex = Math.Abs(angleVertex);
            else if (angleVertex == 360 || angleVertex == 0)
                angleVertex = 0;

            return angleVertex;
        }
    }
}
