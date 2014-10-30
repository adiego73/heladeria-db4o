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
		heladeria.createPedido();
		fillBox<Gusto>(box_gustos, heladeria.getGustos());
		fillCombo<Pote>(cbx_potes, heladeria.getPotes());
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
			ClienteWindow cWin = new ClienteWindow(telefono);
			cWin.Modal = true;
			cWin.Show();
			return;
		}
		heladeria.addClienteAPedido(c);
		lbl_cliente.Text = c.ToString();
	}

	private void fillBox<T>(VBox box, List<T> items) where T : IEntity
	{
		foreach (T o in items) {
			CheckButton check = new CheckButton(o.ToString());
			check.Show();
			check.Clicked += changeEventGusto;
			box.PackStart(check);
		}
	}

	private void fillCombo<T>(ComboBox cb, List<T> items) where T : IEntity
	{
		cb.Clear();
		CellRendererText cell = new CellRendererText();
		cb.PackStart(cell, false);
		cb.AddAttribute(cell, "text", 0);
		ListStore store = new ListStore(typeof(string));
		cb.Model = store;

		foreach (T o in items) {
			store.AppendValues(o.ToString());
		}
	}

	public void changeEventGusto(object sender, System.EventArgs args)
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

	protected void OnBtnGuardarClicked(object sender, System.EventArgs e)
	{
		Console.WriteLine(heladeria.getPedido().ToString());
	}
}
