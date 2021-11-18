using Biblioteca;
using System;
using System.Linq;
using System.Windows.Forms;

namespace VeraSotelo.Mercedes._2D.TPFinal
{
    public partial class FrmEstadisticasHistoricas : Form
    {
        public FrmEstadisticasHistoricas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Muestra el listado de estadisticas hitóricas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEstadisticasHistoricas_Load(object sender, EventArgs e)
        {
            dgvEstadisticasHistoricas.DataSource = EstadisticasDAO.ListarEstadisticas().Select(e => new
            { Fecha = e.Fecha, StockTotal = e.CantidadAnimales, StockEngorde = e.CantidadAnimalesEngorde, ProduccionCarneAnual = e.CarneProducidaAnual, 
                StockTambo = e.CantidadAnimalesTambo, ProduccionLecheAnual = e.LecheProducidaAnual, BovinoMasProductivoTambo = e.BovinoMasProductivoTambo, 
                RazaBovinoMasProductivoTambo = e.RazaBovinoMasProductivoTambo }).ToList();
        }

        /// <summary>
        /// Cierra el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
