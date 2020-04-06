/*
 * Created by SharpDevelop.
 * User: lobo1
 * Date: 21/02/2019
 * Time: 01:18 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace avance1
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.PictureBox_Circulos = new System.Windows.Forms.PictureBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.Boton_Cargar_imagen = new System.Windows.Forms.Button();
			this.Boton_analizar = new System.Windows.Forms.Button();
			this.listBoxCoordenadas = new System.Windows.Forms.ListBox();
			this.Grafo_button = new System.Windows.Forms.Button();
			this.treeViewConexiones = new System.Windows.Forms.TreeView();
			this.buttonCaminoCorto = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.PictureBox_Circulos)).BeginInit();
			this.SuspendLayout();
			// 
			// PictureBox_Circulos
			// 
			this.PictureBox_Circulos.Location = new System.Drawing.Point(12, 12);
			this.PictureBox_Circulos.Name = "PictureBox_Circulos";
			this.PictureBox_Circulos.Size = new System.Drawing.Size(603, 433);
			this.PictureBox_Circulos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.PictureBox_Circulos.TabIndex = 0;
			this.PictureBox_Circulos.TabStop = false;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Boton_Cargar_imagen
			// 
			this.Boton_Cargar_imagen.Location = new System.Drawing.Point(621, 41);
			this.Boton_Cargar_imagen.Name = "Boton_Cargar_imagen";
			this.Boton_Cargar_imagen.Size = new System.Drawing.Size(135, 23);
			this.Boton_Cargar_imagen.TabIndex = 1;
			this.Boton_Cargar_imagen.Text = "Cargar Imagen";
			this.Boton_Cargar_imagen.UseVisualStyleBackColor = true;
			this.Boton_Cargar_imagen.Click += new System.EventHandler(this.Boton_Cargar_imagenClick);
			// 
			// Boton_analizar
			// 
			this.Boton_analizar.Location = new System.Drawing.Point(621, 70);
			this.Boton_analizar.Name = "Boton_analizar";
			this.Boton_analizar.Size = new System.Drawing.Size(135, 23);
			this.Boton_analizar.TabIndex = 2;
			this.Boton_analizar.Text = "Analizar";
			this.Boton_analizar.UseVisualStyleBackColor = true;
			this.Boton_analizar.Click += new System.EventHandler(this.Boton_analizarClick);
			// 
			// listBoxCoordenadas
			// 
			this.listBoxCoordenadas.FormattingEnabled = true;
			this.listBoxCoordenadas.Location = new System.Drawing.Point(621, 155);
			this.listBoxCoordenadas.Name = "listBoxCoordenadas";
			this.listBoxCoordenadas.Size = new System.Drawing.Size(295, 121);
			this.listBoxCoordenadas.TabIndex = 3;
			// 
			// Grafo_button
			// 
			this.Grafo_button.Location = new System.Drawing.Point(775, 49);
			this.Grafo_button.Name = "Grafo_button";
			this.Grafo_button.Size = new System.Drawing.Size(141, 23);
			this.Grafo_button.TabIndex = 4;
			this.Grafo_button.Text = "Grafo";
			this.Grafo_button.UseVisualStyleBackColor = true;
			this.Grafo_button.Click += new System.EventHandler(this.Grafo_buttonClick);
			// 
			// treeViewConexiones
			// 
			this.treeViewConexiones.Location = new System.Drawing.Point(621, 282);
			this.treeViewConexiones.Name = "treeViewConexiones";
			this.treeViewConexiones.Size = new System.Drawing.Size(135, 163);
			this.treeViewConexiones.TabIndex = 5;
			// 
			// buttonCaminoCorto
			// 
			this.buttonCaminoCorto.Location = new System.Drawing.Point(621, 99);
			this.buttonCaminoCorto.Name = "buttonCaminoCorto";
			this.buttonCaminoCorto.Size = new System.Drawing.Size(135, 36);
			this.buttonCaminoCorto.TabIndex = 6;
			this.buttonCaminoCorto.Text = "menor distancia";
			this.buttonCaminoCorto.UseVisualStyleBackColor = true;
			this.buttonCaminoCorto.Click += new System.EventHandler(this.ButtonCaminoCortoClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(802, 93);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(84, 41);
			this.button1.TabIndex = 7;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(917, 457);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.buttonCaminoCorto);
			this.Controls.Add(this.treeViewConexiones);
			this.Controls.Add(this.Grafo_button);
			this.Controls.Add(this.listBoxCoordenadas);
			this.Controls.Add(this.Boton_analizar);
			this.Controls.Add(this.Boton_Cargar_imagen);
			this.Controls.Add(this.PictureBox_Circulos);
			this.Name = "MainForm";
			this.Text = "avance1";
			((System.ComponentModel.ISupportInitialize)(this.PictureBox_Circulos)).EndInit();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button buttonCaminoCorto;
		private System.Windows.Forms.TreeView treeViewConexiones;
		private System.Windows.Forms.Button Grafo_button;
		private System.Windows.Forms.ListBox listBoxCoordenadas;
		private System.Windows.Forms.Button Boton_analizar;
		private System.Windows.Forms.Button Boton_Cargar_imagen;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.PictureBox PictureBox_Circulos;
		private System.Windows.Forms.Button button1;
	}
}
