using System;
using FluentAssertions;
using GolfApp.Input;
using GolfApp.Structures;
using Xunit;

namespace GolfAppTests.UnitTests.IO
{
    public class TextFileTaskParserTests
    {
        [Fact]
        public void Parse_GivenCorrectFilePath_ShouldReturnTaskWithCollectionsAsInFile()
        {
            //arrange
            var filePath = @"..\..\TestFiles\TextFileTaskParserTest.txt";
            var textFileTaskParser = new TextFileTaskParser(filePath);

            //act
            var task = textFileTaskParser.Parse();

            //assert
            task.Balls.Count.Should().Be(2);
            task.Holes.Count.Should().Be(2);

            task.Balls[0].Should().BeEquivalentTo(new Ball(0, 1,0));
            task.Balls[1].Should().BeEquivalentTo(new Ball(1, 2, 0));

            task.Holes[0].Should().BeEquivalentTo(new Hole(0, 0, 1));
            task.Holes[1].Should().BeEquivalentTo(new Hole(1, 0, 2));
        }

        [Fact]
        public void Parse_GivenFilePathWithWrongFormat_ShouldThrowFormatException()
        {
            //arrange
            var filePath = @"..\..\TestFiles\TextFileTaskParserTestWrong.txt";
            var textFileTaskParser = new TextFileTaskParser(filePath);

            //act
            Action act = () => textFileTaskParser.Parse();

            //assert
            act.Should().Throw<FormatException>();
        }
    }
}