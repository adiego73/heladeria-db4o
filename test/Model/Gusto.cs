using System;

namespace Heladeria.model
{
	public class Gusto : IEntity
	{
		private string descripcion;
		
		public Gusto(string desc)
		{
			descripcion = desc;
		}
		
		public string getDescripcion()
		{
			return descripcion;
		}

		public override string ToString()
		{
			return descripcion;
		}

		public override bool Equals(object o)
		{
			Gusto g = o as Gusto;
			if (g == null) {
				return false;
			}

			return (this.descripcion.Equals(g.descripcion));
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

