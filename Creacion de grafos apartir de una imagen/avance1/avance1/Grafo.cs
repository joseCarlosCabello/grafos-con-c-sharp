using System;
using System.Collections.Generic;
using System.Drawing;

namespace avance1
{
	
	/// <summary>
	/// Description of Grafo.
	/// </summary>
	public class Grafo
	{
		int contador;
		List<Vertice> vertices;
		Bitmap bmpGrafo;
		
		public List<Vertice> Vertices {
			get { return vertices; }
		}
		public int getContador{
			get{return contador;}
		}
		public int setContador{
			set{contador=value;}
		}
        
		
		List<Point> ida, regreso;
		Graphics linea;
		
		public Grafo(List<Circulo> circulos, Bitmap bmp)
		{

			linea = Graphics.FromImage(bmp);
			Pen pluma = new Pen(Color.Pink,1);
			this.vertices = new List<Vertice>();
			List<Point> ListaCordenadas = new List<Point>();
			
			for (int x = 0; x < circulos.Count; x++) {
				this.vertices.Add(new Vertice(circulos[x], circulos[x].getID));
			}
			foreach (Vertice inicio in vertices) {
				foreach (Vertice fin in vertices) {
					if (inicio != fin && (inicio.Aristas.Find(delegate(Aristas A) {
						return A.Destino == fin;
					})) == null) {
						ida = new List<Point>();
					if(fin.Circulo.getConectado!=true)
						{
						if (BuscarConexion(inicio, fin, bmp,ListaCordenadas)) {
							if(contador==0)
								conexion(pluma,inicio,fin);
							Aristas nueva = new Aristas(inicio, fin, ida);	
							regreso = new List<Point>(ida);
							regreso.Reverse();
							Aristas arista1 = new Aristas(fin, inicio, regreso);
							inicio.Aristas.Add(nueva);
							fin.Aristas.Add(arista1);
						}
						}
					}
				}
			}

			dibujar(circulos);

		}
				public void conexion(Pen pluma,Vertice inicio,Vertice fin)
		{
			linea.DrawLine(pluma,inicio.Circulo.Centro.X,inicio.Circulo.Centro.Y,fin.Circulo.Centro.X,fin.Circulo.Centro.Y);
		}
			
		public void dibujar(List<Circulo> circulos)
		{
			Point etiqueta= new Point();
			
				for (int x = 0; x < circulos.Count; x++) {
			//	for (int y = 0; y < circulos.Count; y++)
			//	{
					etiqueta.X=vertices[x].Circulo.Centro.X-vertices[x].Circulo.getRadio;
					etiqueta.Y=vertices[x].Circulo.Centro.Y-vertices[x].Circulo.getRadio;
					linea.DrawString(circulos[x].getID.ToString(), new Font("arial", circulos[x].getRadio/*circulos[y].getRadio-15*/, FontStyle.Regular), new SolidBrush(Color.Purple), etiqueta);
				
			//	}
				linea.DrawString(circulos[x].getID2.ToString(), new Font("arial", circulos[x].getRadio/*circulos[x].getRadio-15*/, FontStyle.Regular), new SolidBrush(Color.Black),etiqueta /*vertices[x].Circulo.Centro*/);
			}
			
			
		}
		
		bool BuscarConexion(Vertice inicio, Vertice fin, Bitmap bmp, List<Point> camino)
		{
			Point p_0, p_f;
			p_f =fin.Circulo.Centro;
			
			p_0 =inicio.Circulo.Centro;
			double m = ((double)p_f.Y - (double)p_0.Y) / ((double)p_f.X - (double)p_0.X);
			double b = (double)p_0.Y-m * (double)p_0.X;
			double x_k=0;
			double y_k=0;
			double x_i=0;
			double y_i=0;
			int inc = 1;
			int x=0,a=0;
			int z=0,y=0;
			int maximo;
			int verde=0;
			maximo=inicio.Circulo.getDiametro;
			if (m <= 1 && m >= -1){
				if (p_0.X > p_f.X )
					inc = -1;
				for (x_k = p_0.X; (int)x_k != p_f.X; x_k += inc){
					y_k = m*x_k + b;
					y_k=Math.Round(y_k);
					if(bmp.GetPixel((int)x_k,(int)y_k).R==128 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==128 )//||  //purpura
					 
					{
						z++;
					}
					if(bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==192 &&bmp.GetPixel((int)x_k,(int)y_k).B==203 )//||  //rosa
					{
						y++;
					}	
					if(bmp.GetPixel((int)x_k,(int)y_k).R==0 && bmp.GetPixel((int)x_k,(int)y_k).G==128 &&bmp.GetPixel((int)x_k,(int)y_k).B==0 )//||  //rosa
					{
						verde++;
					}
					if(bmp.GetPixel((int)x_k,(int)y_k).R==0 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==255)
						a++;
					if((bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==255 &&bmp.GetPixel((int)x_k,(int)y_k).B==0 )||  //amarillo
					   (bmp.GetPixel((int)x_k,(int)y_k).R==128 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==128 )||  //purpura
					   (bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==255 &&bmp.GetPixel((int)x_k,(int)y_k).B==255)|| //blanco
					   (bmp.GetPixel((int)x_k,(int)y_k).R==0 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==0 )||      //negro
					   (bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==192 &&bmp.GetPixel((int)x_k,(int)y_k).B==203 ))     //rosa
					{
						continue;
					}


					else
					{
						 x++;
					}
					x_i=x_k;
					y_i=y_k;
				}
			}
			else{
			if (p_0.Y > p_f.Y )
					inc = -1;

				for (y_k = p_0.Y; (int)y_k != p_f.Y; y_k += inc){
					if(inicio.Circulo.Centro.X==fin.Circulo.Centro.X)
						x_k=inicio.Circulo.Centro.X;
					else
						x_k = (y_k - b)/m;
					x_k=Math.Round(x_k);
					if(bmp.GetPixel((int)x_k,(int)y_k).R==128 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==128 )//||  //purpura
					{
						z++;
					}
					if(bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==192 &&bmp.GetPixel((int)x_k,(int)y_k).B==203 )//||  //rosa
					{
						y++;
					}			
					if(bmp.GetPixel((int)x_k,(int)y_k).R==0 && bmp.GetPixel((int)x_k,(int)y_k).G==128 &&bmp.GetPixel((int)x_k,(int)y_k).B==0 )//||  //verde
					{
						verde++;
					}					
					if((bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==255 &&bmp.GetPixel((int)x_k,(int)y_k).B==0 )||  //amarillo
					   (bmp.GetPixel((int)x_k,(int)y_k).R==128 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==128 )||  //purpura
					   (bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==255 &&bmp.GetPixel((int)x_k,(int)y_k).B==255)|| //blanco
					   (bmp.GetPixel((int)x_k,(int)y_k).R==0 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==0 )||      //negro
					   (bmp.GetPixel((int)x_k,(int)y_k).R==255 && bmp.GetPixel((int)x_k,(int)y_k).G==192 &&bmp.GetPixel((int)x_k,(int)y_k).B==203 ))     //rosa
					{
						continue;
					}
					if(bmp.GetPixel((int)x_k,(int)y_k).R==0 && bmp.GetPixel((int)x_k,(int)y_k).G==0 &&bmp.GetPixel((int)x_k,(int)y_k).B==255 )
						a++;
					else 
						x++;
				}
			y_i=y_k;
			x_i=x_k;
			}
			if(z>maximo-5)
			  return false;
			if(y>20)
				return false;
			if(a>0)
				return false;
			if(verde>0)
				return false;
			if(x==0||x<25)
			{
				camino.Add(new Point((int)x_i,(int)y_i));
				inicio.Circulo.setConectado=true;
				return true;
				
			}


			return false;
		}
		
		        public Bitmap BmpGrafo
        {
            get
            {
                return bmpGrafo;
            }
            set
            {
                bmpGrafo = value;
            }
        }

		
		
	}
	

	public class Vertice
	{
		Circulo circulo;
		List<Aristas> aristas;
		int etiqueta = 0;
		Circulo dato;
		
		
		public Circulo Dato
        {
            get
            {
                return dato;
            }
            set
            {
                dato = value;
            }
        }
		
		public List<Aristas> Aristas {
			get { return aristas; }
			set { aristas = value; }
		}
		
		public Circulo Circulo {
			get { return circulo; }
		}
		public int Etiqueta {
			get { return etiqueta; }
		}
		public int setEtiueta{
			set {etiqueta=value;}
		}
		
		public Vertice(Circulo centro, int etiqueta)
		{
			circulo = centro;
			this.etiqueta = etiqueta;
			aristas = new List<Aristas>();
		}

	}
	public class Aristas
	{
		Vertice origen;
		
		public Vertice Origen {
			get { return origen; }
		}
		Vertice destino;
		
		public Vertice Destino {
			get { return destino; }
		}
		List<Point> linea;
		
		public List<Point> Linea {
			get { return linea; }
		}
		public Aristas(Vertice origen, Vertice destino, List<Point> linea)
		{
			this.origen = origen;
			this.destino = destino;
			linea = new List<Point>();
			this.linea = linea;
		}

	}
}