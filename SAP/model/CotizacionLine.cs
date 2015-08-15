using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class CotizacionLine
    {
        private int id;
        private Producto producto;
        private Double cantidad;
        private Double valor;
        private Double descuento;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        public Double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public Double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public Double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }
    }
}
