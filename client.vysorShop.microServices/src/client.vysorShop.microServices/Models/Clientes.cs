using System;
using System.Collections.Generic;

namespace client.vysorShop.microServices.Models
{
    public partial class Clientes
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string ReferenciaNombre { get; set; }
        public string Email { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string Usuario { get; set; }
        public int? IdListaPrecios { get; set; }

        public ListaPrecios IdListaPreciosNavigation { get; set; }
    }
}
