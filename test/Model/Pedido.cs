using System;
using System.Collections.Generic;

namespace Heladeria.model
{
	public class Pedido : IEntity
	{
		private List<Gusto> gustos;
		private string observaciones;
		private Cliente cliente;
		private Pote pote;

		public Pedido()
		{
		}
		
		public List<Gusto> getGustos()
		{
			if (gustos == null) {
				gustos = new List<Gusto>();
			}
			return this.gustos;
		}
		
		public void setObservaciones(string o)
		{
			observaciones = o;
		}
		
		public string getObservaciones()
		{
			if (observaciones == null) {
				observaciones = "";
			}
			return observaciones;
		}

		public void setPote(Pote p)
		{
			this.pote = p;
		}

		public Pote getPote()
		{
			return pote;
		}

		public void setCliente(Cliente c)
		{
			this.cliente = c;
		}

		public Cliente getCliente()
		{
			return cliente;
		}
		
		public void addGusto(Gusto g)
		{
			if (gustos == null) {
				gustos = new List<Gusto>();
			}
			gustos.Add(g);
		}

		public override string ToString()
		{
			string p = "";

			p += this.getCliente().ToString() + "\n";
			p += this.getPote().ToString() + "\n";
			p += this.getObservaciones() + "\n";
			foreach (Gusto g in this.getGustos()) {
				p += g.ToString() + " ";
			}
			return p;
		}
	}
}

