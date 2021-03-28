using System;
namespace Project3
{
    public class FlyingCarpet : Fly
    {
        public FlyingCarpet(double raceDistance)
        {
            Speed = 10;
            this.raceDistance = raceDistance;
            Name = "flyingcarpet";
        }

        public override double distanceReducer()
        {
            if (raceDistance < 1000)
            {
                return 0;
            }
            else if (raceDistance < 5000)
            {
                return 3;
            }
            else if (raceDistance < 10000)
            {
                return 10;
            } else
            {
                return 5;
            }
        }
    }
}
