/*
 * Created by SharpDevelop.
 * User: Rogger
 * Date: 04/02/2019
 * Time: 12:36 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace tarea1
{
	/// <summary>
	/// Description of circulo.
	/// </summary>
	public class circulo
	{
		private int x;
		private int y;
		private int r;
		private int id;
		public circulo(int x,int y,int r, int id)
		{
			this.x=x;
			this.y=y;
			this.r=r;
			this.id=id;
		}
			public override string ToString()
        {
            return string.Format("[X={0} Y={1} | ID={2}]",x,y,id);
        }
	}

}
