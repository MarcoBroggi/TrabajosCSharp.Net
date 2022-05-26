using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        /// <summary>
        /// Constructor estatico de profesor, inicializa el random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// constructor vacio
        /// </summary>
        private Profesor()
        {
        }

        /// <summary>
        /// Constructor de Profesor que declara id, nombre, apellido, dni, nacionalidad y le declara las clases del dia
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni,
                ENacionalidad nacionalidad) : base(id, nombre, apellido,
                dni, nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();
        }

        /// <summary>
        /// Muestra que clases toma
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.AppendLine("CLASES DEL DIA:");
                foreach (Universidad.EClases c in clasesDelDia)
                {
                    sb.Append(" " + c.ToString());
                }
                sb.Append("\n");
            }
            catch(ArgumentOutOfRangeException e)
            {
                return e.Message;
            }
            return sb.ToString();
        }

        /// <summary>
        /// muestra los datos del progfesor
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }

        /// <summary>
        /// imprime todos los datos del profesor juntos con la clases que toma
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

        /// <summary>
        /// randomiza las clases a tomar por el profesor.
        /// </summary>
        private void _randomClases()
        {
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(5));
            System.Threading.Thread.Sleep(1000);
            clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
        }

        ///Operadores Logicos
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (clase == c)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
    }
}
