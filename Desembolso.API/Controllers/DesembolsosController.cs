using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desembolso.Business;
using Desembolso.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desembolso.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DesembolsosController : Controller
    {
        private readonly IPrestamoBusiness prestamoBusiness;

        public DesembolsosController(IPrestamoBusiness prestamoBusiness)
        {
            this.prestamoBusiness = prestamoBusiness;
        }
        
        [HttpGet("{ente_id}")]
        public async Task<PrestamoResponse> Get(long ente_id)
        {
            this.ValidarEnteIdRequerido(ente_id);
            return await prestamoBusiness.ObtenerDesembolsoPorEnteIDAsync(ente_id);
        }
        
        [HttpGet("{ente_desc}")]
        public async Task<PrestamoResponse> Get(string ente_desc)
        {
            this.ValidarEnteDescripcionRequerido(ente_desc);
            return await prestamoBusiness.ObtenerDesembolsoPorEnteDescripcionAsync(ente_desc);
        }

        [HttpGet("{ente_desc}/{fecha_desde}/{fecha_hasta}")]
        public async Task<PrestamoResponse> Get(string ente_desc, DateTime? fecha_desde, DateTime? fecha_hasta)
        {
            if (!fecha_hasta.HasValue)
            {
                fecha_desde = DateTime.Now.Date;
                fecha_hasta = DateTime.Now.Date;
            }
            return await prestamoBusiness.ObtenerDesembolsoPorEnteDescripcionFechaAsync(ente_desc, fecha_desde, fecha_hasta);
        }
        
        [HttpGet("{ente_id}/{fecha_desde}/{fecha_hasta}")]
        public async Task<PrestamoResponse> Get(long ente_id, DateTime? fecha_desde, DateTime? fecha_hasta)
        {
            if (!fecha_hasta.HasValue)
            {
                fecha_desde = DateTime.Now.Date;
                fecha_hasta = DateTime.Now.Date;
            }
            return await prestamoBusiness.ObtenerDesembolsoPorEnteIDFechaAsync(ente_id, fecha_desde, fecha_hasta);
        }

        private void ValidarEnteDescripcionRequerido(string ente_desc)
        {
            if (ente_desc == null || ente_desc == "")
            {
                throw new Exception("El campo correspondiente a la descripción es requerido");
            }
        }

        private void ValidarEnteIdRequerido(long ente_id)
        {
            if (ente_id < 0)
            {
                throw new Exception("El campo correspondiente al ente debe ser mayor a 0");
            }
        }
    }
}