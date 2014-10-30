using System;
using Gtk;
using Heladeria.model;
using System.Collections.Generic;
using System.Globalization;

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

		if (heladeria.getPedido().getCliente() == null) {
			showError("Debe ingresar un cliente");
			return;
		}
		if (heladeria.getPedido().getPote() == null) {
			showError("Debe ingresar un pote");
			return;
		}
		if (heladeria.getPedido().getGustos().Count <= 0) {
			showError("Debe ingresar al menos un gusto");
			return;
		}

		float monto = 0;
		try {
			if (txt_monto.Text != null && txt_monto.Text != "") {
				monto = float.Parse(txt_monto.Text, CultureInfo.InvariantCulture.NumberFormat);
			}
		} catch (FormatException ex) {

		}

		if (monto >= heladeria.getPedido().getPote().getValor()) {
			heladeria.addObsAPedido(txt_observaciones.Buffer.Text);
			heladeria.savePedido();
			heladeria.clearPedido();
			limpiarForm();
		} else {
			showError("Debe pagar el total como minimo");
		}
	}

	protected void OnCbxPotesChanged(object sender, System.EventArgs e)
	{
		lbl_total.UseMarkup = true;
		ComboBox box = (ComboBox)sender;
		string poteDesc = box.ActiveText;
		Pote p = heladeria.getPote(poteDesc);

		if (p == null) {
			return;
		}

		heladeria.addPoteAPedido(p);
		lbl_total.Markup = "<span size=\"xx-large\"><b>" + p.getValor() + "</b></span>";
	}

	protected void OnTxtMontoChanged(object sender, System.EventArgs e)
	{
		if (txt_monto.Text == "" || txt_monto.Text == null) {
			return;
		}

		lbl_vuelto.UseMarkup = true;
		if (heladeria.getPedido() != null && heladeria.getPedido().getPote() != null) {
			float valor = heladeria.getPedido().getPote().getValor();

			try {
				float monto = float.Parse(txt_monto.Text, CultureInfo.InvariantCulture.NumberFormat);
				float vuelto = monto - valor;
				heladeria.addPagaConAPedido(monto);
				lbl_vuelto.Markup = "<span size=\"xx-large\"><b>" + vuelto + "</b></span>";
			} catch (FormatException ex) {
				showError("Debe ingresar un numero");
			}
		} else {
			lbl_vuelto.Markup = "<span size=\"xx-large\"><b>0</b></span>";
		}
	}

	private void showError(string message)
	{
		MessageDialog d = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, true, message, "");
		ResponseType resp = (ResponseType)d.Run();

		if (resp == ResponseType.Ok) {
			d.Hide();
			d.Destroy();
		}
	}

	protected void OnTxtClienteTextInserted(object o, Gtk.TextInsertedArgs args)
	{
		try {
			int pos = ((Entry)o).Position;
			string c = ((Entry)o).GetChars(pos, pos + 1);
			char d;
			Char.TryParse(c[0].ToString(), out d);
			if (!(d >= '0' && d <= '9')) {
				((Entry)o).SelectRegion(pos, pos + 1);
				((Entry)o).DeleteSelection();
			}
		} catch (System.IndexOutOfRangeException e) {
		}
	}

	private void limpiarForm()
	{
		txt_cliente.Text = "";
		lbl_cliente.Text = "";
		lbl_total.UseMarkup = true;
		lbl_total.Markup = "<span size=\"xx-large\"><b>0</b></span>";
		lbl_vuelto.UseMarkup = true;
		lbl_vuelto.Markup = "<span size=\"xx-large\"><b>0</b></span>";
		txt_observaciones.Buffer.Text = "";
		foreach (CheckButton check in box_gustos.Children) {
			check.Active = false;
		}
	}

	protected void OnBtnImprimirClicked(object sender, System.EventArgs e)
	{
		Pedido p = heladeria.getLastPedido();
		if (p != null) {
			Solicitud s = new Solicitud();
			s.setPedido(p);
			s.setMonto(p.getPagaCon());

			s.printToFile();
		}
	}
}
