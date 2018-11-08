using System.Collections.Generic;
using CommandLine;

namespace LogFileExtractor.App
{
    internal class Options
    {
        [Option('f', "logfile", Required = true, HelpText = "Logfile to extract")]
        public string LogFile { get; set; }

        [Option('t', "tag", Required = true, HelpText = "Tag to extract lines")]
        public string Tag { get; set; }

        [Option('o', "output", Required = true, HelpText = "Csv output file path")]
        public string Output { get; set; }
    }
}
