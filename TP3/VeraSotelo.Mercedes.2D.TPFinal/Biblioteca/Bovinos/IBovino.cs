using System;


namespace Biblioteca
{
    public interface IBovino
    {
        public DateTime FechaIngreso { get; }
        public string Identificacion { get; }
        public Bovino.ESexo Sexo { get; }
        public Bovino.EUso Uso { get; }
        public int PermanenciaEnDias { get; }
        public int CalcularPermanenciaEnDias();
        public float CalcularProduccionAnimal();
    }
}
