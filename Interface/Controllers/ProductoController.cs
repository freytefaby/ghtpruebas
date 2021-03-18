using ghtpruebas.Domain;
using ghtpruebas.entity;
using ghtpruebas.Interface.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ghtpruebas.Interface.Request.ProductosRequest;

namespace ghtpruebas.Interface.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("[action]")]
        [Authorize]
        public ActionResult get()
        {
            ProductosDomain productosDomain = new ProductosDomain();
            var productos = productosDomain.get();
            if(productos.Count > 0)
            {
              return  ResponseHttp.ok(null,productos);
            }

            return ResponseHttp.NoEncontrado("No se encontro datos");
            
        }

        [HttpPost("[action]")]
        [Authorize]
        public ActionResult crear(crearProductoRequest request)
        {
            ProductosDomain productosDomain = new ProductosDomain();
            Productos producto = new Productos()
            {
                codigo = request.codigo,
                nombre = request.nombre,
                valor = request.valor,
                cantidad = request.cantidad
            };

            long codproducto = productosDomain.crear(producto);
            if(codproducto != -1)
            {
                return ResponseHttp.ok("Successfully");
            }
            return ResponseHttp.InternalError("No se pudo registrar el producto, error inesperado");

        }
    }
}
