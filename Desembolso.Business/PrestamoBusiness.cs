using System;
using System.Threading.Tasks;
using Desembolso.Contracts;
using Desembolso.Data;

namespace Desembolso.Business
{
    public class PrestamoBusiness : IPrestamoBusiness
    {
        private readonly IPrestamoRepository prestamoRepository;

        public PrestamoBusiness(IPrestamoRepository prestamoRepository)
        {
            this.prestamoRepository = prestamoRepository;
        }

        public async Task<PrestamoResponse> ObtenerDesembolsoPorEnteIDAsync(long ente_id)
        {
            PrestamoResponse prestamoResponse = new PrestamoResponse();
            var prestamo = await this.prestamoRepository.ObtenerDesembolsoPorEnteIDAsync(ente_id);

            if (prestamo.Count == 0 || prestamo == null)
            {
                prestamoResponse.Message = "No se encontraron desembolsos para el ente ingresado";
                prestamoResponse.Error = true.ToString();
            }
            else
            {
                foreach (var prest in prestamo)
                {
                    prestamoResponse.Resultado.Add(prest);
                };
            }

            return prestamoResponse;

        }

        public async Task<PrestamoResponse> ObtenerDesembolsoPorEnteDescripcionAsync(string ente_desc)
        {
            PrestamoResponse prestamoResponse = new PrestamoResponse();
            var prestamo = await this.prestamoRepository.ObtenerDesembolsoPorEnteDescripcionAsync(ente_desc);

            if (prestamo.Count == 0 || prestamo == null)
            {
                prestamoResponse.Message = "No se encontraron desembolsos con la descripción del ente ingresado";
                prestamoResponse.Error = true.ToString();
            }
            else
            {
                foreach (var prest in prestamo)
                {
                    prestamoResponse.Resultado.Add(prest);
                };
            }

            return prestamoResponse;
        }

        public async Task<PrestamoResponse> ObtenerDesembolsoPorEnteDescripcionFechaAsync(string ente_desc, DateTime? fecha_desde, DateTime? fecha_hasta)
        {
            PrestamoResponse prestamoResponse = new PrestamoResponse();
            var prestamo = await this.prestamoRepository.ObtenerDesembolsoPorEnteDescripcionFechaAsync(ente_desc, fecha_desde, fecha_hasta);

            if (prestamo.Count == 0 || prestamo == null)
            {
                prestamoResponse.Message = "No se encontraron desembolsos en las fechas desde y hasta para la descripción del ente ingresado";
                prestamoResponse.Error = true.ToString();
            }
            else
            {
                foreach (var prest in prestamo)
                {
                    prestamoResponse.Resultado.Add(prest);
                };
            }

            return prestamoResponse;
        }

        public async Task<PrestamoResponse> ObtenerDesembolsoPorEnteIDFechaAsync(long ente_id, DateTime? fecha_desde, DateTime? fecha_hasta)
        {
            PrestamoResponse prestamoResponse = new PrestamoResponse();
            var prestamo = await this.prestamoRepository.ObtenerDesembolsoPorEnteIDFechaAsync(ente_id, fecha_desde, fecha_hasta);

            if (prestamo.Count == 0 || prestamo == null)
            {
                prestamoResponse.Message = "No se encontraron desembolsos en las fechas desde y hasta seleccionadas para el ente ingresado";
                prestamoResponse.Error = true.ToString();
            }
            else
            {
                foreach (var prest in prestamo)
                {
                    prestamoResponse.Resultado.Add(prest);
                };
            }

            return prestamoResponse;
        }
    }
}
