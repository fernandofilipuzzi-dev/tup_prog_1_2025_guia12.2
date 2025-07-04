﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploSinClaseControladora
{
    public partial class Form1 : Form
    {
        #region variables y metodos del dominio
        int[] numeros = new int[1000];
        int contador = 0;

        void AgregarNumero(int nro)
        {
            numeros[contador] = nro;
            contador++;
        }

        double CalcularPromedio()
        {
            double acum = 0;
            double promedio = 0;
            for (int n = 0; n < contador; n++)
            {
                acum += numeros[n];
            }
            if (contador > 0)
                promedio = acum / contador;

            return promedio;
        }
        #endregion 

        public Form1()
        {
            InitializeComponent();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            FormDato formDato = new FormDato();

            if (formDato.ShowDialog() == DialogResult.OK)
            {
                int numero = Convert.ToInt32(formDato.textBox1.Text);

                 AgregarNumero(numero);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double promedio = CalcularPromedio();

            FormVer formVer = new FormVer();

            formVer.listBox1.Items.Add($"Promedio: {promedio:f2}");

            formVer.ShowDialog();
        }
    }
}
