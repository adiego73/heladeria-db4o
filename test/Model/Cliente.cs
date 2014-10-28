using System;

namespace Heladeria.model
{
	public class Cliente
	{
		private string nombre;
		private string telefono;
			
		public Cliente (string nombre, string telefono)
		{
			this.nombre = nombre;
			this.telefono = telefono;
		}
		
		public void setNombre (string n)
		{
			this.nombre = n;
		}
		
		public void setTelefono (string t)
		{
			this.telefono = t;
		}
		
		public string getNombre ()
		{
			return nombre;
		}
		
		public string getTelefono ()
		{
			return telefono;
		}
	}
}

