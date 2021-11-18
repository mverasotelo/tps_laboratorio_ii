using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class EstadisticasDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Constructor estático de la clase EstadisticasDAO que establece los datos de la conexión.
        /// </summary>
        static EstadisticasDAO()
        {
            cadenaConexion = @"Data Source=.; Initial Catalog =ESTABLECIMIENTO ; Integrated Security = true";
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        /// <summary>
        /// Crea un registro de estadistica en la base de datos, según el objeto pasado por parámetro. 
        /// Si la estadística de la fecha ya está cargada, la actualiza.
        /// </summary>
        /// <param name="estadistica"></param>
        public static void Agregar(EstadisticaHistorica estadistica)
        {
            try
            {
                comando.Parameters.Clear(); //HAY QUE LIMPIAR LOS PARAMETROS CUANDO TRABAJAMOS CON MIEMBROS ESTATICOS
                conexion.Open();
                comando.Parameters.AddWithValue("@totalAnimales", estadistica.CantidadAnimales);
                comando.Parameters.AddWithValue("@totalTambo", estadistica.CantidadAnimalesTambo);
                comando.Parameters.AddWithValue("@totalEngorde", estadistica.CantidadAnimalesEngorde);
                comando.Parameters.AddWithValue("@produccionTambo", estadistica.LecheProducidaAnual);
                comando.Parameters.AddWithValue("@produccionCarne", estadistica.CarneProducidaAnual);
                comando.Parameters.AddWithValue("@bovinoMasProductivoTambo", estadistica.BovinoMasProductivoTambo);

                comando.CommandText = $"INSERT INTO ESTADISTICAS (FECHA, TOTAL_ANIMALES, TOTAL_TAMBO, TOTAL_ENGORDE, LECHE_PRODUCIDA, CARNE_PRODUCIDA, BOVINO_MAS_PRODUCTIVO_TAMBO) " +
                    $"VALUES (GETDATE(), @totalAnimales, @totalTambo, @totalEngorde, @produccionTambo, @produccionCarne, @bovinoMasProductivoTambo)";
                comando.ExecuteNonQuery();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Debe ingresar una estadística válida");
            }
            catch (SqlException e) when (e.Number == 2627)
            {
                Actualizar(estadistica);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        /// <summary>
        /// Modifica el registro de estadistica de la base de datos con el id pasado por parámetro. 
        /// Es privado porque solo lo utiliza la clase Agregar ante una excepción de tipo UniqueKeyViolation 
        /// </summary>
        /// <param name="estadistica"></param>
        private static void Actualizar(EstadisticaHistorica estadistica)
        {

            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("@fecha", estadistica.Fecha);
            comando.Parameters.AddWithValue("@totalAnimales", estadistica.CantidadAnimales);
            comando.Parameters.AddWithValue("@totalTambo", estadistica.CantidadAnimalesTambo);
            comando.Parameters.AddWithValue("@totalEngorde", estadistica.CantidadAnimalesEngorde);
            comando.Parameters.AddWithValue("@produccionTambo", estadistica.LecheProducidaAnual);
            comando.Parameters.AddWithValue("@produccionCarne", estadistica.CarneProducidaAnual);
            comando.Parameters.AddWithValue("@bovinoMasProductivoTambo", estadistica.BovinoMasProductivoTambo);

            comando.CommandText = $"UPDATE ESTADISTICAS SET TOTAL_ANIMALES = @totalAnimales, TOTAL_TAMBO = @totalTambo, " +
                $"TOTAL_ENGORDE=@totalEngorde, LECHE_PRODUCIDA=@produccionTambo, CARNE_PRODUCIDA=@produccionCarne, BOVINO_MAS_PRODUCTIVO_TAMBO=@bovinoMasProductivoTambo  WHERE FECHA = @fecha";
            comando.ExecuteNonQuery();
        }

        /// <summary>
        /// Lista todas las estadisticas existentes en la base de datos
        /// </summary>
        /// <returns>Lista de estadisticas historicas</returns>
        public static List<EstadisticaHistorica> ListarEstadisticas()
        {
            List<EstadisticaHistorica> estadisticasHistoricas = new List<EstadisticaHistorica>();

            try
            {
                conexion.Open();
                comando.CommandText = "SELECT FECHA, TOTAL_ANIMALES, TOTAL_TAMBO, TOTAL_ENGORDE, LECHE_PRODUCIDA, CARNE_PRODUCIDA, BOVINO_MAS_PRODUCTIVO_TAMBO, RAZA AS RAZA_BOVINO_MAS_PRODUCTIVO FROM ESTADISTICAS JOIN BOVINOS ON BOVINO_MAS_PRODUCTIVO_TAMBO = ID";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    DateTime fecha = Convert.ToDateTime(dataReader["FECHA"].ToString());
                    int cantidadBovinos = int.Parse(dataReader["TOTAL_ANIMALES"].ToString());
                    int cantidadTambo = int.Parse(dataReader["TOTAL_TAMBO"].ToString());
                    int cantidadEngorde = int.Parse(dataReader["TOTAL_ENGORDE"].ToString());
                    float lecheProducida = float.Parse(dataReader["LECHE_PRODUCIDA"].ToString());
                    float carneProducida = float.Parse(dataReader["CARNE_PRODUCIDA"].ToString());
                    int bovinoMasProductivoTambo = int.Parse(dataReader["BOVINO_MAS_PRODUCTIVO_TAMBO"].ToString());
                    string razaBovinoTambo = dataReader["RAZA_BOVINO_MAS_PRODUCTIVO"].ToString();


                    estadisticasHistoricas.Add(new EstadisticaHistorica(fecha, cantidadBovinos,cantidadTambo,cantidadEngorde, lecheProducida, carneProducida,bovinoMasProductivoTambo, razaBovinoTambo));
                }

                return estadisticasHistoricas;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
