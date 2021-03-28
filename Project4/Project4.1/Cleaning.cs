using System;
namespace Project4
{
    public abstract class Cleaning
    {
        
        public DateTime maxData;

        public abstract void Clean(BackUpInfo backUp);

        public abstract int AmountOfCleaning(BackUpInfo backUp);

        public abstract bool isGoOutOfLimit(BackUpInfo backUp, int i);

        public Cleaning() { }
    }
}
