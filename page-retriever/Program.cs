using Common;
using log4net;


namespace page_retriever
{
    internal class Program
    {
        private static readonly string in_path = "..\\in";
        private static readonly string ticker_file_name = "tickers.txt";

        //private static readonly string work_path = "../working";

        private static readonly string out_path = "..\\out";
        private static readonly string out_file_name = "result.txt";
        private static readonly string log_file_name = "logs.txt";

        static void Main(string[] args)
        {
            ILog log = LogManaging.CreateLog(Path.Combine(out_path, log_file_name));
            log.Info("Starting program for page retrieval");

            try
            {
                log.Info("Starting ticker file reading at " + Path.Combine(in_path, ticker_file_name));
                Reader reader = new(in_path, ticker_file_name);
                log.Info("Starting file writing");

                TickerInfo info = reader.GetInfo();
                while (!info.isLastLine)
                {
                    string baseUri = "https://research.investors.com/";
                    log.Info("Read " + info.symbol + "  " + info.url);
                    Writer writer = new(out_path, info.symbol + ".html");
                    log.Info("Http requesting at " + info.url);
                    string path = info.url.Replace(baseUri, "");
                    Task task = writer.Request(path);
                    task.Wait();
                    log.Info("Done http request");
                    log.Info("Writing to " + Path.Combine(out_path, out_file_name));
                    writer.Write();
                    log.Info("Done writing");

                    info = reader.GetInfo();
                    writer.Close();
                }
                log.Info("Done all reading and writing");
                reader.Close();
            }
            catch (Exception ex)
            {
                log.Error("Exception: " + ex.Message);
            }
            finally
            {

            }

        }
    }
}
