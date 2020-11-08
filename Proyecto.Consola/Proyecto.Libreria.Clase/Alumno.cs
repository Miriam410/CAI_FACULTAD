using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Libreria.Clase.Entidades
{
    public class Alumno : Persona
    {
        private int _codigo;

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public Alumno(int cod, string nom, string ape, DateTime fechaNac)
        {
            this._codigo = cod;
            this._nombre = nom;
            this._apellido = ape;
            this._fechaNac = fechaNac;
        }

        public string GetCredencial
        {
            get {return GetCredencial();}
        }

        public override string GetCredencial()
        {
            string ficha = string.Format("Codigo {0}, {1},{2}", this._codigo, this._nombre, this._apellido);
            return ficha;
        }

        public override string ToString()
        {
            return GetCredencial();
        }
    }
}
