using System;
using System.Collections.Generic;

namespace test
{
	public class Pedido
	{
		private List<Gusto> gustos;
		private string observaciones;
		private Cliente cliente;
		private Pote pote;
		
		public Pedido (Cliente c, Pote p)
		{
			cliente = c;
			pote = p;
		}
		
		public List<Gusto> getGustos ()
		{
			return this.gustos;
		}
		
		public void setObservaciones (string o)
		{
			observaciones = o;
		}
		
		public string getObservaciones ()
		{
			return observaciones;
		}
		
		public Pote getPote ()
		{
			return pote;
		}
		
		public Cliente getCliente ()
		{
			return cliente;
		}
		
		public void addGusto (Gusto g)
		{
			gustos.Add (g);
		}
	}
}

