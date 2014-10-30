using System;

namespace Heladeria.model
{
	public class Pote : IEntity
	{
		private string descripcion;
		private float valor;
		
		public Pote(string desc, float v)
		{
			descripcion = desc;
			valor = v;
		}

		public void setValor(float v)
		{
			this.valor = v;
		}

		public float getValor()
		{
			return valor;
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

