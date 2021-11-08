using Biblioteca;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace VeraSotelo.Mercedes._2D.TPFinal
{
    public partial class FrmABMAnimal : Form
    {
        //atributo
        private Bovino bovino;

        public FrmABMAnimal(Bovino bovino)
        {
            InitializeComponent();
            this.bovino = bovino;
        }

        /// <summary>
        /// Setea opciones del formulario.
        /// Si es un alta, no carga nada en los campos
        /// Si es una modificacion, carga los datos del bovino seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmABMAnimal_Load(object sender, EventArgs e)
        {
            //selecciono algun boton para que no hay opciones vacias
            SetearOpciones();

            if (bovino is null)
            {
                Text = "Agregar animal";
            }
            else
            {
                Text = "Modificar animal";
                SetearInfoAnimalAModificar();
            }
        }

        /// <summary>
        /// Propiedad solo lectura del atributo bovino
        /// </summary>
        public Bovino Bovino
        {
            get
            {
                return bovino;
            }
        }

        /// <summary>
        /// Guarda los datos ingresados, creando un bovino que se asigna al atributo bovino.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtId.Text))
            {
                Bovino.ESexo sexo;
                Bovino.ERaza raza = (Bovino.ERaza)cmbRaza.SelectedItem;
                Bovino.EUso uso = (Bovino.EUso)cmbUso.SelectedItem;

                foreach (Control c in gpbSexo.Controls)
                {
                    if (c is RadioButton && ((RadioButton)c).Checked)
                    {
                        if (c.Text == "Hembra")
                        {
                            sexo = Bovino.ESexo.Hembra;
                        }
                        else
                        {
                            sexo = Bovino.ESexo.Macho;
                        }

                        bovino = new Bovino(DateTime.Today, txtId.Text, sexo, raza, uso);
                    }
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No puede ingresarse un dato vacío", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Sale del formulario sin aplicar cambios al archivo Json. Antes pide confirmacion, avisando que los datos no se guardaran.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Los datos no se guardarán. Esta seguro de que desea cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        /// <summary>
        /// Pone por defecto los valores de los campos del bovino a modificar.
        /// </summary>
        private void SetearInfoAnimalAModificar()
        {
            txtId.Text = bovino.Identificacion;
            txtId.Enabled = false;
            if (bovino.Sexo == Bovino.ESexo.Macho)
            {
                rbtMacho.Checked = true;
            }
            else
            {
                rbtHembra.Checked = true;
            }
            cmbUso.SelectedItem = bovino.Uso;
            cmbRaza.SelectedItem = bovino.Raza;
        }

        /// <summary>
        /// Setea las opciones de los combobox uso y raza
        /// </summary>
        private void SetearOpciones()
        {
            cmbUso.DataSource = new List<Bovino.EUso> { Bovino.EUso.Engorde, Biblioteca.Bovino.EUso.Tambo };
            cmbRaza.DataSource = new List<Bovino.ERaza> { Bovino.ERaza.Angus, Biblioteca.Bovino.ERaza.Hereford, Biblioteca.Bovino.ERaza.Holstein };
            rbtMacho.Checked = true;
        }

        /// <summary>
        /// Deshabilita la opcion de sexo Macho cuando se selecciona el uso tambo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbUso_SelectedValueChanged(object sender, EventArgs e)
        {
            if ((Bovino.EUso)cmbUso.SelectedItem == Bovino.EUso.Tambo)
            {
                rbtHembra.Checked = true;
                rbtMacho.Enabled = false;
            }
            else
            {
                rbtMacho.Enabled = true;
            }
        }
    }
}