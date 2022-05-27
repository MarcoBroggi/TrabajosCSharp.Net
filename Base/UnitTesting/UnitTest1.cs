using Microsoft.VisualStudio.TestTools.UnitTesting;
using Base;
using System;
using System.IO;

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        Texto testTexto;
        Alumno testAlumno;

        [TestMethod]
        public void TestLeerFalse()
        {
            string testLeer;
            testTexto = new();
            string testPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\TestLeer.txt";

            try
            {
                testTexto.Leer(testPath, out testLeer);
            }
            catch (FileNotFoundException e)
            {
                Assert.IsInstanceOfType(e, typeof(FileNotFoundException));
            }
        }

        [TestMethod]
        public void TestSinProfesorException()
        {

            Universidad uni = new();
            try
            {
                uni += EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }

        [TestMethod]
        public void TestSetDniNumerico()
        {
            string dniTest = "98765432";
            testAlumno = new Alumno(333, "Bruno", "ElGato", dniTest, ENacionalidad.Extranjero, EClases.Legislacion);

            Assert.AreEqual(int.Parse(dniTest), testAlumno.DNI);
        }

        [TestMethod]
        public void ValidaJornadaAlumnosNoEsNull()
        {
            Profesor testProfesor = new(666, "Tuca", "LaGata", "12345678", ENacionalidad.Argentino);
            Jornada testJornada = new(EClases.Programacion, testProfesor);

            Assert.IsNotNull(testJornada.Alumnos);
        }
    }
}
