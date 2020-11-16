using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;

namespace TheHarbour.BackEnd
{
    class Boat
    {
        static Uri[] TheBoatImages { get; set; } = { new Uri(@"D:\Program\Plugg\.NET\TheHarbour\TheHarbour\Images\blue.png", UriKind.RelativeOrAbsolute),
            new Uri(@"D:\Program\Plugg\.NET\TheHarbour\TheHarbour\Images\darkGray.png", UriKind.RelativeOrAbsolute)};
        public Uri TheBoat { get; protected set; }
        public string RegistrationNumber { get; protected set; }
        public int Weight { get; protected set;}
        public int TopSpeed { get; protected set; }
        public int StayTime { get; protected set; }
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
        public Boat(bool emptyBoat)
        {
            if (emptyBoat)
                TheBoat = TheBoatImages[0];
            else
                TheBoat = TheBoatImages[1];
            
            StayTime = 0;
        }

        public int GetSize()
        {
            return Size;
        
        }
        public bool CountDownStay()
        {
            int days = StayTime -= 1;

            if (days == -1)
            {
                StayTime += 1;
                return false;
            }
            else if (days > 0)
            {
                StayTime = days;
                return false;
            }
            else
                return true;
        }
    }
}
