using System;
using System.Collections.Generic;

namespace dianResolution.vysorShop.microServices.Models
{
    public partial class MovimientoDetalleInventario
    {
        public int Id { get; set; }
        public int IdEncabezado { get; set; }
        public int IdProducto { get; set; }
        public decimal? Cantidad { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Usuario { get; set; }
    }
}
