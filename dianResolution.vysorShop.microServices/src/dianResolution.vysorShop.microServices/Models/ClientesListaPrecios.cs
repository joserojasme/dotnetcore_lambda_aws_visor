using System;
using System.Collections.Generic;

namespace dianResolution.vysorShop.microServices.Models
{
    public partial class ClientesListaPrecios
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdListaPrecio { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Usuario { get; set; }
    }
}
