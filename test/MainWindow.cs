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
		string mensaje = "";
		foreach (Gusto g in heladeria.getGustos()) {
			mensaje += g.getDescripcion() + " ";
		}
		
		MessageDialog d = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, mensaje, "hola");
		d.Show();
		

		// busco el nro de telefono
		// selecciono el cliente, y si no esta pido agregarlo
	}
}
