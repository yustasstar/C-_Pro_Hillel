using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace WebApiDapperDemo.Services
{
    public class DbService : IDbService
    {
        private readonly IDbConnection _db;

        public DbService(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("Employeedb"));
        }

        public async Task<T> GetAsync<T>(string command, object parms)
        {
            return (await _db.QueryAsync<T>(command, parms).ConfigureAwait(false)).FirstOrDefault();
        }

        public async Task<List<T>> GetAll<T>(string command, object parms)
        {
            return (await _db.QueryAsync<T>(command, parms)).ToList();
        }

        public async Task<int> EditData(string command, object parms)
        {
            return await _db.ExecuteAsync(command, parms);
        }
    }
}
