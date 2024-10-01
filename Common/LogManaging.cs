using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace Common
{
    public class LogManaging
    {
        private static readonly string loggerName = "Logging Dude";
        private static readonly string appenderName = "Appending Dude";
        private const string TIME_OF_RUN_LOGGER = "TIME_OF_RUN";
        private const string TIME_OF_RUN_APPENDER = "TIME_OF_RUN";

        public static ILogger GetLogger(string filepath)
        {
            return new LoggerImpl(CreateLog(filepath));
        }

        public static ILogger GetTimeOfRunLogger(string path, string prefix)
        {
            SetLevel(TIME_OF_RUN_LOGGER, "INFO");
            string fileName = Path.Combine(path, String.Concat(prefix, DateTime.Now.ToString("yyyyMMddhhmmss"), ".log"));
            AddAppender(TIME_OF_RUN_LOGGER, CreateFileAppender(TIME_OF_RUN_APPENDER, fileName));
            return new LoggerImpl(LogManager.GetLogger(TIME_OF_RUN_LOGGER));
        }

        public static ILog CreateLog(string filepath)
        {
            SetLevel(loggerName, "ALL");
            IAppender appender = CreateFileAppender(appenderName, filepath);
            AddAppender(loggerName, appender);
            return LogManager.GetLogger(loggerName);
        }

        // Set the level for a named logger
        public static void SetLevel(string loggerName, string levelName)
        {
            ILog log = LogManager.GetLogger(loggerName);
            Logger l = (Logger)log.Logger;

            l.Level = l.Hierarchy.LevelMap[levelName];
        }

        // Add an appender to a logger
        public static void AddAppender(string loggerName, IAppender appender)
        {
            ILog log = LogManager.GetLogger(loggerName);
            Logger l = (Logger)log.Logger;

            l.AddAppender(appender);
            l.Repository.Configured = true;
        }

        // Create a new file appender
        public static IAppender CreateFileAppender(string name, string fileName)
        {
            PatternLayout layout = new()
            {
                ConversionPattern = "%d [%t] %-5p %c - %m%n"
            };
            layout.ActivateOptions();

            FileAppender appender = new()
            {
                Name = name,
                File = fileName,
                AppendToFile = true,
                Layout = layout
            };
            appender.ActivateOptions();

            return appender;
        }
    }
}
