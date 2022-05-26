using System;

namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Universidad gim = new();
            Alumno a1 = new(1, "Juan", "Lopez", "12234456", ENacionalidad.Argentino, 
            EClases.Programacion, EEstadoCuenta.Becado);
            gim += a1;

            try
            {
                Alumno a2 = new(2, "Juana", "Martinez", "12234458",ENacionalidad.Extranjero, EClases.Laboratorio,
                EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Alumno a3 = new(3, "José", "Gutierrez", "12234456",
                ENacionalidad.Argentino, EClases.Programacion, EEstadoCuenta.Becado);
                gim += a3;
            }
            catch (AlumnoRepetidorException e)
            {
                Console.WriteLine(e.Message);
            }
            Alumno a4 = new(4, "Miguel", "Hernandez", "92264456",
            ENacionalidad.Extranjero, EClases.Legislacion, EEstadoCuenta.AlDia);
            gim += a4;

            Alumno a5 = new(5, "Carlos", "Gonzalez", "12236456",
            ENacionalidad.Argentino, EClases.Programacion, EEstadoCuenta.AlDia);
            gim += a5;

            Alumno a6 = new(6, "Juan", "Perez", "12234656",
            ENacionalidad.Argentino, EClases.Laboratorio, EEstadoCuenta.Deudor);
            gim += a6;

            Alumno a7 = new(7, "Joaquin", "Suarez", "91122456",
            ENacionalidad.Extranjero, EClases.Laboratorio, EEstadoCuenta.AlDia);
            gim += a7;

            Alumno a8 = new(8, "Rodrigo", "Smith", "22236456",
            ENacionalidad.Argentino, EClases.Legislacion, EEstadoCuenta.AlDia);
            gim += a8;

            Profesor i1 = new(1, "Juan", "Lopez", "12234456", ENacionalidad.Argentino);
            gim += i1;

            Profesor i2 = new(2, "Roberto", "Juarez", "32234456", ENacionalidad.Argentino);
            gim += i2;

            try
            {
                gim += EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine(gim.ToString());
                Console.ReadKey();
                Console.Clear();
            }
            catch(System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Universidad.Guardar(gim);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                int jornada = 0;
                Jornada.Guardar(gim[jornada]);
                Console.WriteLine("Archivo de Jornada {0} guardado.", jornada);
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.IO.IOException e) 
            { 
                Console.WriteLine(e.Message); 
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.ReadKey();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
           
        }


    }

}

