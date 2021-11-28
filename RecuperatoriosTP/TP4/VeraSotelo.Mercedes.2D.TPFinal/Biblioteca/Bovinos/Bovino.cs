using System;
using System.Text;

namespace Biblioteca
{
    public class Bovino : IBovino
    {

        #region Enumerados
        public enum ERaza
        {
            Angus, Hereford, Holstein
        }

        public enum EUso
        {
            Tambo, Engorde
        }

        public enum ESexo
        {
            Macho, Hembra
        }

        public enum EAlimentacion
        {
            Pasto, Pellet, Mezcla
        }
        #endregion
    
        protected const float CONSUMO_DIARIO = 26F;
        protected int identificacion;
        protected ESexo sexo;
        protected DateTime fechaIngreso;
        protected ERaza raza;
        protected EUso uso;
        protected float produccionDiariaPromedio;

        /// <summary>
        /// Constructor sin parametros para la serializacion 
        /// </summary>
        protected Bovino()
        {
        }

        /// <summary>
        /// Constructor publico de Bovino - Recibe fecha ingreso, sexo, raza, uso
        /// </summary>
        /// <param name="fechaIngreso"></param>
        /// <param name="sexo"></param>
        /// <param name="raza"></param>
        /// <param name="uso"></param>
        public Bovino(DateTime fechaIngreso, ESexo sexo, ERaza raza, EUso uso)
        {
            this.fechaIngreso = fechaIngreso;
            this.sexo = sexo;
            this.raza = raza;
            this.uso = uso;
            this.produccionDiariaPromedio = this.CalcularProduccionDiaria();
        }

        /// <summary>
        /// Sobrecarga de constructor publico de Bovino - Recibe fecha ingreso identificacion, sexo, raza, uso
        /// </summary>
        /// <param name="identificacion"></param>
        /// <param name="fechaIngreso"></param>
        /// <param name="sexo"></param>
        /// <param name="raza"></param>
        /// <param name="uso"></param>
        public Bovino(int identificacion, DateTime fechaIngreso, ESexo sexo, ERaza raza, EUso uso)
            : this(fechaIngreso, sexo, raza, uso)
        {
            this.identificacion = identificacion;
        }


        #region Propiedades

        /// <summary>
        /// Propiedad lectura-escritura del atributo identificacion
        /// </summary>
        public int Identificacion
        {
            get
            {
                return identificacion;
            }
            set
            {
                identificacion = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura del atributo fechaIngreso
        /// </summary>
        public DateTime FechaIngreso
        {
            get
            {
                return fechaIngreso;
            }
            set
            {
                fechaIngreso = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura del atributo uso
        /// </summary>
        public EUso Uso
        {
            get
            {
                return uso;
            }
            set
            {
                uso = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura del atributo sexo
        /// </summary>
        public ESexo Sexo
        {
            get
            {
                return sexo;
            }
            set
            {
                sexo = value;
            }
        }

        /// <summary>
        /// Propiedad lectura-escritura del atributo raza
        /// </summary>
        public ERaza Raza
        {
            get
            {
                return raza;
            }
            set
            {
                raza = value;
            }
        }

        /// <summary>
        /// Propiedad solo lectura del atributo produccionDiariaPromedio
        /// </summary>
        public float ProduccionDiariaPromedio
        {
            get
            {
                return produccionDiariaPromedio;
            }
        }

        #endregion

        #region Metodos y sobrecargas

        /// <summary>
        /// Si el animal es de uso tambo calcula leche producida y si es de uso engorde,
        /// calcula los kilos engordados a partir de un promedio diario generado aleatoriamente 
        /// </summary>
        /// <returns>Devuelve promedio de produccion diaria</returns>
        public float CalcularProduccionDiaria()
        {
            float retorno;
            Random r = new Random();

            if (uso == EUso.Tambo)
            {
                retorno = r.Next(2000, 5000);
            }
            else
            {
                retorno = r.Next(100, 200);
            }
            return (float) retorno / 100;

        }

        /// <summary>
        /// Sobrecarga del operador ==, compara por el identificador.
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns>Devuelve true si son iguales, false si son distintos o algun bovino es null</returns>
        public static bool operator ==(Bovino b1, Bovino b2)
        {
            if(b1 is not null && b2 is not null)
            {
                return b1.identificacion == b2.identificacion;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador !)
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool operator !=(Bovino b1, Bovino b2)
        {
            return !(b1 == b2);
        }

        /// <summary>
        /// Rescritura del metodo Equals(), reutilizando la sobrecarga del operador ==.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Bovino bovino = obj as Bovino;
            return bovino != null && this == bovino;
        }

        /// <summary>
        /// Rescritura del metodo GetHashCode()
        /// </summary>
        /// <returns>Devuelve el hashcode de la identificacion del bovino</returns>
        public override int GetHashCode()
        {
            return identificacion.GetHashCode();
        }

        /// <summary>
        /// Rescritura del metodo ToString incluyendo info de la clase Bovino
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bovino N° {identificacion}");
            sb.AppendLine($"Fecha de ingreso: {fechaIngreso.ToShortDateString()}");
            sb.AppendLine($"Sexo: {sexo}");
            sb.AppendLine($"Raza: {raza}");
            sb.AppendLine($"Uso: {uso}");
            return sb.ToString();
        }
        #endregion
    }
}