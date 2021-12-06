
namespace HinchaPlus
{
    partial class FrmActualizarHincha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmActualizarHincha));
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblNuevoClub = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNombreHincha = new System.Windows.Forms.Label();
            this.lblApellidoHincha = new System.Windows.Forms.Label();
            this.chbEsSocio = new System.Windows.Forms.CheckBox();
            this.cmbNuevoClub = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClubActual = new System.Windows.Forms.Label();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnActualizar.Location = new System.Drawing.Point(479, 299);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(134, 57);
            this.btnActualizar.TabIndex = 3;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.Location = new System.Drawing.Point(321, 299);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(134, 57);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(68, 19);
            this.txtDni.MaxLength = 8;
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(129, 31);
            this.txtDni.TabIndex = 7;
            this.txtDni.TextChanged += new System.EventHandler(this.txtDni_TextChanged);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.BackColor = System.Drawing.Color.Transparent;
            this.lblDni.ForeColor = System.Drawing.Color.Transparent;
            this.lblDni.Location = new System.Drawing.Point(21, 22);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(43, 25);
            this.lblDni.TabIndex = 6;
            this.lblDni.Text = "Dni:";
            // 
            // lblNuevoClub
            // 
            this.lblNuevoClub.AutoSize = true;
            this.lblNuevoClub.BackColor = System.Drawing.Color.Transparent;
            this.lblNuevoClub.ForeColor = System.Drawing.Color.Transparent;
            this.lblNuevoClub.Location = new System.Drawing.Point(366, 22);
            this.lblNuevoClub.Name = "lblNuevoClub";
            this.lblNuevoClub.Size = new System.Drawing.Size(103, 25);
            this.lblNuevoClub.TabIndex = 8;
            this.lblNuevoClub.Text = "Club actual:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Location = new System.Drawing.Point(216, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 34);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.BackColor = System.Drawing.Color.Transparent;
            this.lblApellido.ForeColor = System.Drawing.Color.Transparent;
            this.lblApellido.Location = new System.Drawing.Point(252, 69);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(82, 25);
            this.lblApellido.TabIndex = 13;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.ForeColor = System.Drawing.Color.Transparent;
            this.lblNombre.Location = new System.Drawing.Point(22, 69);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(82, 25);
            this.lblNombre.TabIndex = 12;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblNombreHincha
            // 
            this.lblNombreHincha.AutoSize = true;
            this.lblNombreHincha.BackColor = System.Drawing.Color.Transparent;
            this.lblNombreHincha.ForeColor = System.Drawing.Color.Transparent;
            this.lblNombreHincha.Location = new System.Drawing.Point(98, 69);
            this.lblNombreHincha.Name = "lblNombreHincha";
            this.lblNombreHincha.Size = new System.Drawing.Size(0, 25);
            this.lblNombreHincha.TabIndex = 14;
            // 
            // lblApellidoHincha
            // 
            this.lblApellidoHincha.AutoSize = true;
            this.lblApellidoHincha.BackColor = System.Drawing.Color.Transparent;
            this.lblApellidoHincha.ForeColor = System.Drawing.Color.Transparent;
            this.lblApellidoHincha.Location = new System.Drawing.Point(340, 69);
            this.lblApellidoHincha.Name = "lblApellidoHincha";
            this.lblApellidoHincha.Size = new System.Drawing.Size(0, 25);
            this.lblApellidoHincha.TabIndex = 15;
            // 
            // chbEsSocio
            // 
            this.chbEsSocio.AutoSize = true;
            this.chbEsSocio.BackColor = System.Drawing.Color.Transparent;
            this.chbEsSocio.ForeColor = System.Drawing.Color.White;
            this.chbEsSocio.Location = new System.Drawing.Point(616, 22);
            this.chbEsSocio.Name = "chbEsSocio";
            this.chbEsSocio.Size = new System.Drawing.Size(102, 29);
            this.chbEsSocio.TabIndex = 16;
            this.chbEsSocio.Text = "Es socio";
            this.chbEsSocio.UseVisualStyleBackColor = false;
            // 
            // cmbNuevoClub
            // 
            this.cmbNuevoClub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNuevoClub.FormattingEnabled = true;
            this.cmbNuevoClub.Location = new System.Drawing.Point(616, 66);
            this.cmbNuevoClub.Name = "cmbNuevoClub";
            this.cmbNuevoClub.Size = new System.Drawing.Size(126, 33);
            this.cmbNuevoClub.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(504, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nuevo Club:";
            // 
            // lblClubActual
            // 
            this.lblClubActual.AutoSize = true;
            this.lblClubActual.BackColor = System.Drawing.Color.Transparent;
            this.lblClubActual.ForeColor = System.Drawing.Color.Transparent;
            this.lblClubActual.Location = new System.Drawing.Point(467, 23);
            this.lblClubActual.Name = "lblClubActual";
            this.lblClubActual.Size = new System.Drawing.Size(0, 25);
            this.lblClubActual.TabIndex = 19;
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAyuda.Location = new System.Drawing.Point(162, 299);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(134, 57);
            this.btnAyuda.TabIndex = 20;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // FrmActualizarHincha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(763, 390);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.lblClubActual);
            this.Controls.Add(this.cmbNuevoClub);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chbEsSocio);
            this.Controls.Add(this.lblApellidoHincha);
            this.Controls.Add(this.lblNombreHincha);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblNuevoClub);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.Name = "FrmActualizarHincha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar Hincha";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblNuevoClub;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNombreHincha;
        private System.Windows.Forms.Label lblApellidoHincha;
        private System.Windows.Forms.CheckBox chbEsSocio;
        private System.Windows.Forms.ComboBox cmbNuevoClub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClubActual;
        private System.Windows.Forms.Button btnAyuda;
    }
}