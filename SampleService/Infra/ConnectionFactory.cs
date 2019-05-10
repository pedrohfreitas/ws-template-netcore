using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Template.WindowsSerivces.Infra
{
	public class ConnectionFactory
	{
		public static DbConnection GetTemplateConnection()
		{
			var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TemplateConnection"].ToString());

			if (connection.State != System.Data.ConnectionState.Open)
				connection.Open();

			return connection;
        }
    }
}