using Common;
using data_grabber.bl;
using data_grabber.dataout;
using CommandLine;

namespace data_grabber
{
    internal class Program
    {
        private static readonly string PARSER_LOG_FOLDER = "D:\\Temp";
        private static readonly string PARSER_LOG_FILE_PREFIX = "data-grabber_";

        static void Main(string[] args)
        {
            ILogger log = LogManaging.GetTimeOfRunLogger(PARSER_LOG_FOLDER, PARSER_LOG_FILE_PREFIX);

            var result = Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    Run(options, log);
                })
                .WithNotParsed(e =>
                {
                    log.Error(e);
                    Environment.Exit(1);
                });
        }

        private static void Run(Options options, ILogger log)
        {
            (IInputProcessor p, FileInfo f) = GetActionParams(options, log);
            p.Start();
            p.Process(f);
            p.End();
        }

        private static (IInputProcessor, FileInfo) GetActionParams(Options options, ILogger log)
        {
            IInputProcessor p = GetFileProcessor(log, new OutputDataHandler(new DataWriter(options.OutputCSV), log));

            if (options.InputFile != null)
                return (p, new FileInfo(options.InputFile));

            IInputProcessor f = GetFolderProcessor(log, p);
            return (f, new FileInfo(options.InputFolder));
        }

        private static FolderProcessor GetFolderProcessor(ILogger log, IInputProcessor iProcessor)
        {
            return new FolderProcessor(iProcessor, log);
        }

        private static FileProcessor GetFileProcessor(ILogger log, IPageDataHandler h)
        {
            return new FileProcessor(log, PageParser.Get(log), h);
        }
    }
}
