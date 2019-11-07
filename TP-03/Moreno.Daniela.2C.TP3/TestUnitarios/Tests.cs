using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using Entidades_Instanciables;
using Excepciones;

namespace TestUnitarios
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestExceptionUno()
        {
            Alumno alumno1 = new Alumno(1, "Daniela", "Moreno", "3242323", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            alumno1.StringToDNI = "32874sk";
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestExceptionDos()
        {
            Alumno alumno1 = new Alumno(1, "Daniela", "Moreno", "3242312", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            Alumno alumno2 = new Alumno(1, "Jorge", "Perez", "3242312", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            Universidad universidad = new Universidad();
            universidad += alumno1;
            universidad += alumno2;
        }

        [TestMethod]
        public void TestValorNumerico()
        {
            int valorEsperado = 100000;
            Alumno alumno1 = new Alumno(1, "Pepe", "Grillo", "100000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,Alumno.EEstadoCuenta.Deudor);
            Assert.AreEqual(valorEsperado, alumno1.DNI);
        }

        [TestMethod]
        public void TestNull()
        {
            Universidad universidad = new Universidad();
            Assert.IsNotNull(universidad.Alumnos);
        }
    }
}
