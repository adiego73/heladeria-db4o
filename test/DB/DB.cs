using System;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using Db4objects.Db4o.Query;

namespace test
{
	public class DB
	{
		readonly static string DB_PATH = "db.yap";
		private static IObjectContainer container = null;
		
		private static void close ()
		{
			if (container != null) {
				container.Close ();
			}
		}
		
		public static void test ()
		{
			try {
				container = Db4oEmbedded.OpenFile (DB_PATH);
				container.Store (new Pote ("KILO"));
				IObjectSet objSet = container.QueryByExample (new Pote (null));
				
				Console.Write (objSet [0].ToString ());
			} catch (Exception e) {
				Console.Write (e.Message);
			}
		}
	}
}

