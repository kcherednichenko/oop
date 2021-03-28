using System;
namespace Project3
{
    public abstract class Fly : Transport
    {
        public int Speed { get; set; }
        public abstract double distanceReducer();
        protected double raceDistance;
        public string type = "Fly";

        public override double GetTimeRace(double DistanceRace)
        {
            double totalDistance = raceDistance * ((100 - distanceReducer()) / 100);
            double time = totalDistance / Speed;
            return time;
        }
    }
}
