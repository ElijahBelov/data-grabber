using data_grabber.dataout;

namespace data_grabber.bl
{
    internal class OutputDataHandler(string outPath)
    {
        private readonly DataWriter w = new(outPath);

        public DataState Handle(PageData data)
        {
            if (!data.IsEmpty)
                w.AddLine(data);

            return DataState.Processed;
        }
    }
}
