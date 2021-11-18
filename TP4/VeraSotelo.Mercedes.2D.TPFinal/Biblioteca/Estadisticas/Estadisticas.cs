using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca
{
    public class Estadisticas
    {
        protected int cantidadAnimales;
        protected int cantidadAnimalesTambo;
        protected int cantidadAnimalesEngorde;
        protected float lecheProducida;
        protected float carneProducida;
        protected string razaMasProductivaCarne;
        protected string razaMasProductivaTambo;
        protected int animalMasProductivoTambo;
        protected int animalMasProductivoCarne;
        protected string razaBovinoMasProductivoTambo;

        /// <summary>
        /// Constructor publico sin parámetros para serialización y para setear la cantidad de animales total, para tambo y engorde, según los datos de la clase Establecimiento.
        /// </summary>
        public Estadisticas()
        {
            cantidadAnimales = Establecimiento.StockGanadero.Count;
            cantidadAnimalesTambo = Establecimiento.ListarBovinosPorUso(Bovino.EUso.Tambo).Count;
            cantidadAnimalesEngorde = Establecimiento.ListarBovinosPorUso(Bovino.EUso.Engorde).Count;
        }

        #region Propiedades

        /// <summary>
        /// Propiedad lectura-escritura de la cantidad de animales del establecimiento
        /// </summary>
        public int CantidadAnimales
        {
            get
            {
                return cantidadAnimales;
            }
            set
            {
                cantidadAnimales = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura la cantidad de animales para tambo del establecimiento
        /// </summary>
        public int CantidadAnimalesTambo
        {
            get
            {
                return cantidadAnimalesTambo;
            }
            set
            {
                cantidadAnimalesTambo = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura la cantidad de animales para engorde del establecimiento
        /// </summary>
        public int CantidadAnimalesEngorde
        {
            get
            {
                return cantidadAnimalesEngorde;
            }
            set
            {
                cantidadAnimalesEngorde = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura que devuelve el total de leche producida en el ultimo año, utilizando el metodo CalcularProduccionUltimoAnio
        /// </summary>
        public virtual float LecheProducidaAnual
        {
            get
            {
                return CalcularProduccionUltimoAnio(Bovino.EUso.Tambo);
            }
            set
            {
                lecheProducida = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura que devuelve el total de carne producida en el ultimo año, utilizando el metodo CalcularProduccionUltimoAnio
        /// </summary>
        public virtual float CarneProducidaAnual
        {
            get
            {
                return CalcularProduccionUltimoAnio(Bovino.EUso.Engorde);
            }
            set
            {
                carneProducida = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura que devuelve la raza historicamente mas productiva para tambo
        /// </summary>
        public virtual string RazaMasProductivaTambo
        {
            get
            {
                return CalcularRazaMasProductiva(Bovino.EUso.Engorde);
            }
            set
            {
                razaMasProductivaTambo = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura que devuelve la raza historicamente mas productiva para carne
        /// </summary>
        public virtual string RazaMasProductivaCarne
        {
            get
            {
                return CalcularRazaMasProductiva(Bovino.EUso.Engorde);
            }
            set
            {
                razaMasProductivaCarne = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura que devuelve el bovino mas productivo para tambo
        /// </summary>
        public virtual int BovinoMasProductivoTambo
        {
            get
            {
                return CalcularBovinoMasProductivo(Bovino.EUso.Tambo);
            }
            set
            {
                BovinoMasProductivoTambo = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura que devuelve el bovino mas productivo para carne
        /// </summary>
        public virtual int BovinoMasProductivoCarne
        {
            get
            {
                return CalcularBovinoMasProductivo(Bovino.EUso.Engorde);
            }
            set
            {
                BovinoMasProductivoCarne = value;
            }
        }

        #endregion

        #region Métodos y sobrecargas

        /// <summary>
        /// Calcula el porcentaje de bovinos sobre el total segun el numero pasado por parametro.
        /// </summary>
        /// <param name="numeroBovinos"></param>
        /// <returns>Porcentaje del sexo indicado></returns>
        public float CalcularPorcentaje(int numeroBovinos)
        {
            return (float)(numeroBovinos * 100) / cantidadAnimales;
        }

        /// <summary>
        /// Calcula la producción en el establecimiento segun tipo de producción (tambo/engorde), 
        /// sumando la produccion de las vacas del rubro pasado por parametro.
        /// </summary>
        /// <returns>Devuelve cantidad de leche/carne producida en litros/kilos</returns>
        private float CalcularProduccionUltimoAnio(Bovino.EUso tipoProduccion)
        {
            float totalProducido = 0;
            foreach (Bovino b in Establecimiento.ListarBovinosPorUso(tipoProduccion))
            {
                if (b.FechaIngreso.CalcularPermanenciaEnDias() > 365)
                {
                    totalProducido += b.ProduccionDiariaPromedio * 365; ;
                }
                else
                {
                    totalProducido += b.ProduccionDiariaPromedio * b.FechaIngreso.CalcularPermanenciaEnDias();
                }
            }
            return totalProducido;
        }

        /// <summary>
        /// Calcular la raza mas productiva del uso especificado por parametro
        /// </summary>
        /// <param name="uso"></param>
        /// <returns>Devuelve un string de la raza</returns>
        private string CalcularRazaMasProductiva(Bovino.EUso uso)
        {
            Dictionary<string, float> razas = new Dictionary<string, float>();
            string razaMasProductiva = String.Empty;
            float sumador = 0F;

            foreach (Bovino b in Establecimiento.ListarBovinosPorUso(uso))
            {

                if (!razas.ContainsKey(b.Raza.ToString()))
                {
                    razas.Add(b.Raza.ToString(), b.ProduccionDiariaPromedio * b.FechaIngreso.CalcularPermanenciaEnDias());
                }
                else
                {
                    razas[b.Raza.ToString()] += b.ProduccionDiariaPromedio * b.FechaIngreso.CalcularPermanenciaEnDias();
                }
            }

            foreach (KeyValuePair<string, float> r in razas)
            {
                if (r.Value > sumador)
                {
                    razaMasProductiva = r.Key;
                    sumador = r.Value;
                }
            }

            if (!String.IsNullOrEmpty(razaMasProductiva))
            {
                return razaMasProductiva;
            }
            else
            {
                return "No existen animales";
            }
        }

        /// <summary>
        /// Calcula el bovino que tiene un mayor promedio de producción diaria
        /// </summary>
        /// <param name="uso"></param>
        /// <returns>Devuelve el id del bovino con una mayor produccion diaria, si la lista es es null o esta vacia devuelve -1</returns>
        public int CalcularBovinoMasProductivo(Bovino.EUso uso)
        {
            int idBovinoMasProductivo = -1;
            List<Bovino> listaAuxiliar = Establecimiento.ListarBovinosPorUso(uso);

            if (listaAuxiliar is not null && listaAuxiliar.Count > 0)
            {
                if(uso == Bovino.EUso.Engorde) //lo multiplico por 100 para que devuelva un numero entero diferente de 1 y se ordenen
                {
                    listaAuxiliar.Sort((b1, b2) => (int)(b2.ProduccionDiariaPromedio*100 - b1.ProduccionDiariaPromedio*100));

                }
                else
                {
                    listaAuxiliar.Sort((b1, b2) => (int)(b2.ProduccionDiariaPromedio - b1.ProduccionDiariaPromedio));
                }
                idBovinoMasProductivo = listaAuxiliar.First().Identificacion;
            }
            return idBovinoMasProductivo;
        }

        /// <summary>
        /// Sobrescribe el metodo ToString() mostrando todos los campos del objeto
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ESTADISTICAS DEL ESTABLECIMIENTO\n");

            sb.AppendLine("CABEZAS DE GANADO");
            sb.AppendLine($"Total animales: {CantidadAnimales}\n");
            sb.AppendLine("Distribución por uso");
            sb.AppendLine($"Porcentaje tambo: {CalcularPorcentaje(cantidadAnimalesTambo):N2}%");
            sb.AppendLine($"Porcentaje engorde: {CalcularPorcentaje(cantidadAnimalesEngorde):N2}%\n");

            sb.AppendLine("PRODUCCION LECHERA");
            sb.AppendLine($"Total animales tambo: {cantidadAnimalesTambo}");
            sb.AppendLine($"Producción anual de leche: {LecheProducidaAnual} litros");
            sb.AppendLine($"Raza más productiva: {RazaMasProductivaTambo}");
            sb.AppendLine($"Animal más productivo: {BovinoMasProductivoTambo}\n");


            sb.AppendLine("PRODUCCION ENGORDE");
            sb.AppendLine($"Total animales engorde: {CantidadAnimalesEngorde}");
            sb.AppendLine($"Producción anual de carne: {CarneProducidaAnual} kilos");
            sb.AppendLine($"Raza más productiva: {RazaMasProductivaCarne}");
            sb.AppendLine($"Animal más productivo: {BovinoMasProductivoCarne}\n");

            return sb.ToString();
        }

        #endregion
    }
}
