using System;
using Gtk;
using Heladeria.model;

public partial class MainWindow: Gtk.Window
{	
	private HeladeriaAdmin heladeria;

	public MainWindow(): base (Gtk.WindowType.Toplevel)
	{
		Build();
		heladeria = HeladeriaAdmin.build();
	}
	
	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		heladeria.destroy();
		a.RetVal = true;
	}

	protected void OnBtnBuscarClicked(object sender, System.EventArgs e)
	{
		string telefono = txt_cliente.Text;
		Cliente c = heladeria.getCliente(telefono);

		MessageDialog d = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, c.getNombre() + " " + c.getTelefono(), "hola");
		d.Show();
		

		// busco el nro de telefono
		// selecciono el cliente, y si no esta pido agregarlo
	}
}
