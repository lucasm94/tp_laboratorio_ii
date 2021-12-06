using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HinchaPlus
{
    public partial class FrmActualizarHincha : Form
    {
        private HinchaPlusServicio hinchaPlus;
        private Hincha hinchaBuscado;
        private StringBuilder sb;
        public event DelegadoHinchaPlus EventoActualizarEstadisticaActualizacion;

        public FrmActualizarHincha(HinchaPlusServicio hinchaPlus)
        {
            this.hinchaPlus = hinchaPlus;
            this.sb = new StringBuilder();
            InitializeComponent();
            this.cmbNuevoClub.Items.Add(Club.Boca);
            this.cmbNuevoClub.Items.Add(Club.River);
            this.cmbNuevoClub.Items.Add(Club.Racing);
            this.cmbNuevoClub.Items.Add(Club.Independiente);
            this.cmbNuevoClub.Items.Add(Club.San_Lorenzo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.hinchaBuscado = this.hinchaPlus.ObtenerHinchaPorDni(int.Parse(this.txtDni.Text));
                this.lblApellidoHincha.Text = this.hinchaBuscado.Apellido;
                this.lblNombreHincha.Text = this.hinchaBuscado.Nombre;
                this.lblClubActual.Text = this.hinchaBuscado.Club.ToString();
                this.chbEsSocio.Checked = this.hinchaBuscado.EsSocio;
            }
            catch (HinchaPlusException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.hinchaBuscado is null)
            {
                MessageBox.Show("Primero debe buscar el hincha a actualizar por dni");
            }
            else if (this.hinchaBuscado.Club.ToString().Equals(this.cmbNuevoClub.Text) && 
                this.hinchaBuscado.EsSocio == this.chbEsSocio.Checked)
            {
                MessageBox.Show("Para actualizar debe modificar un nuevo club o cambiar el estado de socio");
            } else
            {
                try
                {
                    DialogResult dialogResult = 
                        MessageBox.Show($"confirma la actualizacion del hincha {this.hinchaBuscado.Dni}?", 
                        "Actualizar hincha", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Club club = this.cmbNuevoClub.Text.Length > 0 ?
                            (Club)Enum.Parse(typeof(Club), this.cmbNuevoClub.Text) : hinchaBuscado.Club;
                        this.hinchaPlus.ActualizarHincha(this.hinchaBuscado, club,
                            this.chbEsSocio.Checked);
                        MessageBox.Show("Hincha actualizado con exito");
                        this.hinchaBuscado = null;
                        this.Clear();
                        this.EventoActualizarEstadisticaActualizacion.Invoke();
                        this.Close();
                    }
                }
                catch (HinchaPlusException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Clear()
        {
            this.txtDni.Text = "";
            this.lblApellidoHincha.Text = "";
            this.lblNombreHincha.Text = "";
            this.chbEsSocio.Checked = false;
            this.lblClubActual.Text = "";
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (txtDni.Text.Length > 0)
            {
                this.btnBuscar.Enabled = true;
            }
            else
            {
                this.btnBuscar.Enabled = false;
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            sb.AppendLine("Actualizar hincha");
            sb.AppendLine("Para actualizar a un hincha primero se debe ingresar el dni y luego buscarlo");
            sb.AppendLine("en caso de que sea un hincha valido se mostraran alguno de sus datos");
            sb.AppendLine("luego se podra modificar el nuevo club del cual es hincha o si cambio su estado de socio");
            sb.AppendLine("para poder actualizar se debera modificar por lo menos uno de los items y realizra click en actualizar.");
            sb.AppendLine("Cancelar vuelve al menu de estadisticas.");
            MessageBox.Show(sb.ToString());
        }
    }
}
