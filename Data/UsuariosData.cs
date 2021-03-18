using ghtpruebas.Data.Connection;
using ghtpruebas.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ghtpruebas.Data
{
    public class UsuariosData
    {
        public Usuario buscarUsario(string user, string password)
        {
            SqlServer sql = new SqlServer();
            object filter = new
            {
                usuario = user,
                password = password
            };
            string query = @"select cod,nombre,usuario,apellido,password from usuario
                             where usuario = @usuario and password = @password";
            var usuario = sql.QueryFirst<Usuario>(query,filter);
            return usuario;

        }
    }
}
