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
            Alumno alumno1 = new Alumno(1, "Daniela", "Moreno", "32423as12", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
            Universidad universidad = new Universidad();
            universidad += alumno1;
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



    }
}
