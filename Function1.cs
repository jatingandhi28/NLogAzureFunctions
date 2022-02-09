using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
//using NLog;
//using Microsoft.Extensions.Logging;

namespace NLogSample
{
    public class Function1
    {
        //private readonly NLog.ILogger _logger;
        private readonly ILogger<Function1> log;
        public Function1(ILogger<Function1> logger1)
        {
          //  _logger = logger;
            log = logger1;
        }
        [FunctionName("Function1")]
        public void Run([TimerTrigger("* * * * * *")]TimerInfo myTimer)
        {
            //_logger.Info("Hello sir");           
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogError("This is example of error log printing");
        }
    }
}
