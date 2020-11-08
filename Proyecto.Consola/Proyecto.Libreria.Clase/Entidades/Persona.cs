using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Libreria.Clase.Entidades
{
    public abstract class Persona
    {
        protected string _apellido;
        protected DateTime _fechaNac;
        protected string _nombre;

        public string Apellido
        {
            get { return _apellido; }
            set { _nombre = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int Edad
        {
            get
            {
                if (DateTime.Now.Year > 1900)
                {
                    return (DateTime.Now.Year - _fechaNac.Year);
                }
                else
                {
                    throw new Exception("Nadie tiene mas de 120 años");
                }
            }
        }

        public abstract string  GetCredencial();

        public virtual string GetNombreCompelto()
        {
            return string.Format("{0},{1}", this._apellido, this._nombre);
        }


    }
}
