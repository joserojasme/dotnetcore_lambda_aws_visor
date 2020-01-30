using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pricelist.vysorShop.microServices.Models
{
    public partial class ListaPrecios
    {

        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Usuario { get; set; }
    }
}
