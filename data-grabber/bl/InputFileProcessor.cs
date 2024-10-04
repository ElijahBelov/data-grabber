using Common;

namespace data_grabber.bl
{
    internal class InputFileProcessor(ILogger log, PageParser parser, FileInfo processFolder)
    {
        private readonly ILogger log = log;
        private readonly PageParser parser = parser;
        private readonly FileInfo processFolder = processFolder;

        public void Start(FileInfo datafile)
        {
            datafile.MoveTo(processFolder.Name, true);

            using (StreamReader r = new(datafile.Open(FileMode.Open)))
            {
                PageData pageData = parser.Parse(r);
                //if (!pageData.IsEmpty)
                //{
                //    w.AddLine(pageData);
                //}
                //else
                //{
                //    log.Warn($"Document {path} did not contain all required information");
                //}
            }
        }
    }
}
