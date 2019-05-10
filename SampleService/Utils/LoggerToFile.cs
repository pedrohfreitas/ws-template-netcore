using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Utils
{
    public static class Logger
    {
        public static Guid ChaveExecucao = Guid.NewGuid();

        public static void WriteToFile(string Message)
        {
            try
            {

                Message = $"{ChaveExecucao} - {DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss:fff")} - " + Message;
                string path = ConfigurationManager.AppSettings["PathToLogger"] + $"\\{DateTime.Now.Year}\\{DateTime.Now.Month}";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filepath = path + $"\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }
                }
            }catch(Exception ex)
            {

            }
        }

        public static void GerarChaveExecucao()
        {
            ChaveExecucao = Guid.NewGuid();
        }
    }
}
