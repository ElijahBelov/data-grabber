namespace page_retriever
{
    internal class Reader
    {
        private readonly string combined;
        private readonly StreamReader sr;

        public Reader(string in_path, string ticker_file_name)
        {
            combined = Path.Combine(in_path, ticker_file_name);

            //Pass the file path and file name to the StreamReader constructor
            sr = new StreamReader(combined);
        }

        public void Close()
        {
            sr.Close();
        }

        public TickerInfo GetInfo()
        {
            string? line = sr.ReadLine();
            if (line == null)
            {
                return new TickerInfo("", "");
            }
            string[] subs = line.Split();
            return new TickerInfo(subs[0], subs[1]);
        }
    }
}