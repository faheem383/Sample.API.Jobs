using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.API.Jobs.Models
{
	/// <summary>
	/// Job Class
	/// </summary>
	public class Job
	{
		/// <summary>
		/// Job Id
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Job Title
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// Job Postion
		/// </summary>
		public string position { get; set; }
		/// <summary>
		/// Job City
		/// </summary>
		public string City { get; set; }


	}
}
