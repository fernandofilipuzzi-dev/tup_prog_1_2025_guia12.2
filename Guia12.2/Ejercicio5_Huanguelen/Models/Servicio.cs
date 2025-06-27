using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio5_Huanguelen.Models
{
    public class Servicio
    {
        #region representa una serie de embarques de ganado
        int[] numerosGuia = new int[1000];
        int[] numerosEstablecimiento = new int[1000];
        int[] cantidadesVacas = new int[1000];
        int[] cantidadesToros = new int[1000];
        int[] cantidadesNovillo = new int[1000];
        int[] cantidadesVaquillona = new int[1000];
        #endregion

        int contadorEmbarques = 0;

        public void RegistrarGuia(int nroGuia, int nroEstablecimiento, int vacas, int toros, int novillos, int vaquillonas)
        {
            numerosGuia[contadorEmbarques] = nroGuia;
            numerosEstablecimiento[contadorEmbarques] = nroEstablecimiento;
            cantidadesVacas[contadorEmbarques] = vacas;
            cantidadesToros[contadorEmbarques] = toros;
            cantidadesNovillo[contadorEmbarques] = novillos;
            cantidadesVaquillona[contadorEmbarques] = vaquillonas;

            contadorEmbarques++;
        }

        public int BuscarPorNumeroGuia(int guia)
        {
            int idx = -1;
            int emb = 0;//recorro embarques
            while (emb < contadorEmbarques)
            {
                if (numerosGuia[emb] == guia)
                {
                    idx = emb;
                }

                emb++;
            }
            return idx;
        }

        public int[] BuscarPorNumeroEstablecimiento(int establecimiento, ref int coincidencias)
        {
            int[] idxs = new int[1000];
            coincidencias = 0;
            
            int establIdx = 0;
            while (establIdx < contadorEmbarques)
            {
                if (numerosEstablecimiento[establIdx] == establecimiento)
                {
                    
                    idxs[coincidencias] = establIdx;
                    coincidencias++;
                }

                establIdx++;
            }
           
            return idxs;
        }

        public int VerContadorEmbarques()
        {
            return contadorEmbarques;
        }

        internal void VerEmbarque(int idx, out int guia, out int establecimiento, out int vacas, out int toros, out int novillos, out int vaquillonas)
        {

            guia = -1;
            establecimiento = 0;
            vacas = 0;
            toros = 0;
            novillos = 0;
            vaquillonas = 0;
            if (idx >= 0 && idx < contadorEmbarques)
            {
                guia = numerosGuia[idx];
                establecimiento=numerosEstablecimiento[idx];
                vacas = cantidadesVacas[idx];
                toros = cantidadesToros[idx];
                novillos = cantidadesNovillo[idx];
                vaquillonas=cantidadesVaquillona[idx];
            }
        }
    }
}
