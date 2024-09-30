namespace data_grabber.bl
{
    internal class StateManager
    {
        private readonly string root;

        public StateManager(string root)
        {
            this.root = root;
            IEnumerable<string> dirs = Directory.EnumerateDirectories(root);
        }

        public void ProcessNext()
        { 
        }
    }
}
