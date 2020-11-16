using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using TheHarbour.BackEnd;

namespace TheHarbour
{
    class AllBoats
    {
        public ObservableCollection<Boat> TheHorizontalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(false) };
        public ObservableCollection<Boat> TheLeftVerticalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(false) };
        public ObservableCollection<Boat> TheRightVerticalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(false) };
        static Random Rand = new Random();

        public AllBoats()
        {
            for (int index = 0; index < 64; index++)
                TheHorizontalBoatList.Add(new Boat(true));
            TheHorizontalBoatList.Add(new Boat(false));

            for (int index = 0; index < 32; index++)
                TheLeftVerticalBoatList.Add(new Boat(true));

            for (int index = 0; index < 32; index++)
                TheRightVerticalBoatList.Add(new Boat(true));
        }

        public void NewBoats()
        {
            for (int count = 0; count < 5; count++)
            {
                Boat aBoat = ChoiceOfBoat();
                int newSize = aBoat.GetSize();
                
                bool success = ArriveBoat(aBoat, TheHorizontalBoatList, newSize, 64);
                
                if (success == false)
                    success = ArriveBoat(aBoat, TheLeftVerticalBoatList, newSize, 31);

                if (success == false)
                    ArriveBoat(aBoat, TheRightVerticalBoatList, newSize, 31);
            }

            DepartBoats(TheHorizontalBoatList);
            DepartBoats(TheLeftVerticalBoatList);
            DepartBoats(TheRightVerticalBoatList);
        }
        static Boat ChoiceOfBoat()
        {
            switch (Rand.Next(0, 3 + 1))
            {
                case 0:
                    return new RowBoat();
                case 1:
                    return new MotorBoat();
                case 2:
                    return new SailBoat();
                case 3:
                    return new Freighter();
                default:
                    return null;
            }
        }
        static bool ArriveBoat(Boat aBoat, ObservableCollection<Boat> aBoatList, int newSize, int dockLength)
        {
            int totalSize = 0;
            int emptySpaceCount = 0;
            
            for (int index = 1; totalSize + newSize <= dockLength; index++)
            {
                int existingSize = aBoatList[index].GetSize();

                if (existingSize == -1)
                    totalSize++;
                else if (existingSize == 0)
                {
                    totalSize++;
                    emptySpaceCount++;
                }
                else
                {
                    totalSize += existingSize;
                    emptySpaceCount = 0;
                }

                if (emptySpaceCount == newSize)
                {
                    int placeIndex = index - newSize + 1;

                    aBoatList.Insert(placeIndex, aBoat);

                    for (int count = 0; count < newSize; count++)
                        aBoatList.RemoveAt(placeIndex + 1);

                    return true;
                }
            }

            return false;
        }
        static void DepartBoats(ObservableCollection<Boat> aBoatList)
        {
            List<Boat> departureList = aBoatList.Where(aBoat => aBoat.CountDownStay() == true).ToList();

            foreach (Boat aBoat in departureList)
            {
                int insertIndex = aBoatList.IndexOf(aBoat);
                int size = aBoat.GetSize();
                aBoatList.Remove(aBoat);

                for (int count = 0; count < size; count++)
                    aBoatList.Insert(insertIndex, new Boat(true));
            }
        }
    }
}
