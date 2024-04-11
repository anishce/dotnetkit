using System;

namespace LoggingKitBase
{
    public interface ILogAdapter
    {
        void Log(LogLevel logLevel, string message);
        void Log(LogLevel logLevel, Exception exception);
        void Log(LogLevel logLevel, Exception exception, string message);
        void Log(LogLevel logLevel, string message, params object[] args);
        void Log(LogLevel logLevel, Exception exception, params object[] args);
        void Log(LogLevel logLevel, Exception exception, string message, params object[] args);
    }
}
