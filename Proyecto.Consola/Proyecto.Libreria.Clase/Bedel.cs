using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Libreria.Clase.Entidades
{
    public class Bedel:Empleado
    {
        protected string _apodo;

        public string Apodo
        {
            get { return _apodo; }
            set { _apodo = value; }
        }

        public Bedel(int cod, string nombre, string apellido, DateTime fechaIngreso,
            double bruto, string apodo, DateTime nacimiento) : base(cod, nombre, apellido, fechaIngreso,
                bruto, nacimiento)
        {
            this._apodo = apodo;
        }

        public override string GetNombreCompleto()
        {
            return "Bedel" + this.Apodo;
        }
    }   
}
