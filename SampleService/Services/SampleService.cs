using Refit;
using System.Configuration;
using Template.WindowsSerivces.Infra.Repositories;
using System.Linq;
using System.Collections.Generic;
using Template.WindowsSerivces.Domain.Models;
using System;

namespace Sample.Services
{
	public class SampleService
	{
		public void Executar()
		{
            //Esta fução é tuilizada como um AppService e mantem toda a logica necessária para execução do serviço.
            var samples = new SampleRepository().Get();
        }
	}
}