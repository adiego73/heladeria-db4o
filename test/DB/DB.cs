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
		
		private static void close()
		{
			if (container != null) {
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
		
		public static List<Cliente> findAllClientes()
		{
			List<Cliente> result = new List<Cliente>();
			IObjectSet clientes = getContainer().QueryByExample(typeof(Cliente));

			foreach (Object o in clientes) {
				result.Add((Cliente)o);
			}

			return result;
		}

		public static List<Gusto> findAllGustos()
		{
			List<Gusto> result = new List<Gusto>();
			IObjectSet gustos = getContainer().QueryByExample(typeof(Gusto));

			foreach (Object o in gustos) {
				result.Add((Gusto)o);
			}

			return result;
		}

		public static List<Pote> findAllPotes()
		{
			List<Pote> result = new List<Pote>();
			IObjectSet potes = getContainer().QueryByExample(typeof(Pote));

			foreach (Object o in potes) {
				result.Add((Pote)o);
			}

			return result;
		}

		public static void test()
		{
			try {
				container = Db4oEmbedded.OpenFile(DB_PATH);
				container.Store(new Pote("KILO"));
				IObjectSet objSet = container.QueryByExample(new Pote(null));
				
				Console.Write(objSet[0].ToString());
			} catch (Exception e) {
				Console.Write(e.Message);
			}
		}
	}
}

