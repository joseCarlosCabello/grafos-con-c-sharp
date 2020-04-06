using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Etapa_5__Dijkstra_
{
    class Graph
    {
        public List<Vertex> vL;
        public List<Edge> eL;

        public Graph()
        {
            vL = new List<Vertex>();
            eL = new List<Edge>();
        }
        public void setAgent(int ind, bool b)
        {
            vL[ind].hasAgent = b;
        }
        public int getTotalEdgeWeigth()
        {
            int value = 0;
            foreach (var i in eL)
                value += i.getEdgeW();

            return value;
        }
        public Vertex findVertex(Vertex p)
        {
            foreach (Vertex v in vL)
                if ((v.getX() == p.getX()) && (v.getY() == p.getY()))
                    return v;
            return null;
        }
        public Vertex findVertex2(Point p)
        {
            foreach(Vertex v in vL)
                if (v.data == p)
                    return v;
            return null;
        }
        public void setBait(int idn, bool b)
        {
            vL[idn].hasBait = b;
        }
        public void addVertex(Vertex c, int rad)
        {
            vL.Add(new Vertex(c.getX(), c.getY(), vL.Count(), rad));
        }
        public int getVertexCount()
        {
            return vL.Count();
        }
        public Vertex getVertexAt(int i)
        {
            return vL[i];
        }
        public void VertexEdgeCount()
        {
            foreach (Vertex v in vL)
                for (int i = 0; i < v.eL.Count; i++)
                    eL.Add(v.eL[i]);
        }
        public bool existfindVertex(Vertex p)
        {
            foreach (Vertex v in vL)
                if (v == p)
                    return true;
            return false;
        }
        public void SortEdges()
        {
            bool cambio;
            int cont = eL.Count();
            do
            {
                cambio = false;
                cont--;

                for (int i = 0; i < cont; i++)
                {
                    if (eL[i].getEdgeW() > eL[i + 1].getEdgeW())
                    {
                        Edge aux = eL[i + 1];

                        eL[i + 1] = eL[i];
                        eL[i] = aux;

                        cambio = true;
                    }

                }
            } while (cambio);
        }
    }
    class Vertex
    {
        public List<Edge> eL;
        public Point data;

        int x;
        int y;
        public int rad;
        public int id;

        public int rank;
        public Vertex root;
        public bool hasBait;
        public bool hasAgent;

        public List<int> flags;

        public Vertex(int x1, int y1, int id, int radio)
        {
            this.x = x1;
            this.y = y1;
            this.id = id;
            this.rad = radio;
            root = this;
            rank = 0;

            hasAgent = false;
            hasBait = false;
            data = new Point(x1, y1);
            eL = new List<Edge>();
            flags = new List<int>();
        }
        public Vertex()
        {

        }
        public Vertex(Point p)
        {
            this.x = p.X;
            this.y = p.Y;
            this.rad = 30;
            root = this;
            rank = 0;
        }
        public static Edge findEdgeByVector(Vertex origin, Vertex destination)
        {
            try
            {
                foreach (Edge e in origin.eL)
                    if (e.getOrigin().getId() == origin.id)
                        if (e.getDestiny().getId() == destination.id)
                            return e;
            }
            catch (Exception e)
            {
                return null;
            }
            return null;
        }

        public static void Join(Vertex v1, Vertex v2)
        {
            if (v2.rank < v1.rank)
                v2.root = v1;
            else
            {
                v1.root = v2;
                if (v1.rank == v2.rank)
                    v1.rank++;
            }
        }
        public int findRastrosById(int id)
        {
            int cont = 0;

            foreach (int i in flags)
                if (i == id)
                    cont++;

            return cont;
        }
        public Vertex GetRoot()
        {
            if (root != this)
                root = root.GetRoot();
            return root;
        }

        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public int getId()
        {
            return id;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public int getR()
        {
            return rad;
        }
        public void addEdge(Vertex d, Vertex o, List<Point> n)
        {
            Edge e = new Edge(d, o, n);

            eL.Add(e);
        }

        public Edge getEdgeAt(int i)
        {
            return eL[i];
        }

        public override string ToString()
        {
            return "ID: " + (id + 1) + "  Centro:  " + getX() + " , " + getY() + "  Radio:  " + getR();
        }
    }
    class Edge
    {
        Vertex origin;
        Vertex destiny;
        int weigth;

        public bool IsDeinfitive;

        public List<Point> pL;

        public Edge(Vertex d, Vertex o, List<Point> p)
        {
            this.destiny = d;
            this.origin = o;

            pL = new List<Point>(p);
            weigth = EuclideanDistance();

            IsDeinfitive = false;
        }
        public int EuclideanDistance()
        {
            int x0 = origin.getX();
            int y0 = origin.getY();

            int x1 = destiny.getX();
            int y1 = destiny.getY();

            return Convert.ToInt32(Math.Sqrt(Math.Pow((x1 - x0), 2) + Math.Pow((y1 - y0), 2)));
        }
        public Vertex getOrigin()
        {
            return origin;
        }
        public Vertex getDestiny()
        {
            return destiny;
        }
        public void setWeight(int w)
        {
            weigth = w;
        }
        public int getEdgeW()
        {
            return weigth;
        }
    }
}
