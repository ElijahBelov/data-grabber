namespace data_grabber.bl
{
    internal class PageData(string key, string composite, string eps, string rs, 
        string grouprs, string smr, string ac, DateOnly erdate, bool isEmpty = false)
    {
        private readonly string key = key;
        private readonly string composite = composite;
        private readonly string eps = eps;
        private readonly string rs = rs;
        private readonly string grouprs = grouprs;
        private readonly string smr = smr;
        private readonly string ac = ac;
        private readonly DateOnly erdate = erdate;
        private readonly bool isEmpty = isEmpty;

        public string Key => key;

        public string Composite => composite;

        public string Eps => eps;

        public string Rs => rs;

        public string Grouprs => grouprs;

        public string Smr => smr;

        public string Ac => ac;

        public DateOnly ERDate => erdate;

        public bool IsEmpty => isEmpty;

        public static PageData Empty
        {
            get { return new PageData("", "", "", "", "", "", "", DateOnly.MinValue, true); }
        }

    }
}
