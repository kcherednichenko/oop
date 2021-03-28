using System;
using System.Collections.Generic;

namespace Project3
{
    public class MixedRace : Race
    {
        public MixedRace(double distance, RaceType type) : base(distance, type) { }

        public override void AddTransport(List<Transport> transportList)
        {
            foreach (var transport in transportList)
            {
                list.Add(transport);
            }
        }
    }
}
