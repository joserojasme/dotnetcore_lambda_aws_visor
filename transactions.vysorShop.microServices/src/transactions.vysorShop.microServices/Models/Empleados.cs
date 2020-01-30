using System;
using System.Collections.Generic;

namespace transactions.vysorShop.microServices.Models
{
    public partial class Empleados
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Eps { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public int? IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Usuario { get; set; }
    }
}
