using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto.Libreria.Clase;
using Proyecto.Libreria.Clase.Entidades;
using Libreria.Consola;

namespace Proyecto.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            bool ContinuarActivo = true;

            string menu = "1) Listar Alumnos" + Environment.NewLine + "2)Listar Empleado"
                + Environment.NewLine + "3) Agregar Alumno" + Environment.NewLine +
                "4) Agregar Empleado" + Environment.NewLine + "5)Borrar Alumno" +
                Environment.NewLine + "6) Borrar Empleado" + Environment.NewLine +
                "7)Limpiar Consola" + Environment.NewLine + "X)Salir";

            Facultad fce = new Facultad("FCE");
            Console.WriteLine("Bienvenidos a " + fce.Nombre);

            do
            {
                Console.WriteLine(menu);

                try
                {
                    string opcionSeleccionada = Console.ReadLine();
                    if (ConsolaHelper.EsOpcionValida(opcionSeleccionada, "1234567X"))
                    {
                        if (opcionSeleccionada.ToUpper() == "X")
                        {
                            ContinuarActivo = false;
                            continue;
                        }
                        switch (opcionSeleccionada)
                        {
                            case "1":
                                Program.ListarAlumno(fce);
                                break;
                            case "2":
                                Program.ListarEmpleado(fce);
                                break;
                            case "3":
                                Program.AgregarAlumno(fce);
                                break;
                            case "4":
                                Program.AgregarEmpleado(fce);
                                break;
                            case "5":
                                Program.EliminarAlumno(fce);
                                break;
                            case "6":
                                Program.EliminarEmpleado(fce);
                                break;
                            case "7":
                                Console.Clear();
                                break;
                            default:
                                Console.WriteLine("Opcion Invalida");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Opcion Invalida");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error durante la ejecucion del comando." +
                        "Por favor intente nuevamente. Mensaje: " + ex.Message);
                }
                Console.WriteLine("Ingrese una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            } while (ContinuarActivo);
            Console.WriteLine("Gracias por usar la APP");
            Console.ReadKey();
        }

        public static void ListarAlumno(Facultad facultad)
        {
            if (facultad.TieneAlumnos)
            {
                foreach (Alumno a in facultad.Alumno)
                {
                    MostrarCredencial(a);
                }
            }
            else
            {
                Console.WriteLine("Por el momento no hay alumnos para listar");
            }
        }

        public static void ListarEmpleado(Facultad facultad)
        {
            if (facultad.TieneEmpleado)
            {
                foreach (Empleado e in facultad.Empleados)
                {
                    MostrarCredencial(e);
                }
            }
            else
            {
                Console.WriteLine("Por el momento no hay empleados para listar");
            }
        }

        public static void MostrarCredencial(Persona persona)
        {
            Console.WriteLine(persona.GetCredencial());
        }
        public static void AgregarAlumno(Facultad facultad)
        {
            try
            {
                int c = ConsolaHelper.PedirInt("Codigo");
                string n = ConsolaHelper.PedirString("Nombre");
                string a = ConsolaHelper.PedirString("Apellido");
                DateTime f = ConsolaHelper.PedirFecha("Nacimiento");

                Alumno a1 = new Alumno(c, n, a, f);
                facultad.AgregarAlumno(a1);
                Console.WriteLine("Alumno agregado");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en uno de los datos ingresados"+
                    Environment.NewLine + ex.Message + "Intente nuevamente" 
                    + Environment.NewLine);
                AgregarAlumno(facultad);
            }
        }

        public static void AgregarEmpleado(Facultad facultad)
        {
            try
            {
                int c = ConsolaHelper.PedirInt("Legajo");
                string n = ConsolaHelper.PedirString("Nombre");
                string a = ConsolaHelper.PedirString("Apellido");
                string t = ConsolaHelper.PedirString("Tipo Empleado(D docente, B bedel, A directivo)");
                DateTime f = ConsolaHelper.PedirFecha("Nacimiento");

                string ap = string.Empty;
                if (t.ToUpper() == "B")
                {
                    ap = ConsolaHelper.PedirString("Apodo");
                }
                double s = ConsolaHelper.PedirDouble("Salario Bruto");
                facultad.AgregarEmpleado(c, n, a, f, t, ap, s, DateTime.Now.AddYears(-20));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en uno de los datos ingresados" +
                    Environment.NewLine + ex.Message + "Intente nuevamente"
                    + Environment.NewLine);
                AgregarEmpleado(facultad);
            }
        }

        public static void EliminarAlumno(Facultad facultad)
        {
            if (facultad.TieneAlumnos)
            {
                ListarAlumno(facultad);
                Console.WriteLine("Seleccione un codigo de la lista para eliminar:");
                try
                {
                    int c = ConsolaHelper.PedirInt("Codigo");
                    facultad.EliminarAlumno(c);
                    Console.WriteLine("El alumno ha sido eliminado");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No es posible eliminar el alumno solicitado." + ex.Message);
                }
            }
            else 
            {
                Console.WriteLine("Por el momento no hay alumnos para eliminar");
            }
        }

        public static void EliminarEmpleado(Facultad facultad)
        {
            if (facultad.TieneEmpleado)
            {
                ListarEmpleado(facultad);
                Console.WriteLine("Seleccione un legajo de la lista para eliminar:");
                try
                {
                    int c = ConsolaHelper.PedirInt("Legajo");
                    facultad.EliminarEmpleado(c);
                    Console.WriteLine("El alumno ha sido eliminado");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No es posible eliminar el empleado solicitado." + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Por el momento no hay empleados para eliminar");
            }
        }

    }
}
