using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Profissional.Aplicacao.Helpers;

namespace Profissional.Aplicacao
{
    public class Program
    {
        public static void Main(string[] args)
        {

            MainAsync().Wait();

        }
        static async Task MainAsync()
        {
            var url = await AuxNotStatic.GetInfoMotorAux("wpProfissionais", 1);
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseUrls(url.Url)
                 //.UseUrls("http://localhost.com:5300")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
