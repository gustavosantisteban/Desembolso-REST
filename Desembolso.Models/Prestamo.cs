using System;

namespace Desembolso.Models
{
    public class Prestamo
    {
        public int PrestamoId { get; set; }

        public DateTime FechaDesde { get; set; }

        public DateTime FechaHasta { get; set; }

        public int EntedeEntregaID { get; set; }

        public string EntedeEntrega { get; set; }

        public string Tipo { get; set; }

        public string Numero { get; set; }

        public string Cliente { get; set; }

        public decimal Monto { get; set; }

        public string Estado { get; set; }
    }
}
