using System;
using System.Text;

namespace Biblioteca
{
    public class Bovino : IBovino
    {
        //ENUMERADOS

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

        //ATRIBUTOS

        protected const float CONSUMO_DIARIO = 26F;
        protected string identificacion;
        protected ESexo sexo;
        protected DateTime fechaIngreso;
        protected ERaza raza;
        protected EUso uso;
        //private EAlimentacion alimentacion;

        /// <summary>
        /// Constructor sin parametros para la serializacion 
        /// </summary>
        protected Bovino()
        {
        }

        /// <summary>
        /// Constructor publico de Bovino - Recibe identificacion, sexo, raza, uso
        /// </summary>
        /// <param name="identificacion"></param>
        /// <param name="sexo"></param>
        /// <param name="raza"></param>
        /// <param name="uso"></param>
        public Bovino(DateTime fechaIngreso, string identificacion, ESexo sexo, ERaza raza, EUso uso)
        {
            this.fechaIngreso = fechaIngreso;
            this.identificacion = identificacion;
            this.sexo = sexo;
            this.raza = raza;
            this.uso = uso;
        }

        //PROPIEDADES

        /// <summary>
        /// Propiedad solo lectura del atributo fechaIngreso
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
        /// Propiedad solo lectura del atributo identificacion
        /// </summary>
        public string Identificacion
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
        /// Propiedad solo lectura del atributo uso
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
        /// Propiedad solo lectura del atributo sexo
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
        /// Propiedad solo lectura del atributo raza
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
        /// Propiedad solo lectura del atributo raza
        /// </summary>
        public int PermanenciaEnDias
        {
            get
            {
                return CalcularPermanenciaEnDias();
            }
        }

        //METODOS

        /// <summary>
        /// Calcula la permanencia en dias del animal en el campo.
        /// </summary>
        /// <returns></returns>
        public int CalcularPermanenciaEnDias()
        {
            TimeSpan ts = DateTime.Today.Subtract(fechaIngreso);
            return (int)ts.TotalDays + 1;
        }

        /// <summary>
        /// Calcula la cantidad de alimento consumido por el bovino de acuerdo a lso dias de permanencia en el establecimiento
        /// </summary>
        /// <returns></returns>
        public float CalcularConsumoAlimento()
        {
            return CalcularPermanenciaEnDias() * CONSUMO_DIARIO;
        }

        /// <summary>
        /// Si el animal es de uso tambo calcula leche producida y si es de uso engorde,
        /// calcula los kilos engordados a partir de un promedio diario generado aleatoriamente 
        /// multiplicado por la permanencia en dias del animal en el establecimiento
        /// </summary>
        /// <returns>Devuelve leche producida, 0 si es no el animal no es destino tambo</returns>
        public float CalcularProduccionAnimal()
        {
            Random r = new Random();
            float produccion = 0;

            if (uso == EUso.Tambo)
            {
                float promedioProduccionDiaria = r.Next(20, 50);
                produccion = promedioProduccionDiaria * PermanenciaEnDias;
            }
            else
            {
                float promedioProduccionDiaria = r.Next(1, 2);
                produccion = promedioProduccionDiaria * PermanenciaEnDias;
            }
            return produccion;
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
                sb.AppendLine("BOVINO");
                sb.AppendLine($"Identificación: {identificacion}");
                sb.AppendLine($"Fecha de ingreso: {fechaIngreso.ToShortDateString()}");
                sb.AppendLine($"Sexo: {sexo}");
                sb.AppendLine($"Raza: {raza}");
                sb.AppendLine($"Uso: {uso}");
                return sb.ToString();
            }
    }
}