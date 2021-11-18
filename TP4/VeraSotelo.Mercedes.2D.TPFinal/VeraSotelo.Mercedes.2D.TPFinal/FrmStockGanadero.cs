using Biblioteca;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace VeraSotelo.Mercedes._2D.TPFinal
{
    public partial class FrmStockGanadero : Form
    {

        public FrmStockGanadero()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento Load del formulario. Se asigna la ruta al archivo Json del stock y se cargan esos datos en la lista de stock, actualizando el datagridview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStockGanadero_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
        }

        /// <summary>
        /// Agrega un  animal a la lista de stock y actualiza el datagridview.
        /// Si el animal con la identificacion seleccionada ya existia muestra un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmABMAnimal form = new FrmABMAnimal(null);
            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                try
                {
                    Establecimiento.AgregarAnimal(form.Bovino);
                    ActualizarDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Modifica el animal seleccionado de la lista de stock y actualiza el datagridview.
        /// Si no hay animal seleccionado muestra un MessageBox.
        /// Si el animal con la nueva identificacion ingresada ya existia muestra un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Establecimiento.StockGanadero.Count > 0 && dataStock.SelectedRows.Count > 0)
            {
                Bovino bovinoSeleccionado = GetBovinoSeleccionado();
                FrmABMAnimal form = new FrmABMAnimal(bovinoSeleccionado);
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dataStock.SelectedRows)
                    {
                        try
                        {
                            Establecimiento.ModificarAnimal(form.Bovino);
                            ActualizarDataGridView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar una fila para modificar");
            }
        }

        /// <summary>
        /// Pide confirmacion al usuario, y si el usuario confirma, elimina un animal de la lista de stock y actualiza el datagridview.
        /// Si no hay animal seleccionado muestra un MessageBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialog =  MessageBox.Show($"Seguro desea eliminar el bovino {GetBovinoSeleccionado().Identificacion}?", "Confirmación", MessageBoxButtons.YesNo);
            if(dialog == DialogResult.Yes)
            {
                if (Establecimiento.StockGanadero.Count > 0 && dataStock.SelectedRows.Count > 0)
                {
                    Establecimiento.EliminarAnimal(GetBovinoSeleccionado());
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("Se debe seleccionar una fila para eliminar");
                }
            }
        }

        /// <summary>
        /// Guarda la lista de animales en un archivo seleccionado por el usuario que puede ser de formato texto, xml o json.
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
                            Archivos<List<Bovino>>.ExportarDatosAXml(rutaDocumento, Establecimiento.StockGanadero);
                            break;
                        case ".json":
                            Archivos<List<Bovino>>.ExportarDatosAJson(rutaDocumento, Establecimiento.StockGanadero);
                            break;
                        case ".txt":
                            Archivos<List<Bovino>>.ExportarDatosATxt(rutaDocumento, Establecimiento.ImprimirStockGanadero());
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
        /// Sale del formulario.
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Actualiza el datagridview con lo cargado en la lista StockGanadero 
        /// y deselecciona la fila seleccionada por default.
        /// </summary>
        private void ActualizarDataGridView()
        {
            dgvStock.Update();
            dgvStock.Refresh();
            dgvStock.DataSource = Establecimiento.StockGanadero;
            if (dgvStock.Rows.Count > 0)
            {
                dgvStock.Rows[0].Selected = false;
            }
        }

        /// <summary>
        /// Chequea el animal seleccionado en el datagridview.
        /// </summary>
        /// <returns>Animal seleccionado</returns>
        private Bovino GetBovinoSeleccionado()
        {
            Bovino animal = null;

            foreach (DataGridViewRow row in dataStock.SelectedRows)
            {
                int index = row.Index;
                animal = Establecimiento.StockGanadero[index];
            }
            return animal;
        }
    }
}
