using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Etapa_5__Dijkstra_
{
    public partial class Form1 : Form
    {
        Graph graf;
        bool yes;
        DijkstraItem auxD = null;
        Edge ed = null;

        #region Variables
        Bitmap bmp1;
        Bitmap aux;

        Bitmap graph;

        Graph ARM;
        Graphics g2 = null;
        Graphics g = null;
        DijkstraItem bait;
        Agent a;


        //List<Agent> aL;
        List<Edge> edgeL;
        List<Edge> dijstraPath;
        List<string> path = new List<string>();
        List<DijkstraItem> items;

        bool isThereABait;
        #endregion

        public Form1()
        {
            InitializeComponent();
           
            openFileDialog1.Filter = "Imagenes(*.jpg,*.png) | *.jpg; *.png";
            openFileDialog1.Title = "Selector de imagenes";

            graf = new Graph();

            //aL = new List<Agent>();
            edgeL = new List<Edge>();
            dijstraPath = new List<Edge>();
            items = new List<DijkstraItem>();

            path = null;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                a = null;
                if (g != null)
                {
                    g.Clear(Color.Transparent);
                    g.Dispose();
                    pictureBox2.Refresh();
                }
                listBox1.Items.Clear();
                button2.Enabled = true;

                openFileDialog1.ShowDialog();

                bmp1 = new Bitmap(openFileDialog1.FileName);
                aux = new Bitmap(openFileDialog1.FileName);

                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                pictureBox2.BackgroundImage = bmp1;
                pictureBox1.Image = aux;

                graf.vL.Clear();
                graf.eL.Clear();
              // path.Clear();
                dijstraPath.Clear(); //edges
                items.Clear();
                //aL.Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show(""+ex);
            }
            try
            {
                pictureBox1.Refresh();
                pictureBox2.Refresh();

                Circulos();
                Aristas(bmp1);

                DrawValores();

                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                pictureBox2.BackgroundImage = bmp1;
                pictureBox1.Image = graph;

                graf.SortEdges();

                button2.Enabled = false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x);
            }
        }

      /*  private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Refresh();
                pictureBox2.Refresh();

                Circulos();
                Aristas(bmp1);

                DrawValores();

                pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
                pictureBox2.BackgroundImage = bmp1;
                pictureBox1.Image = graph;

                graf.SortEdges();

                button2.Enabled = false;

            }
            catch (Exception x)
            {
                MessageBox.Show("Error: " + x);
            }
        }
        */
        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (bait != null && a != null)
                    AnimateDijkstra();
                else
                    MessageBox.Show("No se puede realizar la animación, no existen señuelos u agentes");
            }
            catch(Exception x)
            {
                MessageBox.Show(""+x);
            }
        }
        public int distEu(int x0, int y0, int x1, int y1)
        {
            return Convert.ToInt32(Math.Sqrt(Math.Pow((x1 - x0), 2) + Math.Pow((y1 - y0), 2)));
        }
        public int distmin()
        {
            int minDist = int.MaxValue;

            for (int i = 0; i < graf.getVertexCount(); i++)
            {
                Vertex c1 = graf.getVertexAt(i);

                for (int j = 0; j < graf.getVertexCount(); j++)
                {
                    if (i == j)
                        continue;

                    Vertex c2 = graf.getVertexAt(j);

                    int x0 = c1.getX();
                    int y0 = c1.getY();

                    int x1 = c2.getX();
                    int y1 = c2.getY();

                    int dist = distEu(x0, y0, x1, y1);

                    if (dist < minDist)
                    {
                        minDist = dist;

                    }
                }
            }
            return minDist;
        }
        public void Circulos()
        {
            Bitmap bmplocal = new Bitmap(bmp1);

            for (int i = 0; i < bmplocal.Height; i++)
            {
                for (int j = 0; j < bmplocal.Width; j++)
                {
                    if (IsBlack(bmplocal.GetPixel(j, i)))
                    {
                        int cX = centroX(j, i, bmplocal);
                        int cY = centroY(j, i, bmplocal);

                        int radX = radioX(cX, cY, bmplocal);
                        int rady = radioY(cX, cY, bmplocal);

                        if ((radX - rady) < 10 && (radX - rady) > (-10))
                        {
                            Vertex c = new Vertex();

                            c.setX(cX);
                            c.setY(cY);

                            graf.addVertex(c, radX);

                            Rellena(cX, cY, bmplocal);
                        }
                        else
                            rellenaOvalos(cX, cY, bmplocal);

                        pictureBox2.Image = bmplocal;
                        pictureBox2.BackgroundImage = bmplocal;
                        bmp1 = new Bitmap(bmplocal);
                    }
                }
            }
        }
        public void Aristas(Bitmap bmp)
        {
            Bitmap local = new Bitmap(bmp);
            Graphics g = Graphics.FromImage(local);
            Pen p = new Pen(Brushes.LightPink, 2);
            List<Point> n = new List<Point>();

            for (int i = 0; i < graf.getVertexCount(); i++)
            {
                Vertex c1 = graf.getVertexAt(i);

                for (int j = 0; j < i; j++)
                {
                    Vertex c2 = graf.getVertexAt(j);

                    int x0 = c1.getX();
                    int y0 = c1.getY();

                    int x1 = c2.getX();
                    int y1 = c2.getY();

                    if (drawLine1(x0, y0, x1, y1, local) != null)
                    {
                        n = drawLine1(x0, y0, x1, y1, local);
                        List<Point> aux = new List<Point>(n);
                        c1.addEdge(c2, c1, n);
                        aux.Reverse();
                        c2.addEdge(c1, c2, aux);

                        graf.eL.Add(new Edge(c1, c2, n));
                        g.DrawLine(p, x0, y0, x1, y1);

                        // aux.Clear();
                    }
                }
            }
            graph = local;
            pictureBox2.Image = graph;
            pictureBox1.Image = graph;

            n.Clear();
        }
        private Point ReturnZoom(MouseEventArgs e)
        {
            int X, Y;

            int w_c = pictureBox1.Width;
            int h_c = pictureBox1.Height;

            int w_i = pictureBox1.Image.Width;
            int h_i = pictureBox1.Image.Height;

            float imageRatio = w_i / (float)h_i;
            float containerRatio = w_c / (float)h_c;

            if (imageRatio >= containerRatio)
            {
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                float filler = Math.Abs(h_c - scaledHeight) / 2;
                X = (int)(e.X / scaleFactor);
                Y = (int)((e.Y - filler) / scaleFactor);
            }
            else
            {
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                float filler = Math.Abs(w_c - scaledWidth) / 2;
                X = (int)((e.X - filler) / scaleFactor);
                Y = (int)(e.Y / scaleFactor);
            }

            return new Point(X, Y);
        }
        public List<Point> drawLine1(int x0, int y0, int x1, int y1, Bitmap bmp)
        {
            List<Point> aux = new List<Point>();
            int dx = Math.Abs(x1 - x0);
            int dy = Math.Abs(y1 - y0);

            int sx = x0 < x1 ? 1 : -1;
            int sy = y0 < y1 ? 1 : -1;

            int flag = 0;

            int err = (dx > dy ? dx : -dy) / 2;
            int e2;

            for (; ; )
            {
                Point p = new Point(x0, y0);

                Color c = bmp.GetPixel(x0, y0);
                aux.Add(p);

                if (IsWhite(c) && flag == 0)
                    flag = 1;
                if (!IsWhite(c) && flag == 1)
                    flag = 2;
                if (IsPink(c) && flag == 2)
                    flag = 1;
                if (IsWhite(c) && flag == 2)
                    return null;


                if (x0 == x1 && y0 == y1)
                    break;

                e2 = err;

                if (e2 > -dx)
                {
                    err -= dy;
                    x0 += sx;
                }

                if (e2 < dy)
                {
                    err += dx;
                    y0 += sy;
                }
            }
            return aux;
        }
        public void AnimateDijkstra()
        {
            Graphics g = Graphics.FromImage(graph);
            Pen pe = new Pen(Color.Yellow, 5);
            int r = a.rad;
            int velIndex = 0;
            

            foreach (Point p in a.precomputed)
            {
                if (++velIndex % a.vel != 0)
                    continue;

                pictureBox2.Refresh();
                g.Clear(Color.Transparent);

                foreach (Edge e in dijstraPath)
                    g.DrawLine(pe, e.getDestiny().getX(),e.getDestiny().getY(), e.getOrigin().getX(),e.getOrigin().getY());

                g.FillEllipse(new SolidBrush(Color.Black), bait.original.getX() - r, bait.original.getY() - r, r * 2, r * 2);
                g.FillEllipse(new SolidBrush(Color.LightPink), p.X - r, p.Y - r, r * 2, r * 2);
            }

            listBox1.Items.Clear();
            a.origen.hasAgent = false;
            a.origen = bait.original;
            a.origen.hasAgent = true;
            items = a.Dijkstra(graf);
            dijstraPath.Clear();
            foreach (var d in items)
                if (d.acumulateWeight == int.MaxValue)
                    listBox1.Items.Add("Desde :" + (a.origen.id +1)+ " A: " + (d.original.id + 1) + " no existe camino");
                else
                    listBox1.Items.Add("Desde: " + (a.origen.getId()+1)+" A: " + (d.original.id + 1) + ", el peso es: " + d.acumulateWeight);

            g.Dispose();
        }
        private void CaminoDijktra(DijkstraItem destination, Agent a, Graphics g)
        {
            Pen p = new Pen(Color.Yellow, 5);
            yes = true;
            DijkstraItem actual = destination;
            while (actual.proveniente != a.origen)
            {
                Edge aux = Vertex.findEdgeByVector(actual.original, actual.proveniente);
                dijstraPath.Add(aux);
                try
                {
                    foreach (Point po in aux.pL)
                        a.precomputed.Add(po);
                    pictureBox2.Refresh();
                    auxD = actual;
                    ed = aux;
                    g.DrawLine(p, actual.original.getX(), actual.original.getY(), actual.proveniente.getX(), actual.proveniente.getY());
                    foreach (DijkstraItem d in items)
                        if (d.original == actual.proveniente)
                        {
                            actual = d;
                            break;
                        }
                }
                catch (Exception e)
                {
                    MessageBox.Show("el bait y el agente no se encuentran en el mismo arbol");
                    pictureBox2.Refresh();
                    return;
                }
            }
            Edge aux2 = Vertex.findEdgeByVector(actual.original, actual.proveniente);
            g2.DrawLine(p, actual.original.getX(),actual.original.getY(), a.origen.getX(),a.origen.getY());
            foreach (Point po in aux2.pL)
                a.precomputed.Add(po);
            dijstraPath.Add(aux2);
            a.precomputed.Reverse();
            g.Dispose();
            p.Dispose();

        }             
        public void DrawValores()
        {
            Graphics g = Graphics.FromImage(graph);

            foreach (Vertex c in graf.vL)
            {
                g.DrawString((c.getId() + 1).ToString(), new Font("Arial", 20), Brushes.Crimson, c.getX() - 35, c.getY() - 35);
                foreach (Edge e in c.eL)
                    g.DrawString(e.getEdgeW().ToString(), new Font("Arial", 20), Brushes.Black, e.pL[e.pL.Count / 2].X, e.pL[e.pL.Count / 2].Y);

            }

            pictureBox1.Image = graph;
        }
        private void AddAnimation(object sender, MouseEventArgs e)
        {           
            
                Point zoom = ReturnZoom(e);
                Point p = new Point();

                int minDist = int.MaxValue;

                for (int i = 0; i < graf.getVertexCount(); i++)
                {
                    Vertex v1 = graf.getVertexAt(i);

                    int x0 = v1.getX();
                    int y0 = v1.getY();

                    int dist = distEu(zoom.X, zoom.Y, x0, y0);

                    if (dist < minDist)
                    {
                        minDist = dist;

                        p.X = x0;
                        p.Y = y0;
                    }
                }                
                if (e.Button == MouseButtons.Right)
                {
                    if (a == null)
                        setAgent(p.X, p.Y, Color.LightPink, true);
                    else
                        MessageBox.Show("Ya se alcanzó el máximo de agentes en el grafo");
                }
                else if (e.Button == MouseButtons.Left)
                {
                if (a != null)
                    setAgent(p.X, p.Y, Color.Black, false);
                else
                    MessageBox.Show("Primero agrege un agente");
                }
                pictureBox2.Refresh();                
           
        }
      
     
        private void setAgent(int x, int y, Color c, bool isAnAgent)
        {

            Graphics g = Graphics.FromImage(graph);
            g2 = Graphics.FromImage(graph);
            Point p = new Point();

            int minDist = int.MaxValue;

            for (int i = 0; i < graf.getVertexCount(); i++)
            {
                Vertex v1 = graf.getVertexAt(i);

                int x0 = v1.getX();
                int y0 = v1.getY();
                int dist = distEu(x, y, x0, y0);
                if (dist < minDist)
                {
                    minDist = dist;
                    p.X = x0;
                    p.Y = y0;
                }
            }
            Vertex aux = graf.findVertex2(p);
            int r = aux.getR();
            g.FillEllipse(new SolidBrush(c), aux.getX() - r, aux.getY() - r, r * 2, r * 2);
            if (!aux.hasAgent && !aux.hasBait)
            {
                if (isAnAgent && a == null)
                {
                    a = new Agent(aux, -1);
                    g.FillEllipse(new SolidBrush(c), aux.getX() - r, aux.getY() - r, r * 2, r * 2);
                    aux.hasAgent = true;
                    items = a.Dijkstra(graf);
                    foreach (var d in items)
                        if (d.acumulateWeight == int.MaxValue) //si el peso del elemento dijstra sigue siendo "infinito"
                            listBox1.Items.Add("Desde: "+(a.origen.id+1)+"A: " + (d.original.id + 1) + " no existe camino"); //significa que no existe un camino, es decir, nunca de modificó
                        else
                            listBox1.Items.Add("Desde: " + (a.origen.id + 1) + "A: " + (d.original.id + 1) + ", el peso es: " + d.acumulateWeight);
                }
                else
                {
                   //
                    if (a == null)
                    {
                        MessageBox.Show("Inserta un agente en el grafo primero :)");
                       //eg2.FillEllipse(new SolidBrush(Color.Orange), bait.original.getX() - r, bait.original.getY() - r, r * 2, r * 2);
                        goto End;
                    }
                        dijstraPath.Clear();
                    a.precomputed.Clear();
                    foreach (var d in items)
                        if (d.original.id == aux.id)
                        {
                            bait = d;
                            break;
                        }
                        g.Clear(Color.Transparent);
                    CaminoDijktra(bait, a, g);
                    g2.FillEllipse(new SolidBrush(Color.LightPink), a.origen.getX() - r, a.origen.getY() - r, r * 2, r * 2);
                    g2.FillEllipse(new SolidBrush(c), bait.original.getX() - r, bait.original.getY() - r, r * 2, r * 2);
                    pictureBox2.Refresh();
                    if(!yes)
                        g2.FillEllipse(new SolidBrush(Color.BlueViolet), bait.original.getX() - r, bait.original.getY() - r, r * 2, r * 2);
                    g2.Dispose();
                }
            }
            else
                MessageBox.Show("Ya hay un agente o cebo en ese vértice");
            End:;
            
            //pictureBox2.Refresh();
            g.Dispose();
        }
        public bool IsBlack(Color c)
        {
            if (c.R == 0)
                if (c.G == 0)
                    if (c.B == 0)
                        return true;
            return false;
        }
        public bool IsWhite(Color c)
        {
            if (c.R == 255)
                if (c.G == 255)
                    if (c.B == 255)
                        return true;
            return false;
        }
        public bool IsPink(Color c)
        {
            if (c.R == 255)
                if (c.G == 182)
                    if (c.B ==193)
                        return true;
            return false;
        }
        private void rellenaOvalos(int centroX, int centroY, Bitmap bmp)
        {
            int x = centroX;
            int y = centroY;
            int y_sup;
            int y_inf;

            Color color = bmp.GetPixel(x, y);

            while (!IsWhite(color))
                color = bmp.GetPixel(--x, y);

            color = bmp.GetPixel(++x, y);

            while (!IsWhite(color))
            {
                y_sup = y - 1;
                y_inf = y;

                while (!IsWhite(color))
                {
                    bmp.SetPixel(x, y_inf++, Color.White);
                    color = bmp.GetPixel(x, y_inf);
                }
                color = bmp.GetPixel(x, y_sup);

                while (!IsWhite(color))
                {
                    bmp.SetPixel(x, y_sup--, Color.White);
                    color = bmp.GetPixel(x, y_sup);
                }
                color = bmp.GetPixel(++x, y);
            }

        }

        private void Rellena(int cX, int cY, Bitmap bmp)
        {
            int x = cX;
            int y = cY;

            int y_sup;
            int y_inf;

            Color color = bmp.GetPixel(x, y);

            while (!IsWhite(color))
                color = bmp.GetPixel(--x, y);


            color = bmp.GetPixel(++x, y);

            while (!IsWhite(color))
            {
                y_sup = y - 1;
                y_inf = y;

                while (!IsWhite(color))
                {
                    bmp.SetPixel(x, y_inf++, Color.BlueViolet);
                    color = bmp.GetPixel(x, y_inf);
                }

                color = bmp.GetPixel(x, y_sup);

                while (!IsWhite(color))
                {
                    bmp.SetPixel(x, y_sup--, Color.BlueViolet);
                    color = bmp.GetPixel(x, y_sup);
                }
                color = bmp.GetPixel(++x, y);
            }
        }
        public int centroX(int i, int j, Bitmap bmp)
        {
            int x = i + 1;
            int y = j;

            while (!IsWhite(bmp.GetPixel(x, y)))
                x++;

            return (x + i) / 2;
        }
        public int centroY(int i, int j, Bitmap bmp)
        {
            int x = i;
            int y = j + 1;

            while (!IsWhite(bmp.GetPixel(x, y)))
                y++;

            return (y + j) / 2;
        }

        public int radioX(int x, int y, Bitmap bmp)
        {
            int i = x;

            while (!IsWhite(bmp.GetPixel(i, y)))
                i++;

            return i - x;
        }
        public int radioY(int x, int y, Bitmap bmp)
        {
            int j = y;

            while (!IsWhite(bmp.GetPixel(x, j)))
                j++;

            return j - y;
        }

      


    }
}
