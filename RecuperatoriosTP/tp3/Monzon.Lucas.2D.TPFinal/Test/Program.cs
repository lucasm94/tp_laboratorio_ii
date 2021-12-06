using Entidades;
using System;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            HinchaPlusServicio hinchaPlus = new HinchaPlusServicio();
            Console.WriteLine("Hincha Plus!!!\n");
            Console.WriteLine("Hinchas antes de leer un archivo con hinchas\n");
            Console.WriteLine($"Hinchas cargados: {hinchaPlus.Hinchas.Count}\n");
            Console.WriteLine("Estadisticas totales: \n");
            foreach (ClubEstadistica item in hinchaPlus.HinchasTotales())
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("Empieza la carga de hinchas\n");
            Hincha hincha = new Hincha("Juan", "Pedro", 30443123, DateTime.Parse("2/04/1998"), 
                Sexo.Masculino, Club.Boca, true);
            Hincha hinchaRacing = new Hincha("Diego", "Ramirez", 2544027, DateTime.Parse("22/06/1987"),
                Sexo.Masculino, Club.Racing, true);
            Hincha hinchaRiver = new Hincha("Marcelo", "Dominguez", 90441192, DateTime.Parse("11/07/1968"),
                Sexo.Masculino, Club.River, false);
            hinchaPlus.CargarHincha(hincha);
            hinchaPlus.CargarHincha(hinchaRacing);
            hinchaPlus.CargarHincha(hinchaRiver);
            Console.WriteLine("finalizo la carga de hinchas\n");
            Console.WriteLine($"Hinchas cargados: {hinchaPlus.Hinchas.Count}\n");
            Console.WriteLine("Estadisticas totales: \n");
            foreach (ClubEstadistica item in hinchaPlus.HinchasTotales())
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("Actualizo hincha de Racing dejando de ser socio\n");
            hinchaPlus.ActualizarHincha(hinchaRacing.Dni, hinchaRacing.Club, false);
            Console.WriteLine("Estadisticas totales: \n");
            foreach (ClubEstadistica item in hinchaPlus.HinchasTotales())
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("Doy de baja a hincha de River: \n");
            hinchaPlus.BajaHincha(hinchaRiver.Dni);
            foreach (ClubEstadistica item in hinchaPlus.HinchasTotales())
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine("-Presione una tecla para finalizar-");
            Console.ReadKey();
        }
    }
}
