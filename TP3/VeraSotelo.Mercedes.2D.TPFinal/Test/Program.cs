using System;
using System.Collections.Generic;
using System.IO;
using Biblioteca;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //RUTA ARCHIVOS
            string ruta = Directory.GetCurrentDirectory();
            string rutaJson = Path.Combine(ruta, "DatosEstablecimiento.json");
            string rutaXml = Path.Combine(ruta, "DatosEstablecimiento.xml");
            string rutaTxt = Path.Combine(ruta, "DatosEstablecimiento.txt");

            //CREAR BOVINOS PARA ENGORDE Y TAMBO
            Bovino b1 = new Bovino(DateTime.Now, "B45462", Bovino.ESexo.Macho, Bovino.ERaza.Angus, Bovino.EUso.Tambo);
            Bovino b2 = new Bovino(DateTime.Now, "B45465", Bovino.ESexo.Hembra, Bovino.ERaza.Holstein, Bovino.EUso.Engorde);
            Bovino b3 = new Bovino(new DateTime(2021,10,22), "B45457", Bovino.ESexo.Macho, Bovino.ERaza.Angus, Bovino.EUso.Tambo);
            Bovino b4 = new Bovino(new DateTime(2021, 10, 25), "B54545", Bovino.ESexo.Hembra, Bovino.ERaza.Holstein, Bovino.EUso.Engorde);
            Bovino b5 = new Bovino(new DateTime(2021, 10, 30), "B54546", Bovino.ESexo.Hembra, Bovino.ERaza.Hereford, Bovino.EUso.Tambo);

            //AGREGAR BOVINOS AL ESTABLECIMIENTO
            Establecimiento.AgregarAnimal(b1);
            Establecimiento.AgregarAnimal(b2);
            Establecimiento.AgregarAnimal(b3);
            Establecimiento.AgregarAnimal(b4);
            Establecimiento.AgregarAnimal(b5);

            Console.WriteLine(Establecimiento.ImprimirStockGanadero());

            //GUARDAR DATOS EN JSON
            Console.WriteLine("GUARDAR DATOS A JSON...");
            Console.ReadKey();

            try
            {
                Archivos<List<Bovino>>.ExportarDatosAJson(rutaJson, Establecimiento.StockGanadero);
                Console.WriteLine("Exportación de datos de stock bovino a Json exitosa");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No existe el archivo indicado");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("No existe el directorio indicado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            //GUARDAR DATOS EN XML
            Console.WriteLine("GUARDAR DATOS A XML...");
            Console.ReadKey();
            try
            {
                Archivos<List<Bovino>>.ExportarDatosAXml(rutaXml, Establecimiento.StockGanadero);
                Console.WriteLine("Exportación de datos de stock bovino a XML exitosa");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No existe el archivo indicado");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("No existe el directorio indicado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            //GUARDAR DATOS EN TXT
            Console.WriteLine("GUARDAR DATOS A TXT...");
            Console.ReadKey();
            try
            {
                Archivos<string>.ExportarDatosATxt(rutaTxt, Establecimiento.ImprimirStockGanadero());
                Console.WriteLine("Exportación de datos de stock bovino a Txt exitosa");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No existe el archivo indicado");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("No existe el directorio indicado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }

            //CARGAR BOVINOS DESDE JSON PARA PROBAR EXCEPCIONES
            Console.WriteLine("CARGA UN BOVINO DESDE JSON...");
            Console.ReadKey();
            try
            {
                List<Bovino> bovinosDesdeJson = Archivos<List<Bovino>>.CargarDatosDesdeJson(rutaJson);
                Establecimiento.AgregarAnimal(bovinosDesdeJson[0]);
            }
            catch(AnimalExistenteException)
            {
                Console.WriteLine("Ya existe un animal con esa identificacion");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No existe el archivo indicado");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("No existe el directorio indicado");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine();
            }


            //ELIMINA UN ANIMAL DEL ESTABLECIMIENTO
            Console.WriteLine("ELIMINA UN ANIMAL DEL ESTABLECIMIENTO...");
            Console.ReadKey();
            Establecimiento.EliminarAnimal(b1);
            Console.WriteLine($"Se eliminó el animal con identificación {b1.Identificacion}\n");


            //MODIFICA UN BOVINO
            Console.WriteLine("MODIFICA UN ANIMAL DEL ESTABLECIMIENTO...");
            Console.ReadKey();
            Bovino bovinoModificado = new Bovino(DateTime.Today, "B45457", Bovino.ESexo.Macho, Bovino.ERaza.Angus, Bovino.EUso.Tambo);

            if(Establecimiento.ModificarAnimal(bovinoModificado))
            {
                Console.WriteLine($"Se modificó el animal con identificación {bovinoModificado.Identificacion}");
            }
            else
            {
                Console.WriteLine($"No se pudo modificar el animal con identificación {bovinoModificado.Identificacion}");
            }
            Console.WriteLine();

            //GENERA ESTADISTICAS DEL ESTABLECIMIENTO
            Estadisticas estadisticas = new Estadisticas();
            Console.WriteLine("GENERAR ESTADISTICAS DEL ESTABLECIMIENTO...");
            Console.ReadKey();
            Console.WriteLine(estadisticas);
        }
    }
}
