using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ghtpruebas.Interface.Request
{
    public class ProductosRequest
    {
        public class crearProductoRequest
        {
            [Required]
            public string codigo { get; set; }
            [Required]
            public string nombre { get; set; }
            [Range(1, int.MaxValue)]
            public decimal valor { get; set; }

            [Range(1, int.MaxValue)]
            public int cantidad { get; set; }
        }
        
    }
}
