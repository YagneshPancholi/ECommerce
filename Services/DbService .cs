
using Dapper;
using Npgsql;
using System.Data;

namespace ECommerce.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection conn;

        public DbService(IConfiguration configuration)
        {
            conn = new NpgsqlConnection(configuration.GetConnectionString("Ecommdb"));
        }
        public async Task<int> EditData(string command, object parms)
        {
            int result;

            result = await conn.ExecuteAsync(command, parms);

            return result;
        }
        public async Task<List<T>> GetAll<T>(string command, object parms)
        {
            List<T> result = new();

            result = (await conn.QueryAsync<T>(command, parms)).ToList();

            return result;
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            T result;

            result = (await conn.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();

            return result;
        }
    }

        
    
}
