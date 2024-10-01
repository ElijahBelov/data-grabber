using data_grabber.bl;

namespace data_grabber.dataout
{
    internal class OutConverter
    {
        public static List<LineData> ToLineData(List<PageData> data)
        {
            return data.ConvertAll(ToLineData);
        }

        public static LineData ToLineData(PageData data)
        {
            return new LineData(data.Key, data.Composite, data.Eps, data.Rs, data.Grouprs, data.Smr, data.Ac, data.ERDate);
        }
    }
}
