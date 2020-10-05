using Microsoft.Owin;
using NLog;
using Owin;

[assembly: OwinStartup(typeof(CalculadoraServer.Startup))]

namespace CalculadoraServer
{
	public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			config();
            ConfigureAuth(app);
        }
		private static void config() {
			var config = new NLog.Config.LoggingConfiguration();

			// Targets where to log to: File and Console
			var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "superFileEspecial.txt" };
			var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

			// Rules for mapping loggers to targets            
			config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
			config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);
			config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

			// Apply config           
			NLog.LogManager.Configuration = config;
		}
	}
}
