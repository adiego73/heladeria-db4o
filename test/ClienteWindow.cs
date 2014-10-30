using System;
using Heladeria.model;
using Gtk;

public partial class ClienteWindow : Gtk.Window
{
	private HeladeriaAdmin admin;

	public ClienteWindow(string t) :
				base(Gtk.WindowType.Toplevel)
	{
		this.Build();
		admin = HeladeriaAdmin.build();
		txt_telefono.Text = t;
	}

	protected void OnBtnGuardarClicked(object sender, System.EventArgs e)
	{
		string nombre = txt_nombre.Text;
		string telefono = txt_telefono.Text;

		Cliente c = admin.getCliente(telefono);
		if (c == null) {
			c = new Cliente(nombre, telefono);
			admin.saveCliente(c);

			this.Hide();
			this.Destroy();
		} else {
			MessageDialog d = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, true, "<b>El cliente ya existe</b>", "");
			ResponseType resp = (ResponseType)d.Run();

			if (resp == ResponseType.Ok) {
				d.Hide();
				d.Destroy();
			}
		}
	}

}

