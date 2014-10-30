using System;
using System.Collections.Generic;
using Heladeria.db;
using Heladeria.db.query;

namespace Heladeria.model
{
	public class HeladeriaAdmin
	{
		private static HeladeriaAdmin admin = null;
		private Pedido pedido;
		
		public static HeladeriaAdmin build()
		{
			if (admin != null) {
				return admin;
			}

			cleanDb();

			DB.save<Gusto>(new Gusto("vainilla"));
			DB.save<Gusto>(new Gusto("chocolate"));
			DB.save<Gusto>(new Gusto("frutilla"));
			DB.save<Gusto>(new Gusto("sambayon"));
			DB.save<Gusto>(new Gusto("limon"));
			
			DB.save<Pote>(new Pote("CUARTO_KILO", 20));
			DB.save<Pote>(new Pote("MEDIO_KILO", 35));
			DB.save<Pote>(new Pote("KILO", 50));

			admin = new HeladeriaAdmin();
			return admin;
		}
		
		public List<Gusto> getGustos()
		{
			return new List<Gusto>(DB.getAll<Gusto>());
		}
		
		public List<Pote> getPotes()
		{
			return new List<Pote>(DB.getAll<Pote>());
		}

		public Cliente getCliente(string telefono)
		{
			QueryCliente query = new QueryCliente().setTelefono(telefono);
			return DB.getOne<Cliente>(query);
		}

		public void destroy()
		{
			Console.WriteLine("destruyo Heladeria");
			DB.close();
		}

		private void validatePedido()
		{
			if (pedido == null) {
				pedido = new Pedido();
			}
		}

		public Gusto getGusto(string descripcion)
		{
			QueryGusto query = new QueryGusto().addDescripcion(descripcion);
			return DB.getOne<Gusto>(query);
		}

		public Pote getPote(string descripcion)
		{
			QueryPote query = new QueryPote().addDescripcion(descripcion);
			return DB.getOne<Pote>(query);
		}

		public void addClienteAPedido(Cliente c)
		{
			validatePedido();
			pedido.setCliente(c);
		}

		public void addGustoAPedido(Gusto g)
		{
			validatePedido();
			pedido.addGusto(g);
			Console.WriteLine("agreog gusto: " + g.ToString());
		}

		public void removeGustoAPedido(Gusto g)
		{
			if (pedido.getGustos().Contains(g)) {
				pedido.getGustos().Remove(g);
				Console.WriteLine("borro gusto: " + g.ToString());
			}
		}

		public void addPoteAPedido(Pote p)
		{
			validatePedido();
			pedido.setPote(p);
		}

		public void clearPedido()
		{
			pedido = null;
		}

		private static void cleanDb()
		{
			Console.WriteLine("Limpio DB");
			IList<Gusto> gustos = DB.getAll<Gusto>();
			foreach (Gusto g in gustos) {
				DB.remove<Gusto>(g);
			}

			IList<Pote> potes = DB.getAll<Pote>();
			foreach (Pote p in potes) {
				DB.remove<Pote>(p);
			}
		}
	}
}

