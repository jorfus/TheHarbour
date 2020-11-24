using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using TheHarbour.BackEnd;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TheHarbour
{
    [Serializable]
    class AllBoats : INotifyPropertyChanged
    {
        string _rejectedCounterMessage = "Rejected Vessels: 0";

        public ObservableCollection<Boat> TheHorizontalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(false) };
        public ObservableCollection<Boat> TheLeftVerticalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(false) };
        public ObservableCollection<Boat> TheRightVerticalBoatList { get; private set; } = new ObservableCollection<Boat>() { new Boat(false) };
        int RejectedCounter { get; set; }
        public string RejectedCounterMessage { get { return _rejectedCounterMessage; } private set { _rejectedCounterMessage = value; OnPropertyRaised("RejectedCounterMessage"); } }
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        [field:NonSerialized]
        static Random Rand = new Random();

        public const string FileName = "saveData.bin";

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
            for (int count = 0; count < 15; count++)
            {
                Boat aBoat = ChoiceOfBoat();
                int newSize = aBoat.GetSize();

                bool success = ArriveBoat(aBoat, TheHorizontalBoatList, newSize, 64);

                if (success == false)
                    success = ArriveBoat(aBoat, TheLeftVerticalBoatList, newSize, 31);

                if (success == false)
                    if (ArriveBoat(aBoat, TheRightVerticalBoatList, newSize, 31) == false)
                        RejectedCounterMessage = $"Rejected Vessels: {RejectedCounter++}";
            }

            DepartBoats(TheHorizontalBoatList);
            DepartBoats(TheLeftVerticalBoatList);
            DepartBoats(TheRightVerticalBoatList);
        }
        Boat ChoiceOfBoat()
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
        bool ArriveBoat(Boat aBoat, ObservableCollection<Boat> aBoatList, int newSize, int dockLength)
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
        void DepartBoats(ObservableCollection<Boat> aBoatList)
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
        void OnPropertyRaised(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
