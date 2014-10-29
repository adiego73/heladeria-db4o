using System;
using Heladeria.model;

namespace Heladeria.db.query
{
	public class QueryCliente : IHQuery<Cliente>
	{
		private string telefono;
		private string nombre;
		
		public QueryCliente setTelefono(string t)
		{
			this.telefono = t;
			return this;
		}
		
		public QueryCliente setNombre(string n)
		{
			nombre = n;
			return this;
		}
		
		public Cliente build()
		{
			return new Cliente(nombre, telefono);
		}
	}
}

