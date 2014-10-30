using System;
using Heladeria.model;

namespace Heladeria.db.query
{
	public class QueryPedido : IHQuery<Pedido>
	{

		public Pedido build()
		{
			Pedido p = new Pedido();
			p.setPote(null);
			p.setPagaCon(0);
			p.setObservaciones("");
			p.setCliente(null);
			return p;
		}
	}
}

