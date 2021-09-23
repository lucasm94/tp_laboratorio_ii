using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase pública que permite crear objetos de tipo Operando, realizar operaciones entre ellos o conversiones de decimal-binario o binario-decimal, previa validación.
    /// </summary>
    public class Operando
    {
        /// <summary>
        /// Atributo privado que guarda un número.
        /// </summary>
        private double numero;

        /// <summary>
        /// Constructor por defecto, inicializa el atributo numero en cero.
        /// </summary>
        public Operando() : this(0)
        {

        }

        /// <summary>
        /// Constructor con paremetro.
        /// </summary>
        /// <param name="numero">Numero double para asignar al campo del objeto.</param>
        public Operando(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que invoca al Set para asignar el parámetro recibido como DOUBLE al campo del objeto.
        /// </summary>
        /// <param name="strNumero">Numero en string para asignar al campo del objeto.</param>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        /// <summary>
        /// Asigna el value en el atributo del objeto, previa validación del mismo. 
        /// Llama al método ValidarNumero().
        /// </summary>
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        /// <summary>
        /// Permite convertir un binario a decimal. 
        /// Utiliza la parte entera y absoluta del parametro recibido.
        /// valida que el string recibido sea un binario y luego realiza la conversion.
        /// Si no, retorna "Valor inválido".
        /// </summary>
        /// <param name="binario">Cadena binaria a validar y posteriormente convertir en decimal</param>
        /// <returns>string con el número decimal o la leyenda "Valor inválido" en caso que no se pueda convertir.</returns>
        public static string BinarioDecimal(string binario)
        {
            binario = binario.Contains('-') ? binario.Substring(1, binario.Length - 1) : binario;
            if (binario.Contains(','))
            {
                int indiceComa = binario.IndexOf(',');
                binario = binario.Substring(0, binario.Length - indiceComa);
            }

            string resultado;
            if (EsBinario(binario))
            {
                int sumaDecimal = 0;
                int length = binario.Length - 1;
                for (int i = 0; i < binario.Length; i++)
                {
                    if (binario.ElementAt(length) == '1')
                    {
                        sumaDecimal += (int)Math.Pow(2, i);
                    }
                    length--;
                }
                resultado = sumaDecimal.ToString();
            }
            else
            {
                resultado = "Valor invalido";
            }
            return resultado;
        }

        /// <summary>
        /// Sobrecarga del método, que convierte un número decimal a binario.
        /// Utiliza la parte entera y absoluta del parametro recibido.
        /// Convierte el número a binario. Devuelve un string.
        /// </summary>
        /// <param name="numero">Número double a ser convertido en binario.</param>
        /// <returns>string con el número binario.</returns>
        public static string DecimalBinario(double numero)
        {

            string resultado = "";
            int intNumero = (int)Math.Truncate(numero);
            intNumero = Math.Abs(intNumero);

            char caracterBinario;

            while (intNumero > 0)
            {
                if (intNumero % 2 == 1)
                {
                    caracterBinario = '1';
                }
                else
                {
                    caracterBinario = '0';
                }
                resultado = caracterBinario + resultado;
                intNumero = intNumero / 2;
            }

            return resultado;
        }

        /// <summary>
        /// Sobrecarga del Método que permite convertir un número decimal en número binario. 
        /// Recibe un string de un numero. Lo intenta convertir a double. 
        /// </summary>
        /// <param name="numero">Número double a ser convertido en binario.</param>
        /// <returns>string con el número binario.</returns>
        public static string DecimalBinario(string numero)
        {
            string resultado;
            if (double.TryParse(numero, out double dNumero))
            {
                resultado = DecimalBinario(dNumero); ;
            }
            else
            {
                resultado = "Valor invalido";
            }
            return resultado;
        }

        /// <summary>
        /// Método privado y estático que valida si el string recibido contiene solo 0 y 1.
        /// </summary>
        /// <param name="binario">String a ser validado de que sea binario.</param>
        /// <returns>True: si solo contiene 0 y 1. False: si existe algún caracter distinto de 0 y 1.</returns>
        private static bool EsBinario(string binario)
        {
            bool esBinario = true;
            for (int i = 0; i < binario.Length && esBinario; i++)
            {
                esBinario = (binario.ElementAt(i) == '0' || binario.ElementAt(i) == '1');
            }
            return esBinario;
        }

        /// <summary>
        /// Metodo privado que valida si el string recibido puede convertirse en formato double.
        /// En caso que no pueda convertir, retorna un cero.
        /// </summary>
        /// <param name="strNumero">String para validar si se puede transformar a formato double.</param>
        /// <returns>El número transformado a double o un cero.</returns>
        private double ValidarOperando(string strNumero)
        {
            if (!double.TryParse(strNumero, out double dblNumero))
            {
                dblNumero = 0;
            }
            return dblNumero;
        }

        /// <summary>
        /// Sobrecarga del operador +.
        /// Me permite sumar los atributos de los objetos Operando.
        /// </summary>
        /// <param name="n1">Objeto tipo Operando.</param>
        /// <param name="n2">Objeto tipo Operando.</param>
        /// <returns>La suma de los atributos en double.</returns>
        public static double operator +(Operando a, Operando b)
        {
            return a.numero + b.numero;
        }

        /// <summary>
        /// Sobrecarga del operador -.
        /// Me permite restar los atributos de los objetos Operando.
        /// </summary>
        /// <param name="n1">Objeto tipo Operando.</param>
        /// <param name="n2">Objeto tipo Operando.</param>
        /// <returns>La resta de los atributos en double.</returns>
        public static double operator -(Operando a, Operando b)
        {
            return a.numero - b.numero;
        }

        /// <summary>
        /// Sobrecarga del operador atributos
        /// Me permite multiplicar los atributos de los objetos Operando.
        /// </summary>
        /// <param name="n1">Objeto tipo Operando.</param>
        /// <param name="n2">Objeto tipo Operando.</param>
        /// <returns>El producto de los atributos en double.</returns>
        public static double operator *(Operando a, Operando b)
        {
            return a.numero * b.numero;
        }

        /// <summary>
        /// Sobrecarga del operador /.
        /// Me permite dividir los atributos de los objetos Operando.
        /// En caso de que el atributo del segundo parámetro sea un cero, retorna el double.MinValue;
        /// </summary>
        /// <param name="n1">Objeto tipo Operando.</param>
        /// <param name="n2">Objeto tipo Operando.</param>
        /// <returns>La división de los atributos en double o el double.MinValue.</returns>
        public static double operator /(Operando a, Operando b)
        {
            double resultado;
            if (b.numero != 0)
            {
                resultado = a.numero / b.numero;
            }
            else
            {
                resultado = double.MinValue;
            }
            return resultado;
        }
    }
}
