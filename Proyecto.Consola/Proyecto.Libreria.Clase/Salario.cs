using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto.Libreria.Clase
{
    public class Salario
    {
        private double _bruto;
        private string _codigoTransferencia;
        private double _descuento;
        private DateTime _fecha;

        public double Bruto
        {
            get { return _bruto; }
            set { _bruto = value; }
        }
        public string CodigoTransferencia
        {
            get { return _codigoTransferencia; }
            set { _codigoTransferencia = value; }
        }
        public double Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public Salario(double bruto)
        {
            this._bruto = bruto;
            this._fecha = DateTime.Now;
            this._descuento=bruto*0.17;
            this._codigoTransferencia = _fecha.Ticks.ToString();
        }

        public double GetSalarioNeto()
        { 
            return _bruto -_descuento;
        }
       


    }
}
