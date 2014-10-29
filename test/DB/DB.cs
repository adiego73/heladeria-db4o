using System;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Db4objects.Db4o.Query;
using Heladeria.model;
using System.Collections.Generic;

namespace Heladeria.db
{
	public class DB
	{
		readonly static string DB_PATH = "db.yap";
		private static IObjectContainer container = null;
		
		public static void close()
		{
			if (container != null) {
				Console.WriteLine("Container close");
				container.Close();
			}
		}

		private static IObjectContainer getContainer()
		{
			if (container == null) {
				container = Db4oEmbedded.OpenFile(DB_PATH);
			}
			return container;
		}

		public static IList<Cliente> findAllClientes()
		{
			IList<Cliente> result = getContainer().Query<Cliente>(typeof(Cliente));
			return result;
		}

		public static IList<Gusto> findAllGustos()
		{
			IList<Gusto> result = getContainer().Query<Gusto>(typeof(Gusto));
			return result;
		}

		public static IList<Pote> findAllPotes()
		{
			IList<Pote> result = getContainer().Query<Pote>(typeof(Pote));
			return result;
		}

		public static void saveCliente(Cliente c)
		{
			getContainer().Store(c);
		}

		public static void savePote(Pote p)
		{
			getContainer().Store(p);
		}

		public static void saveGusto(Gusto g)
		{
			getContainer().Store(g);
		}

		public static void removeGusto(Gusto g)
		{
			getContainer().Delete(g);
		}

		public static void removePote(Pote p)
		{
			getContainer().Delete(p);
		}
	}
}

