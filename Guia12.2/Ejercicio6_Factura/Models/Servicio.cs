using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio6_Factura.Models
{
    public class Servicio
    {
        int[] productos = new int[1000];
        double[] preciosUd = new double[1000];
        int contador=0;

        public double RecaudacionTotal = 0;

        public void AgregarProducto(int codigo, double ud)
        {
            productos[contador] = codigo;
            preciosUd[contador] = ud;
            contador++;
        }

        public int BuscarProducto(int codigo)
        {
            int idx = -1;
            int n = 0;
            while (idx == -1 && n < contador)
            {
                if (productos[n] == codigo)
                    idx = n;
                n++;
            }
            return idx;
        }

        public void VerFactura(int idx, out int codigoProducto, out double precio)
        {
            codigoProducto = productos[idx];
            precio = preciosUd[idx];
        }
    }
}
