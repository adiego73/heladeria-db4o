using System;
using System.Collections.Generic;
using Heladeria.db;

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

			DB.saveGusto(new Gusto("vainilla"));
			DB.saveGusto(new Gusto("chocolate"));
			DB.saveGusto(new Gusto("frutilla"));
			DB.saveGusto(new Gusto("sambayon"));
			DB.saveGusto(new Gusto("limon"));
			
			DB.savePote(new Pote("CUARTO_KILO"));
			DB.savePote(new Pote("MEDIO_KILO"));
			DB.savePote(new Pote("KILO"));

			admin = new HeladeriaAdmin();
			return admin;
		}
		
		public IList<Gusto> getGustos()
		{
			return DB.findAllGustos();
		}
		
		public IList<Pote> getPotes()
		{
			return DB.findAllPotes();
		}

		public void destroy()
		{
			Console.WriteLine("destruyo Heladeria");
			DB.close();
		}

		private static void cleanDb()
		{
			Console.WriteLine("Limpio DB");
			IList<Gusto> gustos = DB.findAllGustos();
			foreach (Gusto g in gustos) {
				DB.removeGusto(g);
			}

			IList<Pote> potes = DB.findAllPotes();
			foreach (Pote p in potes) {
				DB.removePote(p);
			}
		}
	}
}

