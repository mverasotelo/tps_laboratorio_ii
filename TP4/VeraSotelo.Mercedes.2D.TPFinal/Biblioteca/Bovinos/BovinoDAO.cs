using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Biblioteca
{
    public static class BovinoDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Constructor estático de la clase BovinoDAO que establece los datos de la conexión.
        /// </summary>
        static BovinoDAO()
        {   
            cadenaConexion = @"Data Source=.; Initial Catalog =ESTABLECIMIENTO ; Integrated Security = true";
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        /// <summary>
        /// Crea un registro de bovino en la base de datos, según el bovino pasado por parámetro
        /// </summary>
        /// <param name="bovino"></param>
        public static void Agregar(Bovino bovino)
        {
            try
            {
                comando.Parameters.Clear(); //HAY QUE LIMPIAR LOS PARAMETROS CUANDO TRABAJAMOS CON MIEMBROS ESTATICOS
                conexion.Open();
                comando.Parameters.AddWithValue("@fechaIngreso", bovino.FechaIngreso);
                comando.Parameters.AddWithValue("@sexo", bovino.Sexo.ToString());
                comando.Parameters.AddWithValue("@raza", bovino.Raza.ToString());
                comando.Parameters.AddWithValue("@uso", bovino.Uso.ToString());

                comando.CommandText = $"INSERT INTO BOVINOS (FECHA_INGRESO, SEXO, RAZA, USO) VALUES (@fechaIngreso, @sexo, @raza, @uso)";
                comando.ExecuteNonQuery();
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Debe ingresar un bovino válido");
            }
            catch (SqlException e) when (e.Number == 2627)
            {
                throw new AnimalExistenteException("El bovino ya se encuentra en la lista");
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
        /// Lee un registro de bovino de la base de datos, según el id pasado por parámetro
        /// </summary>
        /// <param name="codigoBovino"></param>
        /// <returns>Objeto bovino con datos de la base de datos</returns>
        public static Bovino LeerPorId(int codigoBovino)
        {
            Bovino bovino = null;
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "SELECT * FROM BOVINOS WHERE ID = @id";
                comando.Parameters.AddWithValue("@id", codigoBovino);
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    DateTime fecha = Convert.ToDateTime(dataReader["FECHA_INGRESO"].ToString());
                    Bovino.ESexo sexo = (Bovino.ESexo) Enum.Parse(typeof(Bovino.ESexo), dataReader["SEXO"].ToString());
                    Bovino.ERaza raza = (Bovino.ERaza)Enum.Parse(typeof(Bovino.ERaza), dataReader["RAZA"].ToString());
                    Bovino.EUso uso = (Bovino.EUso)Enum.Parse(typeof(Bovino.EUso), dataReader["USO"].ToString());

                    bovino = new Bovino(Convert.ToInt32(dataReader["ID"].ToString()), fecha, sexo , raza, uso);
                }

                if(bovino is not null)
                {
                    return bovino;
                }
                else
                {
                   throw new AnimalInexistenteException("El animal especificado no se encuentra en la lista");
                }
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
        /// Lista todos los bovinos existentes en la base de datos
        /// </summary>
        /// <returns>Lista de bovinos</returns>
        public static List<Bovino> ListarBovinos()
        {
            List<Bovino> bovinos = new List<Bovino>();
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM BOVINOS";
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    DateTime fecha = Convert.ToDateTime(dataReader["FECHA_INGRESO"].ToString());
                    Bovino.ESexo sexo = (Bovino.ESexo)Enum.Parse(typeof(Bovino.ESexo), dataReader["SEXO"].ToString());
                    Bovino.ERaza raza = (Bovino.ERaza)Enum.Parse(typeof(Bovino.ERaza), dataReader["RAZA"].ToString());
                    Bovino.EUso uso = (Bovino.EUso)Enum.Parse(typeof(Bovino.EUso), dataReader["USO"].ToString());

                    bovinos.Add(new Bovino(Convert.ToInt32(dataReader["ID"].ToString()), fecha, sexo, raza, uso));
                }
                return bovinos;
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
        /// Modifica el registro de bovino de la base de datos con el id pasado por parámetro
        /// </summary>
        /// <param name="codigoBovino"></param>
        /// <returns>Objeto bovino con datos de la base de datos</returns>
        public static void Modificar(Bovino bovino)
        {
            try
            {
                if(LeerPorId(bovino.Identificacion) is not null)
                {
                    comando.Parameters.Clear();
                    conexion.Open();
                    comando.Parameters.AddWithValue("@id", bovino.Identificacion);
                    comando.Parameters.AddWithValue("@fechaIngreso", bovino.FechaIngreso);
                    comando.Parameters.AddWithValue("@sexo", bovino.Sexo.ToString());
                    comando.Parameters.AddWithValue("@raza", bovino.Raza.ToString());
                    comando.Parameters.AddWithValue("@uso", bovino.Uso.ToString());

                    comando.CommandText = $"UPDATE BOVINOS SET FECHA_INGRESO = @fechaIngreso, SEXO = @sexo, RAZA = @raza, USO = @uso WHERE ID = @id";

                    comando.ExecuteNonQuery();
                }
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
        /// Elimina un registro de bovino de la base de datos, según el id identificado por parámetro
        /// </summary>
        /// <param name="codigoBovino"></param>
        public static void Eliminar(int codigoBovino)
        {
            try
            {
                if (LeerPorId(codigoBovino) is not null)
                {
                    comando.Parameters.Clear(); //HAY QUE LIMPIAR LOS PARAMETROS CUANDO TRABAJAMOS CON MIEMBROS ESTATICOS
                    conexion.Open();
                    comando.Parameters.AddWithValue("@id", codigoBovino);
                    comando.CommandText = $"DELETE FROM BOVINOS WHERE ID=@id";
                    comando.ExecuteNonQuery();
                }
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
        /// Obtiene el proximo ID a ser asignado
        /// </summary>
        /// <returns>Proximo ID</returns>
        public static int ObtenerProximoId()
        {
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT IDENT_CURRENT('BOVINOS') AS NEXT_ID;";
                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    return Convert.ToInt32(dataReader["NEXT_ID"]) + 1;
                }

                return -1;
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