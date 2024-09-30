namespace data_grabber.bl
{
    internal class DataWriter(string path)
    {
        private readonly string path = path;

        public void WriteLine(LineData data)
        {
            using (StreamReader r = new StreamReader(path))
            {

            }
        }
    }
}
