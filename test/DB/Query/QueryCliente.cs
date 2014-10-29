using System;
using Heladeria.model;
using Db4objects.Db4o.Query;

namespace Heladeria.db.query
{
	public class QueryCliente : IHQuery<Cliente>
	{
		private string telefono;
		
		public QueryCliente setTelefono(string t)
		{
			this.telefono = t;
			return this;
		}
		
		public Cliente build()
		{
			return new Cliente(null, telefono);
		}

	}
}

