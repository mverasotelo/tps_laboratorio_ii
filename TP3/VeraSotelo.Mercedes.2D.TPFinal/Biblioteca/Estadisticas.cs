using System;
using System.Text;
using System.Collections.Generic;

namespace Biblioteca
{
    public class Estadisticas
    {
        private int cantidadAnimales;
        private int cantidadAnimalesTambo;
        private int cantidadAnimalesEngorde;
        private float porcentajeMachos;
        private float porcentajeHembras;
        private float porcentajeTambo;
        private float porcentajeEngorde;
        private float lecheProducida;
        private float carneProducida;
        private string razaMasProductivaCarne;
        private string razaMasProductivaTambo;

        public Estadisticas()
        {
        }

        /// <summary>
        /// Propiedad que la cantidad de animales del establecimiento
        /// </summary>
        public int CantidadAnimales
        {
            get
            {
                return Establecimiento.StockGanadero.Count;
            }
            set
            {
                cantidadAnimales = value;
            }
        }

        /// <summary>
        /// Propiedad que la cantidad de animales para tambo del establecimiento
        /// </summary>
        public int CantidadAnimalesTambo
        {
            get
            {
                return Establecimiento.ListarBovinosPorUso(Bovino.EUso.Tambo).Count;
            }
            set
            {
                cantidadAnimalesTambo = value;
            }
        }

        /// <summary>
        /// Propiedad que la cantidad de animales para engorde del establecimiento
        /// </summary>
        public int CantidadAnimalesEngorde
        {
            get
            {
                return Establecimiento.ListarBovinosPorUso(Bovino.EUso.Engorde).Count;
            }
            set
            {
                cantidadAnimalesEngorde = value;
            }
        }
        /// <summary>
        /// Propiedad que devuelve el porcentaje de machos en el total del stock, utilizando el metodo CalcularPorcentajePorSexo
        /// </summary>
        public float PorcentajeMachos
        {
            get
            {
                return CalcularPorcentajePorSexo(Bovino.ESexo.Macho);
            }
            set
            {
                porcentajeMachos = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el porcentaje de hembras en el total del stock, utilizando el metodo CalcularPorcentajePorSexo
        /// </summary>
        public float PorcentajeHembras
        {
            get
            {
                return CalcularPorcentajePorSexo(Bovino.ESexo.Hembra);
            }
            set
            {
                porcentajeHembras = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el porcentaje de uso para tambo en el total del stock, utilizando el metodo CalcularPorcentajePorUso
        /// </summary>
        public float PorcentajeTambo
        {
            get
            {
                return CalcularPorcentajePorUso(Bovino.EUso.Tambo);
            }
            set
            {
                porcentajeTambo = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el porcentaje de uso para engorde en el total del stock, utilizando el metodo CalcularPorcentajePorUso
        /// </summary>
        public float PorcentajeEngorde
        {
            get
            {
                return CalcularPorcentajePorUso(Bovino.EUso.Engorde);
            }
            set
            {
                PorcentajeEngorde = value;
            }
        }

        /// <summary>
        /// Propiedad que devuelve el total de leche producida en el ultimo año, utilizando el metodo CalcularProduccionUltimoAnio
        /// </summary>
        public float LecheProducidaAnual
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
        /// Propiedad que devuelve el total de carne producida en el ultimo año, utilizando el metodo CalcularProduccionUltimoAnio
        /// </summary>
        public float CarneProducidaAnual
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
        /// Propiedad que devuelve la raza historicamente mas productiva para tambo
        /// </summary>
        public string RazaMasProductivaTambo
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
        /// Propiedad que devuelve la raza historicamente mas productiva para carne
        /// </summary>
        public string RazaMasProductivaCarne
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
        /// Calcula el porcentaje de bovinos sobre el total con el sexo pasado por parametro.
        /// </summary>
        /// <param name="sexo"></param>
        /// <returnsPorcentaje del sexo indicado></returns>
        private float CalcularPorcentajePorSexo(Bovino.ESexo sexo)
        {
            int total = Establecimiento.StockGanadero.Count;
            int cantidadSexo = 0;
            foreach (Bovino b in Establecimiento.StockGanadero)
            {
                if(b.Sexo == sexo)
                {
                    cantidadSexo++;
                }
            }
            return (float)cantidadSexo * 100 / total;
        }
        
        /// <summary>
        /// Calcula el porcentaje de bovinos sobre el total con el uso pasado por parametro.
        /// </summary>
        /// <param name="uso"></param>
        /// <returns>Porcentaje del uso indicado</returns>
        private float CalcularPorcentajePorUso(Bovino.EUso uso)
        {
            return (float)(Establecimiento.ListarBovinosPorUso(uso).Count * 100) / Establecimiento.StockGanadero.Count;
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
                if(b.PermanenciaEnDias > 365)
                {
                    float produccionDiaria = b.CalcularProduccionAnimal() / b.PermanenciaEnDias;
                    totalProducido += produccionDiaria * 365; ;
                }
                else
                {
                    totalProducido += b.CalcularProduccionAnimal();
                }
            }
            return totalProducido;
        }

        /// <summary>
        /// Calcular la raza mas productiva del uso especificado por parametro
        /// </summary>
        /// <param name="uso"></param>
        /// <returns></returns>
        private string CalcularRazaMasProductiva(Bovino.EUso uso)
        {
            Dictionary<string, float> razas = new Dictionary<string, float>();
            string razaMasProductiva = String.Empty;
            float sumador = 0F;

            foreach (Bovino b in Establecimiento.ListarBovinosPorUso(uso))
            {
                if (!razas.ContainsKey(b.Raza.ToString()))
                {
                    razas.Add(b.Raza.ToString(), b.CalcularProduccionAnimal());
                }
                else
                {
                    razas[b.Raza.ToString()] += b.CalcularProduccionAnimal();
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
    /// Sobrescribe el metodo ToString() mostrando todos los campos del objeto
    /// </summary>
    /// <returns></returns>
    public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ESTADISTICAS DEL ESTABLECIMIENTO\n");

            sb.AppendLine("CABEZAS DE GANADO");
            sb.AppendLine($"Total animales: {CantidadAnimales}\n");
            sb.AppendLine("Distribución por sexo");
            sb.AppendLine($"Porcentaje machos: {PorcentajeMachos:N2}%");
            sb.AppendLine($"Porcentaje hembras: {PorcentajeHembras:N2}%\n");
            sb.AppendLine("Distribución por uso");
            sb.AppendLine($"Porcentaje tambo: {PorcentajeTambo:N2}%");
            sb.AppendLine($"Porcentaje engorde: {PorcentajeEngorde:N2}%\n");

            sb.AppendLine("PRODUCCION LECHERA");
            sb.AppendLine($"Total animales tambo: {CantidadAnimalesTambo}");
            sb.AppendLine($"Producción anual de leche: {LecheProducidaAnual} litros");
            sb.AppendLine($"Raza más productiva: {RazaMasProductivaTambo}\n");


            sb.AppendLine("PRODUCCION ENGORDE");
            sb.AppendLine($"Total animales engorde: {CantidadAnimalesEngorde}");
            sb.AppendLine($"Producción anual de carne: {CarneProducidaAnual} kilos");
            sb.AppendLine($"Raza más productiva: {RazaMasProductivaCarne}\n");


            return sb.ToString();
        }
    }
}
