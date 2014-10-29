using System;
using Gtk;
using Db4objects.Db4o;

namespace Heladeria
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Application.Init();
			MainWindow win = new MainWindow();
			win.Show();
			Application.Run();
		}
	}
}
