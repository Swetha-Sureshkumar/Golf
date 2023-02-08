using System.Collections.Generic;
using System.IO;
using FluentAssertions;
using GolfApp.Output;
using GolfApp.Structures;
using Xunit;

namespace GolfAppTests.UnitTests.IO
{
    public class TextFileMatchingPrinterTests
    {
        [Fact]
        public void Print_GivenMatching_ShouldPrintToFileWithProperFormat()
        {
            //arrange
            var filePath = @"..\..\TestFiles\TextFileMatchingPrinterTest.txt";
            var textFileMatchingPrinter = new TextFileMatchingPrinter(filePath);
            var hits = new List<Hit>()
            {
                new Hit(new Ball(0, 0, 0), new Hole(1, 1, 1)),
                new Hit(new Ball(2, 1, 0), new Hole(3, 0, 1))
            };
            var matching = new Matching(hits);

            //act
            textFileMatchingPrinter.Print(matching);

            //assert
            using (StreamReader sr = new StreamReader(filePath))
            {
                foreach (var hit in hits)
                {
                    var line = sr.ReadLine();
                    line.Should().Be($"{hit.Ball.Id},{hit.Hole.Id}");
                }
            }
        }
    }
}