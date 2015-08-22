using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.model
{
    class Producto
    {
        public Producto()
        { }

        public Producto(string itemCode, string itemName)
        {
            this.ItemCode = itemCode;
            this.ItemName = itemName;
        }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public override string ToString()
        {
            return ItemName;
        }
    }
}
