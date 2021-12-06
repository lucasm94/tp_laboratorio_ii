using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase estática que permite realizar operaciones (+ - / *) entre dos Números. 
    /// Permite validar el operador que ingresó el usuario.
    /// </summary>
    public static class Calculadora
    {
        /// <summary>
        /// Valida el parametro recibido de que sea alguno de los caracteres permitidos (+ - / *).
        /// En caso de recibir un caracter erróneo, devuelve un +.
        /// </summary>
        /// <param name="operador">Char ingresado por usuario.</param>
        /// <returns>Operador en string validado o el "+" por default.</returns>
        private static string ValidarOperador(char operador)
        {
            string strOperador;
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                strOperador = operador.ToString();
            }
            else
            {
                strOperador = "+";
            }
            return strOperador;
        }

        /// <summary>
        /// Valida el parametro recibido llamando al método "ValidarOperador".
        /// Realiza alguna de las operaciones posibles (+ - / *) entre los dos numeros.
        /// En caso de que se intente dividir y el segundo parametro sea un cero, devolverá el double.MinValue.
        /// </summary>
        /// <param name="num1">Objeto de tipo Operando, elegido por el usuario</param>
        /// <param name="num2">Objeto de tipo Operando, elegido por el usuario</param>
        /// <param name="operador">Operador a validar, elegido por el usuario</param>
        /// <returns>El resultado de la operación entre los dos números en formato double.</returns>
        public static double Operar(Operando num1, Operando num2, Char operador)
        {
            double resultadoOperacion = 0;
            String operadorValidado = ValidarOperador(operador);
            switch (operadorValidado)
            {
                case "+":
                    resultadoOperacion = num1 + num2;
                    break;
                case "-":
                    resultadoOperacion = num1 - num2;
                    break;
                case "*":
                    resultadoOperacion = num1 * num2;
                    break;
                case "/":
                    resultadoOperacion = num1 / num2;
                    break;
            }
            return resultadoOperacion;
        }
    }
}
