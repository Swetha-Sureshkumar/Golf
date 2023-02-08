using System.Collections.Generic;
using GolfApp.Structures;

namespace GolfApp.Algorithm
{
    public interface IPlanarMatchingFinder
    {
        Matching FindPlanarMatching(IList<Ball> balls, IList<Hole> holes);
    }
}