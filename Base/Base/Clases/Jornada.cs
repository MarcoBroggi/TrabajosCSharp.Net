using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base
{
    public class Jornada 
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        /// <summary>
        /// Constructor que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        /// <summary>
        /// constructor que declara una clase y un profesor
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        /// <summary>
        /// Guarda los datos en el archivo txt, sino lanza un error controlado
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new();
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\jornada.txt";
            try
            {
                texto.Guardar(fileName, jornada.ToString());
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al guardar Jornada.txt", e);
            }
        }
        
        /// <summary>
        /// Lee los datos del archivo txt, sino lanza un error controlado
        /// </summary>
        /// <returns></returns>
        public string Leer()
        {
            Texto texto = new Texto();
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "jornada.txt";
            string retorno;
            try
            {
                texto.Leer(fileName, out retorno);
            }
            catch (Exception e)
            {
                throw new ArchivosException("Error al leer Jornada.txt", e);
            }
            return retorno;
        }

        /// <summary>
        /// Imprime datos de la jornada, sobreescribiendo toString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            try
            {
                sb.AppendLine("[---------------------------------------------]\n");
                sb.AppendLine("Clase: " + clase.ToString());
                sb.AppendLine(instructor.ToString());
                sb.AppendLine("Alumnos: ");
                foreach (Alumno a in alumnos)
                {
                    sb.AppendLine(a.ToString());
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                return e.Message;
            }
            return sb.ToString();
        }

        ///Operadores Logicos
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.alumnos)
            {
                if (a == alumno)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        /// <summary>
        /// propiedades
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

    }
}
