using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Effects;

namespace TheHarbour
{
    class Boat
    {
        static Uri[] TheBoatImages { get; set; } = { new Uri(@"D:\Program\Plugg\.NET\TheHarbour\TheHarbour\Images\darkGray.png"),
            new Uri(@"D:\Program\Plugg\.NET\TheHarbour\TheHarbour\Images\blue.png")};
        public Uri TheBoat { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public int Weight { get; protected set;}
        public int TopSpeed { get; protected set; }
        protected int Size { get; set; }
        protected static Random Rand { get; private set; } = new Random();

        public Boat()
        {
            int number;
            int count;

            for (count = 0; count < 3; count++)
            {
                number = Rand.Next(0, 25 + 1);
                RegistrationNumber += (char)('A' + number);
            }
        }
        public Boat(int greyOrBlue)
        {
            TheBoat = TheBoatImages[greyOrBlue];
        }

        public int GetSize()
        {
            return Size;
        }
    }
}
