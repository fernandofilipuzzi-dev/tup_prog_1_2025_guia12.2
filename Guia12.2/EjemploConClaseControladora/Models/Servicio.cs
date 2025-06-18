using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploConClaseControladora.Models
{
    public class Servicio
    {
        public int[] numeros = new int[1000];
        public int Contador { get; private set; }

        public void AgregarNumero(int nro)
        {
            numeros[Contador] = nro;
            Contador++;
        }

        public int VerRegistro(int n)
        {
            if (n>=0 && n < Contador)
                return numeros[n];
            else
                return -1;
        }

        public double CalcularPromedio()
        {
            double acum = 0;
            double promedio = 0;
            for (int n = 0; n < Contador; n++)
            {
                acum += numeros[n];
            }
            if (Contador > 0)
                promedio = acum / Contador;

            return promedio;
        }
    }
}
