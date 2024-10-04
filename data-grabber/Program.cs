using Common;
using data_grabber.bl;
using data_grabber.dataout;
using CommandLine;
using System.IO;

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
                    var file = options.InputFile;
                    var folder = options.InputFolder;

                    if (IsSet(options, options.InputFile))
                    {
                        ProcessSingeleFile(log, options.InputFile, options.OutputCSV);
                    }
                    else
                    {
                        RunProgram(log, options.InputFolder, options.OutputCSV);
                    }
                })
                .WithNotParsed(e =>
                {
                    log.Error(e);
                    Environment.Exit(1);
                });
        }

        private static bool IsSet(Options options, string option)
        {
            string args = CommandLine.Parser.Default.FormatCommandLine(options, config => config.SkipDefault = true);
            return args.Contains(option);
        }

        private static void ProcessSingeleFile(ILogger log, string inputFile, string outputFile)
        {
            PageParser parser = PageParser.Get(log);

            DataWriter w = new(outputFile);

            using StreamReader r = new(inputFile);
            PageData pageData = parser.Parse(r);
            if (!pageData.IsEmpty)
            {
                w.AddLine(pageData);
            }
            else
            {
                log.Warn($"{inputFile} did not contain all required information");
            }
        }

        private static void RunProgram(ILogger log, string path, string outputFile)
        {
            PageParser parser = PageParser.Get(log);

            DataWriter w = new(outputFile);

            using StreamReader r = new(path);
            PageData pageData = parser.Parse(r);
            if (!pageData.IsEmpty)
            {
                w.AddLine(pageData);
            }
            else
            {
                log.Warn($"Document {path} did not contain all required information");
            }
        }
    }
}
