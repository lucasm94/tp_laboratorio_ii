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

namespace FrmHinchaPlus
{
    public partial class FrmCargarHincha : Form
    {
        private HinchaPlusServicio hinchaPlus;
        private StringBuilder sb;
        private Button mostrarDatos;
        private Button bajaMenu;
        private Button actualizarMenu;

        public FrmCargarHincha(HinchaPlusServicio hinchaPlus, Button mostrarDatos, 
            Button bajaMenu, Button actualizarMenu)
        {
            this.hinchaPlus = hinchaPlus;
            this.sb = new StringBuilder();
            InitializeComponent();
            CargarSexo();
            this.cmbSexo.SelectedIndex = 0;
            CargarClubes();
            this.cmbClub.SelectedIndex = 0;
            this.mostrarDatos = mostrarDatos;
            this.bajaMenu = bajaMenu;
            this.actualizarMenu = actualizarMenu;
        }

        private void CargarSexo()
        {
            this.cmbSexo.Items.Add(Sexo.Femenino);
            this.cmbSexo.Items.Add(Sexo.Masculino);
            this.cmbSexo.Items.Add(Sexo.Otro);
        }

        private void CargarClubes()
        {
            this.cmbClub.Items.Add(Club.Boca);
            this.cmbClub.Items.Add(Club.River);
            this.cmbClub.Items.Add(Club.Racing);
            this.cmbClub.Items.Add(Club.Independiente);
            this.cmbClub.Items.Add(Club.San_Lorenzo);
            this.cmbClub.Items.Add(Club.Otro);
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

        private void txtStr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (this.txtNombre.Text.Length < 1 || this.txtApellido.Text.Length < 1 || 
                this.txtDni.Text.Length < 1)
            {
                MessageBox.Show("El nombre, el apellido y el dni no pueden estar vacios");
            } else
            {
                try
                {
                    Club club = (Club)Enum.Parse(typeof(Club), this.cmbClub.Text);
                    Sexo sexo = (Sexo)Enum.Parse(typeof(Sexo), this.cmbSexo.Text);
                    Hincha hinchaNuevo = new Hincha(this.txtNombre.Text, this.txtApellido.Text,
                        int.Parse(this.txtDni.Text), this.dtpNacimiento.Value.Date, sexo,
                        club, this.chbEsSocio.Checked);
                    this.hinchaPlus.CargarHincha(hinchaNuevo);
                    MessageBox.Show("Hincha cargado con exito");
                    if (this.hinchaPlus.Hinchas.Count == 1)
                    {
                        this.bajaMenu.Enabled = true;
                        this.actualizarMenu.Enabled = true;
                    }
                    this.Clear();
                    this.mostrarDatos.PerformClick();
                    this.Close();
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
            this.txtNombre.Text = "";
            this.txtApellido.Text = "";
            this.chbEsSocio.Checked = false;
            this.cmbClub.SelectedIndex = 0;
            this.cmbSexo.SelectedIndex = 0;
            this.dtpNacimiento.Value = DateTime.Now.Date;
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            sb.AppendLine("Carga de un hincha");
            sb.AppendLine("Para cargar a un hincha primero se debe ingresar el nombre, apellido y dni");
            sb.AppendLine("se debe seleccionar el club del cual es hincha y su sexo, ademas indicar si es socio del club");
            sb.AppendLine("luego se podra dar de alta al hincha haciendo click en Cargar");
            sb.AppendLine("Cancelar vuelve al menu de estadisticas.");
            MessageBox.Show(sb.ToString());
        }
    }
}
