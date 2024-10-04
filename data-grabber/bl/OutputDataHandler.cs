using Common;
using data_grabber.dataout;

namespace data_grabber.bl
{
    internal class OutputDataHandler(DataWriter w, ILogger log) : IPageDataHandler
    {
        private readonly DataWriter w = w;
        private readonly ILogger log = log;

        public void Start()
        {
            log.Info("Staring output");
            if (w != null && w.OutFileExists)
                log.Warn("Output file exists, appending");
        }

        public void Handle(PageData data)
        {
            if (!data.IsEmpty)
                w.AddLine(data);
        }

        public void End()
        {
            log.Info("Done output");
        }
    }
}
