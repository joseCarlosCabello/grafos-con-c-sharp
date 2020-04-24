
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
		
        Grafo grafo;

        Bitmap mapa;
        Bitmap supBmp;

        List<string> L = new List<string>();
        List<Agente> aL = new List<Agente>();

        bool isThereABait;

        Point bait;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
 			grafo = new Grafo();

            PictureBoxCopy.BackgroundImageLayout = ImageLayout.Zoom;

            openFileDialog1.Filter = "Archivos de Imagen (*.jpg, *.png)|*.jpg; *.png";

            bait = new Point();

            isThereABait = false;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void PintarCirculo(int x, int y, Color pintar){
			int izq=x,arr=y,der=x+1,aba=y;
			centroide = Graphics.FromImage(imagenAnalizar);
			//movimiento = Graphics.FromImage(imagenAnalizar);
			Color pintura =pintar;
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
		void EncontrarCentro(int x,int y){//Antes era void
			int CentroX=0,CentroY=0,izquierda=x,derecha=x,abajo=y,arriba=y, radio;
			while(imagenAnalizar.GetPixel(x,abajo).R==0 
			      && imagenAnalizar.GetPixel(x,abajo).G==0
			      && imagenAnalizar.GetPixel(x,abajo).B==0){
				abajo++;
			}
			CentroY=(((abajo-arriba)/2)+arriba);
			while(imagenAnalizar.GetPixel(izquierda,CentroY).R==0 
			      && imagenAnalizar.GetPixel(izquierda,CentroY).G==0
			      && imagenAnalizar.GetPixel(izquierda,CentroY).B==0){
				izquierda--;
			}
			while(imagenAnalizar.GetPixel(derecha,CentroY).R==0 
			      && imagenAnalizar.GetPixel(derecha,CentroY).G==0
			      && imagenAnalizar.GetPixel(derecha,CentroY).B==0){
				derecha++;
			}
			CentroX=(((derecha-izquierda)/2)+izquierda);	
			radio= ((derecha-izquierda)/2);
			PintarCirculo(CentroX,CentroY,Color.Purple);
			listaCirculos.Add(new Circulo(CentroX,CentroY,radio));
			listBoxCoordenadas.Items.Add(" X = " + CentroX + " Y = " + CentroY + "\n");
		}
		
		void Boton_Cargar_imagenClick(object sender, EventArgs e)
		{
			listBoxCoordenadas.Items.Clear();
			listaCirculos.Clear();
			treeViewConexiones.Nodes.Clear();
			try
			 {
			   if (openFileDialog1.ShowDialog() == DialogResult.OK)
			   {
			     string imagen = openFileDialog1.FileName;
			     PictureBox_Circulos.Image = Image.FromFile(imagen);
			     imagenAnalizar = new Bitmap(imagen);//lleva otro argumento(imagen, algo)
			   }
			 }
			 catch (Exception)
			 {
			   MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
			 }
			 animacion = new Bitmap(imagenAnalizar.Width,imagenAnalizar.Height);
			 movimiento = Graphics.FromImage(animacion);//antes animacion
		}
		
		void Boton_analizarClick(object sender, EventArgs e)
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
			grafo = new Grafo(listaCirculos,imagenAnalizar);
			PictureBox_Circulos.Refresh();
			for(int x=0; x<grafo.Vertices.Count;x++){
				treeViewConexiones.Nodes.Add(grafo.Vertices[x].Etiqueta.ToString());
				for(int y=0; y<grafo.Vertices[x].Aristas.Count;y++){
					treeViewConexiones.Nodes[x].Nodes.Add(grafo.Vertices[x].Aristas[y].Destino.Etiqueta.ToString());
				}
			}
			numeroDeAgentes.Maximum = grafo.Vertices.Count;
			PictureBox_Circulos.BackgroundImage = imagenAnalizar;
			//listBoxAristas.Items.Add("Arista " + List<Vertice> + " se conecta con " + List<Vertice> "\n");
		}
		
		void ButtonCaminoCortoClick(object sender, EventArgs e)
		{
			int menor = int.MaxValue;
			
			int distanciaX;
			int distanciaY;
			int distancia;
			Vertice verticeOrigen = null;
			Vertice verticeDestino = null;
			try{
			foreach(Vertice puntoA in grafo.Vertices){
				foreach(Vertice puntoB in grafo.Vertices){
					if(puntoA != puntoB){
						distanciaX = puntoB.Circulo.Centro.X - puntoA.Circulo.Centro.X;
						distanciaY = puntoB.Circulo.Centro.Y - puntoA.Circulo.Centro.Y;
						distancia = (int)Math.Sqrt((distanciaX*distanciaX) + (distanciaY*distanciaY));
						if(distancia < menor){
							menor = distancia;
							verticeOrigen = puntoA;
							verticeDestino = puntoB;
						}
					}
				}
			}
			
			centroide.FillEllipse(new SolidBrush(Color.Yellow),verticeOrigen.Circulo.Centro.X-verticeOrigen.Circulo.Radio,verticeOrigen.Circulo.Centro.Y-verticeOrigen.Circulo.Radio,verticeOrigen.Circulo.Radio*2,verticeOrigen.Circulo.Radio*2);
			centroide.FillEllipse(new SolidBrush(Color.Yellow),verticeDestino.Circulo.Centro.X-verticeDestino.Circulo.Radio,verticeDestino.Circulo.Centro.Y-verticeDestino.Circulo.Radio,verticeDestino.Circulo.Radio*2,verticeDestino.Circulo.Radio*2);
			PictureBox_Circulos.Refresh();
			}
			catch{
				MessageBox.Show("No se cumplen con los requerimientos minimos para los vertices");
			}
		}
		
		void ButtonAgenteClick(object sender, EventArgs e)
		{
			treeViewAgentes.Nodes.Clear();
			int menorDistancia = int.MaxValue;
			agentesTerminaron.Clear();
			try{
			if(listaAgentes.Count >= 0){
			List<Agente> listaAgentesVertices = new List<Agente>();
			Agente agenteMayor = listaAgentes[0];
			Point mover;
			while(agentesTerminaron.Count < listaAgentes.Count){
				movimiento.Clear(Color.Transparent);
				foreach(Agente a in listaAgentes){
					if(!a.FinalizoCaminoArista()){
						mover = a.Mover();
						movimiento.FillEllipse(new SolidBrush(Color.Black),mover.X-10,mover.Y-10,10*2,10*2);
					}
					else if(a.ExistenCaminos()){
						a.ProximoCamino();
					}
					else{
						if(!agentesTerminaron.Contains(a))
							agentesTerminaron.Add(a);
					}
				}
				PictureBox_Circulos.Refresh();
			}
			foreach(Agente A in listaAgentes){
				if(agenteMayor.VerticesTotales.Count < A.VerticesTotales.Count){
					agenteMayor = A;
					listaAgentesVertices.Clear();
					listaAgentesVertices.Add(A);
				}
				else if(agenteMayor.VerticesTotales.Count == A.VerticesTotales.Count){
					listaAgentesVertices.Add(A);
				}
			}
			foreach(Agente B in listaAgentesVertices){
				if(B.RecorridoTota < menorDistancia){
					menorDistancia = B.RecorridoTota;
					agenteMayor = B;
				}
			}
			labelMayorDistancia.Text = (agenteMayor.Id + " : " + agenteMayor.RecorridoTota + " , Vertices: " + agenteMayor.VerticesTotales.Count.ToString());
	
			for(int x=0; x<listaAgentes.Count;x++){
				treeViewAgentes.Nodes.Add(listaAgentes[x].Id.ToString());
				for(int y=0; y<listaAgentes[x].CaminosRecorridos.Count;y=y+2){
					if(y==listaAgentes[x].CaminosRecorridos.Count-2)
					{
						treeViewAgentes.Nodes[x].Nodes.Add(listaAgentes[x].CaminosRecorridos[y++].Origen.Etiqueta.ToString());
					
					}
					
						treeViewAgentes.Nodes[x].Nodes.Add(listaAgentes[x].CaminosRecorridos[y].Origen.Etiqueta.ToString());
				}
			}

			
			}
			}
			catch{
				MessageBox.Show("No hay agentes para mover");
			}
			
		}
		
		void ButtonInsertarAgentesClick(object sender, EventArgs e)
		{
			comboBoxAgentes.Items.Clear();
			listaAgentes.Clear();
			PictureBox_Circulos.Image = animacion;
			Random rand = new Random();
			Vertice punto;
			for(int x=0; x < numeroDeAgentes.Value; x++){
				while(true){
					punto = grafo.Vertices[rand.Next(0,grafo.Vertices.Count)];
					if((listaAgentes.Find(delegate(Agente buscar){return buscar.Origen == punto;})) == null){
						break;
					}
				}
				listaAgentes.Add(new Agente(punto,x));
				movimiento.FillEllipse(new SolidBrush(Color.Black),punto.Circulo.Centro.X-10,punto.Circulo.Centro.Y-10,10*2,10*2);
				PictureBox_Circulos.Refresh();
			}
			for(int i = 0; i< listaAgentes.Count;i++){
				comboBoxAgentes.Items.Add(i.ToString());
			}
		}
		
		void ComboBoxAgentesSelectedIndexChanged(object sender, EventArgs e)
		{
			movimiento.Clear(Color.Transparent);
			int iteradorAgente = comboBoxAgentes.SelectedIndex;
			Pen lapiz = new Pen(Color.Orange,2);
			foreach(Aristas A in listaAgentes[iteradorAgente].CaminosRecorridos){
				movimiento.DrawLine(lapiz,A.Origen.Circulo.Centro.X,A.Origen.Circulo.Centro.Y,A.Destino.Circulo.Centro.X,A.Destino.Circulo.Centro.Y);
			}
			PictureBox_Circulos.Image = animacion;
		}
		

	}
}