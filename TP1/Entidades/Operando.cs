using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        //atributos
        private double numero;

        //propiedades
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }

        //constructores
        public Operando()
        {
            numero = 0;
        }

        public Operando(double numero)
            : this()
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
            : this()
        {
            this.Numero  = strNumero;
        }

        //metodos
        /// <summary>
        /// Valida que un operando ingresado como string sea un numero y lo devuelve como double
        /// </summary>
        /// <param name="strNumero">cadena de caracteres a validar</param>
        /// <returns>devuelve el operando en double si se valida, o 0 sino se puede validar </returns>
        private double ValidarOperando(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Verifica que un numero sea entero binario (que contenga solo 0 y 1)
        /// </summary>
        /// <param name="binario">Cadena de caracteres a chequear</param>
        /// <returns>Devuelve true si es binario y false sino lo es</returns>
        private bool EsBinario(string binario)
        {
            foreach (char caracter in binario)
            {
                if (caracter != '0' && caracter != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Verifica que un numero sea un entero binario y lo convierte al sistema decimal
        /// </summary>
        /// <param name="binario">numero entero binario a convertir en formato string</param>
        /// <returns>El numero en sistema decimal en formato string</returns>
        public string BinarioDecimal(string binario)
        {
            int numeroDecimal = 0;
 
            if (EsBinario(binario))
            {
                char[] binarioCharArray = binario.ToCharArray();
                Array.Reverse(binarioCharArray);

                for (int i = 0; i < binarioCharArray.Length; i++)
                {
                    if (binarioCharArray[i] == '1')
                    {
                        if (i == 0)
                        {
                            numeroDecimal += 1;
                        }
                        else
                        {
                            numeroDecimal += (int) Math.Pow(2, i);
                        }
                    }
                }
                return numeroDecimal.ToString();
            }
            else
            {
                return "Valor inválido";
            }
        }

        /// <summary>
        /// Convierte un numero flotante positivo, pasandolo a entero, a su equivalente en sistema binario
        /// </summary>
        /// <param name="numero">Número en formato double</param>
        /// <returns>Devuelve el numero binario en formato string. Si el numero pasado por parametro es negativo, devuelve "Valor inválido" </returns>
        public string DecimalBinario(double numero)
        {
            int numeroEntero = (int) numero;

            if (numeroEntero >= 0)
            {
                if (numeroEntero == 0)
                {
                    return "0";
                }
                else
                {
                    string binario = "";
                    while (numeroEntero > 0)
                    {

                        if (numeroEntero % 2 == 0)
                        {
                            binario = "0" + binario;
                        }
                        else
                        {
                            binario = "1" + binario;
                        }
                        numeroEntero = numeroEntero / 2;
                    }
                    return binario;
                }
            }
            else
            {
                return "Valor inválido";
            }

        }

        /// <summary>
        /// Convierte string en un numero flotante positivo, pasandolo a entero y a su equivalente en sistema binario
        /// </summary>
        /// <param name="numero">Número en formato double</param>
        /// <returns>Devuelve el numero binario en formato string. Si el numero pasado por parametro es negativo, devuelve "Valor inválido" </returns>

        public string DecimalBinario(string numero)
        {
            if(double.TryParse(numero, out double num))
            {
                return DecimalBinario(num);
            }
            else
            {
                return "Valor inválido";
            }
        }

        //sobrecarga de operadores

        /// <summary>
        /// Realiza la suma entre 2 numeros pasados por parametro
        /// </summary>
        /// <param name="n1">primer operando</param>
        /// <param name="n2">segundo operando</param>
        /// <returns>resultado</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Realiza la resta entre 2 numeros pasados por parametro
        /// </summary>
        /// <param name="n1">primer operando</param>
        /// <param name="n2">segundo operando</param>
        /// <returns>resultado</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Realiza la multiplicacion de 2 numeros pasados por parametro
        /// </summary>
        /// <param name="n1">primer operando</param>
        /// <param name="n2">segundo operando</param>
        /// <returns>resultado</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Realiza la division de 2 numeros pasados por parametro
        /// </summary>
        /// <param name="n1">primer operando</param>
        /// <param name="n2">segundo operando</param>
        /// <returns>si el segundo operando es distinto de 0 devuelve resultado, si es 0 devuelve double.MinValue</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }
    }
}