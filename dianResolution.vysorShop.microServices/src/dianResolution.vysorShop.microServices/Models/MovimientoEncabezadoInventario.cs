using System;
using System.Collections.Generic;

namespace dianResolution.vysorShop.microServices.Models
{
    public partial class MovimientoEncabezadoInventario
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public int IdMotivo { get; set; }
        public int? IdBodegaOrigen { get; set; }
        public int? IdBodegaDestino { get; set; }
        public decimal? Cantidad { get; set; }
        public string Observacion { get; set; }
        public int? IdEstado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Usuario { get; set; }
    }
}
