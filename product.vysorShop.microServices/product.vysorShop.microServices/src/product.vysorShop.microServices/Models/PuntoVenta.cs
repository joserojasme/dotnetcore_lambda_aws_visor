using System;
using System.Collections.Generic;

namespace product.vysorShop.microServices.Models
{
    public partial class PuntoVenta
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int? Estado { get; set; }
    }
}
