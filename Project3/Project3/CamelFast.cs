using System;
namespace Project3
{
    public class CamelFast : Land
    {
        public CamelFast()
        {
            Speed = 40;
            RestInterval = 10;
            countOfRest = 0;
            Name = "camelfast";
        }

        public override double RestDuration()
        {
            if (countOfRest == 0)
            {
                countOfRest++;
                return 5;
            }
            else if (countOfRest == 1)
            {
                countOfRest++;
                return 6.5;
            } else
            {
                countOfRest++;
                return 8;
            }
        }
    }
}

