using System;

namespace Heladeria.model
{
	public class Gusto
	{
		private string descripcion;
		
		public Gusto (string desc)
		{
			descripcion = desc;
		}
		
		public string getDescripcion ()
		{
			return descripcion;
		}
	}
}

