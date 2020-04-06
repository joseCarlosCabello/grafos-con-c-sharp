using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace avance1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		List<Circulo> listaCirculos = new List<Circulo>();
		Bitmap imagenAnalizar;
		Grafo grafoImagen;
		int contador=1;
		Grafo grafo2;
		string nombre2;
		Graphics gra;
		
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void PintarCirculo(int x, int y){
		
			int izq=x,arr=y,der=x+1,aba=y;
			Graphics centroide = Graphics.FromImage(imagenAnalizar);
			Color pintura =Color.Purple;
			SolidBrush centro = new SolidBrush(Color.Yellow);
			while(imagenAnalizar.GetPixel(izq,arr).R != 255 
			     && imagenAnalizar.GetPixel(izq,arr).G != 255
			     && imagenAnalizar.GetPixel(izq,arr).B != 255){
				while(imagenAnalizar.GetPixel(izq,arr).R != 255 
				     && imagenAnalizar.GetPixel(izq,arr).G != 255
				     && imagenAnalizar.GetPixel(izq,arr).B != 255){
						imagenAnalizar.SetPixel(izq,arr,pintura);
						arr--;
				}
				aba=y+1;
				while(imagenAnalizar.GetPixel(izq,aba).R != 255 
				     && imagenAnalizar.GetPixel(izq,aba).G != 255
				     && imagenAnalizar.GetPixel(izq,aba).B != 255){
						imagenAnalizar.SetPixel(izq,aba,pintura);
						aba++;
				}
				izq--;
				arr=y;

			}
			
			arr=y;
			while(imagenAnalizar.GetPixel(der,arr).R != 255 
			     && imagenAnalizar.GetPixel(der,arr).G != 255
			     && imagenAnalizar.GetPixel(der,arr).B != 255){
				while(imagenAnalizar.GetPixel(der,arr).R != 255 
				     && imagenAnalizar.GetPixel(der,arr).G != 255
				     && imagenAnalizar.GetPixel(der,arr).B != 255){
						imagenAnalizar.SetPixel(der,arr,pintura);
						arr--;
				}
				aba=y+1;
				while(imagenAnalizar.GetPixel(der,aba).R != 255 
				     && imagenAnalizar.GetPixel(der,aba).G != 255
				     && imagenAnalizar.GetPixel(der,aba).B != 255){
						imagenAnalizar.SetPixel(der,aba,pintura);
						aba++;
				}
				der++;
				arr=y;
			}
			
			
			centroide.FillEllipse(centro,x-5,y-5,10,10);
		}
				void PintarCirculo3(int x, int y){
		
			int izq=x,arr=y,der=x+1,aba=y;
			Graphics centroide = Graphics.FromImage(imagenAnalizar);
			Color pintura =Color.White;
			SolidBrush centro = new SolidBrush(Color.Yellow);
			while(imagenAnalizar.GetPixel(izq,arr).R != 255 
			     && imagenAnalizar.GetPixel(izq,arr).G != 255
			     && imagenAnalizar.GetPixel(izq,arr).B != 255){
				while(imagenAnalizar.GetPixel(izq,arr).R != 255 
				     && imagenAnalizar.GetPixel(izq,arr).G != 255
				     && imagenAnalizar.GetPixel(izq,arr).B != 255){
						imagenAnalizar.SetPixel(izq,arr,pintura);
						arr--;
				}
				aba=y+1;
				while(imagenAnalizar.GetPixel(izq,aba).R != 255 
				     && imagenAnalizar.GetPixel(izq,aba).G != 255
				     && imagenAnalizar.GetPixel(izq,aba).B != 255){
						imagenAnalizar.SetPixel(izq,aba,pintura);
						aba++;
				}
				izq--;
				arr=y;

			}
			
			arr=y;
			while(imagenAnalizar.GetPixel(der,arr).R != 255 
			     && imagenAnalizar.GetPixel(der,arr).G != 255
			     && imagenAnalizar.GetPixel(der,arr).B != 255){
				while(imagenAnalizar.GetPixel(der,arr).R != 255 
				     && imagenAnalizar.GetPixel(der,arr).G != 255
				     && imagenAnalizar.GetPixel(der,arr).B != 255){
						imagenAnalizar.SetPixel(der,arr,pintura);
						arr--;
				}
				aba=y+1;
				while(imagenAnalizar.GetPixel(der,aba).R != 255 
				     && imagenAnalizar.GetPixel(der,aba).G != 255
				     && imagenAnalizar.GetPixel(der,aba).B != 255){
						imagenAnalizar.SetPixel(der,aba,pintura);
						aba++;
				}
				der++;
				arr=y;
			}
			
			

		}
		void PintarCirculo2(int x, int y,int r){
			Graphics centroide = Graphics.FromImage(imagenAnalizar);
			Graphics pintar = Graphics.FromImage(imagenAnalizar);
			Color pintura =Color.Purple;
			SolidBrush centro = new SolidBrush(Color.Yellow);
			SolidBrush centro2 = new SolidBrush(Color.Purple);
			x=x-r;
			y=y-r;
			centroide.FillEllipse(centro2,x,y,300,300);
			centroide.FillEllipse(centro,x-5,y-5,10,10);
		}
		
		
		
		
		
		
		
		void EncontrarCentro(int x,int y){
			
			int CentroX=0,CentroY=0,izquierda=x,derecha=x,abajo=y,arriba=y,abajo2=y;
			int radio,diametro,diametro2,diferencia,ovalo=0;
			while(imagenAnalizar.GetPixel(x,abajo).R!=255 
			      && imagenAnalizar.GetPixel(x,abajo).G!=255
			      && imagenAnalizar.GetPixel(x,abajo).B!=255){
				abajo++;
			}
			while(imagenAnalizar.GetPixel(x,abajo2).R!=255
			      && imagenAnalizar.GetPixel(x,abajo2).G!=255
			      && imagenAnalizar.GetPixel(x,abajo2).B!=255){
				abajo2--;
			}
			//if(abajo<arriba)
				CentroY=(abajo+arriba)/2;
			//else
			//	CentroY=(((abajo-arriba)/2)+arriba);
			while(imagenAnalizar.GetPixel(izquierda,CentroY).R!=255
			      && imagenAnalizar.GetPixel(izquierda,CentroY).G!=255
				      && imagenAnalizar.GetPixel(izquierda,CentroY).B!=255){
				izquierda--;
			}
			while(imagenAnalizar.GetPixel(derecha,CentroY).R!=255 
			      && imagenAnalizar.GetPixel(derecha,CentroY).G!=255
			      && imagenAnalizar.GetPixel(derecha,CentroY).B!=255){
				derecha++;
			}
		//	if(derecha>izquierda)
				CentroX=(derecha+izquierda)/2;
		//	else
		//		CentroX=(((derecha-izquierda)/2)+izquierda);
			diametro=derecha-izquierda;
			radio=diametro/2;
			
			//PintarCirculo2(CentroX,CentroY,radio);
			diametro=derecha-izquierda;
			diametro2=(abajo-arriba)+3;
			radio=diametro/2;
			diferencia=diametro2-diametro;
							if(diferencia<0)
								diferencia=diferencia*(-1);
							if(diferencia>10)
							{
								PintarCirculo3(CentroX,CentroY);
								ovalo++;
							}
							if(ovalo==0){
								PintarCirculo(CentroX,CentroY);
			listaCirculos.Add(new Circulo(CentroX,CentroY,diametro,contador,contador,diametro/2));
			listBoxCoordenadas.Items.Add(" ID = " + contador +" X = " + CentroX + " Y = " + CentroY +" Diametro = " + diametro +"\n");
			contador++;
							}
		}
		
		void Boton_Cargar_imagenClick(object sender, EventArgs e)
		{
			contador=1;
				cargar();



		}
		void cargar2(string nombre)
		{
					listBoxCoordenadas.Items.Clear();
			listaCirculos.Clear();
			     string imagen = nombre;
			     PictureBox_Circulos.Image = Image.FromFile(imagen);
			     imagenAnalizar = new Bitmap(imagen);	
		}
				void cargar()
		{
			listBoxCoordenadas.Items.Clear();
			listaCirculos.Clear();
			treeViewConexiones.Nodes.Clear();
			try
			 {
			   if (openFileDialog1.ShowDialog() == DialogResult.OK)
			   {
			     string imagen = openFileDialog1.FileName;
			     nombre2=imagen;
			     PictureBox_Circulos.Image = Image.FromFile(imagen);
			     imagenAnalizar = new Bitmap(imagen);
			   }
			 }
			 catch (Exception)
			 {
			   MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
			 }
		}
		
		void Boton_analizarClick(object sender, EventArgs e)
		{
			analizar();

		}
		void analizar()
		{
						
			for(int y=0; y<imagenAnalizar.Height;y++){
				for(int x=0; x<imagenAnalizar.Width;x++){
					if((imagenAnalizar.GetPixel(x,y).G==0) 
					   &&(imagenAnalizar.GetPixel(x,y).R==0) //negro
					   &&(imagenAnalizar.GetPixel(x,y).B==0)){
									EncontrarCentro(x,y);
					}
				}
			}
			PictureBox_Circulos.Image=imagenAnalizar;
		}
		void Grafo_buttonClick(object sender, EventArgs e)
		{
			grafo();
		}
		void grafo()
		{
						int i=0;
			treeViewConexiones.Nodes.Clear();
			grafoImagen = new Grafo(listaCirculos,imagenAnalizar);
			PictureBox_Circulos.Refresh();
			for(int x=0; x<grafoImagen.Vertices.Count;x++){
				treeViewConexiones.Nodes.Add(grafoImagen.Vertices[x].Etiqueta.ToString());
				for(int y=0; y<grafoImagen.Vertices[x].Aristas.Count;y++){
					treeViewConexiones.Nodes[x].Nodes.Add(grafoImagen.Vertices[x].Aristas[y].Destino.Etiqueta.ToString());
				}
			}
			i=grafoImagen.getContador;
			i++;
			grafoImagen.setContador=i;
			
		}

			private void drawCircleCenter(int x_m,int y_m,Bitmap bmpImage)
		{
			for(int i=-2;i<=8;i++)
				for(int j=-2;j<=8;j++)
					bmpImage.SetPixel (x_m+i,y_m+j,Color.Red);
				PictureBox_Circulos.Image=bmpImage;
		}
		
		void ButtonCaminoCortoClick(object sender, EventArgs e)
		{
			
		 int menor = int.MaxValue;
			int distanciaX;
			int distanciaY;
			int distanciaTotal;
			Vertice origen = null;
			Vertice destino = null;
			foreach(Vertice inicio in grafoImagen.Vertices){
				foreach(Vertice fin in grafoImagen.Vertices){
					if(inicio != fin){	
						distanciaX = fin.Circulo.Centro.X - inicio.Circulo.Centro.X;
						distanciaY = fin.Circulo.Centro.Y - inicio.Circulo.Centro.Y;
						distanciaTotal = (int)Math.Sqrt((distanciaX*distanciaX) + (distanciaY*distanciaY));
						if(distanciaTotal < menor){
							menor = distanciaTotal;
							origen = inicio;
							destino = fin;
						}
					}
				}
			}
			drawCircleCenter(destino.Circulo.Centro.X,destino.Circulo.Centro.Y,imagenAnalizar);
			drawCircleCenter(origen.Circulo.Centro.X,origen.Circulo.Centro.Y,imagenAnalizar);
			PictureBox_Circulos.Refresh();
		}
		void Button1Click(object sender, EventArgs e)
		{
			treeViewConexiones.Nodes.Clear();
			//cargar2(nombre2);
			//analizar();
			int[]a=new int[listaCirculos.Count];
			int[]dia=new int[listaCirculos.Count];
			
			int temp = 0;
			int temp2=0;
			int tempo=0;
			gra=Graphics.FromImage(imagenAnalizar);
			SolidBrush centro = new SolidBrush(Color.Transparent);
		

			for (int write = 0; write < listaCirculos.Count; write++)
			{
				for (int sort = 0; sort < listaCirculos.Count - 1; sort++)
				{
					if (listaCirculos[sort].getDiametro > listaCirculos[sort + 1].getDiametro)
					{
						temp = listaCirculos[sort + 1].getDiametro;
						temp2 = listaCirculos[sort + 1].getID2;
						listaCirculos[sort + 1].setDiametro = listaCirculos[sort].getDiametro;
						listaCirculos[sort + 1].setID2 = listaCirculos[sort].getID2;
						listaCirculos[sort].setDiametro = temp;
						listaCirculos[sort].setID2 = temp2;
					}
				}
				
			}
		for (int x = 0; x < listaCirculos.Count; x++)
			{
				for (int y = 0; y < listaCirculos.Count; y++)
				{
					if (listaCirculos[x].getID==listaCirculos[y].getID2)
					{
						
						a[x]=listaCirculos[y].getID;
					}
				}
				
			}
           
            for(int x=0;x<listaCirculos.Count; x++)
            {
            	listaCirculos[x].setID2=a[x];
            }
            for(int x=0; x<grafoImagen.Vertices.Count;x++){
				treeViewConexiones.Nodes.Add(grafoImagen.Vertices[x].Circulo.getID2.ToString());
				for(int y=0; y<grafoImagen.Vertices[x].Aristas.Count;y++){
					treeViewConexiones.Nodes[x].Nodes.Add(grafoImagen.Vertices[x].Aristas[y].Destino.Circulo.getID2.ToString());
				}
			}
             listBoxCoordenadas.Refresh();
            grafoImagen.dibujar(listaCirculos);
            PictureBox_Circulos.Refresh();
            
		}
		
	}
}