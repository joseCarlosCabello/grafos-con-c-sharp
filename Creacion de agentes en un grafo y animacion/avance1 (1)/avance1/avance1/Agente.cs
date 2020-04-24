/*
 * Created by SharpDevelop.
 * User: lobo1
 * Date: 22/03/2019
 * Time: 02:56 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace avance1
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Agente
	{
		 public Vertice actualVertex;
        public Arista actualEdge;

        public int walkingIndex;
        public int r;
        public int vel;

        public int id;

        public Agente(Vertice actualVertex, int id)
        {
            this.actualVertex = actualVertex;
            this.id = id;

            r = actualVertex.getRadio();
            walkingIndex = 0;

            vel = 15;        
        }

        public void ChooseEdge(Point bait)
        {
            List<Arista> list_temp = new List<Arista>();

            Arista edge_temp = actualVertex.eL[0];

            double angleBait = CalculateAngleBait(bait);
            double angleEdge;
            double angleMin = 360;

            foreach (Arista e in actualVertex.eL)
                if (e.Destino.findRastrosById(id) <= edge_temp.Destino.findRastrosById(id))
                    edge_temp = e;

            list_temp.Add(edge_temp);

            foreach (Arista e in actualVertex.eL)
                if (edge_temp.Destino.findRastrosById(id) == e.Destino.findRastrosById(id))
                    list_temp.Add(e);            

            foreach (Arista e in list_temp)
            {
                angleEdge = CalculateAngleVertex(e.Destino);

                if((angleEdge > angleBait ? angleEdge : angleBait) - (angleEdge < angleBait ? angleEdge : angleBait) >= 180)   
                {
                    if((angleEdge > angleBait ? angleEdge : angleBait) - (angleEdge < angleBait ? angleEdge : angleBait) < angleMin)
                    {
                        angleMin = Math.Min(angleEdge, angleBait) + Math.Abs(Math.Max(angleEdge, angleBait) - 360);
                        actualEdge = e;
                    }
                }
                else if((angleEdge > angleBait ? angleEdge : angleBait) - (angleEdge < angleBait ? angleEdge : angleBait) < angleMin)
                {
                    angleMin = Math.Max(angleEdge, angleBait) - Math.Min(angleEdge, angleBait);
                    actualEdge = e;
                }               
            }
            actualVertex = null;
        }

        public void Walk(Point bait)
        {
            if (actualVertex != null)
                ChooseEdge(bait);
            
            if (walkingIndex + vel < actualEdge.linea.Count)           
                walkingIndex += vel;            
            else
            {
                actualVertex = actualEdge.Destino;
                actualVertex.flag.Add(id);
                walkingIndex = 0;
                actualEdge = null;
            }
        }

        public double CalculateAngleBait(Point bait)
        {
            int x_i = actualVertex.getData().X;
            int y_i = actualVertex.getData().Y;
            int x_f = bait.X;
            int y_f = bait.Y;

            double angleBait = Math.Atan2(y_f - y_i, x_f - x_i) * 180 / Math.PI;

            if (angleBait < 0)
                angleBait = Math.Abs(angleBait);
            else if (angleBait == 360 || angleBait == 0)
                angleBait = 0;

            return angleBait;
        }

        public double CalculateAngleVertex(Vertice v_f)
        {
            int x_i = actualVertex.getData().X;
            int y_i = actualVertex.getData().Y;
            int x_f = v_f.getData().X;
            int y_f = v_f.getData().Y;

            double angleVertex = Math.Atan2(y_f - y_i, x_f - x_i) * 180 / Math.PI;

            if (angleVertex < 0)
                angleVertex = Math.Abs(angleVertex);
            else if (angleVertex == 360 || angleVertex == 0)
                angleVertex = 0;

            return angleVertex;
        }
    }
}