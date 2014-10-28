using System;
using System.Collections.Generic;

namespace test
{
	public class Heladeria
	{
		private static Heladeria admin = null;
		private List<Gusto> gustos;
		private List<Pote> potes;
		
		public static Heladeria build ()
		{
			if (admin != null) {
				return admin;
			}
			
			admin = new Heladeria ();
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

