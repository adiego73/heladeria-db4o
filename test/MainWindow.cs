using System;
using Gtk;
using Heladeria.model;

public partial class MainWindow: Gtk.Window
{	
	private Heladeria heladeria;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		heladeria = Heladeria.build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void OnBtnBuscarClicked (object sender, System.EventArgs e)
	{
		string telefono = txt_cliente.Text;
		
		MessageDialog d = new MessageDialog (this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, telefono, "hola");
		d.Show ();
		
		heladeria.test ();
		// busco el nro de telefono
		// selecciono el cliente, y si no esta pido agregarlo
	}
}
