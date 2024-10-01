namespace data_grabber.dataout
{
    internal class LineData(string key, string composite, string eps, string rs, string grouprs, string smr, string ac, DateOnly erdate)
    {
        private readonly string key = key;
        private readonly string composite = composite;
        private readonly string eps = eps;
        private readonly string rs = rs;
        private readonly string grouprs = grouprs;
        private readonly string smr = smr;
        private readonly string ac = ac;
        private readonly DateOnly erdate = erdate;

        public string Key => key;

        public string Composite => composite;

        public string Eps => eps;

        public string Rs => rs;

        public string Grouprs => grouprs;

        public string Smr => smr;

        public string Ac => ac;

        public DateOnly ERDate => erdate;
    }
}
