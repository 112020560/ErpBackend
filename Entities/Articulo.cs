using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Articulo
    {
        public int pk_producto { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal precio_venta { get; set; }
        public int descuento { get; set; }
        public int descuento_maximo { get; set; }
        public decimal iva { get; set; }
    }
}
