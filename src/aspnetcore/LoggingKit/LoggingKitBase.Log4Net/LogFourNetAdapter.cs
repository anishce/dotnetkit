using log4net;
using System;

namespace LoggingKitBase.Log4Net
{
    public sealed class LogFourNetAdapter : ILogAdapter
    {
        private readonly ILog logger;

        public LogFourNetAdapter()
        {
            logger = LogManager.GetLogger(typeof(LogFourNetAdapter));
        }

        public void Log(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    this.logger.Error(message);
                    break;

                case LogLevel.Debug:
                    this.logger.Debug(message);
                    break;

                case LogLevel.Information:
                    this.logger.Info(message);
                    break;

                case LogLevel.Warning:
                    this.logger.Warn(message);
                    break;

                case LogLevel.FATAL:
                    this.logger.Fatal(message);
                    break;
                case LogLevel.Trace:
                    throw new ArgumentNullException("Invalid log level.");

                default:
                    throw new ArgumentNullException("Invalid log level.");
            }
        }

        public void Log(LogLevel logLevel, Exception exception)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    this.logger.Error(exception);
                    break;

                case LogLevel.Debug:
                    this.logger.Debug(exception);
                    break;

                case LogLevel.Information:
                    this.logger.Info(exception);
                    break;

                case LogLevel.Warning:
                    this.logger.Warn(exception);
                    break;

                case LogLevel.FATAL:
                    this.logger.Fatal(exception);
                    break;
                case LogLevel.Trace:
                    throw new ArgumentNullException("Invalid log level.");

                default:
                    throw new ArgumentNullException("Invalid log level.");
            }
        }

        public void Log(LogLevel logLevel, Exception exception, string message)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel logLevel, string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel logLevel, Exception exception, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
