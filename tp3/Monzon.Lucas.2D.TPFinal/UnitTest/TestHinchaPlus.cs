using Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class TestHinchaPlus
    {
        [TestMethod]
        public void TestCargaDeHinchas()
        {
            Json<List<Hincha>> json = new Json<List<Hincha>>();

            List<Hincha> hinchas = json.Leer("../../../hinchas.json");

            Assert.IsNotNull(hinchas);
            Assert.IsTrue(hinchas.Count > 0);
            Assert.AreEqual(Club.Boca, hinchas[0].Club);
        }

        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestCargaJsonExeption()
        {
            Json<List<Hincha>> json = new Json<List<Hincha>>();

            List<Hincha> hinchas = json.Leer("../../../hinchasError.json");
        }

        [TestMethod]
        public void TestExportarHinchas()
        {
            Json<List<Hincha>> json = new Json<List<Hincha>>();
            List<Hincha> hinchas = new List<Hincha>() { new Hincha("Juan", "Pedro", 
                30443123, DateTime.Parse("2/04/1998"), Sexo.Masculino, 
                Club.Boca, true) };

            json.Guardar("../../../hinchasExportados.json", hinchas);
            
            Assert.IsTrue(File.Exists("../../../hinchasExportados.json"));
            File.Delete("../../../hinchasExportados.json");
        }
    }
}
