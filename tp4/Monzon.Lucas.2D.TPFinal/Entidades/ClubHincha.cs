using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClubHincha
    {
        private Club nombre;
        private int hinchasTotales;
        private int hinchasTotalesMayores;
        private int hinchasTotalesMenores;
        private int hinchasTotalesMasculinos;
        private int hinchasTotalesFemeninos;
        private int hinchasTotalesOtros;
        private int hinchasTotalesSocios;
        private int sociosMayores;
        private int sociosMasculinos;
        private int sociosFemeninos;


        /// <summary>
        /// Constructor de la clase ClubHincha con atributo nombre del club
        /// </summary>
        /// <param name="nombre"></param>
        public ClubHincha(Club nombre)
        {
            this.nombre = nombre;
        }

        public Club Nombre { get => nombre; set => nombre = value; }
        public int CantidadHinchas { get => hinchasTotales; set => hinchasTotales = value; }
        public int HinchasTotalesMayores { get => hinchasTotalesMayores; set => hinchasTotalesMayores = value; }
        public int HinchasTotalesMenores { get => hinchasTotalesMenores; set => hinchasTotalesMenores = value; }
        public int HinchasTotalesMasculinos { get => hinchasTotalesMasculinos; set => hinchasTotalesMasculinos = value; }
        public int HinchasTotalesFemeninos { get => hinchasTotalesFemeninos; set => hinchasTotalesFemeninos = value; }
        public int HinchasTotalesOtros { get => hinchasTotalesOtros; set => hinchasTotalesOtros = value; }
        public int HinchasTotalesSocios { get => hinchasTotalesSocios; set => hinchasTotalesSocios = value; }
        public int SociosMayores { get => sociosMayores; set => sociosMayores = value; }
        public int SociosMasculinos { get => sociosMasculinos; set => sociosMasculinos = value; }
        public int SociosFemeninos { get => sociosFemeninos; set => sociosFemeninos = value; }

        /// <summary>
        /// sobrecarga del metodo ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Club: ");
            sb.AppendLine($"Nombre: {this.nombre} ");
            sb.AppendLine($"Hinchas totales: {this.hinchasTotales} ");
            sb.AppendLine($"Hinchas mayores: {this.hinchasTotalesMayores} ");
            sb.AppendLine($"Hinchas menores: {this.hinchasTotalesMenores} ");
            sb.AppendLine($"Hinchas masculinos: {this.hinchasTotalesMasculinos} ");
            sb.AppendLine($"Hinchas femeninos: {this.hinchasTotalesFemeninos} ");
            sb.AppendLine($"Hinchas otros: {this.hinchasTotalesOtros} ");
            sb.AppendLine($"Socios: {this.hinchasTotalesSocios} ");
            return sb.ToString();
        }
    }
}
