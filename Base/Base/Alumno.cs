using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Constructor vacio
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor que declara id, nombre, apellido, dni, nacionalidad y clase que toma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
                ENacionalidad nacionalidad, Universidad.EClases claseQueToma) :
                base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor que ademas declara el estado de cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni,
                ENacionalidad nacionalidad, Universidad.EClases claseQueToma,
                EEstadoCuenta estadoCuenta) : this(id, nombre, apellido,
                    dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine(base.MostrarDatos());
                sb.AppendLine(ParticiparEnClase());
                sb.AppendLine("Estado de cuenta: " + estadoCuenta.ToString());
            }
            catch(ArgumentOutOfRangeException e)
            {
                return e.Message;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Muestra las clases que toma el alumno
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine("Toma clases de  " + claseQueToma.ToString());
            }
            catch(ArgumentOutOfRangeException e)
            {
                return e.Message;
            }
            return sb.ToString();
        }

        /// <summary>
        /// Imprime datos del alumno y las clases que toma, sobreescribiendo toString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        ///Operadores logicos

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a.claseQueToma == clase &&
                   a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }

        
    }
}
