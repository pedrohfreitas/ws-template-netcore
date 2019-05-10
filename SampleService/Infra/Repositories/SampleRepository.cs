using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Template.WindowsSerivces.Domain.Models;

namespace Template.WindowsSerivces.Infra.Repositories
{
	public partial class SampleRepository
	{
		public List<SampleModel> Get()
		{
			using (var conn = ConnectionFactory.GetTemplateConnection())
			{
                var result = conn.Query<SampleModel>(select).ToList();
                return result;
			}
		}
    }
}