using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4_Torneo.Models
{
    public class Controlador
    {
        string[] nombres = new string[1000];

        //fila : es el numero de jugador ; columna el número de partido
        int[,] puntos = new int[1000,100];

        int contadorJugadores = 0;
        int contadorPartidos = 0;

        public int VerContadorJugadores()
        {
            return contadorJugadores;
        }

        public int VerContadorPartidos()
        {
            return contadorPartidos;
        }

        public string VerNombreJugador(int idx)
        {
            return nombres[idx];
        }

        public void InscribirJugador(string nombre)
        {
            nombres[contadorJugadores] = nombre;
            contadorJugadores++;
        }

        public void AnotarResultadosPartido(int numeroJugador, int resultado)
        {
            puntos[numeroJugador, contadorPartidos] =resultado;
        }

        public void FinalizarPartido()
        {
            contadorPartidos++;
        }

        public int[] ListarPuntosPorJugador(int numeroJugador)
        {
            int[] puntos = new int[contadorPartidos];
            for (int partido = 0; partido < contadorPartidos; partido++)
            {
                puntos[partido] = this.puntos[numeroJugador, partido];//fila : es el numero de jugador ; columna el número de partido
            }
            return puntos;
        }

        public int[] ListarPuntosPorPartido(int numeroPartido)
        {
            int[] puntos = new int[contadorJugadores];
            for (int jugador = 0; jugador < contadorJugadores; jugador++)
            {
                puntos[jugador] = this.puntos[jugador, numeroPartido];//fila : es el numero de jugador ; columna el número de partido
            }
            return puntos;
        }
    }
}
