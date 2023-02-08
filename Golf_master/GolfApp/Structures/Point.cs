using System;

namespace GolfApp.Structures
{
    public enum PointType
    {
        Ball,
        Hole
    }

    public abstract class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public abstract PointType Type { get; }
        public abstract int Value { get; }

        protected Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool IsClockwise(Hit hit)
        {
            return this * hit < 0;
        }

        public static double operator *(Point point, Hit hit)
        {
            return (hit.Hole.X - hit.Ball.X) * (point.Y - hit.Ball.Y) -
                   (point.X - hit.Ball.X) * (hit.Hole.Y - hit.Ball.Y);
        }
    }

    public class Ball : Point
    {
        public Ball(int id, double x, double y) : base(x, y)
        {
            Id = id;
        }

        public int Id { get; set; }
        public override PointType Type => PointType.Ball;
        public override int Value => 1;
    }

    public class Hole : Point
    {
        public Hole(int id, double x, double y) : base(x, y)
        {
            Id = id;
        }

        public int Id { get; set; }
        public override PointType Type => PointType.Hole;
        public override int Value => -1;
    }
}