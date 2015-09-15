using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class OfertaVenta
    {
        private int id;
        private Double valor;
        private List<OfertaVentaLine> lines = new List<OfertaVentaLine>();
        private DateTime fecha;


        public int Id {
            get { return id; }
            set { id = value; }
        }

        public Double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public List<OfertaVentaLine> Lines
        {
            get { return lines; }
            set { lines = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        
    }
}
