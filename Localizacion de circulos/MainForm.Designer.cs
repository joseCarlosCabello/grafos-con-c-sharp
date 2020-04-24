/*
 * Created by SharpDevelop.
 * User: Rogger
 * Date: 29/01/2019
 * Time: 07:02 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace tarea1
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button boton1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBoxCentro;
		private System.Windows.Forms.PictureBox pictureBox2;
		
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
			this.boton1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.button1 = new System.Windows.Forms.Button();
			this.listBoxCentro = new System.Windows.Forms.ListBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// boton1
			// 
			this.boton1.Location = new System.Drawing.Point(779, 46);
			this.boton1.Name = "boton1";
			this.boton1.Size = new System.Drawing.Size(152, 83);
			this.boton1.TabIndex = 0;
			this.boton1.Text = "cargar imagen";
			this.boton1.UseVisualStyleBackColor = true;
			this.boton1.Click += new System.EventHandler(this.Boton1Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(46, 413);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(644, 314);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(779, 149);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(163, 85);
			this.button1.TabIndex = 2;
			this.button1.Text = "analizar";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// listBoxCentro
			// 
			this.listBoxCentro.FormattingEnabled = true;
			this.listBoxCentro.Location = new System.Drawing.Point(726, 254);
			this.listBoxCentro.Name = "listBoxCentro";
			this.listBoxCentro.Size = new System.Drawing.Size(178, 173);
			this.listBoxCentro.TabIndex = 3;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(46, 46);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(644, 298);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(968, 749);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.listBoxCentro);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.boton1);
			this.Name = "MainForm";
			this.Text = "tarea1";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
