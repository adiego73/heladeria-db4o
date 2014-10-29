using System;
using Heladeria.model;

namespace Heladeria.db.query
{
	public class QueryGusto : IHQuery<Gusto>
	{
		private string descripcion;

		public QueryGusto setDescripcion(string d)
		{
			descripcion = d;
			return this;
		}

		public Gusto build()
		{
			return new Gusto(descripcion);
		}
	}
}

