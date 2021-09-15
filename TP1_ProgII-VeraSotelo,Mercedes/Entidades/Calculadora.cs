using System;

namespace Entidades
{
    public class Calculadora
    {
        public double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;
            switch (ValidarOperador(operador))
            {
                case '+':
                    resultado = num1 + num2;
                    break;
                case '-':
                    resultado =  num1 - num2;
                    break;
                case '*':
                    resultado = num1 * num2;
                    break;
                case '/':
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        private static char ValidarOperador(char operador)
        {
            if(operador!='+' && operador != '-' && operador != '*' && operador != '/')
            {
                return '+';
            }
            return operador;
        }
    }
}
