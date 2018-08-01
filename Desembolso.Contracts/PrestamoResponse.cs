using Desembolso.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Desembolso.Contracts
{
    public class PrestamoResponse
    {
        public PrestamoResponse()
        {
            Resultado = new List<Prestamo>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        public string Error { get; set; }

        public List<Prestamo> Resultado { get; set; }
    }
}
