using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Biblioteca
{
    public static class Archivos<T>
        where T: class
    {
        /// <summary>
        /// Carga datos desde un archivo json, cuya ruta se le pasa por parametro
        /// Se aplica lo aprendido en la clase 14 - Serializacion
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>Devuelve el archivo serialiazado al tipo de dato pasado como tipo genérico
        /// Si algo sale mal devuelve una excepción</returns>
        public static T CargarDatosDesdeJson(string ruta)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(ruta))
                {
                    return JsonSerializer.Deserialize<T>(streamReader.ReadToEnd());
                }
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException("No se ha encontrado el directorio", e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("No se ha encontrado el archivo", e);
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error", e);
            }
        }

        /// <summary>
        /// Exporta datos de determinado tipo de referencia a un archivo Json.
        /// Se aplica lo aprendido en la clase 14 - Serializacion
        /// Se manejan posibles excepciones.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="datos"></param>
        public static void ExportarDatosAJson(string ruta, T datos)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
                    jsonOptions.WriteIndented = true;

                    string contenidoJson = JsonSerializer.Serialize(datos, jsonOptions);
                    streamWriter.Write(contenidoJson);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException("No se ha encontrado el directorio", e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("No se ha encontrado el archivo", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("La ruta no puede estar vacía", e);
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error", e);
            }
        }

        /// <summary>
        /// Exporta datos de determinado tipo de referencia a un archivo Xml.
        /// Se aplica lo aprendido en la clase 14 - Serializacion
        /// Se manejan posibles excepciones.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="datos"></param>
        public static void ExportarDatosAXml(string ruta, T datos)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, datos);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException("No se ha encontrado el directorio", e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("No se ha encontrado el archivo", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("La ruta no puede estar vacía", e);
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error", e);
            }
        }

        /// <summary>
        /// Exporta datos de determinado tipo de referencia a un archivo Txt como string. 
        /// Se manejan posibles excepciones.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="datos"></param>
        public static void ExportarDatosATxt(string ruta, string datos)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    streamWriter.Write(datos);
                }
            }
            catch (DirectoryNotFoundException e)
            {
                throw new DirectoryNotFoundException("No se ha encontrado el directorio", e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("No se ha encontrado el archivo", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("La ruta no puede estar vacía", e);
            }
            catch(Exception e)
            {
                throw new Exception("Ha ocurrido un error", e);
            }
        }

        /// <summary>
        /// Valida que el archivo existe utilizando File.Exists().
        /// Se aplica lo aprendido en la clase 14 - Sistema de archivos
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>Devuelve true si existe y lanza una excepcion sino existe</returns>
        public static bool ValidarSiExisteElArchivo(string ruta)
        {
            if (File.Exists(ruta))
            {
                return true;
            }
            throw new FileNotFoundException();
        }
    }
}