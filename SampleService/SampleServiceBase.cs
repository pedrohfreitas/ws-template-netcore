using System;
using System.Configuration;
using System.ServiceProcess;
using System.Threading;
using Core.Log;
using Sample.Services;

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
            //Logs MongoDB
            DateTime dataHoraInicio = DateTime.Now;
            Logger.Information("Template.WindowsSerivces - Sample - Iniciando ");
            //Acionamento do serviço
            new SampleService().Executar();
            Logger.Information($"Template.WindowsSerivces - Sample - Tempo de Duração: {DateTime.Now.Subtract(dataHoraInicio)}");
            Logger.Information("Template.WindowsSerivces - Sample - Finalizando ");
        }
    }
}
