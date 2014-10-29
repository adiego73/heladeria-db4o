using System;
using System.Collections.Generic;
using Heladeria.db;
using Heladeria.db.query;

namespace Heladeria.model
{
	public class HeladeriaAdmin
	{
		private static HeladeriaAdmin admin = null;
		
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
			
			DB.save<Pote>(new Pote("CUARTO_KILO"));
			DB.save<Pote>(new Pote("MEDIO_KILO"));
			DB.save<Pote>(new Pote("KILO"));

			DB.save<Cliente>(new Cliente("diego", "1234"));

			admin = new HeladeriaAdmin();
			return admin;
		}
		
		public IList<Gusto> getGustos()
		{
			return DB.getAll<Gusto>();
		}
		
		public IList<Pote> getPotes()
		{
			return DB.getAll<Pote>();
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

