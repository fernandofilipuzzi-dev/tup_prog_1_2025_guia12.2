using Ejercicio2_PuntoDeControl.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio2_PuntoDeControl;
using System.Reflection;

namespace Ejercicio2_PuntoDeControl
{
    public partial class FormPrincipal : Form
    {
        Controlador controlador = new Controlador();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            #region captura de datos de la pantalla
            string patente = tbPatente.Text;
            int tipoVehículo=cbTipoVehiculo.SelectedIndex;
            int modeloVehículo = Convert.ToInt32( tbModelo.Text );
            bool esElectrico = cbkEsElectrico.Checked;
            #endregion

            //invando el registrar vehículo
            controlador.RegistrarVehículo(patente, tipoVehículo, modeloVehículo, esElectrico);

            #region limpiando controles para el próximo registro
            tbPatente.Clear();
            tbModelo.Clear();
            cbTipoVehiculo.SelectedIndex = -1;
            cbkEsElectrico.Checked = false;
            #endregion
        }

        private void btnVerEstadistica_Click(object sender, EventArgs e)
        {
            FormResultados fVer = new FormResultados();

            controlador.ListarElectricosOrdenadosPorModelo();

            fVer.lbxResultados.Items.Clear();

            if (controlador.ContadorElectricos > 0)
            {
                fVer.lbxResultados.Items.Add("Vehículos eléctricos: ");

                for (int n = 0; n < controlador.ContadorElectricos; n++)
                {
                    string patente;
                    int modelo;
                    int tipo;

                    controlador.VerVehiculoElectrico(n, out patente, out modelo, out tipo);

                    string tipoVehiculo="";
                    switch (tipo)
                    {
                        case 1: tipoVehiculo = "Auto"; break;
                        case 2: tipoVehiculo = "Motocicleta"; break;
                        case 3: tipoVehiculo = "Camioneta"; break;
                        case 4: tipoVehiculo = "Camión"; break;
                        default: tipoVehiculo = "Desconocido"; break;
                    }
                
                    fVer.lbxResultados.Items.Add($"\t{patente} - {modelo} - {tipoVehiculo}");
                }
            }
            else
            {
                fVer.lbxResultados.Items.Add($"Aún no se registraron vehículos eléctricos");
            }

            fVer.ShowDialog();
        }
    }
}
