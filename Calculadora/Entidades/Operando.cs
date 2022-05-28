using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);

            }
        }
        /// <summary>
        /// Constructor que inicializa el campo numero en el double pasado por parametro
        /// </summary>
        /// <param name="num"></param>
        public Operando(double num)
        {
            this.numero = num;
        }
        /// <summary>
        /// Constructor que inicializa el campo numero en el valor del string por parametro
        /// </summary>
        /// <param name="operando"></param>
        public Operando(string operando)
        {
            Numero = operando;
        }
        /// <summary>
        /// Constructor sin parametros que inicializa el campo numero en 0. 
        /// </summary>
        public Operando() : this(0)
        {

        }
        /// <summary>
        /// Convierte un numero binario ingresado por parametro a decimal
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna una cadena con el valor del numero convertido a decimal si el numero es binario, o el mensaje Valor invalido si no lo es.</returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "";
            double acumulador = 0;
            double cantCifras;
            int i;


            if (EsBinario(binario))
            {
                cantCifras = binario.Length;
                for (i = 0; i < cantCifras; i++)
                {

                    if (binario[i] == '1')
                    {
                        acumulador = acumulador + Math.Pow(2, cantCifras - i - 1);
                    }
                }
                retorno = Convert.ToString(acumulador);
            }
            else
            {
                retorno = "Valor invalido.";
            }
            return retorno;
        }
        /// <summary>
        /// Transforma un numero decimal ingresado por parametro a binario 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna una cadena con el numero binario.</returns>
        public static string DecimalBinario(string numero)
        {
            double auxCalculo = 0;
            string retorno = "Valor invalido";


            if (double.TryParse(numero, out auxCalculo))
            {
                retorno = DecimalBinario(auxCalculo);
            }
            return retorno;
        }
        /// <summary>
        /// Transforma un numero decimal ingresado por parametro a binario 
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna una cadena con el numero binario.</returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "";
            string buffer = "";
            int aux = (int)numero;
            aux = Math.Abs(aux);
            for (int i = 0; aux > 0; i++)
            {

                if (aux % 2 == 0)
                {
                    buffer += "0";

                }
                else
                {
                    buffer += "1";

                }
                aux = aux / 2;

            }

            foreach (char letra in buffer)
            {

                retorno = letra + retorno;
            }

            return retorno;
        }
        /// <summary>
        ///  Valida si la cadena pasada por parametro es un numero binario o no
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Retorna true si lo es o false si no lo es</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;
            int tam = binario.Length;
            foreach (char c in binario)
            {
                if (c != '0' && c != '1')
                {
                    retorno = false;
                    break;
                }

            }
            return retorno;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;
            double.TryParse(strNumero, out retorno);
            return retorno;
        }

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Operando n1, Operando n2)
        {
            double retorno = 0;
            if (n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }

            return retorno;
        }
    }
}
