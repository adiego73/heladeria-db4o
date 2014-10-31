using System;
using System.IO;

namespace Heladeria.model
{
	public class Solicitud
	{
		private Pedido pedido;
		private float montoPagar;

		public void setPedido(Pedido p)
		{
			this.pedido = p;
		}

		public void setMonto(float monto)
		{
			this.montoPagar = monto;
		}

		public void printToFile()
		{
			DateTime now = DateTime.UtcNow;
			Random rnd = new Random();

			float vuelto = montoPagar - pedido.getPote().getValor();
			string print = "";
			print += " ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n";
			print += "\t\t\t\t\t HELADERIA DB4O \n";
			print += " ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\n";
			print += "\t\t NOMBRE: " + pedido.getCliente().getNombre() + "\n";
			print += "\t\t TELEFONO: " + pedido.getCliente().getTelefono() + "\n";
			print += "\n ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n";
			print += "\t\t\t PEDIDO: " + pedido.getPote().ToString() + "\n \n";
			print += "------------------------- \t GUSTOS \t ----------------------------\n";
			foreach (Gusto g in pedido.getGustos()) {
				print += "\t\t\t > " + g.ToString() + "\n";
			}
			print += "\n  ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n";
			print += "\t\t Observaciones: " + pedido.getObservaciones() + " \n";
			print += "\n  ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n\n";
			print += "\t\t TOTAL: " + pedido.getPote().getValor() + " \n\n";
			print += "\t\t Paga con: " + montoPagar + " \t Vuelto: " + vuelto + "\n\n";
			print += " ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++\n";
			print += "\t\t\t\t\t\t\t" + now.ToString();
			//Console.Write(print);
			System.IO.File.WriteAllText("solicitud" + now.ToString().Replace("/", "-") + rnd.Next() + ".txt", print);
		}
	}
}

