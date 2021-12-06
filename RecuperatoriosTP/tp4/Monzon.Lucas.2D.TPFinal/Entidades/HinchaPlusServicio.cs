using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoHinchaPlus();
    public class HinchaPlusServicio
    {
        private List<ClubHincha> clubesHinchas;
        private Json<List<Hincha>> json;
        private HinchaPlusDb hinchaPlusDb;

        /// <summary>
        /// Constructor de la clase HinchaPlus
        /// </summary>
        public HinchaPlusServicio()
        {
            this.hinchaPlusDb = new HinchaPlusDb();
            this.json = new Json<List<Hincha>>();
            this.clubesHinchas = new List<ClubHincha>();
            InicializarClubes();
            InicializarHinchasYActualizarEstadisticas();
        }

        /// <summary>
        /// Inicializa lista con los hinchas.
        /// </summary>
        private void InicializarHinchasYActualizarEstadisticas()
        {
            foreach (Hincha hincha in this.hinchaPlusDb.ObtenerHinchas())
            {
                this.ActualizarEstadisticasAltaOBaja(hincha.Nacimiento.EsMayor(), 
                    hincha, 1);
            }
        }

        /// <summary>
        /// Inicializa lista con los clubes.
        /// </summary>
        private void InicializarClubes()
        {
            foreach (Club club in this.hinchaPlusDb.ObtenerClubes())
            {
                this.clubesHinchas.Add(new ClubHincha(club));
            }
        }

        /// <summary>
        /// Devuelve la cantidad de hinchas activos.
        /// </summary>
        public int HinchasActivos()
        {
            return this.hinchaPlusDb.ObtenerCantidadDeHinchas();
        }

        /// <summary>
        /// Devuelve el hincha buscado por dni.
        /// </summary>
        /// <param name="dni"></param>
        public Hincha ObtenerHinchaPorDni(int dni)
        {
            try
            {
                return this.hinchaPlusDb.ObtenerHinchaDni(dni);
            }
            catch (HinchaPlusException ex)
            {
                throw new HinchaPlusException("Hincha no encontrado");
            }

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
            if (!this.hinchaPlusDb.ExisteHincha(hincha.Dni))
            {
                this.hinchaPlusDb.AgregarHincha(hincha);
                bool esMayor = hincha.Nacimiento.EsMayor();
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
        /// <param name="hincha"></param>
        /// <param name="clubNuevo"></param>
        /// <param name="esSocioNuevo"></param>
        public void ActualizarHincha(Hincha hincha, Club clubNuevo, bool esSocioNuevo)
        {
            if (this.hinchaPlusDb.ExisteHincha(hincha.Dni))
            {
                this.hinchaPlusDb.ActualizarHincha(hincha.Dni, clubNuevo.ToString(), esSocioNuevo);
                bool esMayor = hincha.Nacimiento.EsMayor();
                if (!hincha.Club.Equals(clubNuevo))
                {
                    ActualizarEstadisticasAltaOBaja(esMayor, hincha, -1);
                    hincha.Club = clubNuevo;
                    ActualizarEstadisticasAltaOBaja(esMayor, hincha, 1);
                } else
                {
                    int suma = esSocioNuevo ? 1 : -1;
                    hincha.EsSocio = esSocioNuevo;
                    ActualizarEstadisticasSoloSocio(esMayor, hincha, suma);
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
        /// <param name="hincha"></param>
        public void BajaHincha(Hincha hincha)
        {
            if (this.hinchaPlusDb.ExisteHincha(hincha.Dni))
            {
                bool esMayor = hincha.Nacimiento.EsMayor();
                this.hinchaPlusDb.BajaHincha(hincha.Dni);
                ActualizarEstadisticasAltaOBaja(esMayor, hincha, -1);
            }
            else
            {
                throw new HinchaPlusException("No existe un hincha con ese DNI");
            }
        }

        /// <summary>
        /// Guardar de clase serializará los datos de los hinchas en un json
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>true si pudo guardar</returns>
        public void Guardar(string ruta)
        {
            this.json.Guardar(ruta, this.hinchaPlusDb.ObtenerHinchas());
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
                if (!this.hinchaPlusDb.ExisteHincha(hinchaNuevo.Dni))
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
