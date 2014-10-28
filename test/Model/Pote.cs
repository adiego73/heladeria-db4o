using System;

namespace Heladeria.model
{
	public class Pote
	{
		private string descripcion;
		
		public Pote (string desc)
		{
			descripcion = desc;
		}
		
		public string getDescripcion ()
		{
			return descripcion;
		}
	}
}

