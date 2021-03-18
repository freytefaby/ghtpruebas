using ghtpruebas.Domain;
using ghtpruebas.Interface.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ghtpruebas.Interface.Request.AuthRequest;

namespace ghtpruebas.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("[action]")]
        public ActionResult login([FromBody] LoginRequest request)
        {
            UsuariosDomain usuario = new UsuariosDomain();
            var data = usuario.auth(request.usuario,request.password);
            if(data.estado != 0)
            {
                data.usuario.password = "***";
                return ResponseHttp.ok("Successfully", new { usuario=data.usuario,token = data.token });
            }
            return ResponseHttp.NoEncontrado("No se encontraron datos");
        }
    }
}
