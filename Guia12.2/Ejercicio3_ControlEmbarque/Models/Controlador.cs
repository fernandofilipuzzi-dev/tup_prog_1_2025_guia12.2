using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_ControlEmbarque.Models
{
    public class Controlador
    {
        int [] IDs=new int[1000];
        string[] origenes = new string[1000];
        double[] pesos = new double[1000];
        public int Contador { get; set; } = 0;

        public void AgregarContenedor(int Id, string pais, double peso) 
        {
            IDs[Contador] = Id;
            origenes[Contador] = pais;
            pesos[Contador] = peso;
            Contador++;
        }

        public void VerRegistro(int n, out int iDBusqueda, out string origenBusqueda, out double pesoBusqueda)
        {
            iDBusqueda = -1;
            origenBusqueda = "";
            pesoBusqueda = 0.0;
            if (n < ContadorBusqueda)
            {
                iDBusqueda = IDs[n];
                origenBusqueda = origenes[n];
                pesoBusqueda = pesos[n];
            }
        }

        #region relativo a la búsqueda
        int[] IDsBusqueda = new int[1000];
        string[] origenesBusqueda = new string[1000];
        double[] pesosBusqueda = new double[1000];
        public int ContadorBusqueda { get; private set; } = 0;

        public void VerRegistroFiltrado(int n, out int iDBusqueda, out string origenBusqueda, out double pesoBusqueda)
        {
            iDBusqueda = -1;
            origenBusqueda = "";
            pesoBusqueda = 0.0;
            if (n < ContadorBusqueda)
            {
                iDBusqueda = IDsBusqueda[n];
                origenBusqueda = origenesBusqueda[n];
                pesoBusqueda = pesosBusqueda[n];
            }
        }

        public void FiltrarPorOrigen(string pais)
        {
            ContadorBusqueda = 0;//importante poner a cero aquí
            for (int n = 0; n < Contador; n++)
            {
                if (pais == origenes[n])
                {
                    IDsBusqueda[ContadorBusqueda] = IDs[n];
                    origenesBusqueda[ContadorBusqueda] = origenes[n];
                    pesosBusqueda[ContadorBusqueda] = pesos[n];
                    ContadorBusqueda++;
                }
            }
        }

        #endregion
    }
}
