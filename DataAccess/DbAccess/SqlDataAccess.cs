
using System.Data;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data.SqlClient;

namespace DataAccessLayer.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId ="Default"
            )
        {
            //at the end of the method using kw shutdowns the close the connection
            //getback the rows,put those rows into an ienumerable
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            /* return (IEnumerable<T>)await connection.QueryAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);*/
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(
            string storedProcedure,
            T parameters,
            string connectionId = "Default"
        )
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }


    }
}

