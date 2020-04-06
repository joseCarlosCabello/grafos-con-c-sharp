using System;
using System.Drawing;

namespace avance1
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Circulo 
	{
		
		Point centro;
		bool conectado=false;
		int diametro;
		int radio;
		int id;
		int id2;
		
		public Point Centro {
			get { return centro; }
		}
		
		public Circulo(int x, int y,int diametro,int id,int id2,int radio)
		{
			centro = new Point(x,y);
			this.diametro=diametro;
			this.id=id;
			this.id2=id2;
			this.radio=radio;
			
		}
		public bool getConectado{
			get{return conectado;}
		}
		public bool setConectado{
			set{conectado=true;}
		}
		public int getRadio{
			get{return radio;}
		}
		public int setRadio{
			set{radio=value;}
		}
		public int getDiametro{
			get{return diametro;}
		}
		public int setDiametro{
			set{diametro=value;}
		}
		public double Distancia(Circulo cDestino)
        {
            int x = (cDestino.Centro.X - Centro.X);
            int y = (cDestino.Centro.Y - Centro.Y);
            return Math.Sqrt((x * x) + (y * y));
        }
		public int getID{
			get{return id;}
		}
				public int setID{
			set{id=value;}
		}
				public int getID2{
			get{return id2;}
		}
				public int setID2{
			set{id2=value;}
		}
		
	}
}
