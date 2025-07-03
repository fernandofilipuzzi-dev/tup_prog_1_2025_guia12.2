using Ejercicio6_Factura.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio6_Factura
{
    public partial class FormPrincipal : Form
    {
        Servicio servicio = new Servicio();
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            FormFactura formFactura = new FormFactura();
            double total=0;
            while (formFactura.ShowDialog()==DialogResult.Retry)
            {
                int codigo = Convert.ToInt32(formFactura.tbCodigo.Text);
                int cantidad = Convert.ToInt32(formFactura.tbCantidad.Text);

                int idx = servicio.BuscarProducto(codigo);
                if (idx == -1)
                {
                    MessageBox.Show("no encontrado");
                }
                else 
                {
                    servicio.VerFactura(idx, out int codigoProducto, out double precio);

                    formFactura.lbPrecioUd.Text = precio.ToString("0.00");

                    double precioTotalItems = precio * cantidad;
                    
                    listBox1.Items.Add($"{codigo} {cantidad} {precio} {precioTotalItems}");

                    total += precioTotalItems;
                }
            }

            if (formFactura.DialogResult == DialogResult.OK)
            {
                listBox1.Items.Add($"Total a pagar: ${total}");

                servicio.RecaudacionTotal += total;
            }
            else
                listBox1.Items.Clear();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            servicio.AgregarProducto(234, 20.2);
            servicio.AgregarProducto(236, 23.2);
            servicio.AgregarProducto(237, 10.2);
        }

        private void btnRecaudacion_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Recaudación total: ${servicio.RecaudacionTotal:f2}");
        }
    }
}
