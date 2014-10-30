using System;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Db4objects.Db4o.Query;
using Heladeria.model;
using Heladeria.db.query;
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
				container.Dispose();
				container = null;
			}
		}

		private static IObjectContainer getContainer()
		{
			if (container == null) {
				container = Db4oEmbedded.OpenFile(DB_PATH);
			}
			return container;
		}

		public static IList<T> getAll<T>() where T : class
		{
			return getContainer().Query<T>(typeof(T));
		}

		public static IList<T> get<T>(IHQuery<T> query) where T : class
		{
			IList<T> lista = new List<T>();
			IObjectSet oSet = getContainer().QueryByExample(query.build());
			foreach (T o in oSet) {
				lista.Add((T)o);
			}
			return lista;
		}

		public static T getOne<T>(IHQuery<T> query) where T : class
		{
			IObjectSet oSet = getContainer().QueryByExample(query.build());
			if (oSet.Count > 0) {
				return ((T)oSet[0]);
			}
			return null;
		}
		
		public static void save<T>(T o)
		{
			getContainer().Store(o);
		}

		public static void remove<T>(T o)
		{
			getContainer().Delete(o);
		}
	}
}

