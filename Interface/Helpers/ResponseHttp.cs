using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ghtpruebas.Interface.Helpers
{
    public class ResponseHttp
    {
        public static ActionResult ok(object message = null, object data = null)
        {
            if (message == null)
            {
                message = "Successfully";
            }
            var result = new OkObjectResult(new { message, data });
            result.StatusCode = 200;
            return result;
        }

        public static ActionResult NoEncontrado(object message = null, object data = null)
        {
            if (message == null)
            {
                message = "No Encontrado";
            }

            var result = new OkObjectResult(new { message, data });
            result.StatusCode = 404;
            return result;
        }

        public static ActionResult NoAuthorizado(object message = null, object data = null)
        {
            if (message == null)
            {
                message = "No Autorizado";
            }

            var result = new OkObjectResult(new { message, data });
            result.StatusCode = 401;
            return result;
        }


        public static ActionResult BadRequest(object message = null, object data = null)
        {
            if (message == null)
            {
                message = "Error en el request";
            }

            var result = new OkObjectResult(new { message, data });
            result.StatusCode = 400;
            return result;
        }

        public static ActionResult InternalError(object message = null, object data = null)
        {
            if (message == null)
            {
                message = "Error en servidor";
            }

            var result = new OkObjectResult(new { message, data });
            result.StatusCode = 500;
            return result;
        }
    }
}
