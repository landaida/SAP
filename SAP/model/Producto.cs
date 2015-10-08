using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPLibraryParaguay;

namespace SAP.model
{
    class Producto
    {
        public Producto()
        { this.ItemCode = ""; this.ItemName = ""; }

        public Producto(string itemCode, string itemName)
        {
            this.ItemCode = itemCode;
            this.ItemName = itemName;
        }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }

        public override string ToString()
        {
            return this.ItemName;
        }

        public override bool Equals(object that)
        {
            return new EqualsBuilder<Producto>(this, that)
              .With(m => m.ItemCode)
              .With(m => m.ItemName)
              .Equals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<Producto>(this)
              .With(m => m.ItemCode)
              .With(m => m.ItemName)
              .HashCode;
        }
    }
}
