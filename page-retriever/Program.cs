using datatool_common;
using log4net;
using log4net.Util;
using System.Text;

namespace page_retriever
{
    internal class Program
    {
        private static readonly string in_path = "..\\in";
        private static readonly string ticker_file_name = "tickers.txt";

        private static readonly string work_path = "../working";

        private static readonly string out_path = "..\\out";
        private static readonly string out_file_name = "result.txt";
        private static readonly string log_file_name = "logs.txt";

        static void Main(string[] args)
        {
            // In order to set the level for a logger and add an appender reference you
            // can then use the following calls:
            ILog log = LogManaging.CreateLog(Path.Combine(out_path, log_file_name));
            log.Info("message123");

            try
            {

                //LogWriter log_writer = new(out_path, log_file_name);
                //log_writer.StartLogging();

                //log_writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {

            }
            //Reader reader = new(in_path, ticker_file_name, work_path);
            //Writer writer = new(out_path, out_file_name);
            //writer.Close();

        }
    }
}
