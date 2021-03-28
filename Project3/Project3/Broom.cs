using System;
namespace Project3
{
    public class Broom : Fly
    {
        public Broom(double raceDistance)
        {
            Speed = 20;
            this.raceDistance = raceDistance;
            Name = "broom";
        }

        public override double distanceReducer()
        {
            int ans = Convert.ToInt32(raceDistance / 1000);
            return ans;
        }
    }
}