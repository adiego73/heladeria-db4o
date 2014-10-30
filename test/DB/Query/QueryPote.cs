using System;
using Heladeria.model;

namespace Heladeria.db.query
{
	public class QueryPote : IHQuery<Pote>
	{
		private string descripcion;
		private float valor;

		public QueryPote addDescripcion(string d)
		{
			descripcion = d;
			return this;
		}

		public QueryPote addValor(float v)
		{
			valor = v;
			return this;
		}

		public Pote build()
		{
			return new Pote(descripcion, valor);
		}
	}
}

