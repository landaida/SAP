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
        private List<Producto> productos;
        private Double cantidad;
        private Double precioUnitario;
        private Double descuento;
        private String indicadorImpuesto = "IVA_10";

        public CotizacionLine(){}

        public CotizacionLine(List<Producto> productos)
        {
            this.productos = productos;
        }

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

        public Double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public Double Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        public String IndicadorImpuesto
        {
            get { return indicadorImpuesto; }
            set { indicadorImpuesto = value; }
        }

        public List<Producto> Productos
        {
            get { return productos; }
            set { productos = value; }
        }
    }
}
