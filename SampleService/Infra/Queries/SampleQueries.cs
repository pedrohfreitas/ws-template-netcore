namespace Template.WindowsSerivces.Infra.Repositories
{
	public partial class SampleRepository
	{
		#region SELECT

		private const string select = @"SELECT ID,NOME, EMAIL, DATANASCIMENTO FROM TABELATEST";

		#endregion SELECT

		#region Update

		private const string update = @"UPDATE TABELATEST SET NOME = @NOME WHERE ID = @ID";
		#endregion Update
	}
}