using ghtpruebas.Data;
using ghtpruebas.entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ghtpruebas.Domain
{
    public class UsuariosDomain
    {
        public (int estado, Usuario usuario,string token) auth(string usuario, string password)
        {
            UsuariosData usuarioDatos = new UsuariosData();
            var user = usuarioDatos.buscarUsario(usuario, password);
            if(user != null)
            {
                string token = crearToken(user);
                return (1, user, token);
            }
            return (0, (Usuario)null, (string)null);
        }

        public string crearToken(Usuario usuario)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuracion = builder.Build();
            string token = generateJSONWebToken(usuario, "token", 1, configuracion["JwT:TOKEN_SECRET"], configuracion["Jwt:Issuer"]);
            return token;
        }

        public string generateJSONWebToken(Usuario usuario, string tipo, int duracion, string SECRET_TOKEN, string ISUUER)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_TOKEN));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,usuario.cod.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("type",tipo)
            };

            var token = new JwtSecurityToken(issuer: ISUUER,
                                             audience: ISUUER,
                                             claims,
                                             expires: DateTime.Now.AddDays(duracion),
                                             signingCredentials: credentials);
            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }



    }
}
