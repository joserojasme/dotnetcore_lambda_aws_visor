using System;
using System.Collections.Generic;

namespace product.vysorShop.microServices.Models
{
    public partial class ResolucionDian
    {
        public int IdresolucionDian { get; set; }
        public string NumeroResolucion { get; set; }
        public string Prefijo { get; set; }
        public int RangoDesde { get; set; }
        public int RangoHasta { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? NumActual { get; set; }
        public int? Pos { get; set; }
    }
}
