using System;

namespace Biblioteca
{
    public class AnimalInexistenteException : Exception
    {
        public AnimalInexistenteException(string message)
        : base(message)
        {
        }
    }
}
