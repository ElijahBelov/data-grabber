using CommandLine;

namespace data_grabber
{
    public class Options
    {
        [Option('f', "file", HelpText = "Set input file", SetName = "file")]
        public required string InputFile { get; set; }

        [Option('i', "in", HelpText = "Set input folder", Default = "./In", SetName = "folder")]
        public required string InputFolder { get; set; }

        [Option('m', "mask", HelpText = "Set input file format", Default = "*.htm")]
        public required string FilenameMask { get; set; }

        [Option('o', "out", HelpText = "Set output file", Default = "./Out/data.csv")]
        public required string OutputCSV { get; set; }
    }
}
