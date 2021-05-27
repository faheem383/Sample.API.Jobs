using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Sample.API.Jobs.Models;
using Dapper;
namespace Sample.API.Jobs.Repository
{
	public class JobRepository : IJobRepository
	{

        private string SampleDbConnection = string.Empty;

        private MySqlConnection Connection
        {
            get
            {
                
                return new MySqlConnection(SampleDbConnection);
            }
        }
        public JobRepository(IConfiguration configuration)
        {
            SampleDbConnection = configuration.GetConnectionString("SampleDbConnection");
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            using (MySqlConnection conn = Connection)
            {
                string query = "SELECT * FROM Jobs";
                List<Job> jobs = (await conn.QueryAsync<Job>(sql: query)).ToList();
                return jobs;
            }
        }

        public async Task<Job> GetJobAsync(int id)
        {
            using (MySqlConnection conn = Connection)
            {
                string query = "SELECT * FROM Jobs where id = @id";
                Job jobs = (await conn.QueryAsync<Job>(sql: query, param: new { id })).FirstOrDefault();
                return jobs;
            }
        }
    }
}
