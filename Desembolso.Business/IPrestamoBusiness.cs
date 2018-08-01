using Desembolso.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Desembolso.Business
{
    public interface IPrestamoBusiness
    {
        Task<PrestamoResponse> ObtenerDesembolsoPorEnteIDAsync(long ente_id);
        Task<PrestamoResponse> ObtenerDesembolsoPorEnteDescripcionAsync(string ente_desc);
        Task<PrestamoResponse> ObtenerDesembolsoPorEnteDescripcionFechaAsync(string ente_desc, DateTime? fecha_desde, DateTime? fecha_hasta);
        Task<PrestamoResponse> ObtenerDesembolsoPorEnteIDFechaAsync(long ente_id, DateTime? fecha_desde, DateTime? fecha_hasta);
    }
}
