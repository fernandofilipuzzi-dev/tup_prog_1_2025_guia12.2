using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_Rally.Models
{
    public class Competencia
    {
        string[] nombres = new string[100];
        int [] tiempos= new int[100];
        public int Contador { get; private set; }

        public Competencia()
        {
            Contador = 0;
        }

        public void VerRegistro(int idx,out string nombre,out int tiempo)
        {
            tiempo = 0;
            nombre = "";
            if (idx >= 0 && idx < Contador)
            {
                nombre = nombres[idx];
                tiempo = tiempos[idx];
            }
        }

        public void AgregarCompetidor(string nombre)
        {
            nombres[Contador] = nombre;
            Contador++;
        }

        public void CargarTiempo(int numeroCompetidor, int HH, int MM)
        {
            tiempos[numeroCompetidor] = HH*60+MM;
        }

        public void OrderListadoPorTiempo()
        {
            for (int act = 0; act < Contador-1; act++)
            {
                for (int sig = act+1; sig < Contador; sig++)
                {
                    if (tiempos[act] > tiempos[sig])
                    {
                        Intercambiar(act, sig);
                    }
                }
            }
        }

        void Intercambiar(int act, int sig)
        {
            string nombre = nombres[act];
            nombres[act] = nombres[sig];
            nombres[sig] = nombre;

            int tiempo = tiempos[act];
            tiempos[act] = tiempos[sig];
            tiempos[sig] = tiempo;
        }
    }
}
