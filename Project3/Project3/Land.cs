using System;
namespace Project3
{
    public abstract class Land : Transport
    {
        public int Speed{get; set;}
        public int RestInterval { get; set; }
        public abstract double RestDuration();
        protected int countOfRest;
        public string type = "Land";

        public override double GetTimeRace(double DistanceRace)
        {
            double time = (DistanceRace / Speed);
            int count = (int)Math.Floor(time / RestInterval);
            for (int i = 0; i < count; i++)
            {
                time += RestDuration();
            }
            return time;
        }
    }
}
