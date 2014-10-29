using System;

namespace Heladeria.model
{
	public class Pote
	{
		private string descripcion;
		
		public Pote(string desc)
		{
			descripcion = desc;
		}
		
		public string getDescripcion()
		{
			return descripcion;
		}

		public override bool Equals(object o)
		{
			Pote p = o as Pote;
			if (p == null) {
				return false;
			}

			return (this.descripcion.Equals(p.descripcion));
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

