using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    public static class Establecimiento
    {
        //atributo
        private static List<Bovino> stockGanadero;

        /// <summary>
        /// Constructor estatico para inicializar stockGanadero
        /// </summary>
        static Establecimiento()
        {
            stockGanadero = new List<Bovino>();
        }

        /// <summary>
        /// Propiedad de solo lectura Stock ganadero
        /// </summary>
        public static List<Bovino> StockGanadero
        {
            get
            {
                return stockGanadero;
            }
        }

        /// <summary>
        /// Agrega un animal a un lote de animales, utilizando la sobrecarga del operador == de la clase Animal
        /// </summary>
        /// <param name="bovino"></param>
        /// <returns>true si lo puedo agregar, false si el animal pasado por parametro es null 
        /// y una AnimalExistenteException si ya se encontraba en la lista</returns>
        public static bool AgregarAnimal(Bovino bovino)
        {
            if(bovino is not null)
            {
                if (!SeEncuentraEnElStock(bovino))
                {
                    stockGanadero.Add(bovino);
                    return true;
                }
                else
                {
                    throw new AnimalExistenteException("Ya existe un animal con la identificación ingresada");
                }
            }
            return false;
        }

        /// <summary>
        /// Elimina el animal pasado por parámetro del stock ganadero
        /// </summary>
        /// <param name="bovino"></param>
        /// <returns>Devuelve true si se puede eliminar, false si el animal era null o no se encontraba en la lista</returns>
        public static bool EliminarAnimal(Bovino bovino)
        {
            if (bovino is not null)
            {
                if (SeEncuentraEnElStock(bovino))
                {
                    stockGanadero.Remove(bovino);
                }
            }
            return false;
        }

        /// <summary>
        /// Modifica un animal de la lista de bovinos, reemplazando el original (con la misma identificacion) por el nuevo pasado por parámetro.
        /// </summary>
        /// <param name="bovinoModificado"></param>
        /// <returns>True si se pudo realizar la modificacion, false si algun objeto fue null o no se encuentra en la lista</returns>
        public static bool ModificarAnimal(Bovino bovinoModificado)
        {
            if (bovinoModificado is not null)
            {
                for (int i = 0; i < stockGanadero.Count; i++)
                {
                    if (stockGanadero[i] == bovinoModificado)
                    {
                        stockGanadero[i] = bovinoModificado;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Chequea si un bovino se encuentra en el stock ganadero.
        /// </summary>
        /// <param name="bovino"></param>
        /// <returns>True si se encuentra en el stock, false si no se encuentra</returns>
        private static bool SeEncuentraEnElStock(Bovino bovino)
        {
            foreach (Bovino b in stockGanadero)
            {
                if (b == bovino)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Lista bovinos segun el uso indicado por paramtro
        /// </summary>
        /// <param name="uso"></param>
        /// <returns>Devuelve lista de bovinos del uso indicado</returns>
        public static List<Bovino> ListarBovinosPorUso(Bovino.EUso uso)
        {
            List<Bovino> lista = new List<Bovino>();
            foreach (Bovino b in StockGanadero)
            {
                if (b.Uso == uso)
                {
                    lista.Add(b);
                }
            }
            return lista;
        }

        /// <summary>
        /// Devuelve un string ocn la informacion del establecimiento
        /// </summary>
        /// <returns>String con info del establecimiento</returns>
        public static string ImprimirStockGanadero()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"STOCK GANADERO ({stockGanadero.Count} cabezas)\n");
            foreach (Bovino b in stockGanadero)
            {
                sb.AppendLine(b.ToString());
            }
            return sb.ToString();
        }
    }
}
