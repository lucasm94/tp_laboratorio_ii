using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClubEstadistica
    {
        private Club nombre;
        private int totalHinchas;
        private int totalSocios;

        public ClubEstadistica(Club nombre, int totalHinchas, int totalSocios)
        {
            this.nombre = nombre;
            this.totalHinchas = totalHinchas;
            this.totalSocios = totalSocios;
        }

        public Club Nombre { get => nombre; }
        public int TotalHinchas { get => totalHinchas; }
        public int TotalSocios { get => totalSocios; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Club: {this.Nombre}");
            sb.AppendLine($"Hinchas Totales: {this.TotalHinchas}");
            sb.AppendLine($"Socios Totales: {this.TotalSocios}");
            return sb.ToString();
        }
    }
}
