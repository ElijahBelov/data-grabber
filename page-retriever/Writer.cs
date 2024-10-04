using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace page_retriever
{
    internal class Writer
    {

        private readonly StreamWriter writer;
        private readonly string path;
        private readonly string path_and_file;
        private readonly string file_name;
        private HttpResponseMessage? HttpResponse;


        public Writer(string folder_path, string out_file_name)
        {
            path = folder_path;
            file_name = out_file_name;
            path_and_file = Path.Combine(path, file_name);
            writer = new StreamWriter(path_and_file);
        }

        public Writer(string folder_path, string out_file_name, StreamWriter w)
        {
            path = folder_path;
            file_name = out_file_name;
            path_and_file = Path.Combine(path, file_name);
            writer = w;
        }

        public void Close()
        {
            writer.Close();
        }

        public void Write()
        {
            writer.Write(HttpResponse);
        }

        public async Task Request(string url)
        {
            string baseUri = "https://research.investors.com/";
            HttpClient httpClient = new() { BaseAddress = new Uri(baseUri) };

            HttpResponse = await httpClient.GetAsync(url);
        }
    }
}