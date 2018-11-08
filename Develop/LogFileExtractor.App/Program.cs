using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using LogfileExtractor.DataModel;
using LogfileExtractor.Export;

namespace LogFileExtractor.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(RunOptionsAndReturnExitCode)
                .WithNotParsed<Options>(HandleParseError);
        }

        private static void HandleParseError(IEnumerable<Error> error)
        {

        }

        private static void RunOptionsAndReturnExitCode(Options options)
        {
            try
            {
                LogfileExtractor.Service.LogFileExtractor logFileExtractor = new LogfileExtractor.Service.LogFileExtractor(options.LogFile);
                IList<LineItem> items = logFileExtractor.Extract(options.Tag);

                CsvExporter exporter = new CsvExporter();
                exporter.Export(options.Output, items);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to extract logfile" + ex);
            }

        }
    }
}
