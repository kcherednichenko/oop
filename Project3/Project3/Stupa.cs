using System;
namespace Project3
{
    public class Stupa : Fly
    {
        public Stupa(double raceDistance)
        {
            Speed = 8;
            this.raceDistance = raceDistance;
            Name = "stupa";
        }

        public override double distanceReducer()
        {
            return 8;
        }
    }
}