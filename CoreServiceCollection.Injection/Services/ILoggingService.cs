using System.Collections.Generic;
using CoreServiceCollection.Domain.Models;

namespace CoreServiceCollection.Injection.Services
{
    public interface ILoggingService
    {
        void Log(string message);
    }

    public class LoggingService : ILoggingService
    {
        private readonly string _logFileLocation;

        public LoggingService(string logFileLocation)
        {
            _logFileLocation = logFileLocation;
        }

        public void Log(string message)
        {
            throw new System.NotImplementedException();
        }
    }

    public class MyOptions
    {
        public string LoggerFileLocation { get; set; }
    }
}