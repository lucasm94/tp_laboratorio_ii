using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    /// <summary>
    /// Clase de formulario que permite realizar las funciones básicas de una calculadora (+, -, *, /) entre dos numeros.
    /// Tambien, permite convertir los numeros de decimal-binario y binario-decimal, si es posible.
    /// </summary>
    public partial class FormCalculadora : Form
    {
        /// <summary>
        /// Constructor que inicializa los componentes.
        /// </summary>
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento que cierra el formulario y finaliza el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Evento que toma el resultado en el Label e intenta convertirlo a binario luego lo mostra en el Label.
        /// Habilita botón de binario-decimal.
        /// Deshabilita botón de decimal-binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string strDecimal = this.lblResultado.Text.Contains('.') ? this.lblResultado.Text.Replace('.', ',') : this.lblResultado.Text;
            this.lblResultado.Text = Operando.DecimalBinario(strDecimal).ToString();
            this.btnConvertirADecimal.Enabled = true;
            this.btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Evento que toma el resultado en el Label e intenta convertirlo a binario para luego mostrarlo en el Label.
        /// Habilita botón de decimal-binario. 
        /// Deshabilita botón de binario-decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string binario = this.lblResultado.Text.Contains('.') ? this.lblResultado.Text.Replace('.', ',') : this.lblResultado.Text;
            this.lblResultado.Text = Operando.BinarioDecimal(binario).ToString();
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Evento que llama al método Limpiar().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Evento que llama al método de clase Operar(). 
        /// Convierte el retorno en string.
        /// Muestra el resultado en el Label. 
        /// Habilita botón de decimal a binario. 
        /// Habilita botón de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = this.txtNumero1.Text.Contains('.') ? this.txtNumero1.Text.Replace(".", ",") : this.txtNumero1.Text;
            string num2 = this.txtNumero2.Text.Contains('.') ? this.txtNumero2.Text.Replace(".", ",") : this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;
            string resultado = FormCalculadora.Operar(num1, num2, operador).ToString();
            this.lblResultado.Text = resultado;
            this.lstOperaciones.Items.Add($"{num1} {operador} {num2} = {resultado}");
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = true;
        }

        /// <summary>
        /// Borra los datos del Label, los TextBox y ComboBox de la pantalla. Y desactiva los botones de conversión.
        /// </summary>
        public void Limpiar()
        {
            this.lblResultado.ResetText();
            this.cmbOperador.SelectedIndex = -1;
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lstOperaciones.Items.Clear();
            this.btnConvertirADecimal.Enabled = false;
            this.btnConvertirABinario.Enabled = false;
        }

        /// <summary>
        /// Convierte los parametros string ingresados en tipo Operando y llama al método Calculadora.Operar().
        /// Se realiza la operación según el operador ingresado. 
        /// Retorna el resultado en double.
        /// </summary>
        /// <param name="num1">String a ser convetido en Operando.</param>
        /// <param name="num2">String a ser convetido en Operando.</param>
        /// <param name="operador">Operador ingresado para realizar la operación.</param>
        /// <returns>El resultado de la operación en double.</returns>
        public static double Operar(string num1, string num2, string operador)
        {
            Operando n1 = new Operando(num1);
            Operando n2 = new Operando(num2);

            return Calculadora.Operar(n1, n2, operador.ElementAt(0));
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
           DialogResult dr = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo);
            if (dr.Equals(DialogResult.No))
            {
                e.Cancel = true;
            }
        }
    }
}
