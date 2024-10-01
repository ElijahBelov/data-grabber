namespace page_retriever
{
    internal class Reader
    {
        private string in_path;
        private string ticker_file_name;
        private string combined;
        private StreamReader sr;

        public Reader(string in_path, string ticker_file_name)
        {
            this.in_path = in_path;
            this.ticker_file_name = ticker_file_name;
            this.combined = Path.Combine(in_path, ticker_file_name);

            //Pass the file path and file name to the StreamReader constructor
            sr = new StreamReader(combined);
        }
        public void Close()
        {
            sr.Close();
        }

        public string[] GetInfo()
        {
            string? line = sr.ReadLine();
            if (line == null)
            {
                return [];
            }
            string[] subs = line.Split();
            return subs;
        }
    }
}