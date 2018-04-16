using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    using Serilog;
    using Serilog.Events;

    public class DefaultLogger : ILogger
    {
        public DefaultLogger()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(LogEventLevel.Information)
                .WriteTo.RollingFile(baseDir + "\\log-{Date}.txt", LogEventLevel.Debug)
                .CreateLogger();
        }

        public void Debug(string message)
        {
            Serilog.Log.Debug(message);
        }

        public void Information(string message)
        {
            Serilog.Log.Information(message);
        }

        public void Error(Exception ex, string message)
        {
            Serilog.Log.Error(ex, message);
        }

        public void Warning(string message)
        {
            Serilog.Log.Warning(message);
        }

        public void Fatal(string message)
        {
            Serilog.Log.Fatal(message);
        }

        public void SaveLog()
        {
            Serilog.Log.CloseAndFlush();
        }
    }
}
