
using data_grabber.bl;

namespace data_grabber.dataout
{
    internal class DataWriter(string path)
    {
        // KEY, Composite Rating, EPS Rating, RS Rating, Group RS Rating, SMR Rating, Acc/Dis Rating, ER Date in YYYY-MM-DD format
        // separated by TABs

        private static readonly string SEPARATOR = "\t";

        private readonly string path = path;

        public bool OutFileExists => Path.Exists(path);

        public void WriteHeader()
        {
            File.AppendAllText(path, HeaderLine());
        }

        public void AddLine(PageData data)
        {
            File.AppendAllText(path, ToSingleLine(data));
        }

        private static string? HeaderLine()
        {
            return "Ticker\t"
                + "Composite Rating\t"
                + "EPS Rating\t"
                + "RS Rating\t"
                + "Group RS Rating\t"
                + "SMR Rating\t"
                + "Acc/Dis Rating\t"
                + "ER Date";
        }

        private static string? ToSingleLine(PageData data)
        {
            return data.Key + SEPARATOR
                + data.Rank + SEPARATOR
                + data.Composite + SEPARATOR
                + data.Eps + SEPARATOR
                + data.Rs + SEPARATOR
                + data.Grouprs + SEPARATOR
                + data.Smr + SEPARATOR
                + data.Ac + SEPARATOR
                + data.ERDate.ToString("yyyy-MM-dd")
            + Environment.NewLine;
        }
    }
}
