using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2_PuntoDeControl.Models
{
    public class Controlador
    {
        string[] Patentes=new string[1000];
        int [] TiposVehiculo = new int[1000];
        int [] Modelos = new int[1000];
        bool[] SonElectricos = new bool[1000];
        public int Contador { get; set; }

        public Controlador()
        {
            Contador = 0;
        }

        public void RegistrarVehículo(string patente, int tipo, int modelo, bool esElectrico)
        {
            Patentes[Contador] = patente;
            TiposVehiculo[Contador] = tipo;
            Modelos[Contador] = modelo;
            SonElectricos[Contador] = esElectrico;           
            Contador++;
        }

        string[] patentesElectricos = new string[1000];
        int[] modelosElectricos = new int[1000];
        int[] tiposVehículoElectricos = new int[1000];
        public int ContadorElectricos { get; private set; } = 0;

        public void VerVehiculoElectrico(int n, out string patente, out int modelo, out int tipo)
        {
            patente = patentesElectricos[n];
            modelo = modelosElectricos[n];
            tipo = tiposVehículoElectricos[n];
        }

        public void ListarElectricosOrdenadosPorModelo() 
        {
            ContadorElectricos = 0;//es importante poner en cero aquí

            for (int n = 0; n < Contador; n++) 
            {
                if (SonElectricos[n] == true)
                {
                    patentesElectricos[ContadorElectricos] = Patentes[n];
                    modelosElectricos[ContadorElectricos] = Modelos[n];
                    tiposVehículoElectricos[ContadorElectricos] = TiposVehiculo[n];
                    ContadorElectricos++;//no olvidarse este detallito
                }
            }

            OrdenarElectricos();
        }

        public void OrdenarElectricos()
        {
            for (int n = 0; n < ContadorElectricos - 1; n++)
            {
                for (int m = n + 1; m < ContadorElectricos; m++)
                {
                    if (modelosElectricos[n] > modelosElectricos[m])
                    {
                        IntercambiarElectricos(n, m);
                    }
                }
            }
        }

        void IntercambiarElectricos(int n,int m)
        {
            string patente = patentesElectricos[m];
            patentesElectricos[m] = patentesElectricos[n];
            patentesElectricos[n] = patente;

            int modelo = modelosElectricos[m];
            modelosElectricos[m] = modelosElectricos[n];
            modelosElectricos[n] = modelo;

            int tipo = tiposVehículoElectricos[m];
            tiposVehículoElectricos[m] = tiposVehículoElectricos[n];
            tiposVehículoElectricos[n] = tipo;
        }
    }
}
