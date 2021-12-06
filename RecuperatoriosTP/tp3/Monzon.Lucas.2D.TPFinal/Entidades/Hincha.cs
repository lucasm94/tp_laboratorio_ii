using System;
using System.Text;

namespace Entidades
{
    public enum Sexo
    {
        Femenino, Masculino, Otro
    }

    public enum Club
    {
        Boca, River, Racing, Independiente, San_Lorenzo, Otro
    }

    public class Hincha
    {
        private string nombre;
        private string apellido;
        private DateTime nacimiento;
        private Sexo sexo;
        private bool activo;
        private Club club;
        private int dni;
        private bool esSocio;

        /// <summary>
        /// Constructor de la clase Hincha con todos sus atributos
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacimiento"></param>
        /// <param name="sexo"></param>
        /// <param name="club"></param>
        /// <param name="dni"></param>
        /// <param name="esSocio"></param>
        public Hincha(string nombre, string apellido, int dni, DateTime nacimiento, 
            Sexo sexo, Club club, bool esSocio)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacimiento = nacimiento;
            this.Sexo = sexo;
            this.Activo = true;
            this.Club = club;
            this.dni = dni;
            this.EsSocio = esSocio;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime Nacimiento { get => nacimiento; set => nacimiento = value; }
        public Sexo Sexo { get => sexo; set => sexo = value; }
        public bool Activo { get => activo; set => activo = value; }
        public Club Club { get => club; set => club = value; }
        public int Dni { get => dni; set => dni = value; }
        public bool EsSocio { get => esSocio; set => esSocio = value; }

        /// <summary>
        /// sobrecarga del metodo ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string esSocioStr = this.esSocio ? "Si" : "No";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Hincha: ");
            sb.AppendLine($"Nombre: {this.nombre} ");
            sb.AppendLine($"Apellido: {this.apellido} ");
            sb.AppendLine($"Dni: {this.dni} ");
            sb.AppendLine($"Fecha de Nacimiento: {this.nacimiento.Date} ");
            sb.AppendLine($"Sexo: {this.sexo} ");
            sb.AppendLine($"Club: {this.club} ");
            sb.AppendLine($"Es socio: {esSocioStr} ");
            return sb.ToString();
        }
    }
}
