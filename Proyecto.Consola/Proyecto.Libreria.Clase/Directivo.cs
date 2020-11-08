﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Libreria.Clase.Entidades
{
    public class Directivo:Empleado
    {
        public Directivo(int cod, string nombre, string apellido, DateTime fechaIngreso,
            double bruto, DateTime nacimiento) : base(cod, nombre, apellido, fechaIngreso
                , bruto, nacimiento)
        {
            
        }

        public override string GetNombreCompleto()
        {
            return "SR. Director" + this._apellido;
        }
    }
}
