using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class AnimalExistenteException : Exception
    {
        public AnimalExistenteException(string message)
            :base(message)
        {
        }
    }
}
