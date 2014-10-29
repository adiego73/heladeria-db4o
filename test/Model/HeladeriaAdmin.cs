using System;
using System.Collections.Generic;
using Heladeria.db;

namespace Heladeria.model
{
	public class HeladeriaAdmin
	{
		private static HeladeriaAdmin admin = null;
		private List<Gusto> gustos;
		private List<Pote> potes;
		
		public static HeladeriaAdmin build ()
		{
			if (admin != null) {
				return admin;
			}
			
			admin = new HeladeriaAdmin ();
			admin.getGustos ().Add (new Gusto ("vainilla"));
			admin.getGustos ().Add (new Gusto ("chocolate"));
			admin.getGustos ().Add (new Gusto ("frutilla"));
			admin.getGustos ().Add (new Gusto ("sambayon"));
			admin.getGustos ().Add (new Gusto ("limon"));
			
			admin.getPotes ().Add (new Pote ("CUARTO_KILO"));
			admin.getPotes ().Add (new Pote ("MEDIO_KILO"));
			admin.getPotes ().Add (new Pote ("KILO"));
			
			return admin;
		}
		
		public List<Gusto> getGustos ()
		{
			if (gustos == null) {
				gustos = new List<Gusto> ();
			}
			return gustos;
		}
		
		public List<Pote> getPotes ()
		{
			if (potes == null) {
				potes = new List<Pote> ();
			}
			return potes;
		}
		
		public void test ()
		{
			DB.test ();
		}
	}
}

