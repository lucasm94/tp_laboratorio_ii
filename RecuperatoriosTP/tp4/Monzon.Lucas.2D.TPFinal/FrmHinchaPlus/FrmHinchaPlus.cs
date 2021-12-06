using Entidades;
using HinchaPlus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmHinchaPlus
{
    public partial class FrmHinchaPlus : Form
    {
        private FrmCargarHincha frmCargarHincha;
        private FrmActualizarHincha frmActualizarHincha;
        private FrmBajaHincha frmBajaHincha;
        private HinchaPlusServicio hinchaPlus;
        private DataTable dataTable;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private StringBuilder sb;
        private Task hiloSecundario;
        private Task hiloAnimado;
        private CancellationTokenSource cancellationTokenSource;

        public FrmHinchaPlus()
        {
            InitializeComponent();
            this.hinchaPlus = new HinchaPlusServicio();
            this.frmCargarHincha = new FrmCargarHincha(this.hinchaPlus, this.btnBaja, 
                this.btnActualizar);
            this.frmActualizarHincha = new FrmActualizarHincha(this.hinchaPlus);
            this.frmBajaHincha = new FrmBajaHincha(this.hinchaPlus, this.btnBaja, 
                this.btnActualizar);
            this.dataTable = new DataTable();
            this.openFileDialog = new OpenFileDialog();
            this.saveFileDialog = new SaveFileDialog();
            this.sb = new StringBuilder();
            List<string> headers = new List<string>() {"Club", "Hinchas Resgistrados", "Socios Registrados"};
            foreach (string header in headers)
            {
                this.dataTable.Columns.Add(header);
            }
            this.frmCargarHincha.EventoActualizarEstadisticas += MostrarDatosHinchasTotales;
            this.frmBajaHincha.EventoActualizarEstadisticaBaja += MostrarDatosHinchasTotales;
            this.frmActualizarHincha.EventoActualizarEstadisticaActualizacion += MostrarDatosHinchasTotales;
            MostrarDatosHinchasTotales();
            if (this.hinchaPlus.HinchasActivos() < 1)
            {
                this.btnBaja.Enabled = false;
                this.btnActualizar.Enabled = false;
            }
            this.cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;
            this.hiloSecundario = new Task(GuardarHinchaEnDocumento, cancellationToken);
            this.hiloAnimado = new Task(IniciarProceso, cancellationToken);
            this.hiloAnimado.Start();
        }

        private void GuardarHinchaEnDocumento()
        {
            try
            {
                Thread.Sleep(3000);
                string str_RutaArchivo = this.saveFileDialog.FileName;
                this.hinchaPlus.Guardar(str_RutaArchivo);
                Thread.Sleep(1000);
                MessageBox.Show(string.Format($"Documento Creado en {str_RutaArchivo}"));
            }
            catch (HinchaPlusException ex)
            {
                MessageBox.Show("No se pudo generar el documento");
            }
        }

        private void btnCarga_Click(object sender, EventArgs e)
        {
            this.frmCargarHincha.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.frmActualizarHincha.ShowDialog();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            this.frmBajaHincha.ShowDialog();
        }

        private void btnTotalHinchasClub_Click(object sender, EventArgs e)
        {
            MostrarDatosHinchasTotales();
        }

        private void MostrarDatosHinchasTotales()
        {
            this.lblTitulo.Text = "Hinchas Totales";
            this.dataTable.Rows.Clear();
            foreach (ClubEstadistica club in this.hinchaPlus.HinchasTotales())
            {
                this.dataTable.Rows.Add(club.Nombre, club.TotalHinchas, club.TotalSocios);
            }
            this.dgvHinchas.DataSource = this.dataTable;
        }

        private void btnMayoresEdad_Click(object sender, EventArgs e)
        {
            this.lblTitulo.Text = "Mayores de edad";
            this.dataTable.Rows.Clear();
            foreach (ClubEstadistica club in this.hinchaPlus.HinchasMayores())
            {
                this.dataTable.Rows.Add(club.Nombre, club.TotalHinchas, club.TotalSocios);
            }
            this.dgvHinchas.DataSource = this.dataTable;
        }

        private void btnMenoresEdad_Click(object sender, EventArgs e)
        {
            this.lblTitulo.Text = "Menores de edad";
            this.dataTable.Rows.Clear();
            foreach (ClubEstadistica club in this.hinchaPlus.HinchasMenores())
            {
                this.dataTable.Rows.Add(club.Nombre, club.TotalHinchas, club.TotalSocios);
            }
            this.dgvHinchas.DataSource = this.dataTable;
        }

        private void btnMasculinos_Click(object sender, EventArgs e)
        {
            this.lblTitulo.Text = "Masculinos";
            this.dataTable.Rows.Clear();
            foreach (ClubEstadistica club in this.hinchaPlus.HinchasMasculinos())
            {
                this.dataTable.Rows.Add(club.Nombre, club.TotalHinchas, club.TotalSocios);
            }
            this.dgvHinchas.DataSource = this.dataTable;
        }

        private void btnFemeninos_Click(object sender, EventArgs e)
        {
            this.lblTitulo.Text = "Femeninos";
            this.dataTable.Rows.Clear();
            foreach (ClubEstadistica club in this.hinchaPlus.HinchasFemeninos())
            {
                this.dataTable.Rows.Add(club.Nombre, club.TotalHinchas, club.TotalSocios);
            }
            this.dgvHinchas.DataSource = this.dataTable;
        }

        private void btnOtros_Click(object sender, EventArgs e)
        {
            this.lblTitulo.Text = "Otros";
            this.dataTable.Rows.Clear();
            foreach (ClubEstadistica club in this.hinchaPlus.HinchasOtros())
            {
                this.dataTable.Rows.Add(club.Nombre, club.TotalHinchas, club.TotalSocios);
            }
            this.dgvHinchas.DataSource = this.dataTable;
        }

        private void menuItemCargar_Click(object sender, EventArgs e)
        {
            this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.openFileDialog.Filter = "Archivos de texto (*.json)|*.json";
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string str_RutaArchivo = this.openFileDialog.FileName;
                    this.hinchaPlus.Leer(str_RutaArchivo);
                    MostrarDatosHinchasTotales();
                    this.btnActualizar.Enabled = true;
                    this.btnBaja.Enabled = true;
                    MessageBox.Show("Se leyo el archivo con exito");
                } catch (ArchivosException ex)
                {
                    MessageBox.Show(ex.Message);
                } catch (HinchaPlusException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void menuItemExportar_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.saveFileDialog.Filter = "Archivos de texto (*.json)|*.json";
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    hiloSecundario.Start();
                    MessageBox.Show("Se esta generando el documento");
                } catch  (ArchivosException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            sb.AppendLine("Hincha plus");
            sb.AppendLine("Cargar hinchas: da la opcion de buscar un archivo de hinchas para asi cargarlos al sistema.");
            sb.AppendLine("Exportar hinchas: da la opcion de elegir donde y que nombre ponerle al" +
                " archivo donde se guardaran los hinchas cargados en el sistema.");
            sb.AppendLine("Estadisticas: ");
            sb.AppendLine("Hinchas por club: muestra las estadisticas para todos los clubes de todos los hinchas registrados.");
            sb.AppendLine("Mayores de edad: muestra los hinchas mayores de edad para todos los clubes.");
            sb.AppendLine("Menores de edad: muestra los hinchas menores de edad para todos los clubes.");
            sb.AppendLine("Masculinos: muestra los hinchas masculinos para todos los clubes.");
            sb.AppendLine("Femeninos: muestra los hinchas femeninos para todos los clubes.");
            sb.AppendLine("Otros: muestra los hinchas de otro sexo para todos los clubes.");
            sb.AppendLine("Menu: ");
            sb.AppendLine("Cargar hincha: te permite agregar un nuevo hincha al sistema.");
            sb.AppendLine("Actualizar hincha: te permite actualizar a un hincha ya registrado en el sistema.");
            sb.AppendLine("Baja hincha: te permite dar de baja a un hincha ya registrado en el sistema.");
            MessageBox.Show(sb.ToString());
        }

        private void FrmHinchaPlus_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro que desea salir?", "Hincha Plus", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }
            this.cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Metodo que itera mientras no se hayan cancelado los token
        /// llama al metodo AnimarForm;
        /// </summary>
        private void IniciarProceso()
        {
            while (true && !cancellationTokenSource.IsCancellationRequested)
            {
                Thread.Sleep(3000);
                AnimarForm();
            }
        }

        /// <summary>
        //Metodo que corre en otro hilo para cambiar un label del form.
        /// </summary>
        private void AnimarForm()
        {
            if (InvokeRequired)
            {
                Action delegado = AnimarForm;
                Invoke(delegado);
            }
            else
            {
                if (this.lblHinchaPlus.Text.Equals("Hincha Plus"))
                {
                    this.lblHinchaPlus.Text = "La mitad mas uno";
                } else
                {
                    this.lblHinchaPlus.Text = "Hincha Plus";
                }
            }
        }
    }
}
