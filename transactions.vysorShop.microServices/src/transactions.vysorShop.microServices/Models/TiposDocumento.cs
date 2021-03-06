﻿using System;
using System.Collections.Generic;

namespace transactions.vysorShop.microServices.Models
{
    public partial class TiposDocumento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int? IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Usuario { get; set; }
    }
}
