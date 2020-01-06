using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Request
{
    public class DocumentsRequest
    {
        public string P_JSON_DOCUMENTO { get; set; }
        public string P_JSON_DETALLE { get; set; }
        public string P_JSON_METODOS_PAGO { get; set; }
        public string P_USUARIO { get; set; }
    }
}
