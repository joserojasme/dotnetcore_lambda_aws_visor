using System;
using System.Collections.Generic;

namespace transactions.vysorShop.microServices.Models
{
    public partial class Transacciones
    {
        public string IdTransacciones { get; set; }
        public DateTime Fecha { get; set; }
        public int Tipo { get; set; }
        public int Estado { get; set; }
        public string Data { get; set; }
        public int? Intentos { get; set; }
    }
}
