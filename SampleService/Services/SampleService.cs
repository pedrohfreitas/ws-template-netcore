using Refit;
using System.Configuration;
using Template.WindowsSerivces.Infra.Repositories;
using System.Linq;
using System.Collections.Generic;
using Template.WindowsSerivces.Domain.Models;
using System;
using Sample.Api;
using System.Threading.Tasks;
using Sample.Utils;

namespace Sample.Services
{
    public class SampleService
    {
        public async Task<bool> Executar()
        {
            try
            {
                //CHAMADA DE API
                var gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");

                var octocat = await gitHubApi.GetUser("octocat");

                //CHAMADO BANCO DE DADOS
                var samples = new SampleRepository().Get();

                return await Task.FromResult<bool>(true);
            }
            catch (Exception ex)
            {
                Logger.WriteToFile(ex.Message);
                return await Task.FromResult<bool>(false);

            }
        }
    }
}