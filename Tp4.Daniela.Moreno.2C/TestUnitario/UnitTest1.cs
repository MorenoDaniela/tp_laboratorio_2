using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPaqueteCorreo()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        [TestMethod]
        [ExpectedException(typeof(TrakingIdRepetidoException))]
        public void TestIdRepetido()
        {
            Correo correo = new Correo();
            Paquete paquete1 = new Paquete("Dorrego 123", "12345667");
            Paquete paquete2 = new Paquete("Lomas 456", "12345667");
            correo += paquete1;
            correo += paquete2;
        }
    }
}
