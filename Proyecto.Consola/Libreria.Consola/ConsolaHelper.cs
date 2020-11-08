using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Consola
{
    public static class ConsolaHelper
    {
        public static bool EsOpcionValida(string input, string opcionesValidas)
        {
            try
            {
                if (string.IsNullOrEmpty(input) || input.Length > 1 ||
                    !opcionesValidas.ToUpper().Contains(input.ToUpper()))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string PedirString(string msg)
        {
            Console.WriteLine("Ingrese"+msg);
            string n = Console.ReadLine();
            return n;
        }

        public static int PedirInt(string msg)
        {
            Console.WriteLine("Ingrese"+ msg);
            int c = Convert.ToInt32(Console.ReadLine());
            return c;
        }

        public static double PedirDouble(string msg)
        {
            Console.WriteLine("Ingrese"+ msg);
            double d = Convert.ToDouble(Console.ReadLine());
            return d;
        }

        public static DateTime PedirFecha(string msg)
        {
            Console.WriteLine("Ingrese fecha" + msg + "Solo en el formato: YYYY-MM-DD");
            DateTime f = Convert.ToDateTime(Console.ReadLine());
            return f;
        }

        
    }
}
