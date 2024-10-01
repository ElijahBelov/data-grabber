using datatool_common;
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

                string[] info = reader.GetInfo();
                while (info.Length > 0)
                {
                    log.Info("Read " + info[0] + "  " + info[1]);
                    string info_path = Path.Combine(out_path, info[0] + ".html");
                    Writer writer = new(out_path, info[0] + ".html");
                    log.Info("Writing to " + Path.Combine(out_path, out_file_name));
                    writer.Request(info[1]);
                    info = reader.GetInfo();
                    writer.Close();
                }

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
