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

		private HeladeriaAdmin()
		{
			pedido = new Pedido();
		}

		public static HeladeriaAdmin build()
		{
			if (admin != null) {
				return admin;
			}

			cleanDb();

			DB.save<Gusto>(new Gusto("vainilla"));
			DB.save<Gusto>(new Gusto("frambueza"));
			DB.save<Gusto>(new Gusto("crema americana"));
			DB.save<Gusto>(new Gusto("chocolate suizo"));
			DB.save<Gusto>(new Gusto("chocolate amargo"));
			DB.save<Gusto>(new Gusto("banana split"));
			DB.save<Gusto>(new Gusto("tramontanas"));
			DB.save<Gusto>(new Gusto("chocolate"));
			DB.save<Gusto>(new Gusto("frutilla"));
			DB.save<Gusto>(new Gusto("sambayon"));
			DB.save<Gusto>(new Gusto("limon"));
			
			DB.save<Pote>(new Pote("CUARTO KILO", 20));
			DB.save<Pote>(new Pote("MEDIO KILO", 35));
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
			pedido.setCliente(c);
		}

		public void addGustoAPedido(Gusto g)
		{
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
			pedido.setPote(p);
		}

		public void clearPedido()
		{
			pedido = new Pedido();
		}

		public void createPedido()
		{
			this.pedido = new Pedido();
		}

		public Pedido getPedido()
		{
			return this.pedido;
		}

		public void savePedido()
		{
			DB.save<Pedido>(pedido);
			clearPedido();
		}

		public void saveCliente(Cliente c)
		{
			DB.save<Cliente>(c);
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

