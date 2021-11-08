using Biblioteca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void AgregarAnimal_RecibeNull_DeberiaDevolverFalse()
        {
            //arrange
            bool expected = false;

            //act
            bool actual = Establecimiento.AgregarAnimal(null);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(AnimalExistenteException))]
        [TestMethod]
        public void AgregarAnimal_RecibeAnimalQueYaEstaEnLaLista_DeberiaDevolverAnimalExistenteException()
        {
            //arrange
            Bovino bovino = new Bovino(DateTime.Today, "T0001", Bovino.ESexo.Hembra, Bovino.ERaza.Angus, Bovino.EUso.Tambo);
            Establecimiento.AgregarAnimal(bovino);

            //act
            Establecimiento.AgregarAnimal(bovino);
        }

        [TestMethod]
        public void CalcularPermanenciaEnDias_RecibeAnimalIngresadoHoy_DeberiaDevolver1()
        {
            //arrange
            Bovino bovino = new Bovino(DateTime.Today, "T0001", Bovino.ESexo.Hembra, Bovino.ERaza.Angus, Bovino.EUso.Tambo);

            int expected = 1;

            //act
            int actual = bovino.CalcularPermanenciaEnDias();

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EliminarAnimal_RecibeAnimalNoExistente_DeberiaDevolverFalse()
        {
            //arrange
            Bovino bovino = new Bovino(DateTime.Today, "T0001", Bovino.ESexo.Hembra, Bovino.ERaza.Angus, Bovino.EUso.Tambo);
            bool expected = false;

            //act
            bool actual = Establecimiento.EliminarAnimal(bovino);

            //assert
            Assert.AreEqual(expected, actual);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ExportarDatosAXml_RecibeUnPathVacio_DeberiaLanzarArgumentExcepcion()
        {
            //arrange
            string path = String.Empty;

            //act
            Archivos<string>.ExportarDatosAXml(path, "Prueba");
        }

        [ExpectedException(typeof(FileNotFoundException))]
        [TestMethod]
        public void CargarDatosDesdeJson_RecibeUnArchivoInexistente_DeberiaLanzarFileNotFoundException()
        {
            //arrange
            string ruta = Directory.GetCurrentDirectory();
            string rutaJson = Path.Combine(ruta, "HolaMundo");

            //act
            Archivos<string>.CargarDatosDesdeJson(rutaJson);
        }
    }
}
