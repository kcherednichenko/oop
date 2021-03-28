using System;
using System.Collections.Generic;

namespace Project3
{
    public class FlyRace : Race
    {
        public FlyRace(double distance, RaceType type) : base(distance, type) { }

        public override void AddTransport(List<Transport> transportList)
        {
            foreach (var transport in transportList)
            {
                if (transport is Fly)
                {
                    list.Add(transport);
                }
                else
                    throw new Exception("Error! type of race doesn't match with type of transport");
            }
        }
    }
}
