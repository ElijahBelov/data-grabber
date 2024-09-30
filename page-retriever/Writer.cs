using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace page_retriever
{
    internal class Writer
    {
        
        private StreamWriter writer;
        private readonly string path;
        private readonly string path_and_file;
        private readonly string file_name;


        public Writer(string folder_path, string out_file_name)
        {
            path = folder_path;
            file_name = out_file_name;
            path_and_file = path + file_name;
            writer = new StreamWriter(path_and_file);
        }

        public Writer(string folder_path, string out_file_name, StreamWriter w)
        {
            path = folder_path;
            file_name = out_file_name;
            path_and_file = path + file_name;
            writer = w;
        }

        public void Close()
        {
            writer.Close();
        }

        //public void Write()
        //{
        //    try
        //    {
        //        out_path_and_file = path + out_file_name;
        //        log_path_and_file = path + log_file_name;

        //        bool existing_log = false;
        //        bool existing_result = false;

        //        if (File.Exists(out_path_and_file))
        //        {
        //            existing_result = true;
        //        }
        //        if (File.Exists(log_path_and_file))
        //        {
        //            existing_log = true;
        //        }

        //        DirectoryInfo di = Directory.CreateDirectory(path);
        //        //Pass the filepath and filename to the StreamWriter Constructor
        //        result_writer = new StreamWriter(path + out_file_name);
        //        log_writer = new StreamWriter(path + log_file_name);

        //        result_writer.WriteLine("Hello World!!");

        //        log_writer.WriteLine("Starting logs at " + DateTime.Now.ToString());
        //        if (existing_log) {
        //            log_writer.WriteLine("Overwriting existing log");
        //        }
        //        if (existing_result) {
        //            log_writer.WriteLine("Overwriting existing results");
        //        }

        //        result_writer.Close();
        //        log_writer.Close();
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception: " + e.Message);
        //    }
        //    finally
        //    {

        //    }
        //}
    }
}