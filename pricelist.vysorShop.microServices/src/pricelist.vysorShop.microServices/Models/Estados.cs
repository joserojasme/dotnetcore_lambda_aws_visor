﻿using System;
using System.Collections.Generic;

namespace pricelist.vysorShop.microServices.Models
{
    public partial class Estados
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public string Usuario { get; set; }
    }
}
