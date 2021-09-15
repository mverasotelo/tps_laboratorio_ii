using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar(Controls);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(Controls);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = txtNumero1.Text;
            string numero2 = txtNumero2.Text;
            string operador = cmbOperador.Text;
            double resultado = Operar(numero1, numero2, operador);
            lblResultado.Text = resultado.ToString();

            if (numero1 == "")
            {
                numero1 = "0";
            }
            if (numero2 == "")
            {
                numero2 = "0";
            }
            if (operador == " ")
            {
                operador = "+";
            }

            lstOperaciones.Items.Add($"{numero1}{operador}{numero2}= {resultado}");
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (double.TryParse(lblResultado.Text, out double aux))
            {
                    Operando resultado = new Operando(lblResultado.Text);
                    string numeroBinario = resultado.DecimalBinario(lblResultado.Text);
                if(aux >= 0)
                {
                    lstOperaciones.Items.Add($"{lblResultado.Text}D = {numeroBinario}B");
                }
                lblResultado.Text = numeroBinario;
            }
            else
            {
                MessageBox.Show("Debe ingresar un valor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (double.TryParse(lblResultado.Text, out _))
            {
                Operando resultado = new Operando(lblResultado.Text);
                string numeroDecimal = resultado.BinarioDecimal(lblResultado.Text); 
                if(int.TryParse(numeroDecimal, out _))
                {
                    lstOperaciones.Items.Add($"{lblResultado.Text}B = {numeroDecimal}D");
                }
                lblResultado.Text = numeroDecimal;
            }
            else
            {
                MessageBox.Show("Debe ingresar un valor válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Limpiar(Control.ControlCollection campos)
        {
            foreach (Control campo in campos)
            {
                if (campo is TextBox)
                {
                    ((TextBox)campo).Clear();
                }
                else if (campo is ComboBox)
                {
                    ((ComboBox)campo).SelectedIndex = 0;
                }
                else if (campo is Label)
                {
                    campo.Text = "";
                }
            }
        }

        public static double Operar(string numero1, string numero2, string operador)
        {
            Calculadora calculadora = new Calculadora();
            Operando operando1 = new Operando(numero1);
            Operando operando2 = new Operando(numero2);
            char operadorChar = char.Parse(operador);
            return calculadora.Operar(operando1, operando2, operadorChar);
        }
    }
}