﻿using System;
using System.Collections.Generic;

namespace product.vysorShop.microServices.Models
{
    public partial class ProductosListaPrecios
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
        public int IdListaPrecio { get; set; }
        public decimal Precio { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Usuario { get; set; }
        public decimal? Iva { get; set; }
    }
}
