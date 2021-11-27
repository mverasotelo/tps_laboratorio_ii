using System;


namespace Biblioteca
{
    public interface IBovino
    {
        public DateTime FechaIngreso { get; }
        public int Identificacion { get; }
        public Bovino.ESexo Sexo { get; }
        public Bovino.EUso Uso { get; }
        public float ProduccionDiariaPromedio { get; }
        public float CalcularProduccionDiaria();
    }
}
