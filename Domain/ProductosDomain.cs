using ghtpruebas.Data;
using ghtpruebas.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ghtpruebas.Domain
{
    public class ProductosDomain
    {
        public List<Productos> get()
        {
            ProductosData productosDatos = new ProductosData();
            var productos = productosDatos.buscarProductos();
            return productos;
        }
        public long crear(Productos pro)
        {
            ProductosData productosDatos = new ProductosData();
            long codproducto = productosDatos.crearProducto(pro);
            return codproducto;
        }

    }
}
