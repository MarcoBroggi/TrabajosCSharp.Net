using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// constructor vacio de universitario
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// constructor de universitario que declara legajo, nombre, apellido, dni y nacionalidad
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido,
                string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// declaracion abtracta
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// mostrara los datos de la persona junto con el legajo
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Legajo: "+ legajo);
            return sb.ToString();
        }

        ///Operadores Logicos
        public override bool Equals(object obj)
        {
            if (((Universitario)obj).legajo == legajo ||
                ((Universitario)obj).DNI == DNI)
                {
                    return true;
                }
            return false;
        }

    }
}
