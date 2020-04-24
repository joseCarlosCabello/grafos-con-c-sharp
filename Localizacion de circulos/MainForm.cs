/*
 * Created by SharpDevelop.
 * User: Rogger
 * Date: 29/01/2019
 * Time: 07:02 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tarea1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();}
			
		//
			// TODO: Add constructor code after the InitializeComponent() call.
					//
	void Boton1Click(object sender, EventArgs e)
		{
			OpenFileDialog fileDialog=new OpenFileDialog();
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
			string imagen=fileDialog.FileName;
			string imagen2=fileDialog.FileName;
			pictureBox1.Image=Image.FromFile(imagen);
			pictureBox2.Image=Image.FromFile(imagen2);
			}}
		
		void Button1Click(object sender, EventArgs e)
		{
			List<circulo> LC= new List<circulo>();
			Bitmap bmpImage = new Bitmap(pictureBox1.Image);
			Color c;
			int contador=0;
			for(int j=0;j<bmpImage.Height;j++){
				for(int i=0;i<bmpImage.Width;i++)
				{
					c=bmpImage.GetPixel(i,j);
					if(isBlack(c))
					{
							{
							int x_i,x_f,x_act,x_m,x_act2;
							int y_i,y_f,y_act;
							int radio;
							int diametro,diametro2;
							int diferencia;
							
							Color c_act;
							
							y_i=j;
							y_act=y_i;
							
							
							do{
								y_act++;
								c_act=bmpImage.GetPixel(i,y_act);
							}while(isBlack(c_act));
							y_m=(y_act-y_i)/2;
							y_f=y_act-y_m;
							diametro=y_act-y_i;
							x_i=i;
							x_act=x_i;
							x_act2=x_i;
							do{
								x_act++;
								c_act=bmpImage.GetPixel(x_act,y_f);
							}while(isBlack(c_act));
							do{
								x_act2--;
								c_act=bmpImage.GetPixel(x_act2,y_f);
							}while(isBlack(c_act));
							
							x_m=(x_act-x_act2)/2;
							diametro2=x_m*2;
							radio=y_m/2;
							x_f=x_act-x_m;
							diferencia=diametro2-diametro;
							if(diferencia<0)
								diferencia=diferencia*(-1);
							if(diferencia>10)
							{
								Colorear_blanco(x_f,y_f,bmpImage);
								break;
							}
							
							Colorear(x_f,y_f,bmpImage);
							drawCircleCenter(x_f,y_f, bmpImage);
							pictureBox1.Image=bmpImage;
							circulo ccirculo=new circulo(x_f,y_f,radio,contador++);
							LC.Add(ccirculo);
							
							
							
					}
							
					}
					

				
			}
			}
			listBoxCentro.DataSource=LC;
			
		}
	private void drawCircleCenter(int x_m,int y_m,Bitmap bmpImage)
		{
			for(int i=-4;i<=4;i++)
				for(int j=-4;j<=4;j++)
					bmpImage.SetPixel (x_m+i,y_m+j,Color.Yellow);
				pictureBox1.Image=bmpImage;
		}

	private bool isBlack(Color c)
	{
		if(c.R!=0)
			return false;
		if(c.G!=0)
			return false;
		if(c.B!=0)
			return false;
		return true;
	}
	
	 private void Colorear(int x, int y, Bitmap bmpImagen)
        {
            Color c_actual;
            for (int Der = x; Der < bmpImagen.Width; Der++)
            {
                c_actual = bmpImagen.GetPixel(Der, y);
                if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                    break;
                for (int Arr = y; Arr > 0; Arr--)
                {
                    c_actual = bmpImagen.GetPixel(Der, Arr);
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                        break;
                    bmpImagen.SetPixel(Der, Arr, Color.Blue);
                }
                for (int Aba = y; Aba < bmpImagen.Height; Aba++)
                {
                    c_actual = bmpImagen.GetPixel(Der, Aba);
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                        break;
                    bmpImagen.SetPixel(Der, Aba, Color.Blue);
                }
            }
            for (int Izq = x - 1; Izq < bmpImagen.Width; Izq--)
            {
                c_actual = bmpImagen.GetPixel(Izq, y);
                if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                    break;
                for (int Arr = y; Arr > 0; Arr--)
                {
                    c_actual = bmpImagen.GetPixel(Izq, Arr);
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                        break;
                    bmpImagen.SetPixel(Izq, Arr, Color.Blue);
                }
                for (int Aba = y; Aba < bmpImagen.Height; Aba++)
                {
                    c_actual = bmpImagen.GetPixel(Izq, Aba);
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                        break;
                    bmpImagen.SetPixel(Izq, Aba, Color.Blue);
                }
            }
        }
	 
	 
	 
	 
	 
	 	 private void Colorear_blanco(int x, int y, Bitmap bmpImagen)
        {
            Color c_actual;
            for (int Der = x; Der < bmpImagen.Width; Der++)
            {
                c_actual = bmpImagen.GetPixel(Der, y);
                if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                    break;
                for (int Arr = y; Arr > 0; Arr--)
                {
                    c_actual = bmpImagen.GetPixel(Der, Arr);
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                        break;
                    bmpImagen.SetPixel(Der, Arr, Color.White);
                }
                for (int Aba = y; Aba < bmpImagen.Height; Aba++)
                {
                    c_actual = bmpImagen.GetPixel(Der, Aba);
                    int contador1=0;
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                        contador1++;
                    if(contador1==10)
                    	break;
                    bmpImagen.SetPixel(Der, Aba, Color.White);
                }
            }
            for (int Izq = x - 1; Izq < bmpImagen.Width; Izq--)
            {
                c_actual = bmpImagen.GetPixel(Izq, y);
                if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                    break;
                for (int Arr = y; Arr > 0; Arr--)
                {
                    c_actual = bmpImagen.GetPixel(Izq, Arr);
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                        break;
                    bmpImagen.SetPixel(Izq, Arr, Color.White);
                }
                for (int Aba = y; Aba < bmpImagen.Height; Aba++)
                {
                    c_actual = bmpImagen.GetPixel(Izq, Aba);
                    int contador2=0;
                    if (c_actual.R == 255 && c_actual.G == 255 && c_actual.B == 255)
                    	contador2++;
                    if(contador2==10)
                    	break;
                    bmpImagen.SetPixel(Izq, Aba, Color.White);
                }
            }
        }

		}
	  
	
		}
	

	
