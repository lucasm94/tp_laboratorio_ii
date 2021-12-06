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
    public partial class FrmBajaHincha : Form
    {
        private HinchaPlusServicio hinchaPlus;
        private StringBuilder sb;
        private Button bajaMenu;
        private Button actualizarMenu;
        private Hincha hincha;
        public event DelegadoHinchaPlus EventoActualizarEstadisticaBaja;

        public FrmBajaHincha(HinchaPlusServicio hinchaPlus, Button bajaMenu, 
            
            Button actualizarMenu)
        {
            this.hinchaPlus = hinchaPlus;
            this.sb = new StringBuilder();
            InitializeComponent();
            this.bajaMenu = bajaMenu;
            this.actualizarMenu = actualizarMenu;
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
                this.hincha = this.hinchaPlus.ObtenerHinchaPorDni(int.Parse(this.txtDni.Text));
                this.lblApellidoHincha.Text = hincha.Apellido;
                this.lblNombreHincha.Text = hincha.Nombre;
            }
            catch (HinchaPlusException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.txtDni is null || this.txtDni.Text.Length < 1)
            {
                MessageBox.Show("Primero debe buscar el hincha a dar de baja por dni");
            }
            else
            {
                try
                {
                    DialogResult dialogResult = 
                        MessageBox.Show($"Confirma la baja del hincha {this.txtDni.Text}", 
                        "Baja hincha", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.hinchaPlus.BajaHincha(this.hincha);
                        MessageBox.Show("Hincha dado de baja con exito");
                        if (this.hinchaPlus.HinchasActivos() < 1)
                        {
                            this.bajaMenu.Enabled = false;
                            this.actualizarMenu.Enabled = false;
                        }
                        this.Clear();
                        this.EventoActualizarEstadisticaBaja.Invoke();
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
            this.hincha = null;
            this.txtDni.Text = "";
            this.lblApellidoHincha.Text = "";
            this.lblNombreHincha.Text = "";
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            if (txtDni.Text.Length > 0)
            {
                this.btnBuscar.Enabled = true;
            } else
            {
                this.btnBuscar.Enabled = false;
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            sb.AppendLine("Baja hincha");
            sb.AppendLine("Para dar de baja a un hincha primero se debe ingresar el dni y luego buscarlo");
            sb.AppendLine("en caso de que sea un hincha valido se mostraran alguno de sus datos");
            sb.AppendLine("luego se podra dar de baja al hincha haciendo click en Baja");
            sb.AppendLine("Cancelar vuelve al menu de estadisticas.");
            MessageBox.Show(sb.ToString());
        }
    }
}
