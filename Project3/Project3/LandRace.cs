using System;
using System.Collections.Generic;

namespace Project3
{
    public class LandRace : Race
    {
        public LandRace(double distance, RaceType type) : base(distance, type) { }
        
        public override void AddTransport(List<Transport> transportList)
        {
            foreach (var transport in transportList)
            {
                if (transport is Land)
                {
                    list.Add(transport);
                }
                else
                    throw new Exception("Error! type of race doesn't match with type of transport");
            }
        }
    }
}