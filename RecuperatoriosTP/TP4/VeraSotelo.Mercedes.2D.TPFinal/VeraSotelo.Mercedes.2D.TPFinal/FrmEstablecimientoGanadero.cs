using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeraSotelo.Mercedes._2D.TPFinal
{
    public partial class FrmEstablecimientoGanadero : Form
    {
        private Random random;

        public FrmEstablecimientoGanadero()
        {
            InitializeComponent();
            random = new Random();
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEstablecimientoGanadero_Load(object sender, EventArgs e)
        {
            btnEstadisticas.Enabled = false;
            Task task = new Task(() => CalcularEstadisticas(pbEstadisticas, lblCalculando));
            task.Start();
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
        /// Simula el calculo de estadísticas, Una vez finalizada hace visible el boton "Información del establecimiento"
        /// Utiliza un hilo secundario para no bloquear el programa mientras se calculan las estadísticas.
        /// </summary>
        private void CalcularEstadisticas(ProgressBar progressBar, Label label)
        {
            while (progressBar.Value < progressBar.Maximum)
            {
                Thread.Sleep(random.Next(50, 250));
                IncrementarBarraProgreso(progressBar, label);
            }
        }

        /// <summary>
        /// Incrementa la barra de progreso, utilizando el invoke required
        /// </summary>
        private void IncrementarBarraProgreso(ProgressBar progressBar, Label label)
        {
            if (InvokeRequired)
            {
                Action<ProgressBar, Label> delegado = IncrementarBarraProgreso;
                Object[] parametros = new Object[] { progressBar, label}; 
                Invoke(delegado, parametros);
            }
            else
            {
                progressBar.Increment(5);
                lblCalculando.Text = $"Calculando estadísticas... {progressBar.Value}%";
                if (progressBar.Value == 100)
                {
                    lblCalculando.Text = "Cálculo completado";
                    btnEstadisticas.Enabled = true;
                }
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