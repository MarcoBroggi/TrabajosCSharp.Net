using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult respuesta;
            respuesta = MessageBox.Show("¿Seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Realiza una operacion matematica al hacer click en el boton operar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text);
            lblResultado.Text = Convert.ToString(resultado);
            lstOperaciones.Items.Add(ConstruirCadena(resultado, txtNumero1.Text, txtNumero2.Text, cmbOperador.Text));

        }
        /// <summary>
        /// Limpia los valores al hacer click en el boton Limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        /// <summary>
        /// Cierra el programa al hacer click en el boton cerrar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Convierte el resultado de una operacion de decimal a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string resultadoAnterior = lblResultado.Text;
            lblResultado.Text = Operando.DecimalBinario(lblResultado.Text);
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = true;
            lstOperaciones.Items.Add(ConstruirCadena(resultadoAnterior,lblResultado.Text));
        }
        /// <summary>
        /// Convierte el resultado de una operacion de binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string resultadoAnterior = lblResultado.Text;
            lblResultado.Text = Operando.BinarioDecimal(lblResultado.Text);
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
            lstOperaciones.Items.Add(ConstruirCadena(resultadoAnterior,lblResultado.Text));
        }
        /// <summary>
        /// Limpia los valores cargando los elementos a cadenas vacias.
        /// </summary>
        private void Limpiar()
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }
        /// <summary>
        /// Realiza una operacion matematica entre dos numeros
        /// </summary>
        /// <param name="Numero1"></param>
        /// <param name="Numero2"></param>
        /// <param name="Operador"></param>
        /// <returns>Retorna un double con el resultado de la operacion.</returns>
        private static double Operar(string Numero1, string Numero2, string Operador)
        {
            double resultado = 0;
            Calculadora calc = new Calculadora();
            Operando num1 = new Operando(Numero1);
            Operando num2 = new Operando(Numero2);
            char c = '+';
            if (Operador != "")
            {
                c = char.Parse(Operador);
            }

            resultado = calc.Operar(num1, num2, c);




            return resultado;
        }
        /// <summary>
        /// Crea una cadena que se va a mostrar en la listbox de operaciones.
        /// </summary>
        /// <param name="resultado"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>Retorna una cadena con la cuenta realizada.</returns>
        private static string ConstruirCadena(double resultado, string num1, string num2, string operador)
        {
            string retorno = "";
            StringBuilder sb = new StringBuilder();
            if (num1 == "")
            {
                sb.Append("0 ");

            }
            else
            {
                sb.Append(num1 + " ");
            }

            if (operador == "")
            {
                sb.Append("+ ");
            }
            else
            {
                sb.Append(operador + " ");
            }

            if (num2 == "")
            {
                sb.Append("0 ");
            }
            else
            {
                sb.Append(num2 + " ");
            }

            sb.Append("= " + resultado.ToString() + "\n");

            retorno = sb.ToString();
            return retorno;

        }

        private static string ConstruirCadena(string num1, string num2)
        {
            StringBuilder sb = new();
            sb.AppendLine(num1+ " -> " + num2);
            return sb.ToString();
        }

        private void lstOperaciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
