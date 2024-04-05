using NLog;
using System;

namespace LoggingKitBase.NLog
{
    public sealed class NLogAdapter : ILogger
    {
        #region Members
        private Logger logger = null!;
        #endregion

        #region Constructor
        public NLogAdapter()
        {
            InitilizeLogAdapter();
        }
        #endregion

        #region Public Methods
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
                    this.logger.Trace(message);
                    break;

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
                    this.logger.Trace(exception);
                    break;

                default:
                    throw new ArgumentNullException("Invalid log level.");
            }
        }

        public void Log(LogLevel logLevel, Exception exception, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    this.logger.Error(exception, message);
                    break;

                case LogLevel.Debug:
                    this.logger.Debug(exception, message);
                    break;

                case LogLevel.Information:
                    this.logger.Info(exception, message);
                    break;

                case LogLevel.Warning:
                    this.logger.Warn(exception, message);
                    break;

                case LogLevel.FATAL:
                    this.logger.Fatal(exception, message);
                    break;
                case LogLevel.Trace:
                    this.logger.Trace(exception, message);
                    break;

                default:
                    throw new ArgumentNullException("Invalid log level.");
            }
        }

        public void Log(LogLevel logLevel, Exception exception, params object[] args)
        {
            var message = exception.Message;

            switch (logLevel)
            {
                case LogLevel.Error:
                    this.logger.Error(exception, message, args);
                    break;

                case LogLevel.Debug:
                    this.logger.Debug(exception, message, args);
                    break;

                case LogLevel.Information:
                    this.logger.Info(exception, message, args);
                    break;

                case LogLevel.Warning:
                    this.logger.Warn(exception, message, args);
                    break;

                case LogLevel.FATAL:
                    this.logger.Fatal(exception, message, args);
                    break;
                case LogLevel.Trace:
                    this.logger.Trace(exception, message, args);
                    break;

                default:
                    throw new ArgumentNullException("Invalid log level.");
            }
        }

        public void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
        {
            switch (logLevel)
            {
                case LogLevel.Error:
                    this.logger.Error(exception, message, args);
                    break;

                case LogLevel.Debug:
                    this.logger.Debug(exception, message, args);
                    break;

                case LogLevel.Information:
                    this.logger.Info(exception, message, args);
                    break;

                case LogLevel.Warning:
                    this.logger.Warn(exception, message, args);
                    break;

                case LogLevel.FATAL:
                    this.logger.Fatal(exception, message, args);
                    break;
                case LogLevel.Trace:
                    this.logger.Trace(exception, message, args);
                    break;

                default:
                    throw new ArgumentNullException("Invalid log level.");
            }
        }

        public void Log(LogLevel logLevel, string message, params object[] args)
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
                    this.logger.Trace(message);
                    break;

                default:
                    throw new ArgumentNullException("Invalid log level.");
            }
        }
        #endregion

        #region Private Methods
        private void InitilizeLogAdapter()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }
        #endregion
    }
}
