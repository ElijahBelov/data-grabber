
namespace data_grabber.dataout
{
    internal class DataWriter(string path)
    {
        // KEY, Composite Rating, EPS Rating, RS Rating, Group RS Rating, SMR Rating, Acc/Dis Rating, ER Date in YYYY-MM-DD format
        // separated by TABs

        private static readonly string SEPARATOR = "\t";

        private readonly string path = path;

        public void AddLine(LineData data)
        {
            File.AppendAllText(path, ToSingleLine(data));
        }

        private static string? ToSingleLine(LineData data)
        {
            return data.Key + SEPARATOR
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
