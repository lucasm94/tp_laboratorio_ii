
namespace FrmHinchaPlus
{
    partial class FrmHinchaPlus
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHinchaPlus));
            this.lblEstadistica = new System.Windows.Forms.Label();
            this.btnTotalHinchasClub = new System.Windows.Forms.Button();
            this.dgvHinchas = new System.Windows.Forms.DataGridView();
            this.btnMayoresEdad = new System.Windows.Forms.Button();
            this.btnMenoresEdad = new System.Windows.Forms.Button();
            this.btnMasculinos = new System.Windows.Forms.Button();
            this.btnFemeninos = new System.Windows.Forms.Button();
            this.btnOtros = new System.Windows.Forms.Button();
            this.btnCarga = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.lblHinchaPlus = new System.Windows.Forms.Label();
            this.menustp = new System.Windows.Forms.MenuStrip();
            this.menuItemExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCargar = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHinchas)).BeginInit();
            this.menustp.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEstadistica
            // 
            this.lblEstadistica.AutoSize = true;
            this.lblEstadistica.BackColor = System.Drawing.SystemColors.Control;
            this.lblEstadistica.Font = new System.Drawing.Font("Segoe UI", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblEstadistica.ForeColor = System.Drawing.Color.Black;
            this.lblEstadistica.Location = new System.Drawing.Point(13, 9);
            this.lblEstadistica.Name = "lblEstadistica";
            this.lblEstadistica.Size = new System.Drawing.Size(172, 38);
            this.lblEstadistica.TabIndex = 0;
            this.lblEstadistica.Text = "Estadisticas";
            // 
            // btnTotalHinchasClub
            // 
            this.btnTotalHinchasClub.Location = new System.Drawing.Point(13, 56);
            this.btnTotalHinchasClub.Name = "btnTotalHinchasClub";
            this.btnTotalHinchasClub.Size = new System.Drawing.Size(245, 40);
            this.btnTotalHinchasClub.TabIndex = 1;
            this.btnTotalHinchasClub.Text = "Hinchas por club";
            this.btnTotalHinchasClub.UseVisualStyleBackColor = true;
            this.btnTotalHinchasClub.Click += new System.EventHandler(this.btnTotalHinchasClub_Click);
            // 
            // dgvHinchas
            // 
            this.dgvHinchas.AllowUserToAddRows = false;
            this.dgvHinchas.AllowUserToDeleteRows = false;
            this.dgvHinchas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHinchas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHinchas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvHinchas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHinchas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHinchas.Location = new System.Drawing.Point(288, 112);
            this.dgvHinchas.MultiSelect = false;
            this.dgvHinchas.Name = "dgvHinchas";
            this.dgvHinchas.RowHeadersVisible = false;
            this.dgvHinchas.RowHeadersWidth = 62;
            this.dgvHinchas.RowTemplate.Height = 33;
            this.dgvHinchas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHinchas.Size = new System.Drawing.Size(623, 269);
            this.dgvHinchas.TabIndex = 2;
            // 
            // btnMayoresEdad
            // 
            this.btnMayoresEdad.Location = new System.Drawing.Point(13, 112);
            this.btnMayoresEdad.Name = "btnMayoresEdad";
            this.btnMayoresEdad.Size = new System.Drawing.Size(245, 40);
            this.btnMayoresEdad.TabIndex = 3;
            this.btnMayoresEdad.Text = "Mayores de edad";
            this.btnMayoresEdad.UseVisualStyleBackColor = true;
            this.btnMayoresEdad.Click += new System.EventHandler(this.btnMayoresEdad_Click);
            // 
            // btnMenoresEdad
            // 
            this.btnMenoresEdad.Location = new System.Drawing.Point(12, 170);
            this.btnMenoresEdad.Name = "btnMenoresEdad";
            this.btnMenoresEdad.Size = new System.Drawing.Size(246, 40);
            this.btnMenoresEdad.TabIndex = 4;
            this.btnMenoresEdad.Text = "Menores de edad";
            this.btnMenoresEdad.UseVisualStyleBackColor = true;
            this.btnMenoresEdad.Click += new System.EventHandler(this.btnMenoresEdad_Click);
            // 
            // btnMasculinos
            // 
            this.btnMasculinos.Location = new System.Drawing.Point(12, 227);
            this.btnMasculinos.Name = "btnMasculinos";
            this.btnMasculinos.Size = new System.Drawing.Size(246, 40);
            this.btnMasculinos.TabIndex = 5;
            this.btnMasculinos.Text = "Masculinos";
            this.btnMasculinos.UseVisualStyleBackColor = true;
            this.btnMasculinos.Click += new System.EventHandler(this.btnMasculinos_Click);
            // 
            // btnFemeninos
            // 
            this.btnFemeninos.Location = new System.Drawing.Point(13, 283);
            this.btnFemeninos.Name = "btnFemeninos";
            this.btnFemeninos.Size = new System.Drawing.Size(245, 40);
            this.btnFemeninos.TabIndex = 6;
            this.btnFemeninos.Text = "Femeninos";
            this.btnFemeninos.UseVisualStyleBackColor = true;
            this.btnFemeninos.Click += new System.EventHandler(this.btnFemeninos_Click);
            // 
            // btnOtros
            // 
            this.btnOtros.Location = new System.Drawing.Point(13, 339);
            this.btnOtros.Name = "btnOtros";
            this.btnOtros.Size = new System.Drawing.Size(245, 40);
            this.btnOtros.TabIndex = 7;
            this.btnOtros.Text = "Otros";
            this.btnOtros.UseVisualStyleBackColor = true;
            this.btnOtros.Click += new System.EventHandler(this.btnOtros_Click);
            // 
            // btnCarga
            // 
            this.btnCarga.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCarga.Location = new System.Drawing.Point(413, 396);
            this.btnCarga.Name = "btnCarga";
            this.btnCarga.Size = new System.Drawing.Size(148, 57);
            this.btnCarga.TabIndex = 8;
            this.btnCarga.Text = "Cargar Hincha";
            this.btnCarga.UseVisualStyleBackColor = true;
            this.btnCarga.Click += new System.EventHandler(this.btnCarga_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(582, 396);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(160, 57);
            this.btnActualizar.TabIndex = 9;
            this.btnActualizar.Text = "Actualizar Hincha";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBaja.Location = new System.Drawing.Point(763, 396);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(148, 57);
            this.btnBaja.TabIndex = 10;
            this.btnBaja.Text = "Baja Hincha";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // lblHinchaPlus
            // 
            this.lblHinchaPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblHinchaPlus.AutoSize = true;
            this.lblHinchaPlus.BackColor = System.Drawing.SystemColors.Control;
            this.lblHinchaPlus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHinchaPlus.ForeColor = System.Drawing.Color.Black;
            this.lblHinchaPlus.Location = new System.Drawing.Point(13, 421);
            this.lblHinchaPlus.Name = "lblHinchaPlus";
            this.lblHinchaPlus.Size = new System.Drawing.Size(0, 32);
            this.lblHinchaPlus.TabIndex = 11;
            // 
            // menustp
            // 
            this.menustp.BackColor = System.Drawing.Color.Transparent;
            this.menustp.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menustp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExportar,
            this.menuItemCargar});
            this.menustp.Location = new System.Drawing.Point(0, 0);
            this.menustp.Name = "menustp";
            this.menustp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menustp.Size = new System.Drawing.Size(939, 33);
            this.menustp.TabIndex = 12;
            this.menustp.Text = "menuStrip1";
            // 
            // menuItemExportar
            // 
            this.menuItemExportar.BackColor = System.Drawing.SystemColors.Control;
            this.menuItemExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuItemExportar.ForeColor = System.Drawing.Color.Black;
            this.menuItemExportar.Name = "menuItemExportar";
            this.menuItemExportar.Size = new System.Drawing.Size(161, 29);
            this.menuItemExportar.Text = "Exportar Hinchas";
            this.menuItemExportar.Click += new System.EventHandler(this.menuItemExportar_Click);
            // 
            // menuItemCargar
            // 
            this.menuItemCargar.BackColor = System.Drawing.SystemColors.Control;
            this.menuItemCargar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.menuItemCargar.ForeColor = System.Drawing.Color.Black;
            this.menuItemCargar.Name = "menuItemCargar";
            this.menuItemCargar.Size = new System.Drawing.Size(147, 29);
            this.menuItemCargar.Text = "Cargar Hinchas";
            this.menuItemCargar.Click += new System.EventHandler(this.menuItemCargar_Click);
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyuda.Location = new System.Drawing.Point(288, 396);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(109, 57);
            this.btnAyuda.TabIndex = 13;
            this.btnAyuda.Text = "Ayuda";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(288, 58);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(193, 32);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "Hinchas Totales";
            // 
            // FrmHinchaPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(939, 470);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnAyuda);
            this.Controls.Add(this.lblHinchaPlus);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnCarga);
            this.Controls.Add(this.btnOtros);
            this.Controls.Add(this.btnFemeninos);
            this.Controls.Add(this.btnMasculinos);
            this.Controls.Add(this.btnMenoresEdad);
            this.Controls.Add(this.btnMayoresEdad);
            this.Controls.Add(this.dgvHinchas);
            this.Controls.Add(this.btnTotalHinchasClub);
            this.Controls.Add(this.lblEstadistica);
            this.Controls.Add(this.menustp);
            this.MainMenuStrip = this.menustp;
            this.MaximumSize = new System.Drawing.Size(1061, 626);
            this.MinimumSize = new System.Drawing.Size(861, 426);
            this.Name = "FrmHinchaPlus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hincha Plus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmHinchaPlus_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHinchas)).EndInit();
            this.menustp.ResumeLayout(false);
            this.menustp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstadistica;
        private System.Windows.Forms.Button btnTotalHinchasClub;
        private System.Windows.Forms.DataGridView dgvHinchas;
        private System.Windows.Forms.Button btnMayoresEdad;
        private System.Windows.Forms.Button btnMenoresEdad;
        private System.Windows.Forms.Button btnMasculinos;
        private System.Windows.Forms.Button btnFemeninos;
        private System.Windows.Forms.Button btnOtros;
        private System.Windows.Forms.Button btnCarga;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Label lblHinchaPlus;
        private System.Windows.Forms.MenuStrip menustp;
        private System.Windows.Forms.ToolStripMenuItem menuItemExportar;
        private System.Windows.Forms.ToolStripMenuItem menuItemCargar;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.Label lblTitulo;
    }
}

