using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace LogfileExtractor.Service
{
    public class TagFinder
    {
        private readonly string _filePath;

        public TagFinder(string filePath)
        {
            _filePath = filePath;
        }

        public IList<string> FindTaggedLines(string tag)
        {
            IList<string> taggedLines = new List<string>();

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(tag))
                    {
                        taggedLines.Add(line);
                    }
                }
            }
            
            return taggedLines;
        }
    }
}
