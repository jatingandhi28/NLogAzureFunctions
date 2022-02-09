using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;


[assembly: FunctionsStartup(typeof(NLogSample.Startup))]
namespace NLogSample
{
    public class Startup :FunctionsStartup
    {
        private NLog.Logger _logger;
        public Startup()
        {
            _logger = LogManager.Setup()
               .SetupExtensions(e => e.AutoLoadAssemblies(false))
               .LoadConfigurationFromFile("nlog.config", optional: false)
               .LoadConfiguration(builder => builder.LogFactory.AutoShutdown = false)
               .GetCurrentClassLogger();
        }
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<NLog.ILogger, NLog.Logger>();

            builder.Services.AddLogging((loggingBuilder) =>
            {
                // loggingBuilder.SetMinimumLevel(LogLevel.Trace); // Update default MEL-filter
                loggingBuilder.AddNLog(new NLogProviderOptions() { ShutdownOnDispose = true });
            });
            //throw new NotImplementedException();
        }
    }
}
