using log4net;

namespace Common
{
    internal class LoggerImpl(ILog logger) : ILogger
    {
        private readonly ILog logger = logger;

        public void Debug(object? message)
        {
            logger.Debug(message);
        }

        public void Debug(object? message, Exception? exception)
        {
            logger.Debug(message, exception);
        }

        public void Error(object? message)
        {
            logger.Error(message);
        }

        public void Error(object? message, Exception? exception)
        {
            logger.Error(message, exception);
        }

        public void Fatal(object? message)
        {
            logger.Fatal(message);
        }

        public void Fatal(object? message, Exception? exception)
        {
            logger.Fatal(message, exception);
        }

        public void Info(object? message)
        {
            logger.Info(message);
        }

        public void Info(object? message, Exception? exception)
        {
            logger.Info(message, exception);
        }

        public void Warn(object? message)
        {
            logger.Warn(message);
        }

        public void Warn(object? message, Exception? exception)
        {
            logger.Warn(message, exception);
        }
    }
}
