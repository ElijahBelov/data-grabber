namespace data_grabber.bl
{
    internal class LineData(string key, string composite, string eps, string er, string grouprs, string smr, string ac)
    {
        private readonly string key = key;
        private readonly string composite = composite;
        private readonly string eps = eps;
        private readonly string er = er;
        private readonly string grouprs = grouprs;
        private readonly string smr = smr;
        private readonly string ac = ac;

        public string Key => key;

        public string Composite => composite;

        public string Eps => eps;

        public string Er => er;

        public string Grouprs => grouprs;

        public string Smr => smr;

        public string Ac => ac;
    }
}
