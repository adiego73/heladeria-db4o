using System;

namespace Heladeria.model
{
	public class Cliente : IEntity
	{
		private string nombre;
		private string telefono;
			
		public Cliente(string nombre, string telefono)
		{
			this.nombre = nombre;
			this.telefono = telefono;
		}
		
		public void setNombre(string n)
		{
			this.nombre = n;
		}
		
		public void setTelefono(string t)
		{
			this.telefono = t;
		}
		
		public string getNombre()
		{
			return nombre;
		}
		
		public string getTelefono()
		{
			return telefono;
		}

		public override bool Equals(object o)
		{
			Cliente c = o as Cliente;
			if (c == null) {
				return false;
			}

			return (this.telefono.Equals(c.telefono));
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}

