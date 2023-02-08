using System.Collections.Generic;
using GolfApp.Structures;

namespace GolfApp.Algorithm
{
    public interface IBalancedHitFinder
    {
        Hit FindBalancedHit(IList<Ball> balls, IList<Hole> holes);
    }
}