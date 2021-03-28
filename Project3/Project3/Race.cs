using System;
using System.Collections.Generic;

namespace Project3
{
    public enum RaceType
    {
        LandRace,
        FlyRace,
        MixedRace

    }

    public abstract class Race
    {
        protected double distance;
        protected RaceType type;
 
        protected List<Transport> list = new List<Transport>();

        public Race(double distance, RaceType type)
        {
            this.distance = distance;
            this.type = type;
        }

        public abstract void AddTransport(List<Transport> inputList);

        public string findWinner()
        {
            string winner = "";
            double answer = Double.MaxValue;
            foreach (var transport in list)
            {
                double currentTime = transport.GetTimeRace(distance);
                if (answer > currentTime)
                {
                    answer = currentTime;
                    winner = transport.Name;
                }
            }
            return winner;
        }
    }
}
