using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using GolfApp.Algorithm;
using GolfApp.Structures;
using Microsoft.Win32.SafeHandles;
using Moq;
using Xunit;

namespace GolfAppTests.UnitTests.Algorithm
{
    public class PlanarMatchingFinderTests
    {

        [Fact]
        public void FindBalancedHit_GivenProperPoints_ShouldReturnCorrectHit()
        {
            //arrange
            var balls = new List<Ball>
            {
                new Ball(0, 0, 0),
                new Ball(1, 1, 0),
                new Ball(2, 0, 1)
            };

            var holes = new List<Hole>
            {
                new Hole(3, 2, 1),
                new Hole(4, 2, 2),
                new Hole(5, 1, 2)
            };

            var middleHit = new Hit(balls[0],holes[1]);

            var leftBalls = new List<Ball>(){balls[2]};
            var leftHoles = new List<Hole>() {holes[2]};
            var leftHit = new Hit(balls[2], holes[2]);

            var rightBalls = new List<Ball>() { balls[1] };
            var rightHoles = new List<Hole>() { holes[0] };
            var rightHit = new Hit(balls[1], holes[0]);

            var balancedHitFinderMock = new Mock<IBalancedHitFinder>();
            balancedHitFinderMock.Setup(x => x.FindBalancedHit(balls, holes)).Returns(middleHit);
            balancedHitFinderMock.Setup(x => x.FindBalancedHit(leftBalls, leftHoles)).Returns(leftHit);
            balancedHitFinderMock.Setup(x => x.FindBalancedHit(rightBalls, rightHoles)).Returns(rightHit);

            var planarMatchingFinder = new PlanarMatchingFinder(balancedHitFinderMock.Object);
            //act
            var matching = planarMatchingFinder.FindPlanarMatching(balls, holes);

            //assert
            var checkHits = new List<Hit>() { middleHit, leftHit, rightHit };
            var hits = matching.ToList();

            checkHits.Count.Should().Be(hits.Count);
            foreach (var checkHit in checkHits)
                hits.Any(h => h.Ball == checkHit.Ball && h.Hole == checkHit.Hole).Should().BeTrue();
        }

        [Fact]
        public void FindPlanarMatching_GivenCollectionsOfDifferentSize_ShouldThrowArgumentException()
        {
            var planarMatchingFinder = new PlanarMatchingFinder(null);

            //arrange
            var balls = new List<Ball>
            {
                new Ball(0, 0, 0)
            };

            var holes = new List<Hole>
            {
                new Hole(2, 1, 1),
                new Hole(3, 0, 1)
            };

            //act
            Action act = () => planarMatchingFinder.FindPlanarMatching(balls, holes);

            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void FindPlanarMatching_GivenNull_ShouldThrowArgumentException()
        {
            //arrange
            var planarMatchingFinder = new PlanarMatchingFinder(null);

            //act
            Action act = () => planarMatchingFinder.FindPlanarMatching(null, null);

            //assert
            act.Should().Throw<ArgumentException>();
        }
    }
}