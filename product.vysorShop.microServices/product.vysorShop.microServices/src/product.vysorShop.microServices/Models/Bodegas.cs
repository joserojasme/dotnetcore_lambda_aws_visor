﻿using System;
using System.Collections.Generic;

namespace product.vysorShop.microServices.Models
{
    public partial class Bodegas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Usuario { get; set; }
    }
}
