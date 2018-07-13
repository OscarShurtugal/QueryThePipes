using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QueryThePipes
{
    class Program
    {
        static void Main(string[] args)
        {

            string rutaDeArchivo = @"ruta del archivo";

            //ESTO ES PARA CUANDO LO LLAMES DESDE UNA DLL
            //rutaDeArchivo = "@" + rutaDeArchivo;

            string[] archivoDelimitado = File.ReadAllLines(rutaDeArchivo);

            List<string> filtro = new List<string>();
            

            foreach (var item in archivoDelimitado)
            {
             
                if(item.Count(f=>f=='|') == 10)
                {
                    
                    filtro.Add(item);
                }
            }

            
            Console.WriteLine("Inicialmente eran: ",archivoDelimitado.Count().ToString());

            Console.WriteLine("Se filtraron: ",archivoDelimitado.Count()-filtro.Count());

            Console.WriteLine("Quedan: ",filtro.Count().ToString());



            //se uso la MISMA variable de ruta de archivo para REEMPLAZAR tu archivo con el filtrado
            StreamWriter sw = new StreamWriter(rutaDeArchivo,false);
            foreach (var item in filtro)
            {
                sw.WriteLine(item);
                //Console.WriteLine(item.MSISDN);
            }
            sw.Close();

            Console.ReadLine();
            

        }
    }
}
