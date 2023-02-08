using System;

namespace GolfApp.Structures
{
    public class Hit
    {
        public Ball Ball { get; }
        public Hole Hole { get; }

        public Hit(Ball ball, Hole hole)
        {
            this.Ball = ball;
            this.Hole = hole;
        }
        
        public bool Intersects(Hit otherHit)
        {
            var d12 = (Ball * otherHit) * (Hole * otherHit);
            var d34 = (otherHit.Ball * this) * (otherHit.Hole * this);

            if (d12 > 0 && d34 > 0)
                return false;
            if (d12 < 0 && d34 < 0)
                return true;

            return OnRectangle(Ball, otherHit)
                   || OnRectangle(Hole, otherHit)
                   || OnRectangle(otherHit.Ball, this)
                   || OnRectangle(otherHit.Hole, this);
        }

        private static bool OnRectangle(Point point, Hit hit)
        {
            return Math.Min(hit.Ball.X, hit.Hole.X) <= point.X
                   && point.X <= Math.Max(hit.Ball.X, hit.Hole.X)
                   && Math.Min(hit.Ball.Y, hit.Hole.Y) <= point.Y
                   && point.Y <= Math.Max(hit.Ball.Y, hit.Hole.Y);
        }
    }
}