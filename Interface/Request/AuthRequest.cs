using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ghtpruebas.Interface.Request
{
    public class AuthRequest
    {
        public class LoginRequest
        {
            [Required]
            public string usuario { get; set; }
            [Required]
            public string password { get; set; }
        }
    }
}
