using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HinchaPlusServicio
    {
        private List<ClubHincha> clubesHinchas;
        private List<Hincha> hinchas;
        private Json<List<Hincha>> json;

        /// <summary>
        /// Constructor de la clase HinchaPlus
        /// </summary>
        public HinchaPlusServicio()
        {
            this.hinchas = new List<Hincha>();
            this.json = new Json<List<Hincha>>();
            this.clubesHinchas = InicializarClubes();
        }

        /// <summary>
        /// Inicializa lista con los clubes.
        /// </summary>
        private List<ClubHincha> InicializarClubes()
        {
            List<ClubHincha> clubesHinchas = new List<ClubHincha>();
            clubesHinchas.Add(new ClubHincha(Club.Boca));
            clubesHinchas.Add(new ClubHincha(Club.River));
            clubesHinchas.Add(new ClubHincha(Club.Racing));
            clubesHinchas.Add(new ClubHincha(Club.Independiente));
            clubesHinchas.Add(new ClubHincha(Club.San_Lorenzo));
            clubesHinchas.Add(new ClubHincha(Club.Otro));
            return clubesHinchas;
        }

        public List<Hincha> Hinchas { get => hinchas; set => hinchas = value; }

        /// <summary>
        /// Devuelve la cantidad de hinchas activos.
        /// </summary>
        public int HinchasActivos()
        {
            int contador = 0;
            foreach (Hincha hincha in this.hinchas)
            {
                if (hincha.Activo)
                {
                    contador++;
                }
            }
            return contador;
        }

        /// <summary>
        /// Devuelve el hincha buscado por dni.
        /// </summary>
        /// <param name="dni"></param>
        public Hincha ObtenerHinchaPorDni(int dni)
        {
            int hinchaBuscado = ExisteHinchaIndex(dni);
            if (hinchaBuscado == -1)
            {
                throw new HinchaPlusException("Hincha no encontrado");
            }
            return this.hinchas[hinchaBuscado];
        }

        /// <summary>
        /// Devuelve el indice del hincha con ese dni, sino retorna -1
        /// </summary>
        /// <param name="dni"></param>
        private int ExisteHinchaIndex(int dni)
        {
            int index = -1;
            for (int i = 0; i < this.hinchas.Count; i++)
            {
                if (dni == this.hinchas[i].Dni)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        /// <summary>
        /// Devuelve el indice del club con ese nombre
        /// </summary>
        /// <param name="club"></param>
        private int IndiceClubes(string club)
        {
            int index = 0;
            while(!club.Equals(this.clubesHinchas[index].Nombre.ToString())) {
                index++;
            }
            return index;
        }

        /// <summary>
        /// Agrega el hincha pasado como parametro.
        /// Actualiza las estadisticas ClubHincha.
        /// </summary>
        /// <param name="hincha"></param>
        public void CargarHincha(Hincha hincha)
        {
            int hinchaBuscado = ExisteHinchaIndex(hincha.Dni);
            if (hinchaBuscado < 0)
            {
                this.hinchas.Add(hincha);
                bool esMayor = EsMayor(hincha.Nacimiento);
                ActualizarEstadisticasAltaOBaja(esMayor, hincha, 1);
            } else
            {
                throw new HinchaPlusException("Ya existe un hincha con ese DNI");
            }
        }

        /// <summary>
        /// Actualiza las estadisticas del club del hincha.
        /// </summary>
        /// <param name="esMayor"></param>
        /// <param name="hincha"></param>
        /// <param name="valor"></param>
        private void ActualizarEstadisticasAltaOBaja(bool esMayor, Hincha hincha, int valor)
        {
            int indice = IndiceClubes(hincha.Club.ToString());
            this.clubesHinchas[indice].CantidadHinchas += valor;
            if (hincha.EsSocio)
            {
                this.clubesHinchas[indice].HinchasTotalesSocios += valor;
                if (hincha.Sexo.Equals(Sexo.Masculino))
                {
                    this.clubesHinchas[indice].SociosMasculinos += valor;
                }
                else if (hincha.Sexo.Equals(Sexo.Femenino))
                {
                    this.clubesHinchas[indice].SociosFemeninos += valor;
                }
                if (esMayor)
                {
                    this.clubesHinchas[indice].SociosMayores += valor;
                }
            }
            if (hincha.Sexo.Equals(Sexo.Masculino))
            {
                this.clubesHinchas[indice].HinchasTotalesMasculinos += valor;
            }
            else if (hincha.Sexo.Equals(Sexo.Femenino))
            {
                this.clubesHinchas[indice].HinchasTotalesFemeninos += valor;
            }
            else
            {
                this.clubesHinchas[indice].HinchasTotalesOtros += valor;
            }
            if (esMayor)
            {
                this.clubesHinchas[indice].HinchasTotalesMayores += valor;
            }
            else
            {
                this.clubesHinchas[indice].HinchasTotalesMenores += valor;
            }
        }

        /// <summary>
        /// Actualiza las estadisticas del club del hincha.
        /// </summary>
        /// <param name="esMayor"></param>
        /// <param name="hincha"></param>
        /// <param name="valor"></param>
        private void ActualizarEstadisticasSoloSocio(bool esMayor, Hincha hincha, int valor)
        {
            int indice = IndiceClubes(hincha.Club.ToString());
            this.clubesHinchas[indice].HinchasTotalesSocios += valor;
            if (hincha.Sexo.Equals(Sexo.Masculino))
            {
                this.clubesHinchas[indice].SociosMasculinos += valor;
            } else if (hincha.Sexo.Equals(Sexo.Femenino))
            {
                this.clubesHinchas[indice].SociosFemeninos += valor;
            }
            if (esMayor)
            {
                this.clubesHinchas[indice].SociosMayores += valor;
            }
        }

        /// <summary>
        /// Actualiza el club del hincha buscado por dni y si es socio.
        /// Actualiza las estadisticas ClubHincha.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="clubNuevo"></param>
        /// <param name="esSocio"></param>
        public void ActualizarHincha(int dni, Club clubNuevo, bool esSocio)
        {
            int hinchaBuscadoIndex = ExisteHinchaIndex(dni);
            if (hinchaBuscadoIndex > -1)
            {
                bool esMayor = EsMayor(this.hinchas[hinchaBuscadoIndex].Nacimiento);
                if (!this.hinchas[hinchaBuscadoIndex].Club.Equals(clubNuevo))
                {
                    ActualizarEstadisticasAltaOBaja(esMayor, this.hinchas[hinchaBuscadoIndex], -1);
                    this.hinchas[hinchaBuscadoIndex].Club = clubNuevo;
                    ActualizarEstadisticasAltaOBaja(esMayor, this.hinchas[hinchaBuscadoIndex], 1);
                } else
                {
                    int suma = esSocio ? 1 : -1;
                    this.hinchas[hinchaBuscadoIndex].EsSocio = esSocio;
                    ActualizarEstadisticasSoloSocio(esMayor, this.hinchas[hinchaBuscadoIndex], suma);
                }
            }
            else
            {
                throw new HinchaPlusException("Ya existe un hincha con ese DNI");
            }
        }

        /// <summary>
        /// Actualiza un hincha como inactivo.
        /// Actualiza las estadisticas ClubHincha.
        /// </summary>
        /// <param name="dni"></param>
        public void BajaHincha(int dni)
        {
            int hinchaBuscadoIndex = ExisteHinchaIndex(dni);
            if (hinchaBuscadoIndex > -1)
            {
                Hincha hincha = this.hinchas[hinchaBuscadoIndex];
                bool esMayor = EsMayor(hincha.Nacimiento);
                int indice = IndiceClubes(hincha.Club.ToString());
                ActualizarEstadisticasAltaOBaja(esMayor, hincha, -1);
                hincha.Activo = false;
            }
            else
            {
                throw new HinchaPlusException("No existe un hincha con ese DNI");
            }
        }

        private bool EsMayor(DateTime nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            return edad > 17;
        }

        /// <summary>
        /// Guardar de clase serializará los datos de los hinchas en un json
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>true si pudo guardar</returns>
        public void Guardar(string ruta)
        {
            this.json.Guardar(ruta, this.Hinchas);
        }

        /// <summary>
        /// Leer de clase retornará lista de hinchas con todos los datos previamente serializados.
        /// </summary>
        /// <returns>lista</returns>
        public void Leer(string path)
        {
            bool agrego = false;
            List<Hincha> hinchasNuevos = this.json.Leer(path);
            foreach (Hincha hinchaNuevo in hinchasNuevos)
            {
                if (ExisteHinchaIndex(hinchaNuevo.Dni) < 0)
                {
                    this.CargarHincha(hinchaNuevo);
                    agrego = true;
                }
            }
            if (!agrego)
            {
                throw new HinchaPlusException("No se agregaron nuevos hinchas, ya existian con los mismos dni.");
            }
        }

        /// <summary>
        /// Devuelve una lista de ClubHincha con las estadisticas de los hinchas mayores de edad por club.
        /// </summary>
        /// <returns>lista</returns>
        public List<ClubEstadistica> HinchasTotales()
        {
            List<ClubEstadistica> hinchasTotales = new List<ClubEstadistica>();
            foreach (ClubHincha item in this.clubesHinchas)
            {
                hinchasTotales.Add(new ClubEstadistica(item.Nombre, item.CantidadHinchas, 
                    item.HinchasTotalesSocios));
            }
            return hinchasTotales;
        }

        /// <summary>
        /// Devuelve una lista de ClubHincha con las estadisticas de los hinchas mayores de edad por club.
        /// </summary>
        /// <returns>lista</returns>
        public List<ClubEstadistica> HinchasMayores()
        {
            List<ClubEstadistica> mayoresDeEdad = new List<ClubEstadistica>();
            foreach (ClubHincha item in this.clubesHinchas)
            {
                mayoresDeEdad.Add(new ClubEstadistica(item.Nombre, item.HinchasTotalesMayores,
                    item.SociosMayores));
            }
            return mayoresDeEdad;
        }

        /// <summary>
        /// Devuelve una lista de ClubHincha con las estadisticas de los hinchas menores de edad por club.
        /// </summary>
        /// <returns>lista</returns>
        public List<ClubEstadistica> HinchasMenores()
        {
            List<ClubEstadistica> menoresDeEdad = new List<ClubEstadistica>();
            foreach (ClubHincha item in this.clubesHinchas)
            {
                menoresDeEdad.Add(new ClubEstadistica(item.Nombre, item.HinchasTotalesMenores,
                    item.HinchasTotalesSocios - item.SociosMayores));
            }
            return menoresDeEdad;
        }

        /// <summary>
        /// Devuelve una lista de ClubHincha con las estadisticas de los hinchas masculinos por club.
        /// </summary>
        /// <returns>lista</returns>
        public List<ClubEstadistica> HinchasMasculinos()
        {
            List<ClubEstadistica> masculinos = new List<ClubEstadistica>();
            foreach (ClubHincha item in this.clubesHinchas)
            {
                masculinos.Add(new ClubEstadistica(item.Nombre, item.HinchasTotalesMasculinos,
                    item.SociosMasculinos));
            }
            return masculinos;
        }

        /// <summary>
        /// Devuelve una lista de ClubHincha con las estadisticas de los hinchas femeninos por club.
        /// </summary>
        /// <returns>lista</returns>
        public List<ClubEstadistica> HinchasFemeninos()
        {
            List<ClubEstadistica> femeninos = new List<ClubEstadistica>();
            foreach (ClubHincha item in this.clubesHinchas)
            {
                femeninos.Add(new ClubEstadistica(item.Nombre, item.HinchasTotalesFemeninos,
                    item.SociosFemeninos));
            }
            return femeninos;
        }

        /// <summary>
        /// Devuelve una lista de ClubHincha con las estadisticas de los hinchas que no se reconocen M/F por club.
        /// </summary>
        /// <returns>lista</returns>
        public List<ClubEstadistica> HinchasOtros()
        {
            List<ClubEstadistica> otros = new List<ClubEstadistica>();
            foreach (ClubHincha item in this.clubesHinchas)
            {
                otros.Add(new ClubEstadistica(item.Nombre, item.HinchasTotalesOtros,
                    item.HinchasTotalesSocios - (item.SociosMasculinos + item.SociosFemeninos)));
            }
            return otros;
        }
    }
}
