namespace data_grabber.bl
{
    internal class PageModel(IDictionary<string, string> dataPoints)
    {
        private readonly IDictionary<string, string> dataPoints = dataPoints;

        public ICollection<string> DataPoints => dataPoints.Keys;

        public string Key => dataPoints["TICKER"];

        public string XPath(string key) => dataPoints[key];
    }
}
