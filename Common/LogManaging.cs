using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace datatool_common
{
    public class LogManaging
    {
        private static readonly string loggerName = "Logging Dude";
        private static readonly string appenderName = "Appending Dude";
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
            FileAppender appender = new
                FileAppender();
            appender.Name = name;
            appender.File = fileName;
            appender.AppendToFile = true;

            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "%d [%t] %-5p %c - %m%n";
            layout.ActivateOptions();

            appender.Layout = layout;
            appender.ActivateOptions();

            return appender;
        }
    }
}
