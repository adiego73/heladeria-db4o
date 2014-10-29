using System;
using Heladeria.db;
using Heladeria.model;

namespace Heladeria.db.query
{
	public class QueryPote : IHQuery<Pote>
	{
		private string descripcion;

		public QueryPote setDescripcion(string d)
		{
			descripcion = d;
			return this;
		}

		public Pote build()
		{
			return new Pote(descripcion);
		}
	}
}

