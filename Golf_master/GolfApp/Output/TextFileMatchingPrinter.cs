using System.IO;
using GolfApp.Structures;

namespace GolfApp.Output
{
    public class TextFileMatchingPrinter : IMatchingPrinter
    {
        private const int BufferSize = 1024;
        private string FilePath { get; }

        public TextFileMatchingPrinter(string filePath)
        {
            FilePath = filePath;
        }

        public void Print(Matching matching)
        {
            using(var writer = new StreamWriter(FilePath, false))
            {
                foreach (var hit in matching)
                    writer.WriteLine("{0},{1}", hit.Ball.Id, hit.Hole.Id);
            }
        }
    }
}