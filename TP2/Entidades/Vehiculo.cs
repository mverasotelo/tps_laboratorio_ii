using System;
using System.Text;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }

        //atributos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        /// <summary>
        /// Constructor de la clase Vehiculo
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        protected Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CHASIS: {chasis}");
            sb.AppendLine($"MARCA: {marca}");
            sb.AppendLine($"COLOR: {color}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CHASIS: {p.chasis}\n");
            sb.AppendLine($"MARCA : {p.marca}\n");
            sb.AppendLine($"COLOR : {p.color}\n");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            if (!(v1 is null) && !(v2 is null))
            {
                return (v1.chasis == v2.chasis);
            }
            return false;
            
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        /// <summary>
        /// Sobrescribe el metodo Equals() para que dos vehiculos sea iguales si su chasis es igual
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>devuelve un booleano</returns>
        public override bool Equals(object obj)
        {
            Vehiculo vehiculo = obj as Vehiculo;
            return vehiculo != null && this == vehiculo;
        }

        /// <summary>
        /// Sobrescribe el metodo GetHashCode() para que se genere el mismo hashcode si los chasis son iguales
        /// </summary>
        /// <returns>Devuelve hashcode</returns>
        public override int GetHashCode()
        {
            return chasis.GetHashCode();
        }
    }
}
