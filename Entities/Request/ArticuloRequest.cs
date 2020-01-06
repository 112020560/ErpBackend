using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Request
{
    public class ArticuloRequest
    {
        [JsonProperty("p_bodega")] 
        public int P_BODEGA { get; set; }
        [JsonProperty("p_linea")] 
        public int P_LINEA { get; set; }
        [JsonProperty("p_modelo")] 
        public int P_MODELO { get; set; }
        [JsonProperty("p_marca")] 
        public int P_MARCA { get; set; }
        [JsonProperty("p_codigo")] 
        public string P_CODIGO { get; set; }
        [JsonProperty("p_descripcion")] 
        public string P_DESCRIPCION { get; set; }
    }
}
