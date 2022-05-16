using CapaDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Anuncio anuncio1 = new Anuncio();
            anuncio1.tipoServicio = "Servicio de acompaņamiento";
            anuncio1.descripcion = "Acompaņamiento a personas dependientes.";
            string result = anuncio1.descripcion;
            Assert.AreEqual("Acompaņamiento a personas dependientes.", result);
        }

        [TestMethod]
        public void GetNombreCategoriaTest()
        {
            //Arrange  

            String nombreCategoria = "Bailes";
            String descripcion = "Clases de tango";
            CategoriaDeServicio categoria1 = new CategoriaDeServicio(nombreCategoria, descripcion);
            String expected = "Bailes";
            String actual;
            //Actual  
            actual = categoria1.nombreCategoria;
            //Assert  
            Assert.AreEqual(expected, actual);
        }

        /*[TestMethod]
        public void GetUsuario()
        {
            DUsuario dUsuario = new DUsuario();
            Usuario userPgrillo;

            userPgrillo = dUsuario.getUsuarioByUsername("pgrillo");
            //Assert.IsInstanceOfType(userPgrillo, typeof(Usuario));

            String expected = userPgrillo.idUsername;
            Assert.AreEqual("pgrillo", expected);
        }*/

            //[TestMethod]
            /*public void TestLoginTrue()
            {
                Usuario usuario = new Usuario();
                usuario.idUsername = "pgrillo";
                usuario.idPassword = "1234";
                DUsuario dUsuario = new DUsuario();
                bool result = dUsuario.checkPassword("pgrillo", "1234");
                Assert.AreEqual(true, result);
            }*/

        }
}