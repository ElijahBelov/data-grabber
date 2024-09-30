namespace data_grabber.bl
{
    internal class PageModel
    {
        private readonly IDictionary<string, string> dataPoints;

        public PageModel(IDictionary<string, string> dataPoints) => this.dataPoints = dataPoints;

        public ICollection<string> DataPoints => dataPoints.Keys;

        public string Location(string key) => dataPoints[key];
    }
}
