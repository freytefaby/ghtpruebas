using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ghtpruebas.Data.Connection
{
    public class SqlServer : IDisposable
    {
        private string conexion { get; set; }
        public SqlServer()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            this.conexion = configuration.GetConnectionString("ght");
        }

        public List<T> QueryList<T>(string sql, object filter = null)
        {

            using (var db = new SqlConnection(this.conexion))
            {

                var result = db.Query<T>(sql, filter);
                return result.ToList();

            }


        }


        public T QueryFirst<T>(string sql, object filter = null)
        {
            using (var db = new SqlConnection(this.conexion))
            {
                var result = db.Query<T>(sql, filter);
                return result.FirstOrDefault();
            }


        }

        public long InsertQueryId<T>(string sql, T model)
        {
            try
            {
                string s = "{0}; SELECT SCOPE_IDENTITY()";
                sql = string.Format(s, sql);
                long result = 0;
                using (var db = new SqlConnection(this.conexion))
                {
                    result = db.ExecuteScalar<long>(sql, model);
                    return result;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }


        /*EJECUCIÓN DE TRANSACCIONES*/

        private IDbConnection _connection;
        private IDbTransaction _trans;

        public void StartTransaction()
        {
            _connection = new SqlConnection(this.conexion);
            _connection.Open();
            _trans = _connection.BeginTransaction();
            isClosed = false;
        }

        private bool isClosed = false;
        public void CommitTransaction()
        {
            _trans?.Commit();
            _connection?.Close();
            isClosed = true;
        }


        public void RollbackTransaction()
        {
            _trans?.Rollback();
            _connection?.Close();
            isClosed = true;
        }


        public void Dispose()
        {
            if (isClosed == false)
            {
                try
                {
                    CommitTransaction();
                }
                catch
                {
                    //LOG this issue
                }

            }
            _trans = null;
            _connection = null;

        }
    }
}
