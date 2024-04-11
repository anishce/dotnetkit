using System;

namespace LoggingKitBase.Log4Net
{
    public sealed class LogFourNetAdapter : ILogAdapter
    {
        public void Log(LogLevel logLevel, string message)
        {
            throw new NotImplementedException();
        }

        public void Log(LogLevel logLevel, Exception exception)
        {
            throw new NotImplementedException();
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
