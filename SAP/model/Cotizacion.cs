using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Cotizacion
    {
        private int id;
        private Double valor;
        private ICollection<CotizacionLine> lines; 

        public int Id {
            get { return id; }
            set { id = value; }
        }

        public Double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public ICollection<CotizacionLine> Lines
        {
            get { return lines; }
            set { lines = value; }
        }
    }
}
