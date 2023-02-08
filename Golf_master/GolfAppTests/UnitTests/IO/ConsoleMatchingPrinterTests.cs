using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using GolfApp.Output;
using GolfApp.Structures;
using Xunit;

namespace GolfAppTests.UnitTests.IO
{
    public class ConsoleMatchingPrinterTests
    {
        [Fact]
        public void Print_GivenMatching_ShouldPrintExpectedStringToConsole()
        {
            //arrange
            var consoleMatchingPrinter = new ConsoleMatchingPrinter();
            var hits = new List<Hit>()
            {
                new Hit(new Ball(0, 0, 0), new Hole(1, 1, 1)),
                new Hit(new Ball(2, 1, 0), new Hole(3, 0, 1))
            };
            var matching = new Matching(hits);

            //act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                consoleMatchingPrinter.Print(matching);

                string expected = $"Solution:{Environment.NewLine}0,1{Environment.NewLine}2,3{Environment.NewLine}";
                var output = sw.ToString();

                //assert
                output.Should().Be(expected);
            }
        }
    }
}