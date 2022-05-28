using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el operador pasado por parametro sea el de una operacion matematica.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>Retorna un caracter de la operacion a realizar</returns>
        private static char ValidarOperador(char operador)
        {
            char retorno = ' ';
            if (operador == '-' || operador == '/' || operador == '*' || operador== '+')
            {
                retorno = operador;
            }
            else
            {
                retorno = '+';
            }
            return retorno;
        }

        /// <summary>
        /// Realiza una operacion matematica entre 2 numeros.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna el resultado de una operacion matematica.</returns>
        public double Operar(Operando num1, Operando num2, char operador)
        {
            double retorno = 0;
            char o = ValidarOperador(operador);

            switch (o)
            {
                case '+':
                    retorno = num1 + num2;
                    break;
                case '-':
                    retorno = num1 - num2;
                    break;
                case '*':
                    retorno = num1 * num2;
                    break;
                case '/':
                    retorno = num1 / num2;
                    break;
            }

            return retorno;



        }
    }
}
