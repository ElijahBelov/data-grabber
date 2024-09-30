namespace page_retriever
{
    internal class Reader
    {
        private string in_path;
        private string ticker_file_name;
        private string work_path;

        public Reader(string in_path, string ticker_file_name, string work_path)
        {
            this.in_path = in_path;
            this.ticker_file_name = ticker_file_name;
            this.work_path = work_path;
        }
    }
}