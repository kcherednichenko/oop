using System;
using System.Collections.Generic;

namespace Project3
{
    class Program
    {
        public static List<Transport> inputList = new List<Transport>();
        public static RaceType type;
        public static double distance;
        public static Race race;


        public static Transport makeParticipant(string participant)
        {
            if (participant == "camel2")
            {
                Camel2 camel2 = new Camel2();
                return camel2;
            }
            else if (participant == "camelfast")
            {
                CamelFast camelfast = new CamelFast();
                return camelfast;
            }
            else if (participant == "centaur")
            {
                Centaur centaur = new Centaur();
                return centaur;
            }
            else if (participant == "boots")
            {
                Boots boots = new Boots();
                return boots;
            }
            else if (participant == "flyingcarpet")
            {
                FlyingCarpet flyingcarpet = new FlyingCarpet(distance);
                return flyingcarpet;
            }
            else if (participant == "stupa")
            {
                Stupa stupa = new Stupa(distance);
                return stupa;
            }
            else if (participant == "broom")
            {
                Broom broom = new Broom(distance);
                return broom;
            }
            else throw new Exception("Error! Such transport doesn't exist");
        }

        public static Race makeRaceByType(string typeName)
        {
            RaceType type;
            if (typeName == "LandRace")
            {
                type = RaceType.LandRace;
                race = new LandRace(distance, type);
            }
            else if (typeName == "FlyRace")
            {
                type = RaceType.FlyRace;
                race = new FlyRace(distance, type);
            } else
            {
                type = RaceType.MixedRace;
                race = new MixedRace(distance, type);
            }
            return race;
        }
       

        public static void Input()
        {
            Console.WriteLine("Choose the type of race: LandRace, FlyRace or MixedRace");
            Console.WriteLine("Enter the distance");
            Console.WriteLine("Enter participants in one line");
            string typeName = Console.ReadLine();
            distance = Convert.ToDouble(Console.ReadLine());
            Race race = makeRaceByType(typeName);
            string[] ReadValue = Console.ReadLine().Split(' ');
            foreach (var participant in ReadValue)
            {
                inputList.Add(makeParticipant(participant));
            }
        }

        public static void makeRace()
        {
            Input();
            race.AddTransport(inputList);
        }

        static void Main(string[] args)
        {
            makeRace();
            Console.WriteLine(race.findWinner());
        }
    }
}
