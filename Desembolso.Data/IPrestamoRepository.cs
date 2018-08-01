using Desembolso.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desembolso.Data
{
    public interface IPrestamoRepository
    {
        Task<List<Prestamo>> ObtenerDesembolsoPorEnteIDAsync(long ente_id);
        Task<List<Prestamo>> ObtenerDesembolsoPorEnteDescripcionAsync(string ente_desc);
        Task<List<Prestamo>> ObtenerDesembolsoPorEnteDescripcionFechaAsync(string ente_desc, DateTime? fecha_desde, DateTime? fecha_hasta);
        Task<List<Prestamo>> ObtenerDesembolsoPorEnteIDFechaAsync(long ente_id, DateTime? fecha_desde, DateTime? fecha_hasta);
    }
}
