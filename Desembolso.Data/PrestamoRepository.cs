using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desembolso.Models;

namespace Desembolso.Data
{
    public class PrestamoRepository : IPrestamoRepository
    {
        public async Task<List<Prestamo>> ObtenerDesembolsoPorEnteIDAsync(long ente_id)
        {
            return await Task.Run(() => this.ObtenerPrestamos().Result.Where(x => x.EntedeEntregaID == ente_id).ToList());
        }

        public async Task<List<Prestamo>> ObtenerDesembolsoPorEnteDescripcionAsync(string ente_desc)
        {
            return await Task.Run(() => this.ObtenerPrestamos().Result.Where(x => x.EntedeEntrega.ToUpper().Contains(ente_desc.ToUpper())).ToList());
        }

        public async Task<List<Prestamo>> ObtenerDesembolsoPorEnteDescripcionFechaAsync(string ente_desc, DateTime? fecha_desde, DateTime? fecha_hasta)
        {
            return await Task.Run(() => this.ObtenerPrestamos().Result.Where(x => x.EntedeEntrega.ToUpper().Contains(ente_desc.ToUpper()) && x.FechaDesde.Date >= fecha_desde.Value && x.FechaHasta < fecha_hasta).ToList());
        }

        public async Task<List<Prestamo>> ObtenerDesembolsoPorEnteIDFechaAsync(long ente_id, DateTime? fecha_desde, DateTime? fecha_hasta)
        {
            return await Task.Run(() => this.ObtenerPrestamos().Result.Where(x => x.EntedeEntregaID == ente_id && x.FechaDesde > fecha_desde.Value && x.FechaHasta < fecha_hasta).ToList());
        }

        private async Task<List<Prestamo>> ObtenerPrestamos()
        {
            var prestamos =  new List<Prestamo>() {
                new Prestamo() { PrestamoId = 1, EntedeEntregaID = 409516, EntedeEntrega = "Walmart", Tipo = "DNI", Numero = "45367281", Cliente = "Perez, Pablo", Monto = 400000.00M, Estado = "Desembolsado", FechaDesde = DateTime.Now, FechaHasta = DateTime.Now.Date },

                 new Prestamo() { PrestamoId = 2, EntedeEntregaID = 409519, EntedeEntrega = "NoEncontrado", Tipo = "DNI", Numero = "12345678", Cliente = "Perez, Juan", Monto = 400000.00M, Estado = "Desembolsado", FechaDesde = DateTime.Now, FechaHasta = DateTime.Now.Date.AddDays(8) },

                 new Prestamo() { PrestamoId = 3, EntedeEntregaID = 409516, EntedeEntrega = "Walmart", Tipo = "DNI", Numero = "45367281", Cliente = "Perez, Pablo", Monto = 19000.00M, Estado = "Desembolsado", FechaDesde = DateTime.Now, FechaHasta = DateTime.Now.Date },

                 new Prestamo() { PrestamoId = 4, EntedeEntregaID = 409516, EntedeEntrega = "Walmart", Tipo = "DNI", Numero = "45367281", Cliente = "Perez, Pablo", Monto = 30000.00M, Estado = "Desembolsado", FechaDesde = DateTime.Now, FechaHasta = DateTime.Now.Date.AddDays(1) },

                 new Prestamo() { PrestamoId = 5, EntedeEntregaID = 409520, EntedeEntrega = "Walmart", Tipo = "DNI", Numero = "87654321", Cliente = "Perez, José", Monto = 400000.00M, Estado = "Desembolsado", FechaDesde = DateTime.Now, FechaHasta = DateTime.Now.Date },
            };

            return prestamos.ToList();
        }
    }
}
