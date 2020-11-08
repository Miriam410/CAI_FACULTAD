using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Libreria.Clase.Entidades
{
    public abstract class Empleado : Persona
    {
        private DateTime _fechaIngreso;
        private int _legajo;
        private List<Salario> _salarios;
        private Salario _ultimoSalario;

        public int Antiguedad 
        {
            get { return (DateTime.Now - _fechaIngreso).Days / 365; }
        }

        public int Legajo 
        {
            get{ return _legajo; }
            set { _legajo = value; }
        }

        public Salario UltimoSalario
        {
            get { return _ultimoSalario; }
            set { _ultimoSalario = value; }
        }

        public DateTime FechaIngreso
        {
            get { return _fechaIngreso; }
        }

        public DateTime FechaNacimiento
        {
            get { return _fechaNac; }
        }

        public List<Salario> Salarios
        {
            get { return _salarios; }
        }

        public override string GetNombreCompleto()
        {
            return this.Apellido;
        }

        public override string GetCredencial()
        {
            string ficha = string.Format("{0}-{3}{1} Salario ${2}", this.Legajo,
                GetNombreCompelto(), this._ultimoSalario.GetSalarioNeto().ToString(),
                this.Nombre);
        }

        public Empleado()
        { 
        }

        public Empleado(int cod, string nombre, string apellido, DateTime fechaIngreso,
            double bruto, DateTime nacimiento)
        {
            if (nacimiento.Year > DateTime.Now.AddYears(18).Year)
            {
                throw new Exception("No se pude tomar empleados menores");
            }
            this.Legajo = cod;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this._fechaIngreso = fechaIngreso;
            this._ultimoSalario = new Salario(bruto);
            this._fechaNac = nacimiento;
            this._salarios = new List<Salario>();
            AgregarSalario(this._ultimoSalario);
        }

        public void AgregarSalario(Salario s)
        {
            this._salarios.Add(s);
            this._ultimoSalario = s;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Empleado))
            {
                return false;
            }
            return (this.Legajo == ((Empleado)obj).Legajo);
        }

        public override string ToString()
        {
            return GetCredencial();
        }
    }
}
