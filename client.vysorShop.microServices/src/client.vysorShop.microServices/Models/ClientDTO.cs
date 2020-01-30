using System;
using System.ComponentModel.DataAnnotations;

namespace client.vysorShop.microServices.Models
{
    public class ClientDTO
    {
        public ClientDTO()
        { }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Identificacion is required.")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Nombre is required.")]
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
        public ListaPrecios ListaPrecio { get; set; }
    }

}
