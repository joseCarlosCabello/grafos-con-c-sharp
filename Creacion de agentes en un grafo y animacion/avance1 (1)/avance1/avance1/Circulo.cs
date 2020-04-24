/*
 * Created by SharpDevelop.
 * User: lobo1
 * Date: 05/03/2019
 * Time: 01:27 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
		int radio;
		
		public int Radio {
			get { return radio; }
		}
		
		public Point Centro {
			get { return centro; }
		}
		
		public Circulo(int x, int y, int radio)
		{
			centro = new Point(x,y);
			this.radio = radio;
		}
		
	}
}
