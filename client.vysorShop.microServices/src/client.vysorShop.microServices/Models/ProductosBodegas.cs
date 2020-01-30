using System;
using System.Collections.Generic;

namespace client.vysorShop.microServices.Models
{
    public partial class ProductosBodegas
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdBodega { get; set; }
        public decimal Cantidad { get; set; }
        public int? IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Usuario { get; set; }
    }
}
