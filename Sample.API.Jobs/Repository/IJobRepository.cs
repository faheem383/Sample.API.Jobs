using Sample.API.Jobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Jobs.Repository
{
	public interface IJobRepository
	{
		/// <summary>
		/// Getting job listing
		/// </summary>
		/// <returns></returns>
		Task<List<Job>> GetAllJobsAsync();

		/// <summary>
		/// Get Job by id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task<Job> GetJobAsync(int id);
	}
}
