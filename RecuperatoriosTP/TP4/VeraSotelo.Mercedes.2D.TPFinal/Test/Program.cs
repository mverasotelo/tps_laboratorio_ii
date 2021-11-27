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

            //ELIMINA UN ANIMAL DEL ESTABLECIMIENTO
            Console.WriteLine("ELIMINA UN ANIMAL DEL ESTABLECIMIENTO...");
            Console.ReadKey();
            Establecimiento.EliminarAnimal(Establecimiento.StockGanadero[2]);
            Console.WriteLine($"Se eliminó el animal con identificación {Establecimiento.StockGanadero[2].Identificacion}\n");


            //MODIFICA UN BOVINO
            Console.WriteLine("MODIFICA UN ANIMAL DEL ESTABLECIMIENTO...");
            Console.ReadKey();
            Bovino bovinoModificado = new Bovino(1001, DateTime.Today, Bovino.ESexo.Macho, Bovino.ERaza.Angus, Bovino.EUso.Tambo);

            if (Establecimiento.ModificarAnimal(bovinoModificado))
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


            Console.WriteLine("LISTAR LOS BOVINOS DE LA BASE DE DATOS...");
            Console.ReadKey();
            try
            {
                foreach (Bovino bovino in Establecimiento.StockGanadero)
                {
                    Console.WriteLine(bovino);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}\n");

            }
        }
    }
}
