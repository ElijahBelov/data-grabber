using Common;
using data_grabber.bl;
using data_grabber.dataout;

namespace data_grabber
{
    internal class Program
    {
        private static readonly string PARSER_LOG_FOLDER = "D:\\Temp";
        private static readonly string PARSER_LOG_FILE_PREFIX = "data-grabber_";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ILogger log = LogManaging.GetTimeOfRunLogger(PARSER_LOG_FOLDER, PARSER_LOG_FILE_PREFIX);

            IDictionary<string, string> points = new Dictionary<string, string>
            {
                { "TICKER", "//div[starts-with(@class, 'stockRolldiv')]" },
                { "", "" }
            };

            PageModel model = new(points);
            PageParser parser = new(log, model);

            string path = "D:\\Temp\\APP.htm";
            string outPath = "D:\\Temp\\data.csv";
            DataWriter w = new(outPath);

            using StreamReader r = new(path);
            PageData pageData = parser.Parse(r);
            if (!pageData.IsEmpty)
            {
                w.AddLine(OutConverter.ToLineData(pageData));
            }
            else
            {
                log.Warn($"Document {path} did not contain all required information");
            }
        }
    }
}
