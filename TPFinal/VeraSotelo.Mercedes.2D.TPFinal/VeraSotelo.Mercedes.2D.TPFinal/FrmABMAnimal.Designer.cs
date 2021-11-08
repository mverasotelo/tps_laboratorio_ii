
namespace VeraSotelo.Mercedes._2D.TPFinal
{
    partial class FrmABMAnimal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.cmbUso = new System.Windows.Forms.ComboBox();
            this.lblUso = new System.Windows.Forms.Label();
            this.rbtMacho = new System.Windows.Forms.RadioButton();
            this.rbtHembra = new System.Windows.Forms.RadioButton();
            this.gpbSexo = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblRaza = new System.Windows.Forms.Label();
            this.cmbRaza = new System.Windows.Forms.ComboBox();
            this.gpbSexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.Salmon;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(332, 419);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(126, 46);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtId.Location = new System.Drawing.Point(21, 69);
            this.txtId.MaxLength = 10;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(431, 27);
            this.txtId.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblId.Location = new System.Drawing.Point(24, 43);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(136, 23);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "IDENTIFICACION";
            // 
            // cmbUso
            // 
            this.cmbUso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbUso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUso.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbUso.FormattingEnabled = true;
            this.cmbUso.Location = new System.Drawing.Point(27, 334);
            this.cmbUso.Name = "cmbUso";
            this.cmbUso.Size = new System.Drawing.Size(431, 31);
            this.cmbUso.TabIndex = 6;
            this.cmbUso.UseWaitCursor = true;
            this.cmbUso.SelectedValueChanged += new System.EventHandler(this.cmbUso_SelectedValueChanged);
            // 
            // lblUso
            // 
            this.lblUso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUso.AutoSize = true;
            this.lblUso.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUso.Location = new System.Drawing.Point(27, 308);
            this.lblUso.Name = "lblUso";
            this.lblUso.Size = new System.Drawing.Size(43, 23);
            this.lblUso.TabIndex = 5;
            this.lblUso.Text = "USO";
            // 
            // rbtMacho
            // 
            this.rbtMacho.AutoSize = true;
            this.rbtMacho.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtMacho.Location = new System.Drawing.Point(14, 27);
            this.rbtMacho.Name = "rbtMacho";
            this.rbtMacho.Size = new System.Drawing.Size(84, 27);
            this.rbtMacho.TabIndex = 9;
            this.rbtMacho.TabStop = true;
            this.rbtMacho.Text = "Macho";
            this.rbtMacho.UseVisualStyleBackColor = true;
            // 
            // rbtHembra
            // 
            this.rbtHembra.AutoSize = true;
            this.rbtHembra.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rbtHembra.Location = new System.Drawing.Point(14, 61);
            this.rbtHembra.Name = "rbtHembra";
            this.rbtHembra.Size = new System.Drawing.Size(95, 27);
            this.rbtHembra.TabIndex = 10;
            this.rbtHembra.TabStop = true;
            this.rbtHembra.Text = "Hembra";
            this.rbtHembra.UseVisualStyleBackColor = true;
            // 
            // gpbSexo
            // 
            this.gpbSexo.Controls.Add(this.rbtHembra);
            this.gpbSexo.Controls.Add(this.rbtMacho);
            this.gpbSexo.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gpbSexo.Location = new System.Drawing.Point(24, 122);
            this.gpbSexo.Name = "gpbSexo";
            this.gpbSexo.Size = new System.Drawing.Size(431, 94);
            this.gpbSexo.TabIndex = 11;
            this.gpbSexo.TabStop = false;
            this.gpbSexo.Text = "SEXO";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.Salmon;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.Location = new System.Drawing.Point(24, 419);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(126, 46);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblRaza
            // 
            this.lblRaza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRaza.AutoSize = true;
            this.lblRaza.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRaza.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRaza.Location = new System.Drawing.Point(27, 231);
            this.lblRaza.Name = "lblRaza";
            this.lblRaza.Size = new System.Drawing.Size(52, 23);
            this.lblRaza.TabIndex = 7;
            this.lblRaza.Text = "RAZA";
            // 
            // cmbRaza
            // 
            this.cmbRaza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRaza.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRaza.FormattingEnabled = true;
            this.cmbRaza.Location = new System.Drawing.Point(24, 257);
            this.cmbRaza.Name = "cmbRaza";
            this.cmbRaza.Size = new System.Drawing.Size(431, 31);
            this.cmbRaza.TabIndex = 8;
            // 
            // FrmABMAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(484, 490);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.gpbSexo);
            this.Controls.Add(this.cmbRaza);
            this.Controls.Add(this.lblRaza);
            this.Controls.Add(this.cmbUso);
            this.Controls.Add(this.lblUso);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.btnGuardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 475);
            this.Name = "FrmABMAnimal";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgregarModificar";
            this.Load += new System.EventHandler(this.FrmABMAnimal_Load);
            this.gpbSexo.ResumeLayout(false);
            this.gpbSexo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.ComboBox cmbUso;
        private System.Windows.Forms.Label lblUso;
        private System.Windows.Forms.ComboBox cmbRaza;
        private System.Windows.Forms.Label lblRaza;
        private System.Windows.Forms.RadioButton rbtMacho;
        private System.Windows.Forms.RadioButton rbtHembra;
        private System.Windows.Forms.GroupBox gpbSexo;
        private System.Windows.Forms.Button btnCancelar;
    }
}