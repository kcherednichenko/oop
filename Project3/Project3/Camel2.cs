using System;
namespace Project3
{
    public class Camel2 : Land
    {
        public Camel2()
        {
            Speed = 10;
            RestInterval = 30;
            countOfRest = 0;
            Name = "camel2";
        }

        public override double RestDuration()
        {
            if (countOfRest == 0)
            {
                countOfRest++;
                return 5;
            } else
            {
                countOfRest++;
                return 8;
            }
        }
    }
}
