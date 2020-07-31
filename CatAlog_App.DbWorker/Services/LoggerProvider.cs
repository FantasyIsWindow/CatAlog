using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace CatAlog_App.DbWorker.Services
{
    internal class LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new MyLogger();
        
        public void Dispose() { }
    }

    internal class MyLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state) => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, 
            TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            File.AppendAllText("log.txt", formatter(state, exception));
        }               
    }
}
