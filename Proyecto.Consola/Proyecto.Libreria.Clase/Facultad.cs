using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Libreria.Clase.Entidades
{
    public class Facultad
    {
        private List<Alumno> _alumnos;
        private List<Empleado> _empleados;
        private string _nombre;
        private int _cantidadSedes;

        public List<Alumno> Alumno
        {
            get { return _alumnos; }
        }
        public List<Empleado> Empleados
        {
            get { return _empleados; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int CantidadSedes
        {
            get { return _cantidadSedes; }
            set { _cantidadSedes = value; }
        }

        public bool TieneAlumnos
        {
            get { return _alumnos.Count > 0; }
        }

        public bool TieneEmpleado
        {
            get { return _empleados.Count > 0; }
        }

        public Facultad(string nombre)
        {
            this._nombre = nombre;
            this._empleados = new List<Empleado>();
            this._alumnos = new List<Alumno>();
        }

        public void IngresarSalario(int codigo, Salario salario)
        {
            foreach (Empleado e in this.Empleados)
            {
                if (e.Legajo == codigo)
                {
                    e.AgregarSalario(salario);
                }
            }
        }

        public void AgregarAlumno(Alumno alumno)
        {
            if (this._alumnos.SingleOrDefault(x => x.Codigo == _alumnos.Codigo) != null)
            {
                throw new Exception("El alumno ya existe");
            }
            if (alumno.Edad < 18)
            {
                throw new Exception("El alumno es menor");
            }
            this._alumnos.Add(alumno);
        }

        // FORMA 2 DE RESOLVERLO
        //public void AgregarAlumno(int codigo, string nombre, string apellido, 
        //    DateTime fechaNac)
        //{
        //    Alumno a1 = new Alumno(codigo, nombre, apellido, fechaNac);
        //    this.AgregarAlumno(a1);
        //}

        public void AgregarEmpleado(int codigo, string nombre, string apellido, DateTime ingreso,
            string tipo, string apodo, double bruto, DateTime nac)
        {
            Empleado empleado;
            switch (this.ToUpper())
            {
                case "A":
                    empleado = new Directivo(codigo, nombre, apellido, ingreso, bruto, nac);
                    break;
                case "B":
                    empleado = new Docente(codigo, nombre, apellido, ingreso, bruto, nac);
                    break;
                case "C":
                    empleado = new Bedel(codigo, nombre, apellido, ingreso, bruto,apodo, nac);
                    break;
                default:
                    throw new Exception("Tipo invalido");
            }
        }

        public void EliminarAlumno(int c)
        {
            Alumno alumno = this._alumnos.SingleOrDefault(x => x.Codigo == c);
            if (alumno != null)
            {
                this._alumnos.Remove(alumno);
            }
            else 
            {
                throw new Exception("El alumno no esta registrado en esta facultad");
            }
        }

        public void EliminarEmpleado(int c)
        {
            Empleado empleado = this._empleados.SingleOrDefault(x => x.Legajo == c);
            if (empleado != null)
            {
                if (empleado.Antiguedad > 5)
                {
                    throw new Exception("El empleado es demasiado caro para despedir");
                }
                else 
                {
                    this._empleados.Remove(empleado);
                }
            }
            else
            {
                throw new Exception("El empleado no trabaja en esta facultad");
            }
        }
    }
}
