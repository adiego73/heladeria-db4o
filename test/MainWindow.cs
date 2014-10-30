using System;
using Gtk;
using Heladeria.model;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
	private HeladeriaAdmin heladeria;

	public MainWindow(): base (Gtk.WindowType.Toplevel)
	{
		Build();
		heladeria = HeladeriaAdmin.build();
		FillBox<Gusto>(box_gustos, heladeria.getGustos());
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

		if (c == null) {
			// creo la ventana para agregar
		}
	}

	private void FillBox<T>(VBox box, List<T> items) where T : IEntity
	{
		foreach (T o in items) {
			CheckButton check = new CheckButton(o.ToString());
			check.Show();
			check.Clicked += changeEvent;
			box.PackStart(check);
		}
	}

	public void changeEvent(object sender, System.EventArgs args)
	{
		CheckButton check = ((CheckButton)sender);
		Gusto g = heladeria.getGusto(check.Label);

		if (g == null) {
			return;
		}

		if (check.Active == true) {
			heladeria.addGustoAPedido(g);
		} else {
			heladeria.removeGustoAPedido(g);
		}
	}

	protected void OnCbxGustosChanged(object sender, System.EventArgs e)
	{
		MessageDialog d = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, ((ComboBox)sender).ActiveText, "hola");
		d.Show();
	}
}
