using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;
using Sample.Services;
using Sample.Utils;

namespace Sample
{
    public partial class SampleServiceBase : ServiceBase
    {
        private Timer timer1;
        public SampleServiceBase()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {

            //Set timer baseado nas configurações do App.config
            int timeBeforeStart = int.Parse(ConfigurationManager.AppSettings["TimeBeforeStartSample"]) * 1000;
            int timeBetweenCalls = int.Parse(ConfigurationManager.AppSettings["TimeBetweenCallsSample"]) * 1000;

            timer1 = new Timer(new TimerCallback(TimerTick), null, timeBeforeStart, timeBetweenCalls);
        }

        private void TimerTick(object state)
        {
            Rodar();
        }

        protected override void OnStop()
        {
            timer1 = null;
        }

        internal void Rodar()
        {
            //Controle de Separação de Log
            Logger.GerarChaveExecucao();

            DateTime dataHoraInicio = DateTime.Now;
            Logger.WriteToFile("Service is running at " + DateTime.Now);
            var result = Task.Run(() => new SampleService().Executar()).Result;

            if (result)
            {
                Logger.WriteToFile("Sucesso " + DateTime.Now);
            }
            else
            {
                Logger.WriteToFile("Erro" + DateTime.Now);
            }

            Logger.WriteToFile("Service is finish at " + DateTime.Now);
        }
    }
}
