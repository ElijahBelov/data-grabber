using Common;

namespace data_grabber.bl
{
    internal class FileProcessor(ILogger log, PageParser parser, IPageDataHandler pdHandler) : IInputProcessor
    {
        private readonly ILogger log = log;
        private readonly PageParser parser = parser;
        private readonly IPageDataHandler pdHandler = pdHandler;

        public void Start()
        {
            pdHandler.Start();
        }

        public void Process(FileInfo file)
        {
            log.Info($"Starting {file.FullName}");

            using StreamReader r = file.OpenText();
            PageData pageData = parser.Parse(r);
            if (!pageData.IsEmpty)
            {
                pdHandler.Handle(pageData);
            }
            else
            {
                log.Warn($"{file.FullName} did not contain all required information");
            }

            log.Info($"Done {file.FullName}");
        }

        public void End()
        {
            pdHandler.End();
        }
    }
}
