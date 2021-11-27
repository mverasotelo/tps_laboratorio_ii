using System;

namespace Biblioteca
{
    public static class CalculadoraDiasPermanencia
    {
        /// <summary>
        /// Método de extensión que extiende la clase DateTime para calcular la cantidad de dias que pasaron desde la fecha dada
        /// </summary>
        /// <returns></returns>
        public static int CalcularPermanenciaEnDias(this DateTime dateTime)
        {
            TimeSpan ts = DateTime.Today.Subtract(dateTime);
            return (int)ts.TotalDays + 1;
        }
    }
}