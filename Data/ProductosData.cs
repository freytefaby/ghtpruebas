using ghtpruebas.Data.Connection;
using ghtpruebas.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ghtpruebas.Data
{
    public class ProductosData
    {
        public List<Productos> buscarProductos()
        {
            SqlServer sql = new SqlServer();
            string query = @"select cod,codigo,nombre,valor,cantidad from productos";
            var productos = sql.QueryList<Productos>(query);
            return productos;

        }

        public long  crearProducto(Productos pro)
        {
            SqlServer sql = new SqlServer();
            string query = @"insert into productos (codigo,nombre,valor,cantidad) values (@codigo,@nombre,@valor,@cantidad) ";
            return sql.InsertQueryId(query, pro);

        }
    }
}
