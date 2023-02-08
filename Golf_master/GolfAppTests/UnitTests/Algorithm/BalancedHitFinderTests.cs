using System;
using System.Collections.Generic;
using FluentAssertions;
using GolfApp.Algorithm;
using GolfApp.Structures;
using Xunit;

namespace GolfAppTests.UnitTests.Algorithm
{

    
    public class BalancedHitFinderTests
    {
        private readonly BalancedHitFinder _balancedHitFinder;

        public BalancedHitFinderTests()
        {
            _balancedHitFinder = new BalancedHitFinder();
        }


        [Fact]
        public void FindBalancedHit_GivenProperPoints_ShouldReturnCorrectHit()
        {
            //arrange
            var balls = new List<Ball>
            {
                new Ball(0, 0, 0),
                new Ball(1, 1, 0)
            };

            var holes = new List<Hole>
            {
                new Hole(2, 1, 1),
                new Hole(3, 0, 1)
            };

            //act
            var hit = _balancedHitFinder.FindBalancedHit(balls, holes);

            //assert
            hit.Ball.Should().Be(balls[0]);
            hit.Hole.Should().Be(holes[1]);
        }

        [Fact]
        public void FindBalancedHit_GivenCollectionsOfDifferentSize_ShouldThrowArgumentException()
        {
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
            Action act  = () => _balancedHitFinder.FindBalancedHit(balls, holes);

            //assert
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void FindBalancedHit_GivenNull_ShouldThrowArgumentException()
        {
            //arrange
            //act
            Action act = () => _balancedHitFinder.FindBalancedHit(null, null);

            //assert
            act.Should().Throw<ArgumentException>();
        }

    }
}