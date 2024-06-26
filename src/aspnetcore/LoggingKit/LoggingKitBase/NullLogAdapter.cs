﻿using System;

namespace LoggingKitBase
{
    public sealed class NullLogAdapter : ILogAdapter
    {
        public void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
        {
        }

        public void Log(LogLevel logLevel, string message, params object[] args)
        {
        }

        public void Log(LogLevel logLevel, string message)
        {
        }

        public void Log(LogLevel logLevel, Exception exception)
        {
        }

        public void Log(LogLevel logLevel, Exception exception, string message)
        {
        }

        public void Log(LogLevel logLevel, Exception exception, params object[] args)
        {
        }
    }
}
