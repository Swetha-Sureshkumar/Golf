using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using GolfApp.Structures;

namespace GolfApp.Input
{
    public class TextFileTaskParser : ITaskParser
    {
        private string FilePath { get; }

        public TextFileTaskParser(string filePath)
        {
            FilePath = filePath;
        }

        public Task Parse()
        {
            var balls = new List<Ball>();
            var holes = new List<Hole>();

            using (var reader = new StreamReader(FilePath))
            {
                var n = ReadInteger(reader);
                for (var i = 0; i < n; ++i)
                    balls.Add(ReadBall(reader, i));
                for (var i = 0; i < n; ++i)
                    holes.Add(ReadHole(reader, i));
            }

            return new Task(balls, holes);
        }

        private static int ReadInteger(TextReader reader)
        {
            var line = reader.ReadLine();
            if (line != null)
                return int.Parse(line.Trim());
            throw new TaskParserException();
        }

        private static void ReadPoint(TextReader reader, out double x, out double y)
        {
            var line = reader.ReadLine();
            if (line == null)
                throw new TaskParserException();

            var coordinates = line.Trim().Split(',');
            x = double.Parse(coordinates[0], CultureInfo.InvariantCulture);
            y = double.Parse(coordinates[1], CultureInfo.InvariantCulture);
        }

        private static Ball ReadBall(TextReader reader, int id)
        {
            ReadPoint(reader, out var x, out var y);
            return new Ball(id, x, y);
        }

        private static Hole ReadHole(TextReader reader, int id)
        {
            ReadPoint(reader, out var x, out var y);
            return new Hole(id, x, y);
        }
    }
}