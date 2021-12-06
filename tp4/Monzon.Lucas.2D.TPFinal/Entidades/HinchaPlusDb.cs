using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class HinchaPlusDb
    {
        private SqlConnection sqlConnection;

        public HinchaPlusDb()
        {
            sqlConnection = new SqlConnection("Server=.;Database=hincha_plus;Trusted_Connection=True;");
        }

        /// <summary>
        /// Devuelve todos los hinchas activos registrados.
        /// </summary>
        public List<Hincha> ObtenerHinchas()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.GET_HINCHAS, this.sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<Hincha> hinchas = new List<Hincha>();
                while (reader.Read())
                {
                    string nombre = reader["nombre"].ToString();
                    string apellido = reader["apellido"].ToString();
                    int dni = int.Parse(reader["dni"].ToString());
                    DateTime nacimiento = DateTime.Parse(reader["nacimiento"].ToString());
                    Sexo sexo = (Sexo)Enum.Parse(typeof(Sexo), reader["sexo"].ToString());
                    Club club = (Club)Enum.Parse(typeof(Club), reader["club"].ToString());
                    bool esSocio = reader.GetBoolean(reader.GetOrdinal("es_socio"));
                    Hincha hincha = new Hincha(nombre, apellido, dni, nacimiento, sexo, club, esSocio);
                    hinchas.Add(hincha);
                }
                reader.Close();
                return hinchas;
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar obtener los hinchas de la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Devuelve una lista con los clubes.
        /// </summary>
        public List<Club> ObtenerClubes()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.GET_CLUBES, this.sqlConnection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                List<Club> clubes = new List<Club>();
                while (reader.Read())
                {
                    Club club = (Club)Enum.Parse(typeof(Club), reader["nombre"].ToString());
                    clubes.Add(club);
                }
                reader.Close();
                return clubes;
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar obtener los clubes de la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Devuelve el hincha con el dni ingresado.
        /// </summary>
        /// <param name="dni"></param>
        public Hincha ObtenerHinchaDni(int dni)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.GET_HINCHA_POR_DNI, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("dni", dni);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                string nombre = reader["nombre"].ToString();
                string apellido = reader["apellido"].ToString();
                DateTime nacimiento = DateTime.Parse(reader["nacimiento"].ToString());
                Sexo sexo = (Sexo)Enum.Parse(typeof(Sexo), reader["sexo"].ToString());
                Club club = (Club)Enum.Parse(typeof(Club), reader["club"].ToString());
                bool esSocio = reader.GetBoolean(reader.GetOrdinal("es_socio"));
                Hincha hincha = new Hincha(nombre, apellido, dni, nacimiento, sexo, club, esSocio);
                reader.Close();
                return hincha;
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar obtener un hincha de la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Devuelve cantidad de hinchas activos.
        /// </summary>
        public int ObtenerCantidadDeHinchas()
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.GET_CANTIDAD_HINCHAS, this.sqlConnection);
                return int.Parse(sqlCommand.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar obtener total de hinchas de la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Devuelve si existe un hincha con ese dni.
        /// </summary>
        public bool ExisteHincha(int dni)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.EXISTE_HINCHA, this.sqlConnection);
                sqlCommand.Parameters.AddWithValue("dni", dni);
                int countRows = int.Parse(sqlCommand.ExecuteScalar().ToString());
                return countRows > 0;
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar obtener total de hinchas de la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Agrega un hincha.
        /// </summary>
        /// <param name="hincha"></param>
        public void AgregarHincha(Hincha hincha)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.AGREGAR_HINCHA, sqlConnection);
                sqlCommand.Parameters.AddWithValue("nombre", hincha.Nombre);
                sqlCommand.Parameters.AddWithValue("apellido", hincha.Apellido);
                sqlCommand.Parameters.AddWithValue("dni", hincha.Dni);
                sqlCommand.Parameters.AddWithValue("sexo", hincha.Sexo);
                sqlCommand.Parameters.AddWithValue("nacimiento", hincha.Nacimiento);
                sqlCommand.Parameters.AddWithValue("club", hincha.Club.ToString());
                sqlCommand.Parameters.AddWithValue("es_socio", hincha.EsSocio ? "1" : "0");
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar guardar un hincha a la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Actualiza un hincha.
        /// </summary>
        /// <param name="dni"></param>
        /// <param name="club"></param>
        /// <param name="esSocio"></param>
        public void ActualizarHincha(int dni, string club, bool esSocio)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.ACTUALIZAR_HINCHA, sqlConnection);
                sqlCommand.Parameters.AddWithValue("dni", dni);
                sqlCommand.Parameters.AddWithValue("club", club);
                sqlCommand.Parameters.AddWithValue("es_socio", esSocio ? "1" : "0");
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar actualizar un hincha en la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Baja logica de un Hincha.
        /// </summary>        
        /// <param name="dni"></param>
        public void BajaHincha(int dni)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(Queries.BAJA_HINCHA, sqlConnection);
                sqlCommand.Parameters.AddWithValue("dni", dni);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new HinchaPlusException($"Ocurrio un error al intentar dar de baja a un hincha en la base de datos: {ex.Message}");
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
