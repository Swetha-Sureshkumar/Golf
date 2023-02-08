using System;
using GolfApp.Structures;

namespace GolfApp.Output
{
    public class ConsoleMatchingPrinter : IMatchingPrinter
    {
        public void Print(Matching matching)
        {
            Console.WriteLine("Solution:");
            foreach (var hit in matching)
                Console.WriteLine("{0},{1}", hit.Ball.Id, hit.Hole.Id);
        }
    }
}