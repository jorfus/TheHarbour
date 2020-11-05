using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using TheHarbour.BackEnd;

namespace TheHarbour
{
    class AllBoats
    {
        Boat[] TheArrivingBoats { get; set; } = new Boat[5];
        public ObservableCollection<Boat> TheHorizontalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(0) };
        public ObservableCollection<Boat> TheLeftVerticalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(0) };
        public ObservableCollection<Boat> TheRightVerticalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(0) };
        static Random Rand = new Random();

        public AllBoats()
        {
            for (int index = 0; index < 64; index++)
                TheHorizontalBoatList.Add(new Boat(1));
            TheHorizontalBoatList.Add(new Boat(0));

            for (int index = 0; index < 32; index++)
                TheLeftVerticalBoatList.Add(new Boat(1));

            for (int index = 0; index < 32; index++)
                TheRightVerticalBoatList.Add(new Boat(1));
        }

        void NewBoats()
        {
            int boatType;

            for (int count = 0; count < 5; count++)
            {
                boatType = Rand.Next(0, 0 + 1);

                switch (boatType)
                {
                    case 0:
                        TheArrivingBoats[count] = new RowBoat();
                        break;
                    default:
                        break;
                }
            }

            for (int index = 0; index < TheArrivingBoats.Length; index++)
            {
                int sizeNewBoat = TheArrivingBoats[index].GetSize();

                //TheHorizontalBoatList.

                for (int jindex = 1; jindex < TheHorizontalBoatList.Count - 1; jindex++)
                {

                }
            }
        }
    }
}
