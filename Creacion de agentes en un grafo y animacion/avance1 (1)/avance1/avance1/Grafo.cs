/*
 * Created by SharpDevelop.
 * User: lobo1
 * Date: 01/03/2019
 * Time: 01:15 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace avance1
{
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Arista
	{
		
		public Vertice Destino;
        public Vertice Origen;
        public List<Point> linea;

        public Arista(Vertice Destino, Vertice Origen, List<Point> linea)
        {
            this.Origen = Origen;
            this.Destino = Destino;
            this.linea = new List<Point>(linea);
        }
    }

    public class Vertice
    {
        public List<Arista> eL;

        public List<int> flag;

        public Point data;

        public int id;
        public int radio;

        public bool hasAnAgent;
        public bool hasABait;

        public Vertice(Point p, int id, int radio)
        {
            data = new Point(p.X, p.Y);
            this.id = id;
            this.radio = radio;

            hasABait = false;
            hasAnAgent = false;

            eL = new List<Arista>();
            flag = new List<int>();
        }

        public int findRastrosById(int id)
        {
            int cont = 0;

            foreach (int i in flag)
                if (i == id)
                    cont++;
            
            return cont;
        }

        public Point getData()
        {
            return data;
        }

        public int getRadio()
        {
            return radio;
        }

        public void addArista(Vertice Destino, Vertice Origen, List<Point> linea)
        {
            Arista e = new Arista(Destino, Origen, linea);
            eL.Add(e);
        }

        public string getAristas()
        {
            string aux = "";

            for (int i = 0; i < getAristasCount(); i++)
                aux += (eL[i].Destino.id + 1) + ", ";

            if (aux != "")
                return "ID: " + (id + 1) + " se  conecta con: " + aux;
            else
                return "ID: " + (id + 1) + " no tiene Aristas.";
        }

        public int getAristasCount()
        {
        	return eL.Count();
        }

        public override string ToString()
        {
            return " ID = " + (id + 1) + "; Aristas: " + getAristasCount() + "; Radio: " + radio + ";  Centro: " + data.X + " , " + data.Y;
        }
    }

    public class Grafo
    {
        public List<Vertice> vL;

        public Grafo()
        {
            vL = new List<Vertice>();
        }

        public void addVertice(Point p, int radio)
        {
            vL.Add(new Vertice(p, vL.Count(), radio));
        }

        public Vertice findVertice(Point p)
        {
            foreach (Vertice v in vL)
                if (v.getData() == p)
                    return v;
            return null;
        }

        public int getVerticeCount()
        {
            return vL.Count();
        }

        public Vertice getVerticeAt(int i)
        {
            return vL[i];
        }

        public void ClearList()
        {
            vL.Clear();
        }

        public void BubbleSort()
        {
            bool cambio;
            int cont = vL.Count();

            do
            {
                cambio = false;
                cont--;

                for (int i = 0; i < cont; i++)
                {
                    if (vL[i].getRadio() < vL[i + 1].getRadio())
                    {
                        Vertice aux = vL[i + 1];

                        vL[i + 1] = vL[i];
                        vL[i] = aux;

                        cambio = true;
                    }

                }
            } while (cambio);
        }
    }
}