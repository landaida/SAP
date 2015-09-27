using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAP.util;
using SAPbobsCOM;
namespace SAP.model
{
    class OfertaVentaLine
    {
        private Items items = GlobalVar.Empresa.GetBusinessObject(BoObjectTypes.oItems);

        private int id;
        private String productoId;
        private Producto producto;
        private Double cantidad = 1;
        private Double precioUnitario;
        private Double descuento;
        private String indicadorImpuesto;
        private Double total;

        public OfertaVentaLine(){}

        public OfertaVentaLine(Double cantidad, Double precioUnitario) {
            this.cantidad = cantidad;
            this.precioUnitario = precioUnitario;
        }
        
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Items Items
        {
            set
            {
                this.items = value;
            }
        }

        public String ProductoId
        {
            get { return productoId; }
            set {
                productoId = value;
                if(value != null && (producto == null || producto.ItemCode != value))
                {
                    List<Producto> lista = Util.getGenericList<Producto>("ItemCode", "ItemName", "oitm", "and itemCode = "+ value).ToList();
                    if(lista != null && lista.Count > 0)
                    {
                        this.producto = lista.First();
                        this.getProductInfo(value);
                    }                           
                }
            }
        }

        public Producto Producto
        {
            get { return producto; }
            set {
                producto = value;
                if(value != null)
                {
                    this.ProductoId = value.ItemCode;
                    this.getProductInfo(value.ItemCode);
                }
            }
        }

        public Double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; this.refreshTotal(); }
        }

        public Double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; this.refreshTotal(); }
        }

        public Double PrecioUnitarioGravada
        {
            get {
                return precioUnitario == 0 ? 0 : precioUnitario / this.getImpuestoPorcentaje();
            }
        }

        public Double TotalGravada
        {
            get {
                return precioUnitario == 0 ? 0 : PrecioUnitarioGravada * this.Cantidad;
            }
        }

        public Double PrecioUnitarioImpuesto
        {
            get {
                return precioUnitario == 0 ? 0 : precioUnitario - (precioUnitario / this.getImpuestoPorcentaje());
            }
        }

        private Double getImpuestoPorcentaje()
        {
            Double value = (10.0 / 100) + 1;
            if (this.IndicadorImpuesto.Equals("IVA_5"))
                value = (5.0 / 100) + 1;
            return value;
        }

        public Double Descuento
        {
            get { return descuento; }
            set { descuento = value; this.refreshTotal(); }
        }

        public String IndicadorImpuesto
        {
            get { return indicadorImpuesto; }
            set { indicadorImpuesto = value; }
        }

        public Double Total
        {
            get { return total; }
            set { total = value; }
        }

        public Double DescuentoValor
        {
            get { return (PrecioUnitario * Descuento)/100; }
        }

        #region Functions
        private void getProductInfo(String value)
        {
            //bool res = items.GetByKey(value);
            //items.PriceList.Price
            this.PrecioUnitario = Util.getItemPrice(GlobalVar.cardCode, value, GlobalVar.datetime);
            this.IndicadorImpuesto = items.ApTaxCode;
        }
        private void refreshTotal()
        {
            this.Total = (this.PrecioUnitario - ((this.PrecioUnitario * this.Descuento) / 100)) * this.Cantidad;
        }

        #endregion
    }
}
