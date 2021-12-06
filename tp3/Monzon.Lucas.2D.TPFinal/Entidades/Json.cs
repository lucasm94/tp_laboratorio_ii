using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Entidades
{
    public class Json<T>: IArchivo<T>
    {

        /// <summary>
        /// Guardar datos en un archivo json,
        /// si hay algun error, se lanza la excepcion ArchivosException
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public void Guardar(string path, T datos)
        {
            StreamWriter streamWriter = null;

            try
            {
                Serializar(path, datos);

            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al guardar el archivo", e);
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Close();
                }
            }


        }


        /// <summary>
        /// método que permite leer el contenido de un archivo y deserializarlo utilizando el método Deserialize() de la lclase JsonSerializer
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>devuelve el contenido del archivo </returns>
        public T Leer(string path)
        {
   
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(path);

                string json = streamReader.ReadToEnd();
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer el archivo", e);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Close();
                }
            }

        }

        /// <summary>
        /// método que permite serializar un objeto genérico a json utilizando el metodo Serialize() de JsomSerializer
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        private void Serializar(string path, T datos)
        {
            using (StreamWriter stw = new StreamWriter(path))
            {
                string json = JsonSerializer.Serialize(datos);
                stw.Write(json);
            }
        }

    }
}
