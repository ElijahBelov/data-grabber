namespace data_grabber.bl
{
    internal class PageData(string key, int rank, int composite, int eps, int rs,
        string grouprs, string smr, string ac, DateOnly erdate, bool isEmpty = false)
    {
        private readonly string key = key;
        private readonly int rank = rank;
        private readonly int composite = composite;
        private readonly int eps = eps;
        private readonly int rs = rs;
        private readonly string grouprs = grouprs;
        private readonly string smr = smr;
        private readonly string ac = ac;
        private readonly DateOnly erdate = erdate;
        private readonly bool isEmpty = isEmpty;

        public string Key => key;

        public int Rank => rank;

        public int Composite => composite;

        public int Eps => eps;

        public int Rs => rs;

        public string Grouprs => grouprs;

        public string Smr => smr;

        public string Ac => ac;

        public DateOnly ERDate => erdate;

        public bool IsEmpty => isEmpty;

        public static PageData Empty
        {
            get { return new PageData("", -1, -1, -1, -1, "", "", "", DateOnly.MinValue, true); }
        }
    }
}
