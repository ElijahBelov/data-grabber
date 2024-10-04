using Common;

namespace data_grabber.bl
{
    internal class FolderProcessor(IInputProcessor p, ILogger log) : IInputProcessor
    {
        private readonly IInputProcessor p = p;
        private readonly ILogger log = log;

        public void Start()
        {
            p.Start();
        }

        public void Process(FileInfo folder)
        {
            log.Info($"Starting {folder.FullName}");

            var dir = new DirectoryInfo(folder.FullName);
            if (dir == null)
            {
                log.Error($"Folder {folder.FullName} does not exist");
                return;
            }

            foreach (FileInfo file in dir.GetFiles("*.htm"))
            {
                p.Process(file);
            }

            log.Info($"Done {folder.FullName}");
        }

        public void End()
        {
            p.End();
        }
    }
}