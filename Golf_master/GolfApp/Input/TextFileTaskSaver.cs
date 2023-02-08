using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GolfApp.Structures;

namespace GolfApp.Input
{
    public class TextFileTaskSaver : ITaskSaver
    {
        private string FilePath { get; }

        public TextFileTaskSaver(string filePath)
        {
            FilePath = filePath;
        }

        public void Save(Task task)
        {
            using (var writer = new StreamWriter(FilePath, append: false))
            {
                WriteSize(writer, task.Size);
                foreach (var ball in task.Balls)
                    WritePoint(writer, ball);
                foreach (var hole in task.Holes)
                    WritePoint(writer, hole);
            }
        }

        private void WriteSize(StreamWriter writer, int size)
        {
            writer.WriteLine("{0}", size);
        }

        private void WritePoint(StreamWriter writer, Point point)
        {
            writer.WriteLine("{0},{1}", point.X, point.Y);
        }

    }
}
