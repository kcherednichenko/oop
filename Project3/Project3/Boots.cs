using System;
namespace Project3
{
    public class Boots : Land
    {
        public Boots()
        {
            Speed = 6;
            RestInterval = 60;
            countOfRest = 0;
            Name = "boots";
        }

        public override double RestDuration()
        {
            if (countOfRest == 0)
            {
                countOfRest++;
                return 10;
            }
            else
            {
                countOfRest++;
                return 5;
            }
        }
    }
}
