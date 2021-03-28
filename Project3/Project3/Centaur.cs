using System;
namespace Project3
{
    public class Centaur : Land
    {
        public Centaur()
        {
            Speed = 15;
            RestInterval = 8;
            countOfRest = 0;
            Name = "centaur";
        }

        public override double RestDuration()
        {
            countOfRest++;
            return 2;
        }
    }
}
