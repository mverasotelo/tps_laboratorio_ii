using System;

namespace Biblioteca
{
    public class EstadisticaHistorica : Estadisticas
    {
        private DateTime dateTime;

        /// <summary>
        /// Constructor public de la clase EstadisticaHistorica que se usa para guardar el estado del objeto como registro en la base de datos
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cantidadAnimales"></param>
        /// <param name="cantidadAnimalesTambo"></param>
        /// <param name="cantidadAnimalesEngorde"></param>
        /// <param name="lecheProducida"></param>
        /// <param name="carneProducida"></param>
        /// <param name="animalMasProductivoTambo"></param>
        public EstadisticaHistorica(DateTime dateTime, int cantidadAnimales, int cantidadAnimalesTambo, int cantidadAnimalesEngorde, float lecheProducida,
        float carneProducida, int animalMasProductivoTambo)
        {
            this.dateTime = dateTime;
            this.cantidadAnimales = cantidadAnimales;
            this.cantidadAnimalesTambo = cantidadAnimalesTambo;
            this.cantidadAnimalesEngorde = cantidadAnimalesEngorde;
            this.lecheProducida = lecheProducida;
            this.carneProducida = carneProducida;
            this.animalMasProductivoTambo = animalMasProductivoTambo;
        }

        /// <summary>
        /// Sobrecarga del constructor público de la clase EstadisticaHistorica que se usa para generar un objeto de acuerdo a lo obtenido de la lectura de la base de datos
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="cantidadAnimales"></param>
        /// <param name="cantidadAnimalesTambo"></param>
        /// <param name="cantidadAnimalesEngorde"></param>
        /// <param name="lecheProducida"></param>
        /// <param name="carneProducida"></param>
        /// <param name="animalMasProductivoTambo"></param>
        /// <param name="razaBovinoMasProductivoTambo"></param>
        public EstadisticaHistorica(DateTime dateTime, int cantidadAnimales, int cantidadAnimalesTambo, int cantidadAnimalesEngorde, float lecheProducida,
            float carneProducida, int animalMasProductivoTambo, string razaBovinoMasProductivoTambo)
            :this(dateTime, cantidadAnimales, cantidadAnimalesTambo, cantidadAnimalesEngorde, lecheProducida, carneProducida, animalMasProductivoTambo)
        {
            this.razaBovinoMasProductivoTambo = razaBovinoMasProductivoTambo;
        }


        #region Propiedades 

        /// <summary>
        /// Propiedad fecha que devuelve la fecha de la estadistica
        /// </summary>
        public DateTime Fecha
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
            }
        }

        /// <summary>
        /// Sobrescritura de la propiedad LecheProducidaAnual que devuelve el total de leche producida en el ultimo año pasado por parametro
        /// </summary>
        public override float LecheProducidaAnual
        {
            get
            {
                return lecheProducida;
            }
            set
            {
                lecheProducida = value;
            }
        }

        /// <summary>
        /// Sobrescritura de la propiedad CarneProducidaAnual que devuelve el total de carne producida en el ultimo año pasado por parametro
        /// </summary>
        public override float CarneProducidaAnual
        {
            get
            {
                return carneProducida;
            }
            set
            {
                carneProducida = value;
            }
        }

        /// <summary>
        /// Sobrescritura de la propiedad CarneProducidaAnual que devuelve el total de carne producida en el ultimo año pasado por parametro
        /// </summary>
        public override int BovinoMasProductivoTambo
        {
            get
            {
                return animalMasProductivoTambo;
            }
            set
            {
                carneProducida = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve la raza  mas productiva para tambo en ese dia, pasado por parametro
        /// </summary>
        public string RazaBovinoMasProductivoTambo
        {
            get
            {
                return razaBovinoMasProductivoTambo;
            }
            set
            {
                razaBovinoMasProductivoTambo = value;
            }
        }

        #endregion
    }
}
