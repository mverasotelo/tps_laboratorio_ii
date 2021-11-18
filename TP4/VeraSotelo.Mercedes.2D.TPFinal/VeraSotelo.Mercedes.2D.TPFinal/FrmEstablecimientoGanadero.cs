using System;
using System.Windows.Forms;

namespace VeraSotelo.Mercedes._2D.TPFinal
{
    public partial class FrmEstablecimientoGanadero : Form
    {

        public FrmEstablecimientoGanadero()
        {
            InitializeComponent();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEstablecimientoGanadero_Load(object sender, EventArgs e)
        {
        }
        
        /// <summary>
        /// Abre la seccion Stock Ganadero
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockGanadero_Click(object sender, EventArgs e)
        {
            FrmStockGanadero form = new FrmStockGanadero();
            form.ShowDialog();
        }

        /// <summary>
        /// Abre la seccion Información Productiva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticas form = new FrmEstadisticas();
            form.ShowDialog();
        }

        /// <summary>
        /// Al cerrar el formulario, se pide confirmacion al usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEstablecimientoGanadero_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}