using Biblioteca;
using System;
using System.IO;
using System.Windows.Forms;


namespace VeraSotelo.Mercedes._2D.TPFinal
{
    public partial class FrmEstadisticas : Form
    {
        private Estadisticas estadisticas;

        /// <summary>
        /// Constructor publico que inicializa el atributo estadisticas.
        /// </summary>
        public FrmEstadisticas()
        {
            InitializeComponent();
            estadisticas = new Estadisticas();
        }

        /// <summary>
        /// Se carga la informacion del establecimiento utilizando un objeto de la clase Estadisticas (información vigente)
        /// y se agrega el registro de la estadística histórica a la tabla ESTADISTICAS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            EstadisticaHistorica estadisticaHistorica = new EstadisticaHistorica(DateTime.Today, estadisticas.CantidadAnimales, estadisticas.CantidadAnimalesTambo,
                estadisticas.CantidadAnimalesEngorde, estadisticas.LecheProducidaAnual, estadisticas.CarneProducidaAnual, estadisticas.BovinoMasProductivoTambo); 

            EstadisticasDAO.Agregar(estadisticaHistorica);

            ///DISTRIBUCION POR USO
            float porcentajeTambo = estadisticas.CalcularPorcentaje(estadisticas.CantidadAnimalesTambo);
            lblPorcentajeTambo.Text = $"{porcentajeTambo:N2}%";
            pnlPorcentajeTambo.Width = (int)porcentajeTambo * 7;
            float porcentajeEngorde = estadisticas.CalcularPorcentaje(estadisticas.CantidadAnimalesEngorde);
            lblPorcentajeEngorde.Text = $"{porcentajeEngorde:N2}%";
            pnlPorcentajeEngorde.Width = (int)porcentajeEngorde * 7;

            //DATOS PRODUCCION LECHERA
            lblTotalBovinosTambo.Text += $" {estadisticas.CantidadAnimalesTambo}";
            lblTotalProduccionLeche.Text += $" {estadisticas.LecheProducidaAnual:N2} litros"; 
            lblRazaMasProductivaTambo.Text += $" {estadisticas.RazaMasProductivaTambo}";
            lblBovMasProductivoTambo.Text += $" {estadisticas.BovinoMasProductivoTambo}";

            //DATOS PRODUCCION ENGORDE
            lblTotalBovinosEngorde.Text += $" {estadisticas.CantidadAnimalesEngorde}";
            lblTotalProduccionCarne.Text += $" {estadisticas.CarneProducidaAnual:N2} kilos";
            lblRazaMasProductivaCarne.Text += $" {estadisticas.RazaMasProductivaCarne}";
            lblBovMasProdCarne.Text += $" {estadisticas.BovinoMasProductivoCarne}";
        }

        /// <summary>
        /// Al hacer click en el boton Exportar se puede guardar la info del formulario en un archivo que puede ser json, xml o txt. 
        /// El resultado del mismo (si salio todo bien o hubo alguna excepción) se muestra en un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                Filter = "Archivos de texto (.txt)|*.txt|Archivos XML (.xml)|*.xml|Archivos JSON (.json)|*.json",
                Title = "Guardar como..."
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaDocumento = saveFileDialog.FileName;

                try
                {
                    switch (Path.GetExtension(rutaDocumento))
                    {
                        case ".xml":
                            Archivos<Estadisticas>.ExportarDatosAXml(rutaDocumento, estadisticas);
                            break;
                        case ".json":
                            Archivos<Estadisticas>.ExportarDatosAJson(rutaDocumento, estadisticas);
                            break;
                        case ".txt":
                            Archivos<Estadisticas>.ExportarDatosATxt(rutaDocumento, estadisticas.ToString());
                            break;
                    }
                    MessageBox.Show($"El archivo fue guardado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Abre un formulario de estadísticas historicas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FrmEstadisticasHistoricas form = new FrmEstadisticasHistoricas();
            form.ShowDialog();
        }

        /// <summary>
        /// Se cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}