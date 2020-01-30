using System;
using System.Collections.Generic;

namespace cellar.vysorShop.microServices.Models
{
    public partial class Productos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Plu { get; set; }
        public string Nombre { get; set; }
        public decimal Costo { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacionCosto { get; set; }
        public string Usuario { get; set; }
    }
}
